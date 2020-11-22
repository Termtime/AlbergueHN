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
            Bitmap icono = AlbergueHN.Properties.Resources.icono;
            this.Icon = Icon.FromHandle(icono.GetHicon());
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
                    var stm = "SELECT SuministroID, a.Descripcion, Existencia, b.Descripcion as Tipo, Talla, Genero FROM suministro a inner join tiposuministro b on a.tipoID = b.tipoID WHERE a.TipoID<>1 AND a.TipoID<>4;";
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
                    dsTipo.Tables["TipoDefault"].DefaultView.RowFilter = "Descripcion <> 'Vestimenta' and Descripcion <> 'Zapatos' ";
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
            if (row == null) return;
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

        private void comboPersonas_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(99, 150, 187)), e.Bounds);
                e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                         e.Font,
                                         new SolidBrush(SystemColors.HighlightText),
                                         new Point(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Menu), e.Bounds);
                e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                              e.Font,
                                              new SolidBrush(Color.Black),
                                              new Point(e.Bounds.X, e.Bounds.Y));
            }
        }

        private void comboTipo_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(99, 150, 187)), e.Bounds);
                e.Graphics.DrawString(((DataRowView)combo.Items[e.Index]).Row.ItemArray[1].ToString(),
                                         e.Font,
                                         new SolidBrush(SystemColors.HighlightText),
                                         new Point(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Menu), e.Bounds);
                e.Graphics.DrawString(((DataRowView)combo.Items[e.Index]).Row.ItemArray[1].ToString(),
                                              e.Font,
                                              new SolidBrush(Color.Black),
                                              new Point(e.Bounds.X, e.Bounds.Y));
            }
        }

        private void comboTalla_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(99, 150, 187)), e.Bounds);
                e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                         e.Font,
                                         new SolidBrush(SystemColors.HighlightText),
                                         new Point(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Menu), e.Bounds);
                e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                              e.Font,
                                              new SolidBrush(Color.Black),
                                              new Point(e.Bounds.X, e.Bounds.Y));
            }
        }

        private void listaProductos_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var list = sender as ListView;

            if (list.View == View.Details) return;
            TextFormatFlags flags = GetTextAlignment(list, 0);
            Color itemColor = e.Item.ForeColor;
            if (e.Item.Selected)
            {
                using (SolidBrush bkgrBrush = new SolidBrush(Color.FromArgb(99, 150, 187)))
                {
                    e.Graphics.FillRectangle(bkgrBrush, e.Bounds);
                }
                itemColor = SystemColors.HighlightText;
            }
            else
            {
                //e.DrawBackground();
                using (SolidBrush bkgrBrush = new SolidBrush(Color.FromArgb(219, 231, 239)))
                {
                    e.Graphics.FillRectangle(bkgrBrush, e.Bounds);
                }
                itemColor = SystemColors.WindowText;
            }
            TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, e.Bounds, itemColor, flags);

            if (list.View == View.Tile && e.Item.SubItems.Count > 1)
            {
                var subItem = e.Item.SubItems[1];
                flags = GetTextAlignment(list, 1);
                TextRenderer.DrawText(e.Graphics, subItem.Text, subItem.Font, e.Bounds, SystemColors.GrayText, flags);
            }
        }

        private void listaProductos_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(SystemBrushes.ControlLightLight, e.Bounds);
            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                e.DrawBackground();

                using (Font headerFont =
                            new Font("Microsoft Sans Serif", 10))
                {
                    using (SolidBrush bkgrBrush = new SolidBrush(Color.FromArgb(138, 176, 204))) //CAMBIAR COLOR AQUI
                    {
                        e.Graphics.FillRectangle(bkgrBrush, e.Bounds);
                    }
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        SystemBrushes.WindowText, e.Bounds, sf);
                }
            }
        }

        private void listaProductos_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var list = sender as ListView;

            TextFormatFlags flags = GetTextAlignment(list, e.ColumnIndex);
            Color itemColor = e.Item.ForeColor;
            if (e.Item.Selected)
            {
                if (e.ColumnIndex == 0 || list.FullRowSelect)
                {
                    using (SolidBrush bkgrBrush = new SolidBrush(Color.FromArgb(99, 150, 187)))
                    {
                        e.Graphics.FillRectangle(bkgrBrush, e.Bounds);
                    }
                    itemColor = SystemColors.HighlightText;
                }
            }
            else
            {
                //e.DrawBackground();
                using (SolidBrush bkgrBrush = new SolidBrush(Color.FromArgb(219, 231, 239)))
                {
                    e.Graphics.FillRectangle(bkgrBrush, e.Bounds);
                }
                itemColor = SystemColors.WindowText;
            }
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, itemColor, flags);
        }

        private TextFormatFlags GetTextAlignment(ListView lstView, int colIndex)
        {
            TextFormatFlags flags = (lstView.View == View.Tile)
                ? (colIndex == 0) ? TextFormatFlags.Default : TextFormatFlags.Bottom
                : TextFormatFlags.VerticalCenter;

            flags |= TextFormatFlags.LeftAndRightPadding | TextFormatFlags.NoPrefix;
            switch (lstView.Columns[colIndex].TextAlign)
            {
                case HorizontalAlignment.Left:
                    flags |= TextFormatFlags.Left;
                    break;
                case HorizontalAlignment.Right:
                    flags |= TextFormatFlags.Right;
                    break;
                case HorizontalAlignment.Center:
                    flags |= TextFormatFlags.HorizontalCenter;
                    break;
            }
            return flags;
        }
    }
    }
