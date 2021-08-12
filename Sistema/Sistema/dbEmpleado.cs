using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace Sistema
{
    class dbEmpleado : BaseDatos
    {
      
        public void Agregar(Empleado obj)
        {
            string sqlConsulta = "INSERT INTO empleado(idempleado,codigo,nombreEmpleado,apellidos,correo,usuario,contraseña,Rol_id,fecha,status,telefono,domicilio)VALUES(NULL,?pcodigo,?pnombreEmpleado,?papellidos,?pcorreo,?pusuario,?pcontraseña,?pRol_id,?pfecha,0,?ptelefono,?pdomicilio)";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo",MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Codigo;
            comando.Parameters.Add("?pnombreEmpleado",MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.NombreEmpleado;
            comando.Parameters.Add("?papellidos",MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Apellidos;
            comando.Parameters.Add("?pcorreo",MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Correo;
            comando.Parameters.Add("?pusuario",MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Usuario;
            comando.Parameters.Add("?pcontraseña",MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Contraseña;
            comando.Parameters.Add("?pRol_id", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Rol;
            comando.Parameters.Add("?pfecha",MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Fecha;
            comando.Parameters.Add("?pstatus", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Status;
            comando.Parameters.Add("?ptelefono",MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Telefono;
            comando.Parameters.Add("?pdomicilio",MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Domicilio;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }

        public void Modificar(Empleado obj)
        {
            String sqlConsulta = "update empleado set codigo=?pcodigo,nombreEmpleado=?pnombreEmpleado,correo=?pcorreo,usuario=?pusuario,contraseña=?pcontraseña,Rol_id=?pRol_id,fecha=?pfecha,status=?pstatus,telefono=?ptelefono,domicilio=?pdomicilio where codigo=?pcodigo and status=0";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Codigo;
            comando.Parameters.Add("?pnombreEmpleado", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.NombreEmpleado;
            comando.Parameters.Add("?papellidos", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Apellidos;
            comando.Parameters.Add("?pcorreo", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Correo;
            comando.Parameters.Add("?pusuario", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Usuario;
            comando.Parameters.Add("?pcontraseña", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Contraseña;
            comando.Parameters.Add("?pRol_id", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Rol;
            comando.Parameters.Add("?pfecha", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Fecha;
            comando.Parameters.Add("?pstatus", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Status;
            comando.Parameters.Add("?ptelefono", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Telefono;
            comando.Parameters.Add("?pdomicilio", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Domicilio;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }
        public void deshabilitarEmpleado(int Codigo)
        {
            String sqlConsulta = "update empleado set status=1 where codigo = ?pcodigo and status=0";
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }
        public void EliminarEmpleado(int codigo)
        {
            String sqlConsulta = "DELETE from empleado where codigo= ?pcodigo";
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value =codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }
        public DataTable buscarEmpleado(int Codigo)
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "select * from empleado where codigo = ?pcodigo and status=0";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Codigo;
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }
        public bool habilitarEmpleado(Empleado obj)
        {
            Boolean existo = false;
            String sqlConsulta = "update empleado set status=0 where codigo=?pcodigo and status=1";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            existo = true;
            this.Desconectar();
            return existo;

        }
        public DataTable mostrarTodosDeshabilitadosEmpleado()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT codigo,nombreEmpleado,apellidos,correo,usuario,contraseña,rol.`id_Rol`,rol.`permisos`,fecha,status,telefono,domicilio FROM empleado INNER JOIN rol ON rol.`id_Rol`=empleado.`Rol_id` WHERE STATUS=1";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }
        public DataTable mostrarTodoEmpleado()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT codigo,nombreEmpleado,apellidos,correo,usuario,contraseña,rol.`id_Rol`,rol.`permisos`,fecha,status,telefono,domicilio FROM empleado INNER JOIN rol ON rol.`id_Rol`=empleado.`Rol_id` WHERE STATUS=0";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;


        }
        public DataTable getproductosFiltroBusqueda(string buscar)
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT * FROM empleado WHERE apellidos LIKE '" + buscar + "%' or nombreEmpleado LIKE '" + buscar + "%' ORDER BY codigo";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }

        public bool existe(int Codigo)
        {
            Boolean exito = false;
            String sqlConsulta = "select * from empleado where codigo= ?pcodigo and status=0";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pCodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            cursor = comando.ExecuteReader();
            if (cursor.Read()) exito = true;
            this.Desconectar();
            return exito;
        }
        public bool existeU(string usuario)
        {
            Boolean exito = false;
            String sqlConsulta = "select * from empleado where usuario= ?pusuario and status=0";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pUsuario", MySql.Data.MySqlClient.MySqlDbType.String).Value = usuario;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            cursor = comando.ExecuteReader();
            if (cursor.Read()) exito = true;
            this.Desconectar();
            return exito;
        }
        public DataTable buscarDeshabilitados(int Codigo)
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select * from empleado where codigo = ?pcodigo and status=1";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Codigo;
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }

        public bool habilitarRegistro(int Codigo)
        {
            Boolean exito = false;
            string sqlConsulta = "Update empleado set status=0 where status=1 and codigo = ?pcodigo";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Codigo;
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            exito = true;
            this.Desconectar();
            return exito;
        }

    }
}
