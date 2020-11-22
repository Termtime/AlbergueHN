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
    public partial class dialogModificarPersona : Form
    {
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        public string municipio = "";
        public dialogModificarPersona()
        {
            InitializeComponent();
            Bitmap icono = AlbergueHN.Properties.Resources.icono;
            this.Icon = Icon.FromHandle(icono.GetHicon());
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Nombres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }
            if (txtApellido.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Apellidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellido.Focus();
                return;
            }
            if (txtCuenta.Text.Trim().Length == 0)
            {
                MessageBox.Show("Error con el formato de numero de Empleado/Estudiante, no se podrán editar los datos. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDireccion.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Dirección.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDireccion.Focus();
                return;
            }
            if (txtID1.Text.Trim().Length == 0 || txtID2.Text.Trim().Length == 0 || txtID3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Error con el numero de identidad, no se podrán editar los datos. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //MOVER ESTO A VENTANA DE MODIFICARPERSONA
            string sql = "call spUpdatePersona(@1, @2, @3, @4, @5, @6, @7, @8, @9)";

            string gen = "";
            string id1 = txtID1.Text.Trim();
            string id2 = txtID2.Text.Trim();
            string id3 = txtID3.Text.Trim();
            string idCompleto = id1 + id2 + id3;
            if (radioMasculino.Checked == true && radioFemenino.Checked == false)
                gen = "M";
            else
                gen = "F";
            try
            {
                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@1", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@2", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@3", fechaNacimiento.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@4", gen);
                        cmd.Parameters.AddWithValue("@5", txtDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@6", spinnerFamiliares.Text.Trim());
                        cmd.Parameters.AddWithValue("@7", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@8", comboMunicipio.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@9", idCompleto);

                        cmd.Connection.Open();  //abrir conexion
                        cmd.ExecuteNonQuery();  //ejecutar comando
                    }
                }

                MessageBox.Show("Datos Actualizados", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                //ocurrio un error
                MessageBox.Show(ex.Message);

            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void cargarMunicipios()
        {
            string sql = "select MunicipioID, Nombre from municipio order by Nombre ASC";
            try
            {
                using (MySqlConnection con = new MySqlConnection(stringConexion))
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
                            comboMunicipio.SelectedIndex = comboMunicipio.FindString(municipio);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Cargando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private void DialogModificarPersona_Load(object sender, EventArgs e)
        {
            cargarMunicipios();
            fechaNacimiento.MaxDate = DateTime.Today.AddDays(-1);
        }

        private void MaskedTextBox1_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtID1.Select(0, 0);
            });
        }

        private void TxtCuenta_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtCuenta.Select(0, 0);
            });
        }

        private void TxtID2_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtID3.Select(0, 0);
            });
        }

        private void TxtID3_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtID3.Select(0, 0);
            });
        }

        private void TxtTelefono_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtTelefono.Select(0, 0);
            });
        }

        private void comboMunicipio_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(99, 150, 187)), e.Bounds);
                e.Graphics.DrawString(((DataRowView)combo.Items[e.Index]).Row.ItemArray[0].ToString(),
                                         e.Font,
                                         new SolidBrush(SystemColors.HighlightText),
                                         new Point(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Menu), e.Bounds);
                e.Graphics.DrawString(((DataRowView)combo.Items[e.Index]).Row.ItemArray[0].ToString(),
                                              e.Font,
                                              new SolidBrush(Color.Black),
                                              new Point(e.Bounds.X, e.Bounds.Y));
            }
        }
    }
}
