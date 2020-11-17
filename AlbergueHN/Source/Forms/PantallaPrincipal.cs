using AlbergueHN.Source.Forms;
using AlbergueHN.Source.Objetos;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
            this.ResizeBegin += (s, e) => { this.SuspendLayout(); };
            this.ResizeEnd += (s, e) => { this.ResumeLayout(true); };

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
                        configurarSizeTablaPersonas();
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
                        configurarSizeTablaSuministros();
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
        
        private void configurarSizeTablaPersonas()
        {
            Invoke(new Action(() =>
            {
                tablaPersonas.Columns[0].FillWeight = 10;
                tablaPersonas.Columns[1].FillWeight = 15;
                tablaPersonas.Columns[2].FillWeight = 25;
                tablaPersonas.Columns[3].FillWeight = 25;
                tablaPersonas.Columns[4].FillWeight = 7;
                tablaPersonas.Columns[5].FillWeight = 8;
                tablaPersonas.Columns[6].FillWeight = 10;
            }));
        }

        private void configurarSizeTablaSuministros()
        {
            Invoke(new Action(() =>
            {
                tablaSuministros.Columns[0].FillWeight = 10;
                tablaSuministros.Columns[1].FillWeight = 30;
                tablaSuministros.Columns[2].FillWeight = 20;
                tablaSuministros.Columns[3].FillWeight = 15;
                tablaSuministros.Columns[4].FillWeight = 15;
                tablaSuministros.Columns[5].FillWeight = 10;
            }));
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
                    dtArticulos.DefaultView.RowFilter = $"descripcion LIKE '%{buscar}%' And (talla = '{filtroTalla}' or {cualquierTalla})  And (genero = '{genero}' or {cualquierGenero})";
                }catch(Exception e){
                    Console.WriteLine(e.StackTrace);
                    MessageBox.Show(e.Message, "Error Filtrando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try {
                    dtArticulos.DefaultView.RowFilter = $"descripcion LIKE '%{buscar}%' and tipo = '{filtroTipo}' And (talla = '%{filtroTalla}%' or {cualquierTalla})  And (genero = '{genero}' or {cualquierGenero})";
                } catch(Exception e) {
                    Console.WriteLine(e.StackTrace);
                    MessageBox.Show(e.Message, "Error Filtrando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void filtrarPersonas()
        {
            if (tablaPersonas.DataSource == null) return;
            String filtrar = txtFiltro1.Text;
            if (comboFiltro.SelectedIndex == 0)
            {
                dtPersonas.DefaultView.RowFilter = "nombres + apellidos LIKE '%"+filtrar+"%'";
            }
            if (comboFiltro.SelectedIndex == 1)
            {
                dtPersonas.DefaultView.RowFilter = "[No.Identidad] LIKE '%" + filtrar + "%'";
            }
            if (comboFiltro.SelectedIndex == 2)
            {
                dtPersonas.DefaultView.RowFilter = "[No.Empleado/Estudiante] LIKE '%" + filtrar + "%'";
            }
        }

        private void ConexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogConectarServidor form = new dialogConectarServidor();
            MessageBox.Show("Si se detecta un cambio, se le requerirá volver a iniciar sesión.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            form.ShowDialog();
            if (form.haCambiadoConfig)
            {
                MessageBox.Show("Ya que ha cambiado la configuración de conexión, se requiere volver a iniciar sesión.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cerrarSesion();
            }
        }

        private void DespacharSuministrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogEntregarProductos form = new dialogEntregarProductos();
            form.ShowDialog();
            callCargaDatos();
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
            callCargaDatos();
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
        }


        private void TabPage2_SizeChanged(object sender, EventArgs e)
        {
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
                cerrarSesion();
            }
        }

        private void cerrarSesion()
        {
            this.Hide();
            loginRef.Show();
            UsuarioActual.ID = null;
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

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void despacharVestimentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogEntregarProductoVestimenta ev = new dialogEntregarProductoVestimenta();
            ev.ShowDialog();
            callCargaDatos();
        }

        private void ingresarVestimentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogIngresarVestimenta iv = new dialogIngresarVestimenta();
            iv.ShowDialog();
            callCargaDatos();
        }

        private void PersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantPersonas personas = new MantPersonas();
            personas.ShowDialog();
            callCargaDatos();
        }

        private void ProductosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MantProductos productos = new MantProductos();
            productos.ShowDialog();
            callCargaDatos();
        }

        private void VestimentaCalzadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dialogIngresarVestimenta iv = new dialogIngresarVestimenta();
            iv.ShowDialog();
            callCargaDatos();
        }

        private void ProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dialogIngresarProductos form = new dialogIngresarProductos();
            form.ShowDialog();
            callCargaDatos();
        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogEntregarProductos form = new dialogEntregarProductos();
            form.ShowDialog();
            callCargaDatos();
        }

        private void VestimentaCalzadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogEntregarProductoVestimenta ev = new dialogEntregarProductoVestimenta();
            ev.ShowDialog();
            callCargaDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreHojaReporte = "Reporte personas";
            string tituloReporte = "Reporte de Personas";
            string celdaInicioTitulo = "C2";
            string celdaFinTitulo = "G2";
            int indexInicioTitulo = 3;
            int indexFinTitulo = 7;
            generarReporte(tablaPersonas, nombreHojaReporte, tituloReporte, celdaInicioTitulo, celdaFinTitulo, indexInicioTitulo, indexFinTitulo);
        }
        public void generarReporte(DataGridView tabla, string nombreHojaReporte, string tituloReporte, string celdaInicioTitulo, string celdaFinTitulo, int indexInicioTitulo, int indexFinTitulo)
        {
            ////Para futura referencia, esta es una forma probable de obtener un rango de celdas basado en indices
            ////Excel.Range range = hoja.Ranges(hoja.Cells[1, 1], hoja.Cells[1, 2]);
            string columnaOrdenamiento = "Filtro";
            
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                exportar.Enabled = false;
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = excel.Application.Workbooks.Add();
                Microsoft.Office.Interop.Excel.Worksheet hojaDatos = wb.ActiveSheet;

                int IndiceColumna = 0;
                foreach (DataGridViewColumn col in tabla.Columns) // Columnas
                {
                    IndiceColumna++;
                    hojaDatos.Cells[1, IndiceColumna] = col.Name;
                }

                //agregar campo de ordenamiento
                hojaDatos.Cells[1, IndiceColumna + 1] = columnaOrdenamiento;
                int IndiceFila = 0;
                foreach (DataGridViewRow row in tabla.Rows) // Filas
                {
                    IndiceFila++;
                    IndiceColumna = 0;
                    foreach (DataGridViewColumn col in tabla.Columns)
                    {
                        IndiceColumna++;
                        hojaDatos.Cells[IndiceFila + 1, IndiceColumna] = "'" + row.Cells[col.Name].Value;
                    }
                    hojaDatos.Cells[IndiceFila + 1, IndiceColumna + 1] = columnaOrdenamiento;
                }

                Excel.Worksheet hojaReporte = excel.Sheets.Add();
                hojaReporte.Name = nombreHojaReporte;
                hojaReporte.Activate();

                Excel.Range oRange = hojaDatos.UsedRange;

                Excel.PivotCache oPivotCache = wb.PivotCaches().Create(Excel.XlPivotTableSourceType.xlDatabase, oRange, Type.Missing);
                Excel.Range oRange2 = hojaReporte.Cells[5, 2];
                Excel.PivotCaches pch = wb.PivotCaches();
                pch.Add(Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlDatabase, oRange).CreatePivotTable(oRange2, "reportePersonas", Type.Missing, Type.Missing);
                Excel.PivotTable pvt = hojaReporte.PivotTables("reportePersonas") as Excel.PivotTable;

                //configuracion de la tabla dinamica
                pvt.RowGrand = false; //Ocultar los totales y subtotales de la tabla dinamica
                pvt.ColumnGrand = false; //Ocultar los totales y subtotales de la tabla dinamica

                pvt.EnableFieldList = false; //desactivar la opcion para apagar o encender campos en la tabla dinamica
                pvt.ShowDrillIndicators = false; //quitar los simbolos de + en cada celda
                pvt.EnableDrilldown = false; //no permitir minimizar las filas
                pvt.InGridDropZones = false; //no permitir drag&drop de las columnas
                pvt.ShowTableStyleRowHeaders = false; //no mostrar columna de por medio en negrita/otro color, segun el estilo de tabla
                pvt.TableStyle2 = "PivotStyleMedium9"; //settear estilo de tabla

                foreach (DataGridViewColumn col in tabla.Columns) // Columnas
                {
                    Excel.PivotField field = (Excel.PivotField)pvt.PivotFields(col.Name);
                    field.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
                    field.Subtotals[1] = false;
                }

                //agregar el PivotField para el campo de ordenamiento
                Excel.PivotField f = (Excel.PivotField)pvt.PivotFields(columnaOrdenamiento);
                f.Orientation = Excel.XlPivotFieldOrientation.xlDataField;
                f.Name = "No remover, ocultar solamente";

                //hacer que las columnas tengan el tamaño adecuado
                hojaReporte.UsedRange.Columns.AutoFit();

                //int startIndex = indexColumnaOrdenamiento.IndexOfAny("0123456789".ToCharArray());
                //string indicatedColumnLetter = indexColumnaOrdenamiento.Substring(0, startIndex);

                string column = obtenerNombreColExcel(tabla.Columns.Count + 2); // se agregan mas dos por la posicion inicial de la tabla y la columna de ordenamiento extra

                hojaReporte.Range[column+"1"].EntireColumn.Hidden = true; //ocultando la columna de sort

                //agregar el dato de encabezado
                hojaReporte.Cells[2, 3] = tituloReporte;
                Excel.Range titulo = hojaReporte.Range[celdaInicioTitulo, celdaFinTitulo] ;
                titulo.Merge();
                titulo.Font.Bold = true;
                titulo.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                titulo.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = Color.Black;
                hojaReporte.Cells[3, indexInicioTitulo] = "Fecha:";
                hojaReporte.Cells[3, indexInicioTitulo + 1] = DateTime.Today;
                hojaReporte.Cells[3, indexFinTitulo - 1] = "Hora:";
                hojaReporte.Cells[3, indexFinTitulo] = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();

                //eliminar la hoja de datos
                excel.DisplayAlerts = false; //bypass del bug que evita que se elimine la hoja
                hojaDatos.Activate();
                hojaDatos.Delete();
                hojaReporte.Activate();
                excel.DisplayAlerts = true; //retornar la propiedad al valor original
                MessageBox.Show("Infome generado exitosamente.", "Operación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                exportar.Enabled = true;
                excel.Visible = true;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Cursor.Current = Cursors.Default;
                exportar.Enabled = true;
                MessageBox.Show("Ha ocurrido un error en la creación del documento, póngase en contacto con los desarrolladores del sistema.", "Error - AlbergueHN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
        private string obtenerNombreColExcel(int numCol)
        {
            int dividendo = numCol;
            string columnName = String.Empty;
            int modulo;

            while (dividendo > 0)
            {
                modulo = (dividendo - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividendo = (int)((dividendo - modulo) / 26);
            }

            return columnName;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string nombreHojaReporte = "Reporte productos";
            string tituloReporte = "Reporte de Productos";
            string celdaInicioTitulo = "C2";
            string celdaFinTitulo = "F2";
            int indexInicioTitulo = 3;
            int indexFinTitulo = 6;
            generarReporte(tablaSuministros, nombreHojaReporte, tituloReporte, celdaInicioTitulo, celdaFinTitulo, indexInicioTitulo, indexFinTitulo);
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
