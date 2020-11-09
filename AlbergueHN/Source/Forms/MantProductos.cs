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
        private void btnCrearProducto_Click(object sender, EventArgs e)
        {
            dialogProducto p = new dialogProducto();
            if (!p.IsDisposed) //Incompleto
            {
                String sql = "CALL ingresar_Producto(@1, @2, @3, @4, @5)";             
                try
                {
                    using (MySqlConnection con = new MySqlConnection(StringConexion))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@1", p.numericCantidad.Value.ToString());
                            cmd.Parameters.AddWithValue("@2", p.tipoArticulo.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@3", p.txtArticulo.Text.Trim());                            
                            cmd.Parameters.AddWithValue("@4", p.txtTalla.Text.Trim());
                            cmd.Parameters.AddWithValue("@5", p.comboGen.SelectedValue.ToString());

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
            var stm = "select * from suministro";
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
                tablaProductos.Columns[0].Width = tablaProductos.Width * 15 / 100;
                tablaProductos.Columns[1].Width = tablaProductos.Width * 35 / 100;
                tablaProductos.Columns[2].Width = tablaProductos.Width * 25 / 100;
                tablaProductos.Columns[3].Width = tablaProductos.Width * 25 / 100;

            }
            catch (Exception ex)
            {

            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            dialogProducto p = new dialogProducto();
            p.tipoArticulo.SelectedItem = tablaProductos.CurrentRow.Cells["Tipo"].Value.ToString();
            p.txtArticulo.Text = tablaProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
            p.numericCantidad.Value = Int32.Parse(tablaProductos.CurrentRow.Cells["Cantidad"].Value.ToString());
            p.txtTalla.Text = tablaProductos.CurrentRow.Cells["Talla"].Value.ToString();
            p.comboGen.SelectedItem = tablaProductos.CurrentRow.Cells["Genero"].Value.ToString();
            int id = Int32.Parse(tablaProductos.CurrentRow.Cells["SuministroID"].Value.ToString());

            if (!p.IsDisposed) //Incompleto
            {
                String sql = "CALL updateProducto(@1, @2, @3, @4, @5)";
                try
                {
                    using (MySqlConnection con = new MySqlConnection(StringConexion))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@1", id);
                            cmd.Parameters.AddWithValue("@2", p.numericCantidad.Value.ToString());
                            cmd.Parameters.AddWithValue("@3", p.tipoArticulo.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@4", p.txtArticulo.Text.Trim());
                            cmd.Parameters.AddWithValue("@5", p.txtTalla.Text.Trim());
                            cmd.Parameters.AddWithValue("@6", p.comboGen.SelectedValue.ToString());

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
            }
        }
    }
}
