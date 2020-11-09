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

    public partial class dialogDespacharArticulo : Form
    {
        string[] tallasRopa = { "Todas","XXS", "XS", "S", "M", "L", "XL", "XL", "XXL" };
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        List<ListViewItem> productos = new List<ListViewItem>();
        public dialogDespacharArticulo()
        {
            InitializeComponent();
        }

        private void DialogDespacharProductos_Load(object sender, EventArgs e)
        {
            llenarDatos();
            foreach(string item in tallasRopa)
            {
                comboTalla.Items.Add(item);
            }
            comboTalla.SelectedIndex = 0;
        }

        private void llenarDatos()
        {

            using (MySqlConnection con = new MySqlConnection(stringConexion))
            {
                DataTable dtSuministro = new DataTable();
                var stm = "SELECT SuministroID, a.Descripcion, Existencia, b.Descripcion as Tipo, Talla, Genero FROM unahvs_al.suministro a inner join unahvs_al.tiposuministro b on a.tipoID = b.tipoID;";
                MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                con.Open();
                da.Fill(dtSuministro);
                foreach(DataRow r in dtSuministro.Rows)
                {
                    string[] row = { (string)r["Descripcion"], ((int)r["Existencia"]).ToString(), (string)r["Tipo"], (r["Talla"] == System.DBNull.Value? " " : (string)r["Talla"]), (r["Genero"] == System.DBNull.Value? " " : (string)r["Genero"]), ((int)r["SuministroID"]).ToString() };
                    ListViewItem tmp2 = new ListViewItem();
                    tmp2.Text = row[0];
                    tmp2.SubItems.Add(row[1]); //Existencia
                    tmp2.SubItems.Add(row[2]); //Tipo
                    tmp2.SubItems.Add(row[3]); //Talla
                    tmp2.SubItems.Add(row[4]); //Genero
                    tmp2.Tag = row[5]; //ID
                    listaProductos.Items.Add(tmp2);

                    productos.Add(tmp2);
                }

            }

            using (MySqlConnection con = new MySqlConnection(stringConexion))
            {
                DataSet dsTipo = new DataSet();
                dsTipo.Tables.Add(new DataTable("TipoDefault"));
                dsTipo.Tables["TipoDefault"].Columns.Add("TipoID", typeof(int));
                dsTipo.Tables["TipoDefault"].Columns.Add("Descripcion", typeof(string));
                dsTipo.Tables["TipoDefault"].Rows.Add(0,"Todos");
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

        private void filtrar()
        {
            DataRowView row = (DataRowView)comboTipo.SelectedItem;
            string filtroTipo = (string)row.Row.ItemArray[1];
            string filtroTxt = txtFiltro.Text;
            listaProductos.Items.Clear();
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
            }else if (radioCualquiera.Checked)
            {
                cualquierGenero = true;
            }

            if (filtroTipo == "Todos")
            {
                foreach (ListViewItem item in productos.Where(item => item.Text.ToLower().Contains(filtroTxt.ToLower())))
                {
                    listaProductos.Items.Add(item);
                }

                return;
            }else if(filtroTipo == "Vestimenta")
            {
                
                bool cualquierTalla = false;
                
                string filtroTalla = (string)comboTalla.SelectedItem.ToString();
                if (filtroTalla == "Todas") cualquierTalla = true;
                foreach (ListViewItem item in productos.Where(item => item.SubItems[2].Text == filtroTipo && item.Text.ToLower().Contains(filtroTxt.ToLower()) && (item.SubItems[4].Text == genero || cualquierGenero) && (item.SubItems[3].Text.Contains(filtroTalla) || cualquierTalla)))
                {
                    
                    listaProductos.Items.Add(item);
                }
            }
            else if(filtroTipo == "Zapatos")
            {
                foreach (ListViewItem item in productos.Where(item => item.SubItems[2].Text == filtroTipo && item.Text.ToLower().Contains(filtroTxt.ToLower()) && item.SubItems[4].Text.Contains(genero)))
                {
                    listaProductos.Items.Add(item);
                }
            }
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
            DataRowView row = (DataRowView)comboTipo.SelectedItem;
            string filtroTipo = (string)row.Row.ItemArray[1];
            if (filtroTipo == "Vestimenta")
            { panelControlRopa.Visible = true; labelTalla.Visible = true; comboTalla.Visible = true; }
            else if (filtroTipo == "Zapatos")
            { panelControlRopa.Visible = true; labelTalla.Visible = false; comboTalla.Visible = false; comboTalla.SelectedIndex = 0; }
            else { panelControlRopa.Visible = false; }
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void ComboTalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void RadioCualquiera_CheckedChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void RadioMasculino_CheckedChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void RadioFemenino_CheckedChanged(object sender, EventArgs e)
        {
            filtrar();
        }
    }
}
