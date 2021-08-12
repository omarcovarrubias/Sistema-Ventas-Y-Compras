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
    class dbProductos:BaseDatos
    {

        public void Agregar(Productos obj)
        {
            string sqlConsulta = "INSERT INTO productos (idproducto,codigo,descripcion,costo,precio,nombreempresa,stock,status)VALUES(NULL,?pcodigo,?pdescripcion,?pcosto,?pprecio,?pnombreempresa,?pstock,0)";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Codigo;
            comando.Parameters.Add("?pdescripcion", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Descripcion;
            comando.Parameters.Add("?pcosto", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Costo;
            comando.Parameters.Add("?pprecio", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Precio;
            comando.Parameters.Add("?pstock", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = obj.Stock;
            comando.Parameters.Add("?pnombreempresa", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Nombreempresa;           
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }

        //AGREGAR LOS SERVICIOS 
        public void AgregarServicios(Servicios obj)
        {
            string sqlConsulta = "INSERT INTO servicios (id,codigo,servicios,precio,status)VALUES(NULL,?pcodigo,?pservicios,?pprecio,0)";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Codigo;
            comando.Parameters.Add("?pservicios", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Descripcion;            
            comando.Parameters.Add("?pprecio", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = obj.Precio;            
            comando.Parameters.Add("?pstatus", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = obj.Status;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }

        public DataTable buscarServicio(int Codigo)
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "select id,codigo,servicios,precio,status FROM servicios  where codigo = ?pcodigo and status=0";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = Codigo;
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }
        //MODIFICAR EL SERVICIO POR CODIGO
        public void ModificarServicios(Servicios obj)
        {
            String sqlConsulta = "update servicios set codigo=?pcodigo,servicios=?pservicios,precio=?pprecio where codigo= ?pcodigo AND status=0";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Codigo;
            comando.Parameters.Add("?pservicios", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Descripcion;            
            comando.Parameters.Add("?pprecio", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = obj.Precio;                        
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }
        //HABILITAR EL REGISTRO DE SERVICIOS
        public bool habilitarServicios(int Codigo)
        {
            Boolean exito = false;
            string sqlConsulta = "Update servicios set status=0 where status=1 and codigo = ?pcodigo";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = Codigo;
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            exito = true;
            this.Desconectar();
            return exito;
        }


        //DESACTIVAR  EL REGISTRO DE SERVICIOS
        public bool inhabilitarServicio(int Codigo)
        {
            Boolean exito = false;
            string sqlConsulta = "Update servicios set status=1 where status=0 and codigo = ?pcodigo";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = Codigo;
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            exito = true;
            this.Desconectar();
            return exito;
        }

        //VERIFICAR SI EXISTE EL SERVICIO AL BUSCAR CON STATUS 0
        public bool existeServicio(string Codigo)
        {
            Boolean exito = false;
            String sqlConsulta = "select id,codigo,servicios,precio,status FROM servicios where codigo= ?pcodigo AND status=0 or status=1";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = Codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            cursor = comando.ExecuteReader();
            if (cursor.Read()) exito = true;
            this.Desconectar();
            return exito;
        }

        // VERIFICAR SI EXISTE EL SERVICIO CON STATUS 1
        public bool existeServicioInhabilitado(string Codigo)
        {
            Boolean exito = false;
            String sqlConsulta = "select id,codigo,servicios,precio,status FROM servicios where codigo= ?pcodigo AND status=1 AND status=0";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = Codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            cursor = comando.ExecuteReader();
            if (cursor.Read()) exito = true;
            this.Desconectar();
            return exito;
        }


        //MOSTRAR TODOS LOS SERVICIOS CON STATUS 0( ACTIVOS)
        public DataTable mostrarTodosServicios()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT id,codigo,servicios,precio,status from servicios where status=0 ";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;


        }


        //MOSTRAR TODOS LOS SERVICIOS CON STATUS 1(INACTIVOS)
        public DataTable mostrarTodosServiciosInactivos()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT id,codigo,servicios,precio,status from servicios where status=1 ";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;


        }

        //BUSCAR EL SERVICIO CON STATUS 1
        public DataTable buscarServiciosInactivos(int Codigo)
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select id,codigo,servicios,precio,status from servicios  where codigo = ?pcodigo and status=1";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = Codigo;
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }


        //AGREGAR LOS PRODUCTOS DEL CLIENTE
        public void AgregarProductosClientes(ProductosClientes obj)
        {
            string sqlConsulta = "INSERT INTO ProductosClientes(id,codigo,descripcion,cliente_id,fecha)VALUES(NULL,?pcodigo,?pdescripcion,?pcliente_id,?pfecha)";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Codigo;
            comando.Parameters.Add("?pdescripcion", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Descripcion;
            comando.Parameters.Add("?pcliente_id", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Cliente;
            comando.Parameters.Add("?pfecha", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Fecha;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }


        //VERIFICAR SI EXISTE EL CODIGO DEL PRODUCTO CLIENTE
        public bool existeProductoCliente(string Codigo)
        {
            Boolean exito = false;
            String sqlConsulta = "select id,codigo,descripcion,cliente_id,fecha FROM ProductosClientes where codigo= ?pcodigo";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = Codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            cursor = comando.ExecuteReader();
            if (cursor.Read()) exito = true;
            this.Desconectar();
            return exito;
        }



        // MOSTRAR TODOS LOS PRODUCTOS LIGADOS AL CLIENTE
        public DataTable mostrarTodoProductosClientes()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT  productosclientes.`codigo`AS 'CODIGO PRODUCTO',cliente.`nombreCliente`,cliente.`apellidos`,productosclientes.`descripcion`,productosclientes.`fecha` FROM cliente INNER JOIN productosclientes ON productosclientes.`cliente_id`= cliente.`idcliente`";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;


        }


        //FILTRAR LOS DATOS DEL CLIENTE EN EL CMB PARA REGISTRAR EL PRODUCTO POR CLIENTE
        public DataTable mostrarClienteP()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select nombreCliente,idcliente from cliente where status=0";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;


        }


        //RELACION DE LAS TABLAS CLIENTES -PRODUCTOS CLIENTES

        public DataTable mostrarClientesProductosClientes()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT  productosclientes.`codigo`AS 'CODIGO PRODUCTO',cliente.`nombreCliente`,cliente.`apellidos`,productosclientes.`descripcion`,productosclientes.`fecha` FROM cliente INNER JOIN productosclientes ON productosclientes.`cliente_id`= cliente.`idcliente`";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;


        }

        //BUSCAR PRODUCTO DEL CLIENTE POR CODIGO

        public DataTable buscarProductoCliente(int Codigo)
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT productosclientes.`codigo`,cliente.`nombreCliente`,cliente.`apellidos`,productosclientes.`cliente_id`,productosclientes.`descripcion`,productosclientes.`fecha` FROM cliente INNER JOIN productosclientes ON productosclientes.`cliente_id`= cliente.`idcliente` where productosclientes.`codigo` = ?pcodigo";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = Codigo;
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }
        //MODIFICAR EL PRODUCTO DEL CLIENTE 
        public void ModificarProductoCliente(ProductosClientes obj)
        {
            String sqlConsulta = "update ProductosClientes set codigo=?pcodigo,descripcion=?pdescripcion,cliente_id=?pcliente,fecha=?pfecha where codigo= ?pcodigo";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Codigo;
            comando.Parameters.Add("?pdescripcion", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Descripcion;
            comando.Parameters.Add("?pcliente", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Cliente;
            comando.Parameters.Add("?pfecha", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Fecha;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }


        // MOSTRAR EL PRODUCTO EN EL PEDIDO DEL CLIENTE ESTABLECIDO 
        public DataTable buscarProductoCliente(string Codigo)
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "select id,codigo,descripcion,cliente,fecha from ProductosClientes where codigo = ?pcodigo";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = Codigo;
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }



        //FILTRAR LOS PRODUCTOS DEL CLIENTE POR EL ID DEL CLIENTE
        public DataTable filtrarproductoclienteid(string Codigo)
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT  productosclientes.`id`,productosclientes.`codigo`AS 'CODIGO PRODUCTO',cliente.`nombreCliente`,cliente.`apellidos`,productosclientes.`descripcion`,productosclientes.`fecha`,productosclientes.`cliente_id` FROM cliente INNER JOIN productosclientes ON productosclientes.`cliente_id`= cliente.`idcliente` where productosclientes.`cliente_id` = ?pcodigo";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = Codigo;
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }


        public DataTable   getproductosFiltroInventarioC()
        { 
            DataTable datos = new DataTable();  
            string sqlConsulta = "SELECT (SELECT SUM(id) from compras)AS'Folio',idproducto,codigo,descripcion,nombreempresa,costo,stock,(SELECT SUM(IF(detalle_compras.cantidad IS NULL,0,detalle_compras.cantidad)) AS cantidad FROM detalle_compras WHERE id_producto = idproducto)-IF((SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto) IS NULL,0,(SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto)) AS cantidad FROM productos order by cantidad";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }
        public void deshabilitarProducto(int Codigo)
        {
            String sqlConsulta = "update productos set status=1 where codigo = ?pcodigo and status=0";
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }


        public void habilitarProducto(int Codigo)
        {
            String sqlConsulta = "update productos set status=0 where codigo = ?pcodigo and status=1";
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = Codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }



        public DataTable getproductosFiltroInventarioVenta()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT (SELECT SUM(id) from ventas) AS'Folio',idproducto,codigo,descripcion,nombreempresa,costo,stock,(SELECT SUM(IF(detalle_compras.cantidad IS NULL,0,detalle_compras.cantidad)) AS cantidad FROM detalle_compras WHERE id_producto = idproducto)-IF((SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto) IS NULL,0,(SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto)) AS cantidad FROM productos where productos.status=0  order by cantidad";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }
        public DataTable getproductosFiltroInventarioVentaNolinea(string descripcion)
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT (SELECT SUM(id) from ventas) AS'Folio',idproducto,codigo,descripcion,nombreempresa,costo,stock,(SELECT SUM(IF(detalle_compras.cantidad IS NULL,0,detalle_compras.cantidad)) AS cantidad FROM detalle_compras WHERE id_producto = idproducto)-IF((SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto) IS NULL,0,(SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto)) AS cantidad FROM productos where productos.status=0 AND descripcion=?pdescripcion order by cantidad";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Parameters.Add("?pdescripcion", MySql.Data.MySqlClient.MySqlDbType.String).Value = descripcion;
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }


        public DataTable getServicios()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT (SELECT SUM(id) from ventaspedido) AS'Folio',id,cantidad,servicios,precio from servicios";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }

        public DataTable getServicios2()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT (SELECT SUM(id) from ventaspedido) AS'Folio',id,cantidad,servicios,precio from servicios where status=0";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }

        public DataTable getproductosFiltroInventarioI()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT codigo,descripcion,nombreempresa,costo,stock,(SELECT SUM(IF(detalle_compras.cantidad IS NULL,0,detalle_compras.cantidad)) AS cantidad FROM detalle_compras WHERE id_producto = idproducto)-IF((SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto) IS NULL,0,(SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto)) AS cantidad FROM productos order by cantidad";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }
        public DataTable getproductosFiltroInventarioBusquedaC(string buscar)
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT (SELECT SUM(id) from compras)As'Folio',idproducto,codigo,descripcion,nombreempresa,costo,stock,(SELECT SUM(IF(detalle_compras.cantidad IS NULL,0,detalle_compras.cantidad)) AS cantidad FROM detalle_compras WHERE id_producto = idproducto)-IF((SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto) IS NULL,0,(SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto)) AS cantidad FROM productos WHERE descripcion LIKE '" + buscar + "%' or codigo LIKE '" + buscar + "%' or nombreempresa LIKE '" + buscar + "%'ORDER BY codigo";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }
        public DataTable getproductosFiltroInventarioBusqueda(string buscar)
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT codigo,descripcion,nombreempresa,costo,stock,(SELECT SUM(IF(detalle_compras.cantidad IS NULL,0,detalle_compras.cantidad)) AS cantidad FROM detalle_compras WHERE id_producto = idproducto)-IF((SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto) IS NULL,0,(SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto)) AS cantidad FROM productos WHERE descripcion LIKE '" + buscar + "%' or codigo LIKE '" + buscar + "%' or nombreempresa LIKE '" + buscar + "%'ORDER BY codigo";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }

        public DataTable getproductosFiltroInventarioBusquedaV(string buscar)
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT (SELECT SUM(id) from ventas)AS'Folio',idproducto,codigo,descripcion,nombreempresa,costo,stock,(SELECT SUM(IF(detalle_compras.cantidad IS NULL,0,detalle_compras.cantidad)) AS cantidad FROM detalle_compras WHERE id_producto = idproducto)-IF((SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto) IS NULL,0,(SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto)) AS cantidad FROM productos WHERE productos.status=0 and descripcion LIKE '" + buscar + "%' or codigo LIKE '" + buscar + "%' or nombreempresa LIKE '" + buscar + "%'ORDER BY codigo";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }

        public void Modificar(Productos obj)
        {
            String sqlConsulta = "update productos set codigo=?pcodigo,descripcion=?pdescripcion,costo=?pcosto,precio=?pprecio,nombreempresa=?pnombreempresa,stock=?pstock where codigo= ?pcodigo";
            comando.Parameters.Clear();
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.String).Value = obj.Codigo;
            comando.Parameters.Add("?pdescripcion", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Descripcion;
            comando.Parameters.Add("?pcosto", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = obj.Costo;
            comando.Parameters.Add("?pprecio", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = obj.Precio;
            comando.Parameters.Add("?pstock", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = obj.Stock;
            comando.Parameters.Add("?pnombreempresa", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = obj.Nombreempresa;           
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }

        public DataTable buscarProducto(int Codigo)
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "select codigo,descripcion,costo,precio,nombreempresa,stock FROM productos  where codigo = ?pcodigo and status=0";
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


        public DataTable buscarProductoDeshabilitados(int Codigo)
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "select codigo,descripcion,costo,precio,nombreempresa,stock FROM productos  where codigo = ?pcodigo and status=1";
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




        public DataTable mostrarTodoProducto()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select idproducto,codigo,descripcion,costo,precio,nombreempresa,stock,status FROM productos WHERE status=0";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;


        }



        public DataTable mostrarTodoProductoDeshabilitados()
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "select idproducto,codigo,descripcion,costo,precio,nombreempresa,stock,status FROM productos where status=1";
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
            string sqlConsulta = "SELECT idproducto,codigo,descripcion,costo,precio,nombreempresa,stock,status FROM productos WHERE   codigo LIKE '" + buscar+"' or descripcion LIKE '" + buscar + "%' or nombreempresa LIKE '" + buscar + "%' AND status=0";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }


        public DataTable getproductosFiltroBusquedaDeshabilitado(string buscar)
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT idproducto,codigo,descripcion,costo,precio,nombreempresa,stock,status FROM productos WHERE  codigo LIKE '" + buscar + "' or descripcion LIKE '" + buscar + "%' or nombreempresa LIKE '" + buscar + "%' AND status=1";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        }




        public bool existe(string Codigo)
        {
            Boolean exito = false;
            String sqlConsulta = "select idproducto,codigo,descripcion,costo,precio,nombreempresa,stock FROM productos where codigo= ?pcodigo";
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


        public void EliminarProducto(int codigo)
        {
            String sqlConsulta = "DELETE from productos where codigo= ?pcodigo";
            comando.Parameters.Add("?pcodigo", MySql.Data.MySqlClient.MySqlDbType.Int32).Value = codigo;
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            comando.ExecuteNonQuery();
            this.Desconectar();
        }


        public DataTable MostrarDetalleCompras()
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT compras.`fecha`,productos.`codigo`,productos.`descripcion`,productos.`costo`,(SELECT detalle_compras.`cantidad` WHERE detalle_compras.`id_producto`=productos.`idproducto`)'Cantidad Comprado', (SELECT ROUND(detalle_compras.`precio`*detalle_compras.`cantidad`, 2) WHERE detalle_compras.`folio`= compras.`folio`)AS 'Precio Total',detalle_compras.`folio`FROM productos INNER JOIN detalle_compras ON detalle_compras.`id_producto`= productos.`idproducto`INNER JOIN compras ON detalle_compras.`folio`= compras.`folio`ORDER BY detalle_compras.`folio`";
            this.Conectar();
            comando.Parameters.Clear();            
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }


        public DataTable MostrarDetalleVenta()
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT detalle_ventas.`cliente`,detalle_ventas.`vendedor`,ventas.`fecha`,ventas.`folio`,detalle_ventas.`id_producto`,productos.`descripcion`,detalle_ventas.`cantidad`,detalle_ventas.`precio`  FROM detalle_ventas INNER JOIN productos ON productos.`idproducto`= detalle_ventas.`id_producto` INNER JOIN ventas  WHERE detalle_ventas.`folio`= ventas.`folio` or detalle_ventas.`folio`";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }


        public DataTable MostrarDetalleVentaPedidos()
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT detalles_pedido.`folio`,detalles_pedido.`precio`,cliente.`nombreCliente`,detalles_pedido.`vendedor`,productosclientes.`descripcion`,ventaspedido.`fecha`,servicios.`servicios` FROM detalles_pedido INNER JOIN productosclientes ON  detalles_pedido.`id_productoCliente`= productosclientes.`id` INNER JOIN cliente ON cliente.`idcliente`= detalles_pedido.`id_cliente` INNER JOIN servicios ON detalles_pedido.`id_servicio`= servicios.`id` INNER JOIN ventaspedido ON detalles_pedido.`folio`= ventaspedido.`folio`";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }

        public DataTable MostrarDetallePedido2(string folio)
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT detalles_pedido.`folio`,detalles_pedido.`precio`,cliente.`nombreCliente`,detalles_pedido.`vendedor`,productosclientes.`descripcion`,ventaspedido.`fecha`,servicios.`servicios`,cliente.`idcliente` FROM detalles_pedido INNER JOIN productosclientes ON  detalles_pedido.`id_productoCliente`= productosclientes.`id` INNER JOIN cliente ON cliente.`idcliente`= detalles_pedido.`id_cliente` INNER JOIN servicios ON detalles_pedido.`id_servicio`= servicios.`id` INNER JOIN ventaspedido ON detalles_pedido.`folio`= ventaspedido.`folio` AND  detalles_pedido.`folio` LIKE '" + folio + "'";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

            /*
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT detalle_ventas.`cliente`,detalle_ventas.`vendedor`,ventas.`fecha`,ventas.`folio`,detalle_ventas.`id_producto`,productos.`descripcion`,detalle_ventas.`cantidad`,detalle_ventas.`precio`,detalle_ventas.`saldo`,detalle_ventas.`total`,detalle_ventas.`cambio` FROM detalle_ventas INNER JOIN productos ON productos.`idproducto`= detalle_ventas.`id_producto` INNER JOIN ventas  WHERE detalle_ventas.`folio`= ventas.`folio` AND  ventas.`folio` LIKE '" + folio+"'";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        */
        }





        public DataTable MostrarDetalleCompra()
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT detalle_compras.`proveedor`,detalle_compras.`vendedor`,compras.`fecha`,compras.`folio`,detalle_compras.`id_producto`,productos.`descripcion`,detalle_compras.`cantidad`,detalle_compras.`precio` FROM detalle_compras INNER JOIN productos ON productos.`idproducto`= detalle_compras.`id_producto` INNER JOIN compras  WHERE detalle_compras.`folio`= compras.`folio`";
            this.Conectar();
            comando.Parameters.Clear();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }





        public DataTable MostrarDetalleVenta2(string folio)
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT detalle_ventas.`cliente`,detalle_ventas.`vendedor`,ventas.`fecha`,ventas.`folio`,detalle_ventas.`id_producto`,productos.`descripcion`,detalle_ventas.`cantidad`,detalle_ventas.`precio` FROM detalle_ventas INNER JOIN productos ON productos.`idproducto`= detalle_ventas.`id_producto` INNER JOIN ventas  WHERE detalle_ventas.`folio`= ventas.`folio` AND  ventas.`folio` LIKE '" + folio + "'";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

            /*
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT detalle_ventas.`cliente`,detalle_ventas.`vendedor`,ventas.`fecha`,ventas.`folio`,detalle_ventas.`id_producto`,productos.`descripcion`,detalle_ventas.`cantidad`,detalle_ventas.`precio`,detalle_ventas.`saldo`,detalle_ventas.`total`,detalle_ventas.`cambio` FROM detalle_ventas INNER JOIN productos ON productos.`idproducto`= detalle_ventas.`id_producto` INNER JOIN ventas  WHERE detalle_ventas.`folio`= ventas.`folio` AND  ventas.`folio` LIKE '" + folio+"'";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        */
        }

    



        public DataTable MostrarDetalleCompra2(string folio)
        {
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT detalle_compras.`proveedor`,detalle_compras.`vendedor`,compras.`fecha`,compras.`folio`,detalle_compras.`id_producto`,productos.`descripcion`,detalle_compras.`cantidad`,detalle_compras.`precio` FROM detalle_compras INNER JOIN productos ON productos.`idproducto`= detalle_compras.`id_producto` INNER JOIN compras  WHERE detalle_compras.`folio`= compras.`folio` AND  compras.`folio` LIKE '" + folio + "'";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

            /*
            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT detalle_ventas.`cliente`,detalle_ventas.`vendedor`,ventas.`fecha`,ventas.`folio`,detalle_ventas.`id_producto`,productos.`descripcion`,detalle_ventas.`cantidad`,detalle_ventas.`precio`,detalle_ventas.`saldo`,detalle_ventas.`total`,detalle_ventas.`cambio` FROM detalle_ventas INNER JOIN productos ON productos.`idproducto`= detalle_ventas.`id_producto` INNER JOIN ventas  WHERE detalle_ventas.`folio`= ventas.`folio` AND  ventas.`folio` LIKE '" + folio+"'";
            this.Conectar();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;

        */
        }



        public DataTable MostrarDetalleComprasF(string fecha)
        {

            DataTable datos = new DataTable();
            string sqlConsulta = "SELECT compras.`fecha`,productos.`codigo`,productos.`descripcion`,productos.`costo`,(SELECT detalle_compras.`cantidad` WHERE detalle_compras.`id_producto`=productos.`idproducto`)'Cantidad Comprado', (SELECT ROUND(detalle_compras.`precio`*detalle_compras.`cantidad`, 2) WHERE detalle_compras.`folio`= compras.`folio`)AS 'Precio Total',detalle_compras.`folio`FROM productos INNER JOIN detalle_compras ON detalle_compras.`id_producto`= productos.`idproducto`INNER JOIN compras ON detalle_compras.`folio`= compras.`folio`     where fecha BETWEEN '" + fecha + "'AND'" + fecha + "'    ORDER BY detalle_compras.`folio`";
            comando.Parameters.Add("?pfecha", MySql.Data.MySqlClient.MySqlDbType.String).Value = fecha;
            this.Conectar();
            comando.Parameters.Clear();
            comando.Connection = con;
            comando.CommandText = sqlConsulta;
            adaptador.SelectCommand = comando;
            adaptador.Fill(datos);
            this.Desconectar();
            return datos;
        }
    }
}
