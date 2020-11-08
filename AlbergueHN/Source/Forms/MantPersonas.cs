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
        String cs = "";
        private void BtnDarDeAlta_Click(object sender, EventArgs e)
        {

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
            using (MySqlConnection con = new MySqlConnection(cs))
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

            if(!p.IsDisposed)
            {

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
    }
}
