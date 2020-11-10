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
                MessageBox.Show(ex.Message);
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
                var stm = "select PersonaID as Identidad, Cuenta, Nombres, Apellidos, FechaNacimiento, Genero, CantidadFamiliares as 'Cantidad de Familiares', "
                    +"Telefono, m.Nombre as 'Municipio', Direccion, FechaEntrada as 'Fecha de Entrada', FechaSalida as 'Fecha de Salida'"+
                    " from persona p inner join municipio m on p.municipio = m.municipioid";
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
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String genero;
            String fecha;
            dialogModificarPersona p = new dialogModificarPersona();
            p.txtNombre.Text = tablaPersonas.CurrentRow.Cells["Nombres"].Value.ToString();
            p.txtApellido.Text = tablaPersonas.CurrentRow.Cells["Apellidos"].Value.ToString();
            string id1 = tablaPersonas.CurrentRow.Cells["Identidad"].Value.ToString().Substring(0,3);
            string id2 = tablaPersonas.CurrentRow.Cells["Identidad"].Value.ToString().Substring(4,7);
            string id3 = tablaPersonas.CurrentRow.Cells["Identidad"].Value.ToString();

            p.txtID1.Text = id1;
            p.txtID2.Text = id2;
            p.txtID3.Text = id3;

            p.txtID1.Enabled = false;
            p.txtID2.Enabled = false;
            p.txtID3.Enabled = false;

            p.txtCuenta.Text = tablaPersonas.CurrentRow.Cells["Cuenta"].Value.ToString();
            p.txtTelefono.Text = tablaPersonas.CurrentRow.Cells["Telefono"].Value.ToString();
            p.txtDireccion.Text = tablaPersonas.CurrentRow.Cells["Direccion"].Value.ToString();
            p.spinnerFamiliares.Value = (int) tablaPersonas.CurrentRow.Cells["Cantidad de Familiares"].Value;
            genero = tablaPersonas.CurrentRow.Cells["Genero"].Value.ToString();
            fecha = tablaPersonas.CurrentRow.Cells["FechaNacimiento"].Value.ToString();
           
            p.fechaNacimiento.Value = DateTime.Parse(fecha);
            p.comboMunicipio.SelectedItem = tablaPersonas.CurrentRow.Cells["Municipio"].Value.ToString();
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
                ////MOVER A DIALOGOINGRESARPERSONA
                //if (!p.checkFamiliar.Checked)
                //{
                //    sql = "CALL spIngresarPersona(@1, @2, @3, @4, @5, @6, @7, @8, @9, @10)";
                //}
                //else
                //    sql = "CALL spIngresarFamiliar(@1, @2, @3, @4, @5, @6, @7, @8, @9, @10)";
                //string gen = "";
                //if (p.radioMasculino.Checked == true && p.radioFemenino.Checked == false)
                //    gen = "M";
                //else
                //    gen = "F";
                //try
                //{
                //    using (MySqlConnection con = new MySqlConnection(StringConexion))
                //    {
                //        using (MySqlCommand cmd = new MySqlCommand(sql, con))
                //        {
                //            cmd.Parameters.AddWithValue("@1", p.txtId.Text.Trim());
                //            cmd.Parameters.AddWithValue("@2", p.txtNombre.Text.Trim());
                //            cmd.Parameters.AddWithValue("@3", p.txtApellido.Text.Trim());
                //            cmd.Parameters.AddWithValue("@4", p.fechaNacimiento.Value.ToString("yyyy-MM-dd"));
                //            cmd.Parameters.AddWithValue("@5", gen);
                //            cmd.Parameters.AddWithValue("@6", p.txtDireccion.Text.Trim());
                //            cmd.Parameters.AddWithValue("@7", p.txtCuenta.Text.Trim());
                //            cmd.Parameters.AddWithValue("@8", p.spinnerFamiliares.Text.Trim());
                //            cmd.Parameters.AddWithValue("@9", p.txtTelefono.Text.Trim());
                //            cmd.Parameters.AddWithValue("@10", p.comboMunicipio.SelectedValue.ToString());

                //            cmd.Connection.Open();  //abrir conexion
                //            cmd.ExecuteNonQuery();  //ejecutar comando
                //        }
                //    }

                //}
                //catch (MySqlException ex)
                //{
                //    //ocurrio un error
                //    MessageBox.Show(ex.Message);
                //}
        }

        private void TablaPersonas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(tablaPersonas.SelectedRows[0] != null)
                {
                    if(tablaPersonas.SelectedRows[0].Cells["FechaSalida"].Value.ToString().Trim().Length > 0)
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
            }catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
