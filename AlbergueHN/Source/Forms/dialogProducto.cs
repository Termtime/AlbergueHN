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
    }
}
