using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sistema
{
    class Conexion
    {
        public static MySqlConnection getConexion()
        {
            string servidor = "localhost";
            string usuario = "root";
            string password = "";
            string bd = "digitsbits";

            string cadenaConexion = "server=" + servidor + ";user id=" + usuario + "; password=" + password + "; database=" + bd;

            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            return conexion;

        }
    }
}
