using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using System.Windows.Forms;
namespace Sistema
{
    class Ventas:BaseDatos
    {
        public bool vender(string fecha, int id_tipo_pago,int folio,ArrayList lista)
        {
            MySqlCommand comando = new MySqlCommand();
            bool exito = false;
            try
            {
                if (Conectar())
                {
                    comando.Connection = con;
                    comando.CommandText = "INSERT INTO ventas(fecha, id_tipo_pago,folio) Values('" + fecha + "','" + id_tipo_pago + "','"+folio+"')";
                    int id_venta = comando.ExecuteNonQuery();                    

                    foreach (Producto x in lista)
                    {
                        comando.CommandText = "INSERT INTO detalle_ventas(id_venta, cantidad, id_producto, precio,folio,cliente,vendedor) Values('" + id_venta + "','" + x.Cantidad + "','" + x.Id + "','" + x.Precio + "','" + x.Folio +"','"+x.Cliente+"','"+x.Vendedor+"')";
                        //comando.CommandText = "INSERT INTO detalle_ventas(id_venta, cantidad, id_producto, precio,folio,cliente,vendedor) Values('" + id_venta + "','" + x.Cantidad + "','" + x.Id + "','" + x.Precio + "','" + x.Folio + "','" + x.Cliente + "','" + x.Vendedor + "')";

                        /*  comando.CommandText = "INSERT INTO detalle_ventas(id_venta, cantidad, id_producto, precio,folio,cliente,vendedor,saldo,total,cambio) Values('" + id_venta + "','" + x.Cantidad + "','" + x.Id + "','" + x.Precio + "','"+x.Folio+"','"+x.Cliente+"','"+x.Vendedor+"','"+x.Saldo+"','"+x.Total+"','"+x.Cambio+"')";*/
                        comando.ExecuteNonQuery();
                    }

                    exito = true;
                }
            }
            catch (MySqlException ME)
            {
                MessageBox.Show("Se produjo error:" + ME.Message);

            }
            finally
            {
                Desconectar();
            }
            return exito;
        }
    }
}
