using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace AlbergueHN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string StringConexion = "";

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

            var stm = "select Identidad, Cuenta,Nombre, Apellido, DateDiff(YY, fechaDeNacimiento, GetDate()) as Edad, Telefono1, Departamento, Municipio from Personas";

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

            var stm = "select ArticuloID, Descripcion, tp.Descripcion as Tipo, Talla, Genero, Cantidad as Existencia from articulos a inner join tipoArticulo tp on a.tipoArticulo = tp.tipoArticuloID";

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
    }
}
