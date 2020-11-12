using AlbergueHN.Source.Objetos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbergueHN.Source.Forms
{

    public partial class dialogEntregarProductos : Form
    {
        string[] tallasRopa = { "Todas", "XXS", "XS", "S", "M", "L", "XL", "XL", "XXL" };
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        BindingList<Suministro> binding;
        BindingList<Persona> bindingComboPersonas;
        List<Suministro> suministrosIngresados = new List<Suministro>();
        List<ListViewItem> productos = new List<ListViewItem>();
        List<Persona> personas = new List<Persona>();
        bool estaCargando = false;
        public dialogEntregarProductos()
        {
            InitializeComponent();
        }

        private void DialogDespacharProductos_Load(object sender, EventArgs e)
        {
            usuarioID.Text = UsuarioActual.ID.ToString();
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

            tablaDespacho.Columns[0].FillWeight = 8;
            tablaDespacho.Columns[1].FillWeight = 40;
            tablaDespacho.Columns[2].FillWeight = 15;
            tablaDespacho.Columns[3].FillWeight = 30;
            tablaDespacho.Columns[4].FillWeight = 9;
            tablaDespacho.Columns[5].FillWeight = 9;

            foreach (string item in tallasRopa)
            {
                comboTalla.Items.Add(item);
            }
            comboTalla.SelectedIndex = 0;
           
        }

        

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
            DataRowView row = (DataRowView)comboTipo.SelectedItem;
            string filtroTipo = (string)row.Row.ItemArray[1];
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
            agregarSuministroTabla();
        }
        private void BtnDespachar_Click(object sender, EventArgs e)
        {
            

            if (tablaDespacho.Rows.Count == 0)
            {
                MessageBox.Show("No se han agregado suministros para despachar",
                                   "Advertencia", MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                despacharProductos();
                Cursor.Current = Cursors.Default;

            }

               
        }

        private void DialogDespacharArticulo_SizeChanged(object sender, EventArgs e)
        {
        }

        

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            binding.Clear();
        }
        private void llenarDatos()
        {
            if (estaCargando) return;
            try
            {
                estaCargando = true;
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
                estaCargando = false;
            }
            catch(Exception ex)
            {
                estaCargando = false;
                MessageBox.Show(ex.Message, "Error Cargando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
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
            bool cualquierTalla = false;
            string filtroTalla = ((string)comboTalla.SelectedItem) ?? comboTalla.Text;
            filtroTalla = filtroTalla.ToString();
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
                foreach (ListViewItem item in productos.Where(item => item.Text.ToLower().Contains(filtroTxt.ToLower()) && (item.SubItems[4].Text.Contains(genero) || cualquierGenero) && (item.SubItems[3].Text.ToLower().Equals(filtroTalla.ToLower()) || cualquierTalla)))
                {
                    listaProductos.Items.Add(item);
                }
            }
            else
            {
                foreach (ListViewItem item in productos.Where(item => item.SubItems[2].Text == filtroTipo && item.Text.ToLower().Contains(filtroTxt.ToLower()) && (item.SubItems[4].Text.Contains(genero) || cualquierGenero) && (item.SubItems[3].Text.ToLower().Equals(filtroTalla.ToLower()) || cualquierTalla)))
                {
                    listaProductos.Items.Add(item);
                }
                
            }                   
        }

        private void agregarSuministroTabla()
        {
            if (listaProductos.SelectedItems.Count == 0) return;
            ListViewItem objetoSeleccionado = listaProductos.SelectedItems[0];
            if (objetoSeleccionado == null)
            {
                return;
            }

            //Si el objeto ya existe en la tabla, salir
            if (binding.ToList().Where(suministro => suministro.Id == objetoSeleccionado.Tag.ToString()).Count() != 0)
            {
                MessageBox.Show("Este objeto ya fue agregado a la tabla",
                                   "Advertencia", MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                return;
             }
            Suministro tmp = new Suministro();
            tmp.Id = objetoSeleccionado.Tag.ToString();
            tmp.Descripcion = objetoSeleccionado.Text;
            tmp.Tipo = objetoSeleccionado.SubItems[2].Text;
            tmp.Talla = objetoSeleccionado.SubItems[3].Text;
            tmp.Genero = objetoSeleccionado.SubItems[4].Text;

            binding.Add(tmp);
        }
        private void despacharProductos()
        {
            if (comboPersonas.SelectedItem == null) {
                MessageBox.Show("No se ha seleccionado a nombre de quién despachar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                catch (MySqlException ex)
                {

                    if (ex.Message.Equals("Check constraint 'CH_UNAHAL_SUMINISTROEX' is violated."))
                        MessageBox.Show("Existencia insuficiente en el inventario.");
                    if (ex.Message.Equals("Check constraint 'chkCantidad' is violated."))
                        MessageBox.Show("La cantidad no puede ser negativa.");
                    con.Close();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                llenarDatos();
                filtrar();
                return true;
            }else if (keyData == (Keys.Enter) && !tablaDespacho.Focused && !tablaDespacho.IsCurrentCellInEditMode)
            {
                agregarSuministroTabla();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ComboTalla_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void listaProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tablaDespacho_CellValidating_1(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == tablaDespacho.Columns["Cantidad"].Index)
            {
                tablaDespacho.Rows[e.RowIndex].ErrorText = "";
                int newInteger;

                if (tablaDespacho.Rows[e.RowIndex].IsNewRow) { return; }
                if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger <= 0)
                {
                    SystemSounds.Beep.Play();
                    e.Cancel = true;
                    tablaDespacho.Rows[e.RowIndex].ErrorText = "El valor debe ser un entero positivo distinto de 0.";
                }
            }
        }

        private void listaProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
