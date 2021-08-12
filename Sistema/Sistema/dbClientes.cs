using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace Sistema
{
    class dbClientes : BaseDatos
    {

        public void Agregar(Cliente obj)
        {
            string sqlConsulta = "INSERT INTO cliente (idcliente,codigo,nombreCliente,apellidos,direccion,correo,numeroCelular,fecha,status)VALUES(NULL,?pcodigo,?pnombreCliente,?papellidos,?pdireccion,?pcorreo,?pnumeroCelular,?pfecha,0)";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Codigo;
            comando.Parameters.Add("?pnombreCliente", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Nombre;
            comando.Parameters.Add("?papellidos", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Apellidos;
            comando.Parameters.Add("?pdireccion", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Colonia;
            comando.Parameters.Add("?pcorreo", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Correo;                        
            comando.Parameters.Add("?pnumeroCelular", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Numero;
            comando.Parameters.Add("?pfecha", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Fecha;
            comando.Parameters.Add("?pstatus", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Status;                        
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }

        public void Modificar(Cliente obj)
        {
            String sqlConsulta = "update cliente set codigo=?pcodigo,nombreCliente=?pnombreCliente,apellidos=?papellidos,direccion=?pdireccion,correo=?pcorreo,numeroCelular=?pnumeroCelular,fecha=?pfecha where codigo=?pCodigo and status=0";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Codigo;
            comando.Parameters.Add("?pnombreCliente", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Nombre;
            comando.Parameters.Add("?papellidos", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Apellidos;
            comando.Parameters.Add("?pdireccion", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Colonia;
            comando.Parameters.Add("?pcorreo", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Correo;
            comando.Parameters.Add("?pnumeroCelular", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Numero;
            comando.Parameters.Add("?pfecha", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Fecha;
            comando.Parameters.Add("?pstatus", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Status;       
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }
        public void deshabilitarCliente(int Codigo)
        {
            String sqlConsulta = "update cliente set status=1 where codigo = ?pcodigo and status=0";
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }
        public DataTable buscarCliente(int Codigo)
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "select codigo,nombreCliente,apellidos,direccion,correo,numeroCelular,fecha,status from cliente where codigo = ?pcodigo and status=0";
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
        public bool habilitarCliente(Cliente obj)
        {
            Boolean existo = false;
            String sqlConsulta = "update cliente set status=0 where codigo=?pcodigo and status=1";
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
        public DataTable getproductosFiltroBusqueda(string buscar)
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT * FROM cliente WHERE apellidos LIKE '"+buscar+ "%' or nombreCliente LIKE '" + buscar + "%' ORDER BY codigo";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }

        public DataTable mostrarTodosDeshabilitadosCliente()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select codigo,nombreCliente,apellidos,direccion,correo,numeroCelular,fecha,status from cliente where status=1";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }
        public DataTable mostrarTodoCliente()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select idcliente,codigo,nombreCliente,apellidos,direccion,correo,numeroCelular,fecha,status from cliente where status=0";
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
            String sqlConsulta = "select codigo,nombreCliente,apellidos,direccion,correo,numeroCelular,fecha,status from cliente where codigo= ?pcodigo and status=0";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Codigo;
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
            string sqlConsulta = "select codigo,nombreCliente,apellidos,direccion,correo,numeroCelular,fecha,status from cliente where codigo = ?pcodigo and status=1";
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
            string sqlConsulta = "Update cliente set status=0 where status=1 and codigo = ?pcodigo";
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
        public void EliminarCliente(int codigo)
        {
            String sqlConsulta = "DELETE from cliente where codigo= ?pcodigo";
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }

    }


}
