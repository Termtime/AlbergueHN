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
            comprobarConexion();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string pass = txtPass.Text;
            string usuario = txtUsuario.Text;
            using (MySqlConnection con = new MySqlConnection(stringConexion))
            {
                try
                {
                    con.Open();
                    //simluacion de inicio de sesion

                    //TODO: Llamar funcion de login y esperar resultado;

                    //devuelve el ID del usuario loggeado
                    //TODO: Cambiar esto a codigo verdadero
                    UsuarioActual.ID = "test";
                    UsuarioActual.usuario = "Usuario Prueba";
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    labelEstado.Text = "Conexión Fallida.";
                }

                //Si sigue aqui, el login fue correcto, ingresar al sistema
                if(UsuarioActual.ID != null)
                {
                    Form1 pantallaPrincipal = new Form1();
                    pantallaPrincipal.Show();
                    this.Visible = false;
                }
            }
        }

        private void comprobarConexion()
        {
            if(stringConexion.Length == 0)
            {
                labelEstado.Text = "No configurado";
                btnLogin.Enabled = false;
                return;
            }
            using (MySqlConnection con = new MySqlConnection(stringConexion))
            {
                try
                {
                    con.Open();
                    labelEstado.Text = "En linea";
                    btnLogin.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    labelEstado.Text = "Conexión Fallida.";
                    btnLogin.Enabled = false;
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
    }
}
