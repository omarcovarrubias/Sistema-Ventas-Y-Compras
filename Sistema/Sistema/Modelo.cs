using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Sistema
{
    class Modelo
    {
        public int registro(Usuarios usuario)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "INSERT INTO usuarios (usuario, password, nombre, id_tipo) VALUES(@usuario, @password, @nombre, @id_tipo)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario.Usuario);
            comando.Parameters.AddWithValue("@password", usuario.Password);
            comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
            comando.Parameters.AddWithValue("@id_tipo", usuario.Id_tipo);

            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }

        public bool existeUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT Rol_id FROM empleado WHERE usuario LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);


            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Usuarios porUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();
            string sql = "SELECT idempleado, contraseña, nombreEmpleado, Rol_id,rol.`permisos` FROM empleado INNER JOIN rol on rol.`id_Rol`=empleado.`Rol_id`  WHERE usuario LIKE @usuario";
            /*string sql = "SELECT idempleado, contraseña, nombreEmpleado, Rol_id FROM empleado WHERE usuario LIKE @usuario";*/
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);
            reader = comando.ExecuteReader();

            Usuarios usr = null;

            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Id = int.Parse(reader["idempleado"].ToString());
                usr.Password = reader["contraseña"].ToString();
                usr.Nombre = reader["nombreEmpleado"].ToString();
                usr.Id_tipo = int.Parse(reader["Rol_id"].ToString());
                usr.Permiso = reader["Rol_id"].ToString();
            }
            return usr;
        }
    }
}
