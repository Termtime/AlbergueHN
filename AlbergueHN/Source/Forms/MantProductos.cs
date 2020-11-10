using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AlbergueHN.Source.Forms
{
    public partial class MantProductos : Form
    {
        public MantProductos()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        string StringConexion = (string)Properties.Settings.Default["stringConexion"];
        string talla = "";
        string genero = "";
        private void btnCrearProducto_Click(object sender, EventArgs e)
        {
            dialogProducto p = new dialogProducto();
            p.ShowDialog();
            if (!p.IsDisposed)
            {
                String sql = "CALL spIngresarProducto(@1, @2, @3, @4, @5)";             
                try
                {
                    if (p.tipoArticulo.Text ==  "Vestimenta"  || p.tipoArticulo.Text == "Zapatos")
                    {
                        genero = p.comboGen.SelectedItem.ToString();
                        talla = p.txtTalla.Text.Trim();
                    }
                    using (MySqlConnection con = new MySqlConnection(StringConexion))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@1", p.numericCantidad.Value.ToString());
                            cmd.Parameters.AddWithValue("@2", p.tipoArticulo.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@3", p.txtArticulo.Text.Trim());                            
                            cmd.Parameters.AddWithValue("@4", talla);
                            cmd.Parameters.AddWithValue("@5", genero);

                            cmd.Connection.Open();  //abrir conexion
                            cmd.ExecuteNonQuery();  //ejecutar comando
                        }
                    }

                }
                catch (Exception ex)
                {
                    //ocurrio un error
                    MessageBox.Show(ex.Message);
                }
                cargarProductos();
            }
        }

        private void MantProductos_Load(object sender, EventArgs e)
        {
            cargarProductos();
            MantProductos_SizeChanged(sender, e);
        }

        public void cargarProductos()
        {
            dt.Clear();
            var stm = "select SuministroID, s.Descripcion, t.Descripcion as Tipo, Talla, Genero, Existencia from suministro s inner join tiposuministro t on s.tipoid = t.tipoid";
            using (MySqlConnection con = new MySqlConnection(StringConexion))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(stm, con);
                con.Open();
                da.Fill(dt);
                tablaProductos.DataSource = dt;
            }
        }

        private void MantProductos_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                tablaProductos.Columns[0].Width = tablaProductos.Width * 16 / 100;
                tablaProductos.Columns[1].Width = tablaProductos.Width * 20 / 100;
                tablaProductos.Columns[2].Width = tablaProductos.Width * 16 / 100;
                tablaProductos.Columns[3].Width = tablaProductos.Width * 16 / 100;
                tablaProductos.Columns[4].Width = tablaProductos.Width * 16 / 100;
                tablaProductos.Columns[5].Width = tablaProductos.Width * 16 / 100;

            }
            catch (Exception ex)
            {

            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                cargarProductos();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            dialogProducto p = new dialogProducto();
            p.tipoArticulo.SelectedItem = tablaProductos.CurrentRow.Cells["Tipo"].Value.ToString();
            p.txtArticulo.Text = tablaProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
            p.numericCantidad.Value = Int32.Parse(tablaProductos.CurrentRow.Cells["Existencia"].Value.ToString());
            p.txtTalla.Text = tablaProductos.CurrentRow.Cells["Talla"].Value.ToString();
            p.comboGen.SelectedItem = tablaProductos.CurrentRow.Cells["Genero"].Value.ToString();
            int id = Int32.Parse(tablaProductos.CurrentRow.Cells["SuministroID"].Value.ToString());
            p.ShowDialog();
            if (!p.IsDisposed) //Incompleto
            {
                String sql = "CALL spUpdateProducto(@1, @2, @3, @4, @5, @6)";
                try
                {
                    if (p.tipoArticulo.Text == "Vestimenta" || p.tipoArticulo.Text == "Zapatos")
                    {
                        genero = p.comboGen.SelectedItem.ToString();
                        talla = p.txtTalla.Text.Trim();
                    }
                    using (MySqlConnection con = new MySqlConnection(StringConexion))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@1", id);
                            cmd.Parameters.AddWithValue("@2", p.numericCantidad.Value.ToString());
                            cmd.Parameters.AddWithValue("@3", p.tipoArticulo.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@4", p.txtArticulo.Text.Trim());
                            cmd.Parameters.AddWithValue("@5", p.txtTalla.Text.Trim());
                            cmd.Parameters.AddWithValue("@6", p.comboGen.SelectedItem.ToString());

                            cmd.Connection.Open();  //abrir conexion
                            cmd.ExecuteNonQuery();  //ejecutar comando
                        }
                    }

                }
                catch (Exception ex)
                {
                    //ocurrio un error
                    MessageBox.Show(ex.Message);
                }
                cargarProductos();
            }
        }
    }
}
