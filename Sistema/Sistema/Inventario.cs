using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Sistema
{
    class Inventario : BaseDatos
    {
        public DataTable getInventario()
        {
            DataTable dt = new DataTable();
            try
            {
                if (Conectar())
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.Connection = con;
                    comando.CommandText =
                    "SELECT *, " +
        "IFNULL((SELECT SUM(cantidad) FROM detalle_ventas WHERE id_producto = productos.id_producto), 0) AS cantidad_vendidos, " +
        "IFNULL((SELECT SUM(cantidad * precio) FROM detalle_ventas WHERE id_producto = productos.id_producto), 0) AS dinero_ventas, " +
         " cantidad_comprados -IFNULL((SELECT SUM(cantidad) FROM detalle_ventas WHERE id_producto = productos.id_producto),0) AS existencia, " +
         "ROUND(IFNULL((SELECT SUM(cantidad * precio) FROM detalle_ventas WHERE id_producto = productos.id_producto), 0)-dinero_compras, 2) AS ganancia " +
    "FROM( " +
        " SELECT idproducto AS id_producto, " +
            " codigo, " +
            " descripcion AS producto, " +
            " SUM(detalle_compras.cantidad) AS cantidad_comprados, " +
            "(SELECT precio FROM detalle_compras WHERE id_producto = idproducto ORDER BY id DESC LIMIT 1) AS precio_compra, " +
            "MAX(detalle_compras.precio) AS precio_venta, " +
            "SUM(detalle_compras.cantidad * detalle_compras.precio) AS dinero_compras " +
        "FROM detalle_compras " +
        "INNER JOIN productos ON detalle_compras.id_producto = idproducto " +
        "GROUP BY detalle_compras.id_producto " +
    ") AS productos "+
    "ORDER BY producto";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter();
                    adaptador.SelectCommand = comando;
                    adaptador.Fill(dt);
                }

            }
            catch (MySqlException ME)
            {
                MessageBox.Show("Se produjo el siguiente error: " + ME.Message);
            }
            return dt;
        }


        public DataTable getDineroInventario()
        {
            DataTable dt = new DataTable();
            try
            {
                if (Conectar())
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.Connection = con;
                    comando.CommandText =
                    "SELECT idproducto AS id_producto,codigo,descripcion AS producto, SUM(detalle_compras.cantidad) AS cantidad_comprados, (SELECT precio FROM detalle_compras WHERE id_producto = idproducto ORDER BY id DESC LIMIT 1) AS precio_compra, MAX(detalle_compras.precio) AS precio_venta, SUM(detalle_compras.cantidad*detalle_compras.precio) AS dinero_compras, IF(dinero_ventas IS NULL,0,dinero_ventas) AS dinero_ventas, IF(cantidad_vendidos IS NULL,0,cantidad_vendidos) AS cantidad_vendidos,(SUM(detalle_compras.cantidad)-IF(cantidad_vendidos IS NULL,0,cantidad_vendidos)) AS existencia, (IF(dinero_ventas IS NULL, 0, dinero_ventas)-SUM(detalle_compras.cantidad*detalle_compras.precio)) AS ganancia " +
                    "FROM detalle_compras INNER JOIN productos ON detalle_compras.id_producto = idproducto " +
                    "LEFT JOIN (SELECT id_producto, SUM(detalle_ventas.cantidad*detalle_ventas.precio) AS dinero_ventas, detalle_ventas.cantidad AS cantidad_vendidos FROM detalle_ventas) AS detalle_ventas ON idproducto = detalle_ventas.id_producto";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter();
                    adaptador.SelectCommand = comando;
                    adaptador.Fill(dt);
                }

            }
            catch (MySqlException ME)
            {
                MessageBox.Show("Se produjo el siguiente error: " + ME.Message);
            }
            return dt;
        }
    }
}
