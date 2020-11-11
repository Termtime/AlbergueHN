using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AlbergueHN.Source.Forms
{
    public partial class MantProductos : Form
    {
        bool estaCargando = false;
        public MantProductos()
        {
            InitializeComponent();
        }

        public void callCargaProductos() {

            if (estaCargando) return;

            Thread t = new Thread(new ThreadStart(cargaProductos));
            t.Name = "CargaProductos";
            t.IsBackground = true;
            t.Start();
        }
        DataTable dt = new DataTable();
        string StringConexion = (string)Properties.Settings.Default["stringConexion"];
        string talla = "";
        string genero = "";
        private void btnCrearProducto_Click(object sender, EventArgs e)
        {
            dialogCrearProducto p = new dialogCrearProducto();
            p.ShowDialog();

            callCargaProductos();
        }

        private void MantProductos_Load(object sender, EventArgs e)
        {
            callCargaProductos();
            MantProductos_SizeChanged(sender, e);
        }

        public void cargaProductos()
        {
            estaCargando = true;
            var stm = "select * from vistaMantProductos";
            using (MySqlConnection con = new MySqlConnection(StringConexion))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                con.Open();
                Invoke(new Action(() =>
                {
                    dt.Clear();
                    da.Fill(dt);
                    tablaProductos.DataSource = dt;
                    tablaProductos.Columns["usaTalla"].Visible = false;
                    tablaProductos.Columns["usaGenero"].Visible = false;
                    resizearTabla();

                }));
            }
            estaCargando = false;
        }

        private void resizearTabla()
        {
            try
            {
                tablaProductos.Columns[0].Width = tablaProductos.Width * 16 / 100;
                tablaProductos.Columns[1].Width = tablaProductos.Width * 20 / 100;
                tablaProductos.Columns[2].Width = tablaProductos.Width * 16 / 100;
                tablaProductos.Columns[3].Width = tablaProductos.Width * 13 / 100;
                tablaProductos.Columns[4].Width = tablaProductos.Width * 13 / 100;
                tablaProductos.Columns[5].Width = tablaProductos.Width * 13 / 100;
                tablaProductos.Columns[6].Width = tablaProductos.Width * 9 / 100;
            }
            catch (Exception ex)
            {

            }
        }
        private void MantProductos_SizeChanged(object sender, EventArgs e)
        {
            resizearTabla();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                callCargaProductos();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            dialogModificarProducto p = new dialogModificarProducto();
            p.tipoItem = tablaProductos.CurrentRow.Cells["Tipo"].Value.ToString();
            p.txtArticulo.Text = tablaProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
            p.talla = tablaProductos.CurrentRow.Cells["Talla"].Value.ToString().Trim() == "" ? null : tablaProductos.CurrentRow.Cells["Talla"].Value.ToString().Trim();
            p.genero = tablaProductos.CurrentRow.Cells["Genero"].Value.ToString().Trim() == "" ? null : tablaProductos.CurrentRow.Cells["Genero"].Value.ToString().Trim();
            
            if(tablaProductos.CurrentRow.Cells["usaTalla"].Value.ToString() == "Si")
            {
                p.checkUsaTalla.Checked = true;
            }
            if(tablaProductos.CurrentRow.Cells["usaGenero"].Value.ToString() == "Si")
            {
                p.checkUsaGenero.Checked = true;
            }

            int id = Int32.Parse(tablaProductos.CurrentRow.Cells["SuministroID"].Value.ToString());
            p.id = id;
            p.ShowDialog();

            callCargaProductos();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (tablaProductos.RowCount == 0)
                return;
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea deshabilitar este registro?", "Desahbilitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //se ha contestado que Si, entonces eliminamos
            if (opcion == DialogResult.Yes)
            {
                String sql = "call spDeshabilitarProducto(@1)";
                try
                {
                    using (MySqlConnection con = new MySqlConnection(StringConexion))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@1", tablaProductos.CurrentRow.Cells["SuministroID"].Value);
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            //refrescar el grid, si llego hasta aqui
                            callCargaProductos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No fue posible eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.StackTrace);
                }
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (tablaProductos.RowCount == 0 || tablaProductos.CurrentRow == null)
                return;
            try
            {
                String sql = "call spHabilitarProducto(@1)";
                using (MySqlConnection con = new MySqlConnection(StringConexion))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@1", tablaProductos.CurrentRow.Cells["SuministroID"].Value);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        //refrescar el grid, si llego hasta aqui
                        callCargaProductos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No fue posible reactivar el producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void TablaProductos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(tablaProductos.SelectedRows[0] != null)
                {
                    btnModificarProducto.Enabled = true;
                    if (tablaProductos.SelectedRows[0].Cells["¿Está Activo?"].Value.ToString() == "Si")
                    {
                        btnHabilitarProducto.Enabled = false;
                        btnEliminarProducto.Enabled = true;
                    }
                    else
                    {
                        btnHabilitarProducto.Enabled = true;
                        btnEliminarProducto.Enabled = false;
                    }
                }
                else
                {
                    btnModificarProducto.Enabled = false;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
