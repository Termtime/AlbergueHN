using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlbergueHN.Source.Forms;
using AlbergueHN.Source.Objetos;
using MySql.Data.MySqlClient;

namespace AlbergueHN
{
    public partial class Form1 : Form
    {
        string[] tallasRopa = { "Todas", "XXS", "XS", "S", "M", "L", "XL", "XL", "XXL" };
        string loggedUserID = UsuarioActual.ID;
        DataTable dtPersonas = new DataTable();
        DataTable dtArticulos = new DataTable();
        public LoginForm loginRef;
        bool estaCargandoDatos = false;
        public Form1()
        {
            InitializeComponent();
            tablaSuministros.DataSource = null;
            tablaPersonas.DataSource = null;
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
            callCargaDatos();
            comboFiltro.SelectedIndex = 0;
            resizearTablaPersonas();
            resizearTablaSuministros();
        }

        public void callCargaDatos()
        {
            if (estaCargandoDatos) return;
            Thread t = new Thread(new ThreadStart(cargaDatos));
            t.IsBackground = true;
            t.Name = "cargaDatos";
            t.Start();
        }

        public void cargaDatos()
        {
            estaCargandoDatos = true;
            try
            {

                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    var stm = "SELECT * FROM vistaPersonasPantallaPrincipal";
                    MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                    con.Open();
                    Invoke(new Action(() =>
                    {
                        dtPersonas.Clear();
                        da.Fill(dtPersonas);
                        tablaPersonas.DataSource = dtPersonas;
                        resizearTablaPersonas();
                    }));
                }

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
                    dsTipo.Tables["TipoDefault"].Merge(dsTipo.Tables["Tipos"]);
                    Invoke(new Action(() =>
                    {
                        comboTipo.DisplayMember = "Descripcion";
                        comboTipo.ValueMember = "TipoID";
                        comboTipo.DataSource = dsTipo.Tables["TipoDefault"];
                    }));
                }

                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    var stm = "SELECT suministroID, a.Descripcion, tp.Descripcion as Tipo, a.Talla, Genero, Existencia FROM suministro a INNER JOIN tiposuministro tp on a.tipoID = tp.tipoID";
                    MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                    con.Open();
                    Invoke(new Action(() =>
                    {
                        dtArticulos.Clear();
                        da.Fill(dtArticulos);
                        tablaSuministros.DataSource = dtArticulos;
                        resizearTablaSuministros();
                    }));
                }
                estaCargandoDatos = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Cargando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
                estaCargandoDatos = false;
            }
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                callCargaDatos();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            
        }
        private void filtrarSuministros()
        {
            if (tablaSuministros.DataSource == null) return;
            DataRowView row = (DataRowView)comboTipo.SelectedItem;
            string filtroTipo = (string)row.Row.ItemArray[1];
            string filtroTxt = txtFiltro.Text;
            string genero = "";
            string filtroTalla = (string)(comboTalla.SelectedItem ?? comboTalla.Text);
            String buscar = txtFiltro.Text;
            bool cualquierGenero = false;
            bool cualquierTalla = false;

            if (filtroTalla == "Todas") cualquierTalla = true;

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
                try
                {
                    dtArticulos.DefaultView.RowFilter = $"descripcion LIKE '%{buscar}%' And (talla LIKE '%{filtroTalla}%' or {cualquierTalla})  And (genero = '{genero}' or {cualquierGenero})";
                }catch(Exception e){
                    Console.WriteLine(e.StackTrace);
                    MessageBox.Show(e.Message, "Error Filtrando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try {
                    dtArticulos.DefaultView.RowFilter = $"descripcion LIKE '%{buscar}%' and tipo = '{filtroTipo}' And (talla LIKE '%{filtroTalla}%' or {cualquierTalla})  And (genero = '{genero}' or {cualquierGenero})";
                } catch(Exception e) {
                    Console.WriteLine(e.StackTrace);
                    MessageBox.Show(e.Message, "Error Filtrando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        //private void filtrarSuministros()
        //{
        //    if (tablaSuministros.DataSource == null) return;
        //    DataRowView row = (DataRowView)comboTipo.SelectedItem;
        //    string filtroTipo = (string)row.Row.ItemArray[1];
        //    string filtroTxt = txtFiltro.Text;
        //    string genero = "";
        //    string filtroTalla = (string)(comboTalla.SelectedItem ?? comboTalla.Text);
        //    String buscar = txtFiltro.Text;
        //    bool cualquierGenero = false;

        //    if (radioMasculino.Checked)
        //    {
        //        genero = "M";
        //    }
        //    else if (radioFemenino.Checked)
        //    {
        //        genero = "F";
        //    }
        //    else if (radioCualquiera.Checked)
        //    {
        //        cualquierGenero = true;
        //    }
            
        //    if(filtroTipo == "Todos")
        //    {
        //        try
        //        {
        //            dtArticulos.DefaultView.RowFilter = $"descripcion LIKE '%{buscar}%'";
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.StackTrace);
        //            MessageBox.Show(e.Message, "Error Filtrando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else if (filtroTipo == "Vestimenta" || filtroTipo == "Zapatos")
        //    {
        //        panelControlRopa.Visible = true;
        //        bool cualquierTalla = false;
                
        //        filtroTalla = (string)(comboTalla.SelectedItem ?? comboTalla.Text);
           
        //        if (filtroTalla == "Todas") cualquierTalla = true;
        //        try
        //        {
        //            dtArticulos.DefaultView.RowFilter = $"descripcion LIKE '%{buscar}%' and tipo = '{filtroTipo}' And (talla LIKE '%{filtroTalla}%' or {cualquierTalla})  And (genero = '{genero}' or {cualquierGenero})";
        //        }
        //        catch(Exception e)
        //        {
        //            Console.WriteLine(e.StackTrace);
        //            MessageBox.Show(e.Message, "Error Filtrando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else 
        //    {
        //        dtArticulos.DefaultView.RowFilter = $"descripcion LIKE '%{buscar}%' and tipo = '{filtroTipo}'";  
        //    }
        //}
        private void filtrarPersonas()
        {
            if (tablaPersonas.DataSource == null) return;
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
                dtPersonas.DefaultView.RowFilter = "[No.Empleado/Estudiante] LIKE '%" + filtrar + "%'";
            }
        }

        private void ConexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogConectarServidor form = new dialogConectarServidor();
            form.ShowDialog();
        }

        private void DespacharSuministrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogEntregarProductos form = new dialogEntregarProductos();
            form.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarSuministros();
            DataRowView row = (DataRowView)comboTipo.SelectedItem;
            string filtroTipo = (string)row.Row.ItemArray[1];
            if (filtroTipo == "Vestimenta" || filtroTipo == "Zapatos")
            { panelControlRopa.Visible = true; labelTalla.Visible = true; comboTalla.Visible = true; }
            else { panelControlRopa.Visible = false; }
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
            dialogIngresarProductos form = new dialogIngresarProductos();
            form.ShowDialog();
        }

        private void ingresarPersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantPersonas personas = new MantPersonas();
            personas.ShowDialog();
            callCargaDatos();
        }

        private void administrarSuministrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantProductos productos = new MantProductos();
            productos.ShowDialog();
            callCargaDatos();
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

        private void comboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarPersonas();
        }

        private void txtFiltro1_TextChanged(object sender, EventArgs e)
        {
            filtrarPersonas();
        }

        private void CerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea cerrar sesión?","Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                this.Hide();
                loginRef.Show();
                UsuarioActual.ID = null;
            }
                
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
        }

        private void ComboTalla_TextChanged(object sender, EventArgs e)
        {
            filtrarSuministros();
        }

        private void RefrescarListadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            callCargaDatos();
            filtrarPersonas();
            filtrarSuministros();
        }

        private void VersiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(INFORMACION.VERSION, "Acerca de: AlbergueHN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool quiereSalir = false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (!quiereSalir)
            {
                if(MessageBox.Show("¿Desea salir del programa?", "Confirmar accion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    quiereSalir = false;
                }
                else
                {
                    quiereSalir = true;
                }
            }
            else
            {
                e.Cancel = false;
                quiereSalir = true;
            }
        }
    }

    public static class INFORMACION
    {
        public const string VERSION = "1.0.0";
        public static readonly string[] DEVELOPERS = {
            "MARIO FERNANDO MEJÍA INESTROZA",
            "JORGE ALEJANDRO ARITA MARTHEL ",
            "BRÉNEDIN GOMEZ",
            "MARIA FERNANDA BARAHONA DUARTE",
            "CARLOS ADONAY MENJIVAR ALEMAN",
            "RAUL EDGARDO CRUZ MENDOZA"
        };
    }
}
