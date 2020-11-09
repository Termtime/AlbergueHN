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
    public partial class dialogIngresarProducto : Form
    {
        public dialogIngresarProducto()
        {
            InitializeComponent();
        }
        string StringConexion = (string)Properties.Settings.Default["stringConexion"];
        private void dialogIngresarProducto_Load(object sender, EventArgs e)
        {
            LlenarArticulos();
            LlenarTipo();
        }
        public void LlenarArticulos()
        {
            string sql = "select ArticuloID, Descripcion from articulo order by Descripcion DESC";
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConexion))
                {
                    con.Open();
                    using (MySqlCommand sqlcmd = new MySqlCommand(sql, con))
                    {
                        using (MySqlDataReader lector = sqlcmd.ExecuteReader())
                        {
                            DataTable dtArticulos = new DataTable();
                            dtArticulos.Columns.Add("Descripcion", typeof(string));
                            dtArticulos.Load(lector);

                            articulo.ValueMember = "ArticuloID";
                            articulo.DisplayMember = "Descripcion";
                            articulo.DataSource = dtArticulos;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (articulo.Items.Count != 0)
            {
                articulo.SelectedIndex = 0;
            }
        }
        public void LlenarTipo()
        {
            string sql = "select TipoArticuloID, Descripcion from tipoArticulo order by Descripcion ASC";
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConexion))
                {
                    con.Open();
                    using (MySqlCommand sqlcmd = new MySqlCommand(sql, con))
                    {
                        using (MySqlDataReader lector = sqlcmd.ExecuteReader())
                        {
                            DataTable dtTipo = new DataTable();
                            dtTipo.Columns.Add("Descripcion", typeof(string));
                            dtTipo.Load(lector);

                            tipoArticulo.ValueMember = "TipoArticuloID";
                            tipoArticulo.DisplayMember = "Descripcion";
                            tipoArticulo.DataSource = dtTipo;

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
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
