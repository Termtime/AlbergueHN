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
        string StringConexion = (string)Properties.Settings.Default["stringConexion"];
        private void BtnDarDeAlta_Click(object sender, EventArgs e)
        {
            String id = tablaPersonas.CurrentRow.Cells["PersonaID"].Value.ToString();
            String sql = "call dar_alta(@1)";
            try
            {
                using (MySqlConnection con = new MySqlConnection(StringConexion))
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
        }

        private void MantPersonas_Load(object sender, EventArgs e)
        {
            cargarPersonas();
            MantPersonas_SizeChanged(sender, e);
        }
        public void cargarPersonas()
        {
            dt.Clear();
            var stm = "select PersonaID as Identidad, Cuenta, Nombres, Apellidos, FechaNacimiento, Genero, CantidadFamiliares as 'Cantidad de Familiares', "
                +"Telefono1, Telefono2, d.Nombre as 'Departamento', m.Nombre as 'Municipio', Direccion, FechaEntrada as 'Fecha de Entrada', FechaSalida as 'Fecha de Salida'"+
                " from persona p inner join departamento d on p.Departamento = d.DepartamentoIDinner join municipio m on d.DepartamentoID = m.Departamento";
            using (MySqlConnection con = new MySqlConnection(StringConexion))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                con.Open();
                da.Fill(dt);
                tablaPersonas.DataSource = dt;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String genero;
            String fecha;
            dialogIngresarPersona p = new dialogIngresarPersona();
            p.txtNombres.Text = tablaPersonas.CurrentRow.Cells["Nombres"].Value.ToString();
            p.txtApellidos.Text = tablaPersonas.CurrentRow.Cells["Apellidos"].Value.ToString();
            p.txtId.Text = tablaPersonas.CurrentRow.Cells["Identidad"].Value.ToString();
            p.txtCuenta.Text = tablaPersonas.CurrentRow.Cells["Cuenta"].Value.ToString();
            p.txtTelefono.Text = tablaPersonas.CurrentRow.Cells["Telefono1"].Value.ToString();
            genero = tablaPersonas.CurrentRow.Cells["Genero"].Value.ToString();
            fecha = tablaPersonas.CurrentRow.Cells["FechaNacimiento"].Value.ToString();
            String identidadOriginal = p.txtId.Text.Trim();
            //p.fechaNacimiento. = fecha;
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

            if(!p.IsDisposed) //Incompleto
            {
                String sql = "call updatePersona(@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, "+identidadOriginal+")";
                string gen = "";
                if (p.radioMasculino.Checked == true && p.radioFemenino.Checked == false)
                    gen = "M";
                else
                    gen = "F";
                try
                {
                    using (MySqlConnection con = new MySqlConnection(StringConexion))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@1", p.txtId.Text.Trim());
                            cmd.Parameters.AddWithValue("@2", p.txtNombres.Text.Trim());
                            cmd.Parameters.AddWithValue("@3", p.txtApellidos.Text.Trim());
                            cmd.Parameters.AddWithValue("@4", p.fechaNacimiento.Value.ToString("yyyy-mm-dd"));
                            cmd.Parameters.AddWithValue("@5", gen);
                            cmd.Parameters.AddWithValue("@6", p.txtDireccion.Text.Trim());
                            cmd.Parameters.AddWithValue("@7", p.txtCuenta.Text.Trim());
                            cmd.Parameters.AddWithValue("@8", p.txtFamiliares.Text.Trim());
                            cmd.Parameters.AddWithValue("@9", p.txtTelefono.Text.Trim());
                            cmd.Parameters.AddWithValue("@10", p.comboMunicipio.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@11", p.comboDepto.SelectedValue.ToString());

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
            }
        }

        private void MantPersonas_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                tablaPersonas.Columns[0].Width = tablaPersonas.Width * 7 / 100;
                tablaPersonas.Columns[1].Width = tablaPersonas.Width * 8 / 100;
                tablaPersonas.Columns[2].Width = tablaPersonas.Width * 8 / 100;
                tablaPersonas.Columns[3].Width = tablaPersonas.Width * 7 / 100;
                tablaPersonas.Columns[4].Width = tablaPersonas.Width * 7 / 100;
                tablaPersonas.Columns[5].Width = tablaPersonas.Width * 7 / 100;
                tablaPersonas.Columns[6].Width = tablaPersonas.Width * 7 / 100;
                tablaPersonas.Columns[7].Width = tablaPersonas.Width * 7 / 100;
                tablaPersonas.Columns[8].Width = tablaPersonas.Width * 7 / 100;
                tablaPersonas.Columns[9].Width = tablaPersonas.Width * 7 / 100;
                tablaPersonas.Columns[10].Width = tablaPersonas.Width * 7 / 100;
                tablaPersonas.Columns[11].Width = tablaPersonas.Width * 7 / 100;
                tablaPersonas.Columns[12].Width = tablaPersonas.Width * 7 / 100;
                tablaPersonas.Columns[13].Width = tablaPersonas.Width * 7 / 100;

            }
            catch (Exception ex)
            {

            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            dialogIngresarPersona p = new dialogIngresarPersona();
            if (!p.IsDisposed) //Incompleto
            {
                String sql = "CALL ingresarPersona(@1, @2, @3, @4, @5, @6, @7, @8, @9, @10)";
                string gen = "";
                if (p.radioMasculino.Checked == true && p.radioFemenino.Checked == false)
                    gen = "M";
                else
                    gen = "F";
                try
                {
                    using (MySqlConnection con = new MySqlConnection(StringConexion))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@1", p.txtNombres.Text.Trim());
                            cmd.Parameters.AddWithValue("@2", p.txtApellidos.Text.Trim());
                            cmd.Parameters.AddWithValue("@3", p.fechaNacimiento.Value.ToString("yyyy-mm-dd"));
                            cmd.Parameters.AddWithValue("@4", gen);
                            cmd.Parameters.AddWithValue("@5", p.txtDireccion.Text.Trim());
                            cmd.Parameters.AddWithValue("@6", p.txtCuenta.Text.Trim());
                            cmd.Parameters.AddWithValue("@7", p.txtFamiliares.Text.Trim());
                            cmd.Parameters.AddWithValue("@8", p.txtTelefono.Text.Trim());
                            cmd.Parameters.AddWithValue("@9", p.comboMunicipio.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@10", p.comboDepto.SelectedValue.ToString()); 
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
            }
        }
    }
}
