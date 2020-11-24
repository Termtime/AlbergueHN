using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AlbergueHN.Source.Forms
{
    public partial class MantPersonas : Form
    {
        public MantPersonas()
        {
            InitializeComponent();
            Bitmap icono = AlbergueHN.Properties.Resources.icono;
            this.Icon = Icon.FromHandle(icono.GetHicon());
            comboFiltro.SelectedIndex = 0;
        }
        DataTable dt = new DataTable();
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        private void BtnDarDeAlta_Click(object sender, EventArgs e)
        {
            String id = tablaPersonas.CurrentRow.Cells["Identidad"].Value.ToString();
            String sql = "call spDarAlta(@1)";
            try
            {
                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@1", id);
                        cmd.Connection.Open();  //abrir conexion
                        cmd.ExecuteNonQuery();  //ejecutar comando
                    }
                }

            }
            catch (Exception ex)
            {
                //ocurrio un error
                MessageBox.Show(ex.Message, "Error dando de alta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
            cargarPersonas();
        }

        private void MantPersonas_Load(object sender, EventArgs e)
        {
            cargarPersonas();
            MantPersonas_SizeChanged(sender, e);
        }
        public void cargarPersonas()
        {
            try
            {
                dt.Clear();
                var stm = "select * from vistaPersonas";
                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                    con.Open();
                    da.Fill(dt);
                    tablaPersonas.DataSource = dt;
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Cargando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String genero;
            String fecha;
            dialogModificarPersona p = new dialogModificarPersona();
            if(tablaPersonas.CurrentRow.Cells["No. Empleado/Estudiante"].Value.ToString().Contains("Fam:"))
            {
                p.checkFamiliar.Checked = true;
            }
            p.txtNombre.Text = tablaPersonas.CurrentRow.Cells["Nombres"].Value.ToString();
            p.txtApellido.Text = tablaPersonas.CurrentRow.Cells["Apellidos"].Value.ToString();
            string id1 = tablaPersonas.CurrentRow.Cells["Identidad"].Value.ToString().Substring(0,4);
            string id2 = tablaPersonas.CurrentRow.Cells["Identidad"].Value.ToString().Substring(4,4);
            string id3 = tablaPersonas.CurrentRow.Cells["Identidad"].Value.ToString().Substring(8,5);

            p.txtID1.Text = id1;
            p.txtID2.Text = id2;
            p.txtID3.Text = id3;

            p.txtID1.Enabled = false;
            p.txtID2.Enabled = false;
            p.txtID3.Enabled = false;

            p.txtCuenta.Text = tablaPersonas.CurrentRow.Cells["No. Empleado/Estudiante"].Value.ToString().Replace("Fam:", "");
            p.txtTelefono.Text = tablaPersonas.CurrentRow.Cells["Telefono"].Value.ToString();
            p.txtDireccion.Text = tablaPersonas.CurrentRow.Cells["Direccion"].Value.ToString();
            p.spinnerFamiliares.Value = (int) tablaPersonas.CurrentRow.Cells["Cantidad de Familiares"].Value;
            genero = tablaPersonas.CurrentRow.Cells["Genero"].Value.ToString();
            fecha = tablaPersonas.CurrentRow.Cells["FechaNacimiento"].Value.ToString();
           
            p.fechaNacimiento.Value = DateTime.Parse(fecha);
            p.municipio = tablaPersonas.CurrentRow.Cells["Municipio"].Value.ToString();
            if (genero == "M")
            {
                p.radioMasculino.Checked = true;
                p.radioFemenino.Checked = false;
            }
            else
            {
                p.radioMasculino.Checked = false;
                p.radioFemenino.Checked = true;
            }
                
            p.ShowDialog();
            cargarPersonas();  
        }

        private void MantPersonas_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                tablaPersonas.Columns[0].Width = tablaPersonas.Width * 8 / 100;
                tablaPersonas.Columns[1].Width = tablaPersonas.Width * 10 / 100;
                tablaPersonas.Columns[2].Width = tablaPersonas.Width * 10 / 100;
                tablaPersonas.Columns[3].Width = tablaPersonas.Width * 8 / 100;
                tablaPersonas.Columns[4].Width = tablaPersonas.Width * 8 / 100;
                tablaPersonas.Columns[5].Width = tablaPersonas.Width * 8 / 100;
                tablaPersonas.Columns[6].Width = tablaPersonas.Width * 8 / 100;
                tablaPersonas.Columns[7].Width = tablaPersonas.Width * 8 / 100;
                tablaPersonas.Columns[8].Width = tablaPersonas.Width * 8 / 100;
                tablaPersonas.Columns[9].Width = tablaPersonas.Width * 8 / 100;
                tablaPersonas.Columns[10].Width = tablaPersonas.Width * 8 / 100;
                tablaPersonas.Columns[11].Width = tablaPersonas.Width * 8 / 100;
            }
            catch (Exception ex)
            {

            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                cargarPersonas();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
            dialogIngresarPersona p = new dialogIngresarPersona();
            p.ShowDialog();
            cargarPersonas();
        }

        private void tablaPersonas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (tablaPersonas.SelectedRows[0] != null)
                {
                    btnModificar.Enabled = true;
                    if (tablaPersonas.SelectedRows[0].Cells["Fecha de Salida"].Value.ToString().Trim().Length > 0)
                    {
                        btnDarDeAlta.Enabled = false;
                        btnModificar.Enabled = false;
                    }
                    else
                    {
                        btnDarDeAlta.Enabled = true;
                        btnModificar.Enabled = true;
                    }
                }
                else
                {
                    btnModificar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void filtrarPersonas()
        {
            if (tablaPersonas.DataSource == null) return;
            String filtrar = txtFiltro1.Text.Replace("'", "''");
            if (comboFiltro.SelectedIndex == 0)
            {
                (tablaPersonas.DataSource as DataTable).DefaultView.RowFilter = "nombres + apellidos LIKE '%" + filtrar + "%'";
            }
            if (comboFiltro.SelectedIndex == 1)
            {
                (tablaPersonas.DataSource as DataTable).DefaultView.RowFilter = "[Identidad] LIKE '%" + filtrar + "%'";
            }
            if (comboFiltro.SelectedIndex == 2)
            {
                (tablaPersonas.DataSource as DataTable).DefaultView.RowFilter = "[No. Empleado/Estudiante] LIKE '%" + filtrar + "%'";
            }
        }

        private void comboFiltro_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                if(e.Index != -1)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(99, 150, 187)), e.Bounds);
                    e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                             e.Font,
                                             new SolidBrush(SystemColors.HighlightText),
                                             new Point(e.Bounds.X, e.Bounds.Y));
                }
            }
            else
            {
                if(e.Index != -1)
                {
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Menu), e.Bounds);
                    e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                                  e.Font,
                                                  new SolidBrush(Color.Black),
                                                  new Point(e.Bounds.X, e.Bounds.Y));
                }
            }
        }

        private void ComboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarPersonas();
        }

        private void TxtFiltro1_TextChanged(object sender, EventArgs e)
        {
            filtrarPersonas();
        }

        private void TxtFiltro1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '#':
                    e.Handled = true;
                    break;
                case '[':
                    e.Handled = true;
                    break;
                case ']':
                    e.Handled = true;
                    break;

                case '*':
                    e.Handled = true;
                    break;
                case '%':
                    e.Handled = true;
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }
    }
}
