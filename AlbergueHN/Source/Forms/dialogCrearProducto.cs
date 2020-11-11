using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace AlbergueHN.Source.Forms
{
    public partial class dialogCrearProducto : Form
    {
        string talla = null;
        string genero = null;
        string[] tallasRopa = {"XXS", "XS", "S", "M", "L", "XL", "XL", "XXL" };
        public dialogCrearProducto()
        {
            InitializeComponent();
        }
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        private void dialogProducto_Load(object sender, EventArgs e)
        {
            cargarTipos();
            comboTalla.Items.AddRange(tallasRopa);
            comboGen.Items.Add("M");
            comboGen.Items.Add("F");
            comboGen.SelectedIndex = 0;
            comboTalla.SelectedIndex = 0;
        }
        public void cargarTipos()
        {
            string sql = "select * from tiposuministro order by Descripcion DESC";
            try
            {
                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    con.Open();
                    using (MySqlCommand sqlcmd = new MySqlCommand(sql, con))
                    {
                        using (MySqlDataReader lector = sqlcmd.ExecuteReader())
                        {
                            DataTable dtTipos = new DataTable();
                            dtTipos.Columns.Add("Descripcion", typeof(string));
                            dtTipos.Load(lector);

                            comboTipo.ValueMember = "TipoID";
                            comboTipo.DisplayMember = "Descripcion";
                            comboTipo.DataSource = dtTipos;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Cargando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }
            if (comboTipo.Items.Count != 0)
            {
                comboTipo.SelectedIndex = 0;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtArticulo.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Descripción de Articulo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArticulo.Focus();
                return;
            }

            try
            {
                String sql = "CALL spCrearProducto(@1, @2, @3, @4)";
                if (comboTipo.Text == "Vestimenta" || comboTipo.Text == "Zapatos")
                {
                    genero = comboGen.SelectedItem.ToString();
                    talla = (string) (comboTalla.SelectedItem ?? comboTalla.Text);
                }
                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@1", comboTipo.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@2", txtArticulo.Text.Trim());
                        cmd.Parameters.AddWithValue("@3", talla);
                        cmd.Parameters.AddWithValue("@4", genero);

                        cmd.Connection.Open();  //abrir conexion
                        cmd.ExecuteNonQuery();  //ejecutar comando
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                //ocurrio un error
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TipoArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboTipo.Text == "Vestimenta" || comboTipo.Text == "Zapatos")
            {
                comboTalla.Enabled = true;
                comboGen.Enabled = true;
            }
            else
            {
                comboTalla.Enabled = false;
                comboGen.Enabled = false;
                talla = null;
                genero = null;
            }
        }
    }
}
