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
    public partial class frmPedido : Form
    {
        public frmPedido()
        {
            InitializeComponent();
            txtvendedor.Text = Session.nombre;

        }
        Compras compras = new Compras();
        dbProductos productos = new dbProductos();
        ArrayList lista = new ArrayList();
        VentasPedido ventas = new VentasPedido();

        private void frmPedido_Load(object sender, EventArgs e)
        {
            dgvProductos.AllowUserToAddRows = false;
            dgvLista.AllowUserToAddRows = false;
            dbgProductoCliente.Visible = false;
            dbgClienteVenta.AllowUserToAddRows = false;

            dgvProductos.AllowUserToAddRows = false;
            dgvLista.AllowUserToAddRows = false;
            dgvProductos.DataSource = productos.getServicios2();
            dbProveedores xx = new dbProveedores();
            label5.Visible = true;
            cmbTipoPago.DataSource = xx.MostrarTipo();
            cmbTipoPago.DisplayMember = "descripcion";
            cmbTipoPago.ValueMember = "id";
            comboBox1.DataSource = xx.MostrarFolioServicio();
            comboBox1.DisplayMember = "SUM(id)";
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
                            ticket.TextoCentro("CARNICERIA");
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
                                ticket.AgregarPedido(fila.Cells[4].Value.ToString(),fila.Cells[9].Value.ToString(),decimal.Parse(fila.Cells[10].Value.ToString()));

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


                            if (ventas.venderPedido(dateTimePicker1.Text, int.Parse(cmbTipoPago.SelectedValue.ToString()), int.Parse(comboBox1.Text), lista))
                            {
                                dbProveedores xx = new dbProveedores();
                                label5.Visible = true;
                                comboBox1.DataSource = xx.MostrarFolioServicio();
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
                //dgvProductos.DataSource = null;
            }
        }

        private void txtAgregar_Click(object sender, EventArgs e)
        {
            {
                if (dgvProductos.CurrentRow != null)
                {
                    if(txtProductoCliente.Text!="" && txtDescripcion.Text!="")
                    { 

                    if (txtCantidad.Text != "" && txtPrecio.Text != "")
                    {
                        if (txtClienteVenta.Text != "" && txtIdCliente.Text!="")
                        {
                            if (txtvendedor.Text != "")
                            {
                                if (txtCantidad.Text != "0")
                                {

                                    txtSaldo.Enabled = true;
                                    int cantidad_lista = 0;
                                    foreach (Pedido x in lista)
                                    {
                                        if (x.Cantidad == int.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString()))
                                        {
                                            cantidad_lista += x.Cantidad;
                                        }
                                    }
                                    int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[1].Value.ToString());
                                    string folio = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                                    int cantidad = Convert.ToInt32(dgvProductos.CurrentRow.Cells[2].Value.ToString());
                                    string servicio = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                                    decimal precio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[4].Value.ToString());
                                    string cliente = dbgClienteVenta.CurrentRow.Cells[2].Value.ToString();
                                    int codigo = Convert.ToInt32(dbgProductoCliente.CurrentRow.Cells[1].Value.ToString());
                                    string descripcion = dbgProductoCliente.CurrentRow.Cells[4].Value.ToString();
                                    string idproducto = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                                    int idcliente = Convert.ToInt32(dbgProductoCliente.CurrentRow.Cells[6].Value.ToString());

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
                                        lista.Add(new Pedido(idcliente,idproducto,id, codigo, descripcion, folio, cantidad, servicio, precio, cliente, vendedor));
                                        dgvLista.DataSource = null;
                                        dgvLista.DataSource = lista;
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
                    MessageBox.Show("Elegir Producto Del Cliente");
                }

                    
                }

                else
                {
                    MessageBox.Show("Seleccione un producto");
                }
            }

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

        private void button1_Click(object sender, EventArgs e)
        {

            dbClientes xx = new dbClientes();
            dbgClienteVenta.DataSource = xx.mostrarTodoCliente();
            dbgClienteVenta.Visible = true;
            dbgClienteVenta.Refresh();


        }

        private void txtClienteVenta_TextChanged(object sender, EventArgs e)
        {
            if (dbgClienteVenta.CurrentRow != null)
            {

                dbClientes ff = new dbClientes();
                dbgClienteVenta.DataSource = ff.getproductosFiltroBusqueda(txtClienteVenta.Text);
            }
        }

        private void dbgClienteVenta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  if (dbgClienteVenta.CurrentRow != null)
            {
                txtClienteVenta.Text = dbgClienteVenta.CurrentRow.Cells[0].Value.ToString();
                txtidcliente.Text = dbgClienteVenta.CurrentRow.Cells[1].Value.ToString();
                dbgClienteVenta.Visible = false;
                dbgProductoCliente.Visible = true;
            }*/
        }

        private void dgvProductos_Click(object sender, EventArgs e)
        {
            txtPrecio.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();
            txtCantidad.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();

        }

        private void dgvLista_DataSourceChanged(object sender, EventArgs e)
        {
            if (lista.Count != 0)
            {

                decimal suma = 0;
                foreach (Pedido x in lista)
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

        private void btnFiltrarPC_Click(object sender, EventArgs e)
        {
            dbProductos xx = new dbProductos();
            // dbgProductoCliente.DataSource = xx.buscarProductoCliente(txtProductoCliente.Text);
            //dbgProductoCliente.DataSource = xx.mostrarClientesProductosClientes();
            dbgProductoCliente.DataSource = xx.filtrarproductoclienteid(txtIdCliente.Text);
            //Agregar a la tabla productos clientes cliente_id 
          }

        private void txtProductoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void dbgClienteVenta_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            if (dbgClienteVenta.CurrentRow != null)
            {
                dbgClienteVenta.Visible = false;
                dbgProductoCliente.Visible = true;
                txtClienteVenta.Text = dbgClienteVenta.CurrentRow.Cells[2].Value.ToString();
                txtIdCliente.Text = dbgClienteVenta.CurrentRow.Cells[0].Value.ToString();

            }

        }

        private void dbgProductoCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dbgProductoCliente.AllowUserToAddRows = false;
            txtProductoCliente.Text = dbgProductoCliente.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dbgProductoCliente.CurrentRow.Cells[4].Value.ToString();
            txtidproducto.Text = dbgProductoCliente.CurrentRow.Cells[0].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "Servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close();
        }
    }
}
