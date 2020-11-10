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
    public partial class dialogProducto : Form
    {
        public dialogProducto()
        {
            InitializeComponent();
        }
        string StringConexion = (string)Properties.Settings.Default["stringConexion"];
        private void dialogProducto_Load(object sender, EventArgs e)
        {
            cargarTipos();
            comboGen.Items.Add("M");
            comboGen.Items.Add("F");
            comboGen.SelectedIndex = 0;
        }
        public void cargarTipos()
        {
            string sql = "select * from TipoSuministro order by Descripcion DESC";
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConexion))
                {
                    con.Open();
                    using (MySqlCommand sqlcmd = new MySqlCommand(sql, con))
                    {
                        using (MySqlDataReader lector = sqlcmd.ExecuteReader())
                        {
                            DataTable dtTipos = new DataTable();
                            dtTipos.Columns.Add("Descripcion", typeof(string));
                            dtTipos.Load(lector);

                            tipoArticulo.ValueMember = "TipoID";
                            tipoArticulo.DisplayMember = "Descripcion";
                            tipoArticulo.DataSource = dtTipos;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (tipoArticulo.Items.Count != 0)
            {
                tipoArticulo.SelectedIndex = 0;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtArticulo.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Descripción de Articulo.", "Validación");
                txtArticulo.Focus();
                return;
            }
            float num;
            if (!float.TryParse(numericCantidad.Text.Trim(), out num))
            {
                MessageBox.Show("La cantidad no es valida.", "Validación");
                numericCantidad.Focus();
                return;
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
