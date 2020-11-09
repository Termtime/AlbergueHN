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
using AlbergueHN.Source.Objetos;
using MySql.Data.MySqlClient;

namespace AlbergueHN
{
    public partial class Form1 : Form
    {
        List<List<string>> suministros = new List<List<string>>();
        DataGridViewRowCollection personas;
        string[] tallasRopa = { "Todas", "XXS", "XS", "S", "M", "L", "XL", "XL", "XXL" };
        string loggedUserID = UsuarioActual.ID;
        public Form1()
        {
            InitializeComponent();
            llenarComboFiltroTipoArticulo();
            foreach (string item in tallasRopa)
            {
                comboTalla.Items.Add(item);
            }

            comboTalla.SelectedIndex = 0;
        }
        string StringConexion = (string)Properties.Settings.Default["stringConexion"];
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

            var stm = "select PersonaID, Cuenta, Nombres, Apellidos, DateDiff(fechaNacimiento, CURDATE()) as Edad, Telefono, M.Nombre as Municipio from Persona p inner join municipio m on p.municipio = m.municipioid where fechasalida is null";


            using (MySqlConnection con = new MySqlConnection(StringConexion))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                con.Open();
                da.Fill(dtPersonas);
                tabla.DataSource = dtPersonas;
            }

        }

        public void llenarComboFiltroTipoArticulo()
        {
            using (MySqlConnection con = new MySqlConnection(StringConexion))
            {
                DataSet dsTipo = new DataSet();
                dsTipo.Tables.Add(new DataTable("TipoDefault"));
                dsTipo.Tables["TipoDefault"].Columns.Add("TipoID", typeof(int));
                dsTipo.Tables["TipoDefault"].Columns.Add("Descripcion", typeof(string));
                dsTipo.Tables["TipoDefault"].Rows.Add(0, "Todos");
                var stm = "SELECT TipoID, Descripcion FROM tiposuministro";
                MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                con.Open();
                da.Fill(dsTipo, "Tipos");
                comboTipo.DisplayMember = "Descripcion";
                comboTipo.ValueMember = "TipoID";
                dsTipo.Tables["TipoDefault"].Merge(dsTipo.Tables["Tipos"]);
                comboTipo.DataSource = dsTipo.Tables["TipoDefault"];
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
            foreach(DataGridViewRow item in tablaProductos.Rows)
            {
                List<string> fila = new List<string>();
                fila.Add(item.Cells[0].Value.ToString());
                fila.Add(item.Cells[1].Value.ToString());
                fila.Add(item.Cells[2].Value.ToString());
                fila.Add(item.Cells[3].Value.ToString());
                fila.Add(item.Cells[4].Value.ToString());
                fila.Add(item.Cells[5].Value.ToString());

                suministros.Add(fila);
            }
            Console.WriteLine("PREVIO FILTRO");
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
                tabla.Columns[6].Width = tabla.Width * 20 / 100;


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

        private void filtrarSuministros()
        {
            //QUITAR ESTO CUANDO SE ARREGLE LA FUNCION
            return;
            //!!!!!!
            if (suministros.Count == 0)
            {
                return;
            }
            DataRowView row = (DataRowView)comboTipo.SelectedItem;
            string filtroTipo = (string)row.Row.ItemArray[1];
            string filtroTxt = txtFiltro.Text;
            tablaProductos.Rows.Clear();
            List<ListViewItem> productosFiltrados = new List<ListViewItem>();
            string genero = "";
            bool cualquierGenero = false;
            if (radioMasculino.Checked)
            {
                genero = "M";
            }
            else if (radioFemenino.Checked)
            {
                genero = "F";
            }
            else if (radioCualquiera.Checked)
            {
                cualquierGenero = true;
            }

            if (filtroTipo == "Todos")
            {
                Console.WriteLine("FILTRO TODOS");
                foreach (List<string> item in suministros.Where(item => item[1].ToLower().Contains(filtroTxt.ToLower())))
                {
                    
                }

                return;
            }
            else if (filtroTipo == "Vestimenta")
            {

                bool cualquierTalla = false;

                string filtroTalla = (string)comboTalla.SelectedItem.ToString();
                if (filtroTalla == "Todas") cualquierTalla = true;
                foreach (List<string> item in suministros.Where(item => item[2] == filtroTipo && item[1].ToLower().Contains(filtroTxt.ToLower()) && (item[4] == genero || cualquierGenero) && (item[3].Contains(filtroTalla) || cualquierTalla)))
                {

                    tablaProductos.Rows.Add(item);
                }
            }
            else if (filtroTipo == "Zapatos")
            {
                foreach (List<string> item in suministros.Where(item => item[2] == filtroTipo && item[1].Contains(filtroTxt.ToLower()) && (item[4] == genero || cualquierGenero)))
                {
                    tablaProductos.Rows.Add(item);
                }
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarSuministros();
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            filtrarSuministros();
        }

        private void ComboTalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarSuministros();
        }

        private void RadioCualquiera_CheckedChanged(object sender, EventArgs e)
        {
            filtrarSuministros();
        }

        private void RadioMasculino_CheckedChanged(object sender, EventArgs e)
        {
            filtrarSuministros();
        }

        private void RadioFemenino_CheckedChanged(object sender, EventArgs e)
        {
            filtrarSuministros();
        }

        private void IngresarSuministrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogIngresarProducto form = new dialogIngresarProducto();
            form.ShowDialog();
        }

        private void ingresarPersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantPersonas personas = new MantPersonas();
            personas.Show();
        }

        private void administrarSuministrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantProductos productos = new MantProductos();
            productos.Show();
        }
    }
}
