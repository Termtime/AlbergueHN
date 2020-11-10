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

    public partial class dialogDespacharSuministro : Form
    {
        string[] tallasRopa = { "Todas", "XXS", "XS", "S", "M", "L", "XL", "XL", "XXL" };
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        BindingList<Suministro> binding;
        BindingList<Persona> bindingComboPersonas;
        List<Suministro> suministrosIngresados = new List<Suministro>();
        List<ListViewItem> productos = new List<ListViewItem>();
        List<Persona> personas = new List<Persona>();
        public dialogDespacharSuministro()
        {
            InitializeComponent();
        }

        private void DialogDespacharProductos_Load(object sender, EventArgs e)
        {
            llenarDatos();
            binding = new BindingList<Suministro>(suministrosIngresados);
            bindingComboPersonas = new BindingList<Persona>(personas);
            tablaDespacho.DataSource = binding;
            comboPersonas.DataSource = bindingComboPersonas;

            tablaDespacho.Columns[0].ReadOnly = true;
            tablaDespacho.Columns[1].ReadOnly = true;
            tablaDespacho.Columns[3].ReadOnly = true;
            tablaDespacho.Columns[4].ReadOnly = true;
            tablaDespacho.Columns[5].ReadOnly = true;
            resizearTablaDespacho();
            foreach (string item in tallasRopa)
            {
                comboTalla.Items.Add(item);
            }
            comboTalla.SelectedIndex = 0;
        }

        private void llenarDatos()
        {
            productos.Clear();
            personas.Clear();
            listaProductos.Items.Clear();
            using (MySqlConnection con = new MySqlConnection(stringConexion))
            {
                DataTable dtSuministro = new DataTable();
                var stm = "SELECT SuministroID, a.Descripcion, Existencia, b.Descripcion as Tipo, Talla, Genero FROM suministro a inner join tiposuministro b on a.tipoID = b.tipoID;";
                MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                con.Open();
                da.Fill(dtSuministro);
                foreach (DataRow r in dtSuministro.Rows)
                {
                    string[] row = { (string)r["Descripcion"], ((int)r["Existencia"]).ToString(), (string)r["Tipo"], (r["Talla"] == System.DBNull.Value ? " " : (string)r["Talla"]), (r["Genero"] == System.DBNull.Value ? " " : (string)r["Genero"]), ((int)r["SuministroID"]).ToString() };
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

            using (MySqlConnection con = new MySqlConnection(stringConexion))
            {
                var stm = "SELECT PersonaID, Nombres, Apellidos FROM persona WHERE FechaSalida IS NULL ORDER BY nombres ASC";
                DataTable dtPersona = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                con.Open();
                da.Fill(dtPersona);

                foreach (DataRow fila in dtPersona.Rows)
                {
                    Persona tmp = new Persona(fila[0].ToString(), fila[1].ToString(), fila[2].ToString());
                    personas.Add(tmp);
                }
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
            }
            else if (radioCualquiera.Checked)
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
            }
            else if (filtroTipo == "Vestimenta" || filtroTipo == "Zapatos")
            {

                bool cualquierTalla = false;
                string filtroTalla = ((string)comboTalla.SelectedItem) ?? comboTalla.Text;
                filtroTalla = filtroTalla.ToString();
                if (filtroTalla == "Todas") cualquierTalla = true;
                foreach (ListViewItem item in productos.Where(item => item.SubItems[2].Text == filtroTipo && item.Text.ToLower().Contains(filtroTxt.ToLower()) && (item.SubItems[4].Text.Contains(genero) || cualquierGenero) && (item.SubItems[3].Text.ToLower().Contains(filtroTalla.ToLower()) || cualquierTalla)))
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
            if (filtroTipo == "Vestimenta" || filtroTipo == "Zapatos")
            { panelControlRopa.Visible = true; labelTalla.Visible = true; comboTalla.Visible = true; }
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


        private void ListaProductos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem objetoSeleccionado = listaProductos.SelectedItems[0];
            if (objetoSeleccionado == null)
            {
                return;
            }

            Console.WriteLine("Doble click");
            //Si el objeto ya existe en la tabla, salir
            if (binding.ToList().Where(suministro => suministro.Id == objetoSeleccionado.Tag.ToString()).Count() != 0) return;
            Suministro tmp = new Suministro();
            tmp.Id = objetoSeleccionado.Tag.ToString();
            tmp.Descripcion = objetoSeleccionado.Text;
            tmp.Tipo = objetoSeleccionado.SubItems[2].Text;
            tmp.Talla = objetoSeleccionado.SubItems[3].Text;
            tmp.Genero = objetoSeleccionado.SubItems[4].Text;

            binding.Add(tmp);
        }
        private void BtnDespachar_Click(object sender, EventArgs e)
        {
            string idPersonaRecibe = ((Persona)comboPersonas.SelectedItem).identidad;
            //ejecutar el procedimiento almacenado de despachar
                List<string> inserts = new List<string>();

            using (MySqlConnection con = new MySqlConnection(stringConexion))
            {
                try
                {
                    con.Open();
                    StringBuilder sqlTemp = new StringBuilder("DROP TEMPORARY TABLE IF EXISTS Datos;" +
                        "CREATE TEMPORARY TABLE Datos (artID int, cant int);" +
                                     "INSERT INTO Datos (artID, cant) VALUES");

                    foreach (Suministro item in binding.ToList())
                    {
                        int id = int.Parse(item.Id);
                        int cant = item.Cantidad;

                        inserts.Add(string.Format("({0},{1})", id, cant));
                        Console.WriteLine(string.Format("({0},{1})", id, cant));
                    }
                    sqlTemp.Append(string.Join(",", inserts));
                    sqlTemp.Append(";");

                    MySqlCommand cmdTmp = new MySqlCommand(sqlTemp.ToString(), con);
                    cmdTmp.ExecuteNonQuery();

                    var stm = "CALL spDespacharSuministros(@personaRecibe, @uid);";
                    MySqlCommand cmd = new MySqlCommand(stm, con);
                    cmd.Parameters.AddWithValue("@personaRecibe", idPersonaRecibe);
                    cmd.Parameters.AddWithValue("@uid", UsuarioActual.ID);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    llenarDatos();
                    binding.Clear();
                    MessageBox.Show("Ingresado con éxito.", "Operación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    filtrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
        }

        private void DialogDespacharArticulo_SizeChanged(object sender, EventArgs e)
        {
            resizearTablaDespacho();
        }

        private void resizearTablaDespacho()
        {
            try
            {
                tablaDespacho.Columns[0].Width = (tablaDespacho.Width - 40) * 10 / 100;
                tablaDespacho.Columns[1].Width = (tablaDespacho.Width - 40) * 40 / 100;
                tablaDespacho.Columns[2].Width = (tablaDespacho.Width - 40) * 10 / 100;
                tablaDespacho.Columns[3].Width = (tablaDespacho.Width - 40) * 20 / 100;
                tablaDespacho.Columns[4].Width = (tablaDespacho.Width - 40) * 10 / 100;
                tablaDespacho.Columns[5].Width = (tablaDespacho.Width - 40) * 10 / 100;
            }
            catch (Exception ex) { }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            binding.Clear();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                llenarDatos();
                filtrar();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ComboTalla_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }
    }
}
