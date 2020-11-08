using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlbergueHN.Source.Forms;
using MySql.Data.MySqlClient;

namespace AlbergueHN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string StringConexion = "Server=127.0.0.1;Database=unahvs_al;Uid=root;Pwd=1234";
        //String stringConexion = "Server=127.0.0.1;Database=unahvs_-al;Uid=root;Pwd=1234";
        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarGridPersonas();
            llenarGridArticulos();
            this.Form1_SizeChanged(sender, e);
        }

        public void llenarGridPersonas()
        {
            DataTable dtPersonas = new DataTable();

            var stm = "select PersonaID, Cuenta, Nombres, Apellidos, DateDiff(fechaNacimiento, CURDATE()) as Edad, Telefono, Municipio from Persona";


            using (MySqlConnection con = new MySqlConnection(StringConexion))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                con.Open();
                da.Fill(dtPersonas);
                tabla.DataSource = dtPersonas;
            }

        }

        public void llenarGridArticulos()
        {
            DataTable dtArticulos = new DataTable();

            var stm = "select suministroID, a.Descripcion, tp.Descripcion as Tipo, Talla, Genero, Existencia from suministro a inner join tiposuministro tp on a.tipoID = tp.tipoID";

            using (MySqlConnection con = new MySqlConnection(StringConexion))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                con.Open();
                da.Fill(dtArticulos);
                tablaProductos.DataSource = dtArticulos;
            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                tabla.Columns[0].Width = tabla.Width * 10 / 100;
                tabla.Columns[1].Width = tabla.Width * 10 / 100;
                tabla.Columns[2].Width = tabla.Width * 20 / 100;
                tabla.Columns[3].Width = tabla.Width * 20 / 100;
                tabla.Columns[4].Width = tabla.Width * 10 / 100;
                tabla.Columns[5].Width = tabla.Width * 10 / 100;
                tabla.Columns[6].Width = tabla.Width * 10 / 100;
                tabla.Columns[7].Width = tabla.Width * 10 / 100;


                tablaProductos.Columns[0].Width = tablaProductos.Width * 10 / 100;
                tablaProductos.Columns[1].Width = tablaProductos.Width * 35 / 100;
                tablaProductos.Columns[2].Width = tablaProductos.Width * 25 / 100;
                tablaProductos.Columns[3].Width = tablaProductos.Width * 10 / 100;
                tablaProductos.Columns[4].Width = tablaProductos.Width * 10 / 100;
                tablaProductos.Columns[5].Width = tablaProductos.Width * 10 / 100;

            }
            catch (Exception ex)
            {

            }
        }

        private void ConexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogConectarServidor form = new dialogConectarServidor();
            form.ShowDialog();
        }

        private void DespacharSuministrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogDespacharArticulo form = new dialogDespacharArticulo();
            form.ShowDialog();
        }
    }
}
