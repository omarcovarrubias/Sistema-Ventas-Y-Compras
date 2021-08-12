using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Sistema
{
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
            txtvendedor.Text = Session.nombre;
            

        }

        //Clientes clientes = new Clientes();
        Compras compras = new Compras();
        dbProductos productos = new dbProductos();
        ArrayList lista = new ArrayList();
        Ventas ventas = new Ventas();
        

        private void txtAgregar_Click(object sender, EventArgs e)
        {            
            if (dgvProductos.CurrentRow != null)
            {
                if (!string.IsNullOrEmpty(dgvProductos.CurrentRow.Cells[7].Value.ToString()))
                {
                    if (txtCantidad.Text != "" && txtPrecio.Text != "")
                    {
                        if (txtClienteVenta.Text != "")
                        {
                            if (txtvendedor.Text != "")
                            {
                                if (txtCantidad.Text != "0")
                                {
                                    if (!string.IsNullOrEmpty(dgvProductos.CurrentRow.Cells[6].Value.ToString()) || txtCantidad.Text.Equals("."))
                                    {
                                        txtSaldo.Enabled = true;
                                        decimal cantidad_lista = 0;
                                        foreach (Producto x in lista)
                                        {
                                            if (x.Id == float.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString()))
                                            {
                                                cantidad_lista += x.Cantidad;
                                            }
                                        }
                                        if ((decimal.Parse(txtCantidad.Text) + cantidad_lista) <= decimal.Parse(dgvProductos.CurrentRow.Cells[7].Value.ToString()))
                                        {
                                            int folio = int.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString());
                                            int id_producto = int.Parse(dgvProductos.CurrentRow.Cells[1].Value.ToString());
                                            string codigo = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                                            string descripcion = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                                            string nombreempresa = dgvProductos.CurrentRow.Cells[4].Value.ToString();
                                            decimal compra = decimal.Parse(dgvProductos.CurrentRow.Cells[5].Value.ToString());
                                            string cliente = dbgClienteVenta.CurrentRow.Cells[2].Value.ToString();
                                            decimal precio = decimal.Parse(txtPrecio.Text);
                                            decimal cantidad = decimal.Parse(txtCantidad.Text);
                                           /* float saldo = float.Parse(txtSaldo.Text);
                                            float total = float.Parse(txtTotal.Text);
                                            string clienteE = txtClienteVenta.Text;
                                            float cambio = total - saldo;*/
                                            string vendedor = txtvendedor.Text;
                                            if (cantidad_lista > 0) //ya esta en la lista?
                                            {
                                                foreach (Producto x in lista)
                                                {
                                                    if (x.Id == int.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString()))
                                                    {
                                                        x.Cantidad = (decimal.Parse(txtCantidad.Text) + cantidad_lista); //aumentar la cantidad
                                                        break;
                                                    }
                                                }
                                                dgvLista.DataSource = lista;
                                                dgvLista.Refresh();
                                            }
                                            else //agregar nuevo articulo a la lista
                                            {       //, clienteE,vendedor,saldo,total,cambio
                                                lista.Add(new Producto(folio, id_producto, codigo, descripcion, nombreempresa, compra, precio, cantidad,cliente,vendedor));
                                                dgvLista.DataSource = null;
                                                dgvLista.DataSource = lista;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("No dispones con inventario suficiente");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El producto no esta en tu inventario");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("La cantidad debe ser mayor a 0");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Favor de iniciar sesion");
                            }
                    }
                    else
                    {
                            MessageBox.Show("Campo cliente vacio");
                    }
                    }
                
                
                else
                {
                    MessageBox.Show("Favor de llenar los campos");
                }
                
                }
                else
                {
                    MessageBox.Show("El producto no se encuentra en el inventario");

                }
            }

            else
            {
                MessageBox.Show("Seleccione un producto");
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            dgvProductos.DataSource = productos.getproductosFiltroInventarioVentaNolinea(txtDescripcionProducto.Text);
            if(txtDescripcionProducto.Text=="")
            {
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = productos.getproductosFiltroInventarioVenta();


            }

        }

        private void dgvLista_DataSourceChanged(object sender, EventArgs e)
        {
            if (lista.Count != 0)
            {

                decimal suma = 0;
                foreach (Producto x in lista)
                {
                    suma += (x.Cantidad * x.Precio);
                }
                txtTotal.Text = suma.ToString("N2");
 

            }
            else
            {
                txtTotal.Text = "0.00";
            }
        }

        private void dgvProductos_Click(object sender, EventArgs e)
        {
            txtPrecio.Text = dgvProductos.CurrentRow.Cells[5].Value.ToString();

        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (txtSaldo.Text.Equals("."))
            {
                MessageBox.Show("Favor de ingresar el saldo");

            }

            if (txtTotal.Text.Equals("."))
            {
                MessageBox.Show("Favor de ingresar el total");

            }

            else
            {
                if (txtSaldo.Text != "")
                {
                    if (txtvendedor.Text != "")
                    {
                         
                            if (float.Parse(txtSaldo.Text) >= float.Parse(txtTotal.Text))
                            {
                                //Creamos una instancia d ela clase CrearTicket
                                crearTicket ticket = new crearTicket();
                                //Ya podemos usar todos sus metodos
                                ticket.AbreCajon();//Para abrir el cajon de dinero.

                            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

                            //Datos de la cabecera del Ticket.
                            ticket.TextoCentro("'DIGITS AND BITS'");
                            ticket.TextoCentro("'DB'");
                                ticket.TextoCentro("COL. CENTRO, A. #####");
                                ticket.TextoCentro("MAZATLAN, SINALOA");
                                ticket.TextoCentro("TEL. (666) - 666 - 6666");
                                ticket.TextoIzquierda("EXPEDIDO EN: DB");
                                ticket.TextoIzquierda("Folio de la venta:" + comboBox1.Text);
                                ticket.TextoIzquierda("");
                                ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
                                ticket.lineasAsteriscos();

                                //Sub cabecera.
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierda("ATENDIO: " + txtvendedor.Text);
                                ticket.TextoIzquierda("CLIENTE:" + txtClienteVenta.Text);
                                ticket.TextoIzquierda("");

                                ticket.lineasAsteriscos();

                                //Articulos a vender.                    
                                ticket.EncabezadoVenta();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
                                ticket.lineasAsteriscos();
                                //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
                                //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
                                //{
                                //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                                //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                                //}
                                foreach (DataGridViewRow fila in dgvLista.Rows)
                                {
                                    ticket.AgregaArticulo(fila.Cells[4].Value.ToString(), decimal.Parse(fila.Cells[7].Value.ToString()), decimal.Parse(fila.Cells[5].Value.ToString()));

                                }
                                ticket.lineasIgual();

                                //Resumen de la venta. Sólo son ejemplos
                                //ticket.AgregarTotales("         SUBTOTAL......$", 100);
                                //ticket.AgregarTotales("         IVA...........$", 10.04M);//La M indica que es un decimal en C#
                                double cambio = Convert.ToDouble(txtSaldo.Text) - Convert.ToDouble(txtTotal.Text);
                                ticket.AgregarTotales("         TOTAL.........$", Convert.ToDecimal(txtTotal.Text));
                                ticket.AgregarTotales("         EFECTIVO......$", Convert.ToDecimal(txtSaldo.Text));
                                ticket.AgregarTotales("         CAMBIO........$", Convert.ToDecimal(cambio));

                                //Texto final del Ticket.
                                ticket.TextoIzquierda("");
                                //ticket.TextoIzquierda("ARTÍCULOS VENDIDOS: 3");
                                ticket.TextoIzquierda("");
                                ticket.TextoCentro("REVISE SU COMPRA CON DETALLE");
                                ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
                                ticket.TextoCentro("¡VUELVA PRONTO :D!");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierda("");
                                ticket.TextoIzquierda("");
                                ticket.CortaTicket();
                                ticket.ImprimirTicket("Microsoft XPS Document Writer");//Nombre de la impresora ticketera
                                                                                       //ticket.ImprimirTicket("EPSON TM-T88V Receipt");//Nombre de la impresora ticketera  Microsoft XPS Document Writer   


                                if (ventas.vender(dateTimePicker1.Text, int.Parse(cmbTipoPago.SelectedValue.ToString()), int.Parse(comboBox1.Text), lista))
                                {
                                    dbProveedores xx = new dbProveedores();
                                    label5.Visible = true;
                                    comboBox1.DataSource = xx.MostrarFolio();
                                    comboBox1.DisplayMember = "SUM(id)";

                                    txtSaldo.Clear();
                                    lista.Clear();
                                    dgvLista.DataSource = new ArrayList();
                                    dgvProductos.DataSource = new ArrayList();
                                    MessageBox.Show("Venta realizada con exito");
                                    MessageBox.Show("Su cambio:$" + cambio + "", "CAMBIO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                else
                                {
                                    MessageBox.Show("Error al hacer la venta");
                                }
                    
                            }
                            else
                            {
                                MessageBox.Show("Saldo insuficiente para pagar esta cuenta");
                            }


                        }
                        else
                        {
                            MessageBox.Show("Favor de logearse");
                        }
                    }


                    else
                    {
                        MessageBox.Show("Introdusta saldo para pagar");

                    }
                    txtCantidad.Clear();
                    txtPrecio.Clear();
                    txtTotal.Text = "";
                    txtSaldo.Text = "";
                    dgvLista.DataSource = null;
                 txtClienteVenta.Enabled = true;
                }
            }
        
        private void frmVenta_Load(object sender, EventArgs e)
        {
            
            dgvProductos.AllowUserToAddRows = false;
            dgvLista.AllowUserToAddRows = false;
            dgvProductos.DataSource = productos.getproductosFiltroInventarioVenta();
            dbProveedores xx = new dbProveedores();
            label5.Visible = true;
            cmbTipoPago.DataSource = xx.MostrarTipo();
            cmbTipoPago.DisplayMember = "descripcion";
            cmbTipoPago.ValueMember = "id";
            comboBox1.DataSource = xx.MostrarFolioVenta();                        
            comboBox1.DisplayMember = "SUM(id)";
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void txtDescripcionProducto_TextChanged(object sender, EventArgs e)
        {
            dbProductos xx = new dbProductos();
            //dgvProductos.DataSource = xx.getproductosFiltroInventarioBusquedaV(txtDescripcionProducto.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbClientes xx = new dbClientes();
            dbgClienteVenta.DataSource = xx.mostrarTodoCliente();
            dbgClienteVenta.Visible = true;
            dbgClienteVenta.Refresh();

        }

        private void dbgClienteVenta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dbgClienteVenta.CurrentRow != null)
            {
                txtClienteVenta.Text = dbgClienteVenta.CurrentRow.Cells[2].Value.ToString();
                dbgClienteVenta.Visible = false;
                txtClienteVenta.Enabled = false;
               


            }
        }

        private void txtClienteVenta_TextChanged(object sender, EventArgs e)
        {
            if (dbgClienteVenta.CurrentRow != null)
            {

                dbClientes ff = new dbClientes();
                dbgClienteVenta.DataSource = ff.getproductosFiltroBusqueda(txtClienteVenta.Text);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close();
        }
    }
}
