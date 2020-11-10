using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        DataTable dtPersonas = new DataTable();
        DataTable dtArticulos = new DataTable();
        public Form1()
        {
            InitializeComponent();
            
        }
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (string item in tallasRopa)
            {
                comboTalla.Items.Add(item);
            }
            comboTalla.SelectedIndex = 0;                    
            llenarGridPersonas();
            llenarGridArticulos();
            llenarComboFiltroTipoArticulo();
            comboFiltro.SelectedIndex = 0;
            

            
            resizearTablaPersonas();
            resizearTablaSuministros();
        }

        public void llenarGridPersonas()
        {
            try
            {
                dtPersonas.Clear();
                var stm = "select PersonaID, Cuenta, Nombres, Apellidos, year(curdate()) - year(fechanacimiento) as Edad, Telefono, m.Nombre as Municipio from persona p inner join municipio m on p.municipio = m.municipioid where fechasalida is null";


                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                    con.Open();
                    da.Fill(dtPersonas);
                    tablaPersonas.DataSource = dtPersonas;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Cargando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void llenarComboFiltroTipoArticulo()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(stringConexion))
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

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Cargando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void llenarGridArticulos()
        {
            try
            {
                dtArticulos.Clear();
                var stm = "select suministroID, a.Descripcion, tp.Descripcion as Tipo, Talla, Genero, Existencia from suministro a inner join tiposuministro tp on a.tipoID = tp.tipoID";

                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                    con.Open();
                    da.Fill(dtArticulos);
                    tablaSuministros.DataSource = dtArticulos;
                }
                foreach(DataGridViewRow item in tablaSuministros.Rows)
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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Cargando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                llenarGridArticulos();
                llenarGridPersonas();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void filtrarSuministros()
        {
            //QUITAR ESTO CUANDO SE ARREGLE LA FUNCION
            //!!!!!!
            if (suministros.Count == 0)
            {
                return;
            }
            DataRowView row = (DataRowView)comboTipo.SelectedItem;
            string filtroTipo = (string)row.Row.ItemArray[1];
            string filtroTxt = txtFiltro.Text;
            //tablaSuministros.Rows.Clear();
            //List<ListViewItem> productosFiltrados = new List<ListViewItem>();
            string genero = "";
            string filtroTalla = comboTalla.SelectedItem.ToString() ?? comboTalla.Text;
            String buscar = txtFiltro.Text;
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
            
            if (filtroTipo == "Vestimenta" || filtroTipo == "Zapatos")
            {
                panelControlRopa.Visible = true;
                bool cualquierTalla = false;
                
                filtroTalla = (string)comboTalla.SelectedItem.ToString() ?? comboTalla.Text;
           
                if (filtroTalla == "Todas") cualquierTalla = true;
                try
                {
                    dtArticulos.DefaultView.RowFilter = "descripcion LIKE '%"+buscar+"%' and tipo = '" + filtroTipo+"' And (talla = '" + filtroTalla + "' or "+ cualquierTalla+")  And (genero = '" + genero+"' or "+cualquierGenero+")";
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else 
            {
                dtArticulos.DefaultView.RowFilter = "descripcion LIKE '%"+buscar+"%'";  
            }

           

        }
        private void filtrarPersonas()
        {
            String filtrar = txtFiltro1.Text;
            if (comboFiltro.SelectedIndex == 0)
            {
                dtPersonas.DefaultView.RowFilter = "nombres LIKE '%"+filtrar+"%'";
                
            }
            if (comboFiltro.SelectedIndex == 1)
            {
                dtPersonas.DefaultView.RowFilter = "personaID LIKE '%" + filtrar + "%'";

            }
            if (comboFiltro.SelectedIndex == 2)
            {
                dtPersonas.DefaultView.RowFilter = "cuenta LIKE '%" + filtrar + "%'";

            }
        }

        private void ConexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogConectarServidor form = new dialogConectarServidor();
            form.ShowDialog();
        }

        private void DespacharSuministrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogDespacharSuministro form = new dialogDespacharSuministro();
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
            dialogIngresarSuministro form = new dialogIngresarSuministro();
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

        private void TabPage1_SizeChanged(object sender, EventArgs e)
        {
            resizearTablaPersonas();
        }

        private void resizearTablaPersonas()
        {
            try
            {
                tablaPersonas.Columns[0].Width = (tablaPersonas.Width-2) * 10 / 100;
                tablaPersonas.Columns[1].Width = (tablaPersonas.Width-2) * 10 / 100;
                tablaPersonas.Columns[2].Width = (tablaPersonas.Width-2) * 20 / 100;
                tablaPersonas.Columns[3].Width = (tablaPersonas.Width-2) * 20 / 100;
                tablaPersonas.Columns[4].Width = (tablaPersonas.Width-2) * 10 / 100;
                tablaPersonas.Columns[5].Width = (tablaPersonas.Width-2) * 10 / 100;
                tablaPersonas.Columns[6].Width = (tablaPersonas.Width-2) * 20 / 100;
            }                                                       
            catch (Exception ex) { }
        }

        private void resizearTablaSuministros()
        {
            try
            {
                tablaSuministros.Columns[0].Width = (tablaSuministros.Width-1) * 10 / 100;
                tablaSuministros.Columns[1].Width = (tablaSuministros.Width-1) * 35 / 100;
                tablaSuministros.Columns[2].Width = (tablaSuministros.Width-1) * 25 / 100;
                tablaSuministros.Columns[3].Width = (tablaSuministros.Width-1) * 10 / 100;
                tablaSuministros.Columns[4].Width = (tablaSuministros.Width-1) * 10 / 100;
                tablaSuministros.Columns[5].Width = (tablaSuministros.Width-1) * 10 / 100;
            }
            catch (Exception ex){}
        }
        private void TabPage2_SizeChanged(object sender, EventArgs e)
        {
            resizearTablaSuministros();
        }

        private void btRefrescar_Click(object sender, EventArgs e)
        {
            llenarGridArticulos();
            llenarGridPersonas();
        }

        private void comboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarPersonas();
        }

        private void txtFiltro1_TextChanged(object sender, EventArgs e)
        {
            filtrarPersonas();
        }
    }
}
