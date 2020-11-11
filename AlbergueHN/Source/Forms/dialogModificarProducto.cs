using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbergueHN.Source.Forms
{
    public partial class dialogModificarProducto : Form
    {
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        string talla = null;
        string genero = null;
        public string tipoItem = null;
        string[] tallasRopa = { "XXS", "XS", "S", "M", "L", "XL", "XL", "XXL" };
        public int id;
        public dialogModificarProducto()
        {
            InitializeComponent();
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTipo.Text == "Vestimenta" || comboTipo.Text == "Zapatos")
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

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (txtArticulo.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Descripción de Articulo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArticulo.Focus();
                return;
            }

            String sql = "CALL spUpdateProducto(@1, @2, @3, @4, @5)";
            try
            {
                if (comboTipo.Text == "Vestimenta" || comboTipo.Text == "Zapatos")
                {
                    genero = comboGen.SelectedItem.ToString();
                    talla = comboTalla.Text.Trim();
                }
                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@1", id);
                        cmd.Parameters.AddWithValue("@2", comboTipo.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@3", txtArticulo.Text.Trim());
                        cmd.Parameters.AddWithValue("@4", talla);
                        cmd.Parameters.AddWithValue("@5", genero);
                        cmd.Connection.Open();  //abrir conexion
                        cmd.ExecuteNonQuery();  //ejecutar comando
                    }
                }

            }
            catch (Exception ex)
            {
                //ocurrio un error
                MessageBox.Show(ex.Message, "Error actualizando informacion del producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DialogModificarProducto_Load(object sender, EventArgs e)
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
            string sql = "select * from tiposuministro order by Descripcion ASC";
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
                            comboTipo.SelectedIndex = comboTipo.FindString(tipoItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Cargando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
