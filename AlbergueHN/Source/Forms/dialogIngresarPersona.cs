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
    public partial class dialogIngresarPersona : Form
    {
        public dialogIngresarPersona()
        {
            InitializeComponent();
        }
        string StringConexion = (string)Properties.Settings.Default["stringConexion"];

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dialogIngresarPersona_Load(object sender, EventArgs e)
        {
            cargarMunicipios();
        }

        public void cargarMunicipios()
        {
            string sql = "select MunicipioID, Nombre from municipio order by Nombre ASC";
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConexion))
                {
                    con.Open();
                    using (MySqlCommand sqlcmd = new MySqlCommand(sql, con))
                    {
                        using (MySqlDataReader lector = sqlcmd.ExecuteReader())
                        {
                            DataTable dtMunicipios = new DataTable();
                            dtMunicipios.Columns.Add("Nombre", typeof(string));
                            dtMunicipios.Load(lector);

                            comboMunicipio.ValueMember = "MunicipioID";
                            comboMunicipio.DisplayMember = "Nombre";
                            comboMunicipio.DataSource = dtMunicipios;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (comboMunicipio.Items.Count != 0)
            {
                comboMunicipio.SelectedIndex = 0;
            }
        }

        
    }
}

