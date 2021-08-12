using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Sistema
{
    class Compras : BaseDatos
        
    {
        public bool comprar(int id_proveedor, string fecha, int id_tipo_pago, int folio, ArrayList lista)
        {
            MySqlCommand comando = new MySqlCommand();
            bool exito = false;
            try
            {
                if (Conectar())
                {
                    
                    comando.Connection = con;
                    comando.CommandText = "INSERT INTO compras(id_proveedor, fecha, id_tipo_pago,folio) Values('" + id_proveedor + "','" + fecha + "','" + id_tipo_pago +"','"+folio+"')";
                    int id_venta = comando.ExecuteNonQuery();

                    foreach (ProductoCompra x in lista)
                    {
                        decimal total = x.Cantidad * x.Precio;
                        comando.CommandText = "INSERT INTO detalle_compras(id_compra, cantidad, id_producto, precio,folio,vendedor,proveedor)Values('" + id_venta + "','" + x.Cantidad + "','" + x.Id + "','" + x.Costo+"','"+ x.Folio+"','"+x.Vendedor+"','"+x.Proveedor+"')";
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
