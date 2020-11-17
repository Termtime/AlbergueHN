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
            Bitmap icono = AlbergueHN.Properties.Resources.icono;
            this.Icon = Icon.FromHandle(icono.GetHicon());
        }
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        private void dialogProducto_Load(object sender, EventArgs e)
        {
            cargarTipos();
            comboTalla.Items.AddRange(tallasRopa);
            comboGen.Items.Add("M");
            comboGen.Items.Add("F");
            comboGen.Text = "";
            comboTalla.Text = "";
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

            if (comboTalla.Text.Length == 0 && checkUsaTalla.Checked)
            {
                MessageBox.Show("No se ha especificado la talla. Por favor escriba una o seleccione desde la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string descripcion = txtArticulo.Text.Trim();
                String sql = "CALL spCrearProducto(@1, @2, @3, @4, @5, @6)";
                if (checkUsaTalla.Checked)
                {
                    talla = comboTalla.Text;
                }else { talla = null; }
                if (checkUsaGenero.Checked)
                {
                    genero = comboGen.Text;
                }else { genero = null; }

                if (radioAdulto.Checked)
                {
                    descripcion += " - Adulto";
                }
                else if (radioInfante.Checked)
                {
                    descripcion += " - Infante";
                }
                //Quitar todas las instancias de Adulto e Infante de la descripcion
                if (txtArticulo.Text.Trim().Contains(" - Infante"))
                {
                    bool aunContiene = true;
                    while (aunContiene)
                    {
                        txtArticulo.Text = txtArticulo.Text.Trim().Replace(" - Infante", "");
                        aunContiene = txtArticulo.Text.Trim().Contains(" - Infante");
                    }
                }
                if (txtArticulo.Text.Trim().Contains(" - Adulto"))
                {
                    bool aunContiene = true;
                    while (aunContiene)
                    {
                        txtArticulo.Text = txtArticulo.Text.Trim().Replace(" - Adulto", "");
                        aunContiene = txtArticulo.Text.Trim().Contains(" - Adulto");
                    }
                }
                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@1", comboTipo.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@2", descripcion);
                        cmd.Parameters.AddWithValue("@3", talla);
                        cmd.Parameters.AddWithValue("@4", genero);
                        cmd.Parameters.AddWithValue("@5", checkUsaTalla.Checked);
                        cmd.Parameters.AddWithValue("@6", checkUsaGenero.Checked);

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
        }

        private void CheckUsaTalla_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUsaTalla.Checked)
            {
                comboTalla.Enabled = true;
                comboTalla.SelectedIndex = 0;
            }
            else
            {
                comboTalla.Enabled = false;
                comboTalla.Text = "";
                talla = null;
            }
        }

        private void CheckUsaGenero_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUsaGenero.Checked)
            {
                comboGen.Enabled = true;
                comboGen.SelectedIndex = 0;
            }
            else
            {
                comboGen.Enabled = false;
                comboGen.SelectedIndex = -1;
                genero = null;
            }
        }
    }
}
