using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlbergueHN.Source.Objetos;
using MySql.Data.MySqlClient;

namespace AlbergueHN.Source.Forms
{
    public partial class dialogIngresarVestimenta : Form
    {
        string[] tallasRopa = { "Todas", "XXS", "XS", "S", "M", "L", "XL", "XL", "XXL" };
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        BindingList<Suministro> binding;
        List<Suministro> suministrosIngresados = new List<Suministro>();
        List<ListViewItem> productos = new List<ListViewItem>();

        public dialogIngresarVestimenta()
        {
            InitializeComponent();
            Bitmap icono = AlbergueHN.Properties.Resources.icono;
            this.Icon = Icon.FromHandle(icono.GetHicon());
        }

        private void dialogIngresarVestimenta_Load(object sender, EventArgs e)
        {
            llenarDatos();
            binding = new BindingList<Suministro>(suministrosIngresados);
            tablaIngreso.DataSource = binding;
            //hacer solo la columna de cantidad editable
            tablaIngreso.Columns[0].ReadOnly = true;
            tablaIngreso.Columns[1].ReadOnly = true;
            tablaIngreso.Columns[3].ReadOnly = true;
            tablaIngreso.Columns[4].ReadOnly = true;
            tablaIngreso.Columns[5].ReadOnly = true;

            tablaIngreso.Columns[0].FillWeight = 8;
            tablaIngreso.Columns[1].FillWeight = 40;
            tablaIngreso.Columns[2].FillWeight = 15;
            tablaIngreso.Columns[3].FillWeight = 30;
            tablaIngreso.Columns[4].FillWeight = 9;
            tablaIngreso.Columns[5].FillWeight = 9;
            foreach (string item in tallasRopa)
            {
                comboTalla.Items.Add(item);
            }
            comboTalla.SelectedIndex = 0;
        }

        private void listaProductos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            agregarSuministroTabla();
        }

        private void llenarDatos()
        {
            try
            {
                productos.Clear();
                listaProductos.Items.Clear();
                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    DataTable dtSuministro = new DataTable();
                    var stm = "SELECT SuministroID, a.Descripcion, Existencia, b.Descripcion as Tipo, Talla, Genero FROM suministro a inner join tiposuministro b on a.tipoID = b.tipoID WHERE a.TipoID=1 OR a.TipoID=4;";
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
                    var stm = "SELECT TipoID, Descripcion FROM tiposuministro";
                    DataSet dsTipo = new DataSet();
                    dsTipo.Tables.Add(new DataTable("TipoDefault"));
                    dsTipo.Tables["TipoDefault"].Columns.Add("TipoID", typeof(int));
                    dsTipo.Tables["TipoDefault"].Columns.Add("Descripcion", typeof(string));
                    dsTipo.Tables["TipoDefault"].Rows.Add(0, "Todos");
                    MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                    con.Open();
                    da.Fill(dsTipo, "Tipos");
                   /*comboTipo.DisplayMember = "Descripcion";
                    comboTipo.ValueMember = "TipoID";
                    dsTipo.Tables["TipoDefault"].Merge(dsTipo.Tables["Tipos"]);
                    comboTipo.DataSource = dsTipo.Tables["TipoDefault"];*/
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Cargando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filtrar()
        {
            //DataRowView row = (DataRowView)comboTipo.SelectedItem;
            //string filtroTipo = (string)row.Row.ItemArray[1];
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

            
                foreach (ListViewItem item in productos.Where(item => item.Text.ToLower().Contains(filtroTxt.ToLower()) && (item.SubItems[4].Text.Contains(genero) || cualquierGenero) && (item.SubItems[3].Text.ToLower().Equals(filtroTalla.ToLower()) || cualquierTalla)))
                {
                    listaProductos.Items.Add(item);
                }
            
            


        }

        private void TablaIngreso_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == tablaIngreso.Columns["Cantidad"].Index)
            {
                tablaIngreso.Rows[e.RowIndex].ErrorText = "";
                int newInteger;

                if (tablaIngreso.Rows[e.RowIndex].IsNewRow) { return; }
                if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger <= 0)
                {
                    SystemSounds.Beep.Play();
                    e.Cancel = true;
                    tablaIngreso.Rows[e.RowIndex].ErrorText = "El valor debe ser un entero positivo distinto de 0.";
                }
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (tablaIngreso.RowCount == 0)
            {
                MessageBox.Show("Aún no ha agregado ningún suministro a la lista, seleccione un suministro y agréguelo haciendo doble clic sobre él", "Notificación - UNAH - VS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ingresarSuministros();
            }
        }

        private void ComboTalla_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            binding.Clear();
        }

        private void agregarSuministroTabla()
        {
            if (listaProductos.SelectedItems.Count == 0)
            {
                MessageBox.Show("No se ha seleccionado un producto.",
                                   "Advertencia", MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                return;
            }

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

            if (binding.ToList().Where(suministro => suministro.Id == objetoSeleccionado.Tag.ToString()).Count() != 0) return;
            Suministro tmp = new Suministro();
            tmp.Id = objetoSeleccionado.Tag.ToString();
            tmp.Descripcion = objetoSeleccionado.Text;
            tmp.Tipo = objetoSeleccionado.SubItems[2].Text;
            tmp.Talla = objetoSeleccionado.SubItems[3].Text;
            tmp.Genero = objetoSeleccionado.SubItems[4].Text;

            binding.Add(tmp);
        }

        private void ingresarSuministros()
        {
            string donante = txtDonante.Text.Trim().Length == 0 ? "Anonimo" : txtDonante.Text.Trim();

            //ejecutar el stored procedure
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

                    var stm = "CALL spIngresarSuministro(@donante, @uid);";
                    MySqlCommand cmd = new MySqlCommand(stm, con);
                    cmd.Parameters.AddWithValue("@donante", donante);
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                llenarDatos();
                filtrar();
                return true;
            }
            else if (keyData == (Keys.Enter) && !tablaIngreso.Focused && !tablaIngreso.IsCurrentCellInEditMode)
            {
                agregarSuministroTabla();
            }
            else if (keyData == (Keys.Enter | Keys.Control))
            {
                ingresarSuministros();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            dialogCrearProducto p = new dialogCrearProducto();
            p.ShowDialog();
            llenarDatos();
        }

        private void nuevo_Click_1(object sender, EventArgs e)
        {
            dialogCrearProducto p = new dialogCrearProducto();
            p.ShowDialog();
            llenarDatos();
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            if (tablaIngreso.RowCount == 0)
            {
                MessageBox.Show("Aún no ha agregado ningún suministro a la lista, seleccione un suministro y agréguelo haciendo doble clic sobre él", "Notificación - UNAH - VS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ingresarSuministros();
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            binding.Clear();
        }

        private void radioCualquiera_CheckedChanged_1(object sender, EventArgs e)
        {
            filtrar();
        }

        private void radioMasculino_CheckedChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void radioFemenino_CheckedChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void comboTalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void ComboTalla_TextChanged_1(object sender, EventArgs e)
        {
            filtrar();
        }

        private void nuevo_Click_2(object sender, EventArgs e)
        {
            dialogCrearProducto p = new dialogCrearProducto();
            p.ShowDialog();
            llenarDatos();
        }

        private void listaProductos_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(SystemBrushes.ControlLightLight, e.Bounds);
            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                e.DrawBackground();

                using (Font headerFont =
                            new Font("Microsoft Sans Serif", 11))
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
    }
}
