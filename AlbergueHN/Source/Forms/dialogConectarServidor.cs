using MySqlConnector;
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
    public partial class dialogConectarServidor : Form
    {
        public dialogConectarServidor()
        {
            InitializeComponent();
        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
            String stringConexion = "Server=" + txtIP.Text + ";Database=unahvs-albergue-hn;Uid=Albergue;Pwd=" + txtPass.Text;

            MySqlConnection con = new MySqlConnection(stringConexion);
        }
    }
}
