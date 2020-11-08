﻿using MySql.Data.MySqlClient;
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
    public partial class dialogConectarServidor : Form
    {
        string error;
        public dialogConectarServidor()
        {
            InitializeComponent();
            try
            {
                string ip = (string) Properties.Settings.Default["serverIP"];
                string usuario = (string)Properties.Settings.Default["usuarioServer"];
                string pass = (string) Properties.Settings.Default["serverPass"];
                string bd = (string) Properties.Settings.Default["bd"];
                string stringConexion = (string)Properties.Settings.Default["stringConexion"];
                if(ip.Length == 0 || usuario.Length == 0 || pass.Length == 0 || bd.Length == 0 || stringConexion.Length == 0)
                {
                    return;
                }
                try
                {
                    MySqlConnection con = new MySqlConnection(stringConexion);
                    btnDetalles.Visible = false;
                    labelEstado.Text = "Conectando...";
                    con.Open();
                    labelEstado.Text = "Conectado";
                    con.Close();
                }
                catch (Exception ex)
                {
                    //La conexion fallo, indicarle al usuario
                    labelEstado.Text = "Conexion Fallida";
                    btnDetalles.Visible = true;
                    error = ex.ToString();
                }

                txtIP.Text = ip;
                txtUsuario.Text = usuario;
                txtPass.Text = pass;
                txtBD.Text = bd;
            }
            catch(Exception e){}


        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
            string stringConexion = "Server=" + txtIP.Text + ";Database="+txtBD.Text+";Uid="+txtUsuario.Text+";Pwd=" + txtPass.Text;

            MySqlConnection con = new MySqlConnection(stringConexion);
            try
            {
                btnDetalles.Visible = false;
                labelEstado.Text = "Conectando...";
                con.Open();
                //Se conectó correctamente, guardar conexion
                Properties.Settings.Default["serverIP"] = txtIP.Text;
                Properties.Settings.Default["serverPass"] = txtPass.Text;
                Properties.Settings.Default["usuarioServer"] = txtUsuario.Text;
                Properties.Settings.Default["bd"] = txtBD.Text;
                Properties.Settings.Default["stringConexion"] = stringConexion;

                Properties.Settings.Default.Save();
                labelEstado.Text = "Conectado";
                con.Close();
            }
            catch(Exception ex)
            {
                //La conexion fallo, indicarle al usuario
                labelEstado.Text = "Conexion Fallida";
                btnDetalles.Visible = true;
                error = ex.ToString();
                Console.WriteLine(error);
            }

            
        }

        private void BtnDetalles_Click(object sender, EventArgs e)
        {
            MessageBox.Show(error, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["serverIP"] = "";
            Properties.Settings.Default["serverPass"] = "";
            Properties.Settings.Default["usuarioServer"] = "";
            Properties.Settings.Default["bd"] = "";

            Properties.Settings.Default.Save();

            txtIP.Text = "";
            txtUsuario.Text = "";
            txtPass.Text = "";
            txtBD.Text = "";
        }
    }
}