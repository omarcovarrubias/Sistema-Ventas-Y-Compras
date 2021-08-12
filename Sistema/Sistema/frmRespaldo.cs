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
namespace Sistema
{
    public partial class frmRespaldo : Form
    {
        public frmRespaldo()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            SaveFileDialog selecciona = new SaveFileDialog();
            selecciona.Filter = "Archivo de SQL(*.sql)|*.sql";
            selecciona.InitialDirectory = @"C:\Users\Usuario\Documents";
            selecciona.Title = "Seleccionar archivo de respaldo";
            if (selecciona.ShowDialog() == DialogResult.OK)
            {
                string ruta = selecciona.FileName;
                
                string cadena = "Server=localhost; user =root; password=;database=qkarne;";
                cadena += "charset=utf8; convertzerodatetime=true";

                MySqlConnection conexion = new MySqlConnection(cadena);
                MySqlCommand comando = new MySqlCommand();
                MySqlBackup bk = new MySqlBackup(comando);
                comando.Connection = conexion;
                conexion.Open();
                bk.ExportToFile(ruta);
                conexion.Close();
                MessageBox.Show("Respaldo Generado");
            }

        }

    }
}
