using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Sistema
{
    class dbProveedores:BaseDatos
    {
        public void Agregar(Proveedores obj)
        {
            string sqlConsulta = "INSERT INTO proveedor (idproveedor,codigo,nombreProveedor,apellidos,direccion,correo,numeroCelular,fecha,empresa,status)VALUES(NULL,?pcodigo,?pnombreProveedor,?papellidos,?pdireccion,?pcorreo,?pnumeroCelular,?pfecha,?pempresa,0)";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Codigo;
            comando.Parameters.Add("?pnombreProveedor", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Nombreproveedor;
            comando.Parameters.Add("?papellidos", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Apellidos;
            comando.Parameters.Add("?pdireccion", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Direccion;
            comando.Parameters.Add("?pcorreo", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Correo;
            comando.Parameters.Add("?pnumeroCelular", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Numerocelular;
            comando.Parameters.Add("?pfecha", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Fecha;
            comando.Parameters.Add("?pempresa", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Empresa;
            comando.Parameters.Add("?pstatus", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Status;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }

        public void Modificar(Proveedores obj)
        {
            String sqlConsulta = "update proveedor set codigo=?pcodigo,nombreProveedor=?pnombreProveedor,apellidos=?papellidos,direccion=?pdireccion,correo=?pcorreo,numeroCelular=?pnumeroCelular,fecha=?pfecha,empresa=?pempresa where codigo=?pcodigo and status=0";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Codigo;
            comando.Parameters.Add("?pnombreProveedor", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Nombreproveedor;
            comando.Parameters.Add("?papellidos", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Apellidos;
            comando.Parameters.Add("?pdireccion", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Direccion;
            comando.Parameters.Add("?pcorreo", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Correo;
            comando.Parameters.Add("?pnumeroCelular", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Numerocelular;
            comando.Parameters.Add("?pfecha", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Fecha;
            comando.Parameters.Add("?pempresa", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Empresa;
            comando.Parameters.Add("?pstatus", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Status;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }
        public void deshabilitarProveedor(int Codigo)
        {
            String sqlConsulta = "update proveedor set status=1 where codigo = ?pcodigo and status=0";
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }
        public DataTable buscarProveedor(int Codigo)
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "select codigo,nombreProveedor,apellidos,direccion,correo,numeroCelular,fecha,empresa,status from proveedor where codigo = ?pcodigo and status=0";
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
        public bool habilitarProveedor(Proveedores obj)
        {
            Boolean existo = false;
            String sqlConsulta = "update proveedor set status=0 where codigo=?pcodigo and status=1";
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
        public DataTable mostrarTodosDeshabilitadosProveedor()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select codigo,nombreProveedor,apellidos,direccion,correo,numeroCelular,fecha,empresa,status from proveedor where status=1";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }
        public DataTable mostrarTodoProveedor()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select codigo,nombreProveedor,apellidos,direccion,correo,numeroCelular,fecha,empresa,status from proveedor where status=0";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;


        }

        public DataTable MostrarEmpresa()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select empresa,idproveedor from proveedor where status=0";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;


        }

        public DataTable MostrarFolio()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select SUM(id) from ventas";
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
            string sqlConsulta = "SELECT * FROM proveedor WHERE apellidos LIKE '" + buscar + "%' or nombreProveedor LIKE '" + buscar + "%' ORDER BY codigo";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }
        public DataTable MostrarFolioCompra()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select SUM(id) from compras";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;


        }
        public DataTable MostrarFolioVenta()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select SUM(id)from ventas";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }


        public DataTable MostrarFolioServicio()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select SUM(id)from ventaspedido";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }



        public DataTable MostrarTipo()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select descripcion,id from tipos_pago";
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
            String sqlConsulta = "select codigo,nombreProveedor,apellidos,direccion,correo,numeroCelular,fecha,empresa,status from proveedor where codigo= ?pcodigo and status=0";
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
            string sqlConsulta = "select codigo,nombreProveedor,apellidos,direccion,correo,numeroCelular,fecha,empresa,status from proveedor where codigo = ?pcodigo and status=1";
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
            string sqlConsulta = "Update proveedor set status=0 where status=1 and codigo = ?pcodigo";
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
