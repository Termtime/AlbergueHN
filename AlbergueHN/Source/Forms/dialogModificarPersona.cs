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
    public partial class dialogModificarPersona : Form
    {
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        public dialogModificarPersona()
        {
            InitializeComponent();
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
                MessageBox.Show("No ha llenado el campo de Dirección.", "Validación");
                txtDireccion.Focus();
                return;
            }
            if (txtID1.Text.Trim().Length == 0 || txtID2.Text.Trim().Length == 0 || txtID3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Error con el numero de identidad, no se podrán editar los datos. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //MOVER ESTO A VENTANA DE MODIFICARPERSONA
            string sql = "call spUpdatePersona(@1 @2, @3, @4, @5, @6, @7, @8, @9)";

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
    }
}
