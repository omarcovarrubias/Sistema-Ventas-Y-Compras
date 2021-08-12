using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Sistema
{
    class BaseDatos
    {
        public MySqlConnection con;
        public MySqlCommand comando;
        public MySqlDataAdapter adaptador;
        public DataSet datos;
        protected MySqlDataReader cursor;

        

        public BaseDatos()
        {
            comando = new MySqlCommand();
            adaptador = new MySqlDataAdapter();
            datos = new DataSet();
            this.con = new MySqlConnection("Server=localhost; user =root; password=;database=digitsbits; Character Set=utf8");
        }

        public bool Conectar()
        {
            try
            {
                if (this.con.State == ConnectionState.Open)
                {
                    this.con.Close();
                }
                this.con.Open();
            }
            catch (MySqlException ME)
            {
                MessageBox.Show(ME.Message);
            }
            return true;
        }

        public void Desconectar()
        {
            if (this.con.State == ConnectionState.Open)

                this.con.Close();

        }

    }
}


