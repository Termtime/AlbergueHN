﻿using System;
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
            Bitmap icono = AlbergueHN.Properties.Resources.icono;
            this.Icon = Icon.FromHandle(icono.GetHicon());
        }
        string StringConexion = (string)Properties.Settings.Default["stringConexion"];

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Nombres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }
            if (txtApellido.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Apellidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }
            if (txtCuenta.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de No de Cuenta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCuenta.Focus();
                return;
            }
            if (txtDireccion.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Dirección.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return;
            }
            if (txtID1.Text.Trim().Length == 0 || txtID2.Text.Trim().Length == 0 || txtID3.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Identidad.", "Validación");
                return;
            }

            string sql = "";
            //MOVER A DIALOGOINGRESARPERSONA
            if (!checkFamiliar.Checked)
            {
                sql = "CALL spIngresarPersona(@1, @2, @3, @4, @5, @6, @7, @8, @9, @10)";
            }
            else
                sql = "CALL spIngresarFamiliar(@1, @2, @3, @4, @5, @6, @7, @8, @9, @10)";
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
                using (MySqlConnection con = new MySqlConnection(StringConexion))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@1", idCompleto);
                        cmd.Parameters.AddWithValue("@2", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@3", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@4", fechaNacimiento.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@5", gen);
                        cmd.Parameters.AddWithValue("@6", txtDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@7", txtCuenta.Text.Trim());
                        cmd.Parameters.AddWithValue("@8", spinnerFamiliares.Text.Trim());
                        cmd.Parameters.AddWithValue("@9", txtTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@10",comboMunicipio.SelectedValue.ToString());

                        cmd.Connection.Open();  //abrir conexion
                        cmd.ExecuteNonQuery();  //ejecutar comando
                    }
                }
                this.Close();
            }
            catch (MySqlException ex)
            {
                //ocurrio un error
                if (ex.Number == 2627)
                    MessageBox.Show("Número de Identidad repetido.");
                MessageBox.Show(ex.Message , "Error ingresando persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);

            }


            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dialogIngresarPersona_Load(object sender, EventArgs e)
        {
            cargarMunicipios();
            fechaNacimiento.MaxDate = DateTime.Today.AddDays(-1);
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
                Console.WriteLine(ex.Message);
            }
            if (comboMunicipio.Items.Count != 0)
            {
                comboMunicipio.SelectedIndex = 0;
            }
        }

        private void TxtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void MaskedTextBox1_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtTelefono.Select(0, 0);
            });
        }

        private void TxtCuenta_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtCuenta.Select(0, 0);
            });
        }

        private void TxtID1_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtID1.Select(0, 0);
            });
        }

        private void TxtID2_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtID2.Select(0, 0);
            });
        }

        private void TxtID3_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtID3.Select(0, 0);
            });
        }

        private void comboMunicipio_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;
            if (e.Index == -1) return;
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

