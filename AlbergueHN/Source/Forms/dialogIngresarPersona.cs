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
            if (txtNombres.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Nombres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombres.Focus();
                return;
            }
            if (txtApellidos.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Apellidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtApellidos.Focus();
                return;
            }
            if (txtCuenta.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de No de Cuenta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCuenta.Focus();
                return;
            }
            if (txtDireccion.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Dirección.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDireccion.Focus();
                return;
            }
            if (txtId.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Identidad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtId.Focus();
                return;
            }



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
                MessageBox.Show(ex.Message, "Error Cargando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (comboMunicipio.Items.Count != 0)
            {
                comboMunicipio.SelectedIndex = 0;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}

