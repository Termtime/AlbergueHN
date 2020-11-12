using AlbergueHN.Source.Objetos;
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
    public partial class LoginForm : Form
    {
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string pass = txtPass.Text;
            string usuario = txtUsuario.Text;
            using (MySqlConnection con = new MySqlConnection(stringConexion))
            {
                try
                {
                    con.Open();
                    ////TODO: DESCOMENTAR CUANDO SE PASE A PRODUCCION
                    //string query = "SELECT `verificar_login`(@userID, @pass)";
                    //MySqlCommand cmd = new MySqlCommand();
                    //cmd.CommandText = query;
                    //cmd.Connection = con;

                    //cmd.Parameters.AddWithValue("@userID", usuario);
                    //cmd.Parameters.AddWithValue("@pass", pass);

                    ////devuelve el ID del usuario loggeado
                    //try
                    //{
                    //    string result = (string)cmd.ExecuteScalar();
                    //    if (result != null)
                    //    {
                    //        UsuarioActual.ID = result;
                    //        //UsuarioActual.usuario = "Usuario Prueba";
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show("Credenciales invalidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    Console.WriteLine(ex.StackTrace);
                    //    con.Close();
                    //    Cursor.Current = Cursors.Default;
                    //}
                    UsuarioActual.ID = "0501199912345";
                    //Si sigue aqui, el login fue correcto, ingresar al sistema
                    con.Close();
                    if (UsuarioActual.ID != null)
                    {
                        Form1 pantallaPrincipal = new Form1();
                        pantallaPrincipal.Show();
                        pantallaPrincipal.loginRef = this;
                        this.Hide();
                        txtPass.Text = "";
                        txtUsuario.Text = "";
                        Cursor.Current = Cursors.Default;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.StackTrace);
                    con.Close();
                    Cursor.Current = Cursors.Default;
                }

                
            }
        }

        private void comprobarConexion()
        {
            stringConexion = (string)Properties.Settings.Default["stringConexion"];
            if (stringConexion.Length == 0)
            {
                labelEstado.Text = "No configurado";
                labelEstado.ForeColor = Color.Black;
                btnLogin.Enabled = false;
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            using (MySqlConnection con = new MySqlConnection(stringConexion))
            {
                try
                {
                    con.Open();
                    labelEstado.Text = "En línea";
                    Cursor.Current = Cursors.Default;
                    labelEstado.ForeColor = Color.Green;
                    btnLogin.Enabled = true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.StackTrace);
                    labelEstado.Text = "Conexión Fallida.";
                    labelEstado.ForeColor = Color.Red;
                    Cursor.Current = Cursors.Default;
                    btnLogin.Enabled = false;
                    con.Close();
                }
            }
        }
        private void BtnComprobar_Click(object sender, EventArgs e)
        {
            comprobarConexion();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dialogConectarServidor form = new dialogConectarServidor();
            form.ShowDialog();
            stringConexion = (string)Properties.Settings.Default["stringConexion"];
            comprobarConexion();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            comprobarConexion();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            comprobarConexion();
        }
    }
}
