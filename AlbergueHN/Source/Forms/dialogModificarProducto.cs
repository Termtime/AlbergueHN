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
    public partial class dialogModificarProducto : Form
    {
        string stringConexion = (string)Properties.Settings.Default["stringConexion"];
        public string talla = null;
        public string genero = null;
        public string tipoItem = null;
        string[] tallasRopa = { "XXS", "XS", "S", "M", "L", "XL", "XL", "XXL" };
        public int id;
        public dialogModificarProducto()
        {
            InitializeComponent();
            Bitmap icono = AlbergueHN.Properties.Resources.icono;
            this.Icon = Icon.FromHandle(icono.GetHicon());
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (txtArticulo.Text.Trim().Length == 0)
            {
                MessageBox.Show("No ha llenado el campo de Descripción de Articulo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArticulo.Focus();
                return;
            }

            String sql = "CALL spUpdateProducto(@1, @2, @3, @4, @5, @6, @7)";
            try
            {
                if (txtArticulo.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No ha llenado el campo de Descripción de Articulo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtArticulo.Focus();
                    return;
                }
                if(comboTalla.Text.Length == 0 && checkUsaTalla.Checked)
                {
                    MessageBox.Show("No se ha especificado la talla. Por favor escriba una o seleccione desde la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string descripcion = txtArticulo.Text.Trim();
                if (checkUsaTalla.Checked)
                {
                    talla = comboTalla.Text;
                }
                else { talla = null; }
                if (checkUsaGenero.Checked)
                {
                    genero = comboGen.Text;
                }
                else { genero = null; }

                if (radioAdulto.Checked)
                {
                    descripcion += " - Adulto";
                }
                else if(radioInfante.Checked)
                {
                    descripcion += " - Infante";
                }

                //Quitar todas las instancias de Adulto e Infante de la descripcion
                if (txtArticulo.Text.Trim().Contains(" - Infante"))
                {
                    bool aunContiene = true;
                    while (aunContiene)
                    {
                        txtArticulo.Text = txtArticulo.Text.Trim().Replace(" - Infante", "");
                        aunContiene = txtArticulo.Text.Trim().Contains(" - Infante");
                    }
                }
                if (txtArticulo.Text.Trim().Contains(" - Adulto"))
                {
                    bool aunContiene = true;
                    while (aunContiene)
                    {
                        txtArticulo.Text = txtArticulo.Text.Trim().Replace(" - Adulto", "");
                        aunContiene = txtArticulo.Text.Trim().Contains(" - Adulto");
                    }
                }

                
                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@1", id);
                        cmd.Parameters.AddWithValue("@2", comboTipo.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@3", descripcion);
                        cmd.Parameters.AddWithValue("@4", talla);
                        cmd.Parameters.AddWithValue("@5", genero);
                        cmd.Parameters.AddWithValue("@6", checkUsaTalla.Checked);
                        cmd.Parameters.AddWithValue("@7", checkUsaGenero.Checked);
                        cmd.Connection.Open();  //abrir conexion
                        cmd.ExecuteNonQuery();  //ejecutar comando
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                //ocurrio un error
                MessageBox.Show(ex.Message, "Error actualizando informacion del producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DialogModificarProducto_Load(object sender, EventArgs e)
        {
            cargarTipos();
            comboTalla.Items.AddRange(tallasRopa);
            comboGen.Items.Add("M");
            comboGen.Items.Add("F");
            //si no se encuentra es una talla especifica numerica
            Console.WriteLine(comboTalla.FindString(talla));
            //quitar todas las instancias de "Infante" y de "Adulto"
            if(txtArticulo.Text.Trim().Contains(" - Infante"))
            {
                bool aunContiene = true;
                while (aunContiene)
                {
                    txtArticulo.Text = txtArticulo.Text.Trim().Replace(" - Infante", "");
                    aunContiene = txtArticulo.Text.Trim().Contains(" - Infante");
                }
                radioInfante.Checked = true;
            } if (txtArticulo.Text.Trim().Contains(" - Adulto"))
            {
                bool aunContiene = true;
                while (aunContiene)
                {
                    txtArticulo.Text = txtArticulo.Text.Trim().Replace(" - Adulto", "");
                    aunContiene = txtArticulo.Text.Trim().Contains(" - Adulto");
                }
                radioAdulto.Checked = true;
            }

            if (talla == null)
            {
                comboTalla.Text = "";
            }
            else
            {
                if (comboTalla.FindString(talla) == -1)
                {
                    comboTalla.Text = talla;
                }
                else
                {
                    comboTalla.SelectedIndex = comboTalla.FindString(talla);
                }
            }

            if(genero == null)
            {
                comboGen.Text = "";
            }
            else
            {
                comboGen.SelectedIndex = comboGen.FindString(genero);
            }

            
        }
        public void cargarTipos()
        {
            string sql = "select * from tiposuministro order by Descripcion ASC";
            try
            {
                using (MySqlConnection con = new MySqlConnection(stringConexion))
                {
                    con.Open();
                    using (MySqlCommand sqlcmd = new MySqlCommand(sql, con))
                    {
                        using (MySqlDataReader lector = sqlcmd.ExecuteReader())
                        {
                            DataTable dtTipos = new DataTable();
                            dtTipos.Columns.Add("Descripcion", typeof(string));
                            dtTipos.Load(lector);
                            comboTipo.ValueMember = "TipoID";
                            comboTipo.DisplayMember = "Descripcion";
                            comboTipo.DataSource = dtTipos;
                            comboTipo.SelectedIndex = comboTipo.FindString(tipoItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Cargando datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void CheckUsaTalla_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUsaTalla.Checked)
            {
                comboTalla.Enabled = true;
                if (comboTalla.FindString(talla) == -1)
                {
                    comboTalla.Text = talla;
                }
                else
                {
                    comboTalla.SelectedIndex = comboTalla.FindString(talla);
                }
            }
            else
            {
                comboTalla.Enabled = false;
                comboTalla.SelectedIndex = -1;
            }
        }

        private void CheckUsaGenero_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUsaGenero.Checked)
            {
                comboGen.Enabled = true;
                if (genero == null)
                {
                    comboGen.SelectedIndex = 0;
                }
                else
                {
                    comboGen.SelectedIndex = comboGen.FindString(genero);
                }
            }
            else
            {
                comboGen.Enabled = false;
                comboGen.SelectedIndex = -1;
            }
        }

        private void comboTipo_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = sender as ComboBox;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(99, 150, 187)), e.Bounds);
                e.Graphics.DrawString(((DataRowView)combo.Items[e.Index]).Row.ItemArray[0].ToString(),
                                         e.Font,
                                         new SolidBrush(SystemColors.HighlightText),
                                         new Point(e.Bounds.X, e.Bounds.Y));
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Menu), e.Bounds);
                e.Graphics.DrawString(((DataRowView)combo.Items[e.Index]).Row.ItemArray[0].ToString(),
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

        private void comboGen_DrawItem(object sender, DrawItemEventArgs e)
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
                if (e.Index != -1)
                {
                    e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                                  e.Font,
                                                  new SolidBrush(Color.Black),
                                                  new Point(e.Bounds.X, e.Bounds.Y));
                }
            }
        }
    }
}
