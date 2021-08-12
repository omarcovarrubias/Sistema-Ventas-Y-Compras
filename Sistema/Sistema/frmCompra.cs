using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;
namespace Sistema
{

    public partial class frmCompra : Form
    {
        Compras comprar = new Compras();
        dbProductos productos = new dbProductos();
        ArrayList lista = new ArrayList();



        public frmCompra()
        {
            InitializeComponent();
            dbProveedores xx = new dbProveedores();
            cmbProveedores.DataSource = xx.MostrarEmpresa();
            cmbProveedores.ValueMember = "idproveedor";
            cmbProveedores.DisplayMember = "empresa";
            comboBox1.DataSource = xx.MostrarTipo();
            comboBox1.DisplayMember = "descripcion";
            comboBox1.ValueMember = "id";

            txtvendedor.Text = Session.nombre;

        }



        private void frmCompra_Load(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (Convert.ToString(row.Cells["cantidad"].Value).Trim() == string.Empty)
                {
                    row.Cells["cantidad"].Value = 0;
                }
            }



            dbgProveedorCompra.AllowUserToAddRows = false;
            dgvLista.AllowUserToAddRows = false;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.DataSource = productos.getproductosFiltroInventarioC();
            groupBox1.Visible = false;
            comboBox1.Visible = true;
            label5.Visible = true;
            //cmbProveedores.ValueMember = "idproveedor";
            //cmbProveedores.DisplayMember = "empresa";
            //comboBox1.DisplayMember = "descripcion";
            //comboBox1.ValueMember = "id";
            dbProveedores xx = new dbProveedores();
            label5.Visible = true;
            comboBox2.DataSource = xx.MostrarFolioCompra();
            comboBox2.DisplayMember = "SUM(id)";

        }

        private void txtAgregar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                if (txtvendedor.Text != "")
                {
                    if (txtProveedorCompra.Text != "")
                    {
                        if (txtCantidad.Text != "" && txtPrecio.Text != "")
                        {
                            if (txtCantidad.Text != "0")
                            {
                                txtSaldo.Enabled = true;

                                decimal cantidad_lista = 0;
                                foreach (ProductoCompra x in lista)
                                {
                                    if (x.Id == int.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString()))
                                    {
                                        cantidad_lista += x.Cantidad;
                                    }
                                }
                                if (true) //esto nunca va a pasar
                                {
                                    int folio = int.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString());
                                    int id_producto = int.Parse(dgvProductos.CurrentRow.Cells[1].Value.ToString());
                                    string codigo = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                                    string descripcion = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                                    string nombreempresa = dgvProductos.CurrentRow.Cells[4].Value.ToString();
                                    decimal compra = decimal.Parse(dgvProductos.CurrentRow.Cells[5].Value.ToString());
                                    string proveedor = dbgProveedorCompra.CurrentRow.Cells[2].Value.ToString();
                                    decimal precio = decimal.Parse(txtPrecio.Text);
                                    decimal cantidad = decimal.Parse(txtCantidad.Text);
                                    string vendedor = txtvendedor.Text;

                                    //string codigo = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                                    //string descripcion = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                                    //string nombreempresa = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                                    //float compra = float.Parse(dgvProductos.CurrentRow.Cells[3].Value.ToString());
                                    //int cantidad = int.Parse(txtCantidad.Text);
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
                                        dgvLista.DataSource = null;
                                        dgvLista.DataSource = lista;
                                        dgvLista.Refresh();
                                    }
                                    else //agregar nuevo articulo a la lista
                                    {
                                        /*Comente lista.Add porque andaba probando la reimpresion del ticket en venta*/
                                        //   lista.Add(new Producto(folio, id_producto, codigo, descripcion, nombreempresa, compra, precio, cantidad,cliente));
                                        lista.Add(new ProductoCompra(folio, id_producto, codigo, descripcion, nombreempresa, compra, precio, cantidad, proveedor, vendedor));
                                        dgvLista.DataSource = null;
                                        dgvLista.DataSource = lista;
                                    }
                                }
                                btnBuscarProducto.PerformClick();
                            }
                            else
                            {
                                MessageBox.Show("La cantidad debe ser mayor a 0");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Favor de poner una cantidad y un precio");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Favor de seleccionar un proveedor");
                    }
                }
                else
                {
                    MessageBox.Show("Favor de logearse");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto");
            }
        }

        private void dgvProductos_Click(object sender, EventArgs e)
        {
            txtPrecio.Text = dgvProductos.CurrentRow.Cells[5].Value.ToString();

        }

        private void dgvLista_DataSourceChanged(object sender, EventArgs e)
        {
            if (lista.Count == 0)
            {
                txtTotal.Text = "0.0";
            }
            else
            {
                decimal suma = 0;
                foreach (ProductoCompra x in lista)
                {
                    suma += (x.Cantidad * x.Costo);
                }
                txtTotal.Text = (suma).ToString("N2");
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
          

            if (txtSaldo.Text != "")
            {
                if (float.Parse(txtSaldo.Text) >= float.Parse(txtTotal.Text))
                {
                    if (txtTotal.Text != "" || txtSaldo.Text != "")
                    {


                        if (!String.IsNullOrEmpty(cmbProveedores.SelectedValue.ToString()))
                            if (!String.IsNullOrEmpty(comboBox1.SelectedValue.ToString()))
                                if (!string.IsNullOrEmpty(comboBox2.SelectedValue.ToString()))
                                    if (comprar.comprar(int.Parse(cmbProveedores.SelectedValue.ToString()), dateTimePicker1.Text, int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox2.Text), lista)) //comprar
                                    {


                                        //Creamos una instancia d ela clase CrearTicket
                                        crearTicket ticket = new crearTicket();
                                        //Ya podemos usar todos sus metodos
                                        ticket.AbreCajon();//Para abrir el cajon de dinero.

                                        //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

                                        //Datos de la cabecera del Ticket.
                                         ticket.TextoCentro("'DIGITS AND BITS'");
                                        ticket.TextoCentro("COL. CENTRO, CP. #####");
                                        ticket.TextoCentro("MAZATLAN, SINALOA");
                                        ticket.TextoCentro("TEL. (666) - 666 - 6666");
                                        ticket.TextoIzquierda("EXPEDIDO EN: CARNICERIA QKARNE");
                                        ticket.TextoIzquierda("Folio de la compra:" + comboBox2.Text);
                                        ticket.TextoIzquierda("");
                                        ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
                                        ticket.lineasAsteriscos();

                                        //Sub cabecera.
                                        ticket.TextoIzquierda("");
                                        ticket.TextoIzquierda("ATENDIO:" + txtvendedor.Text + "");
                                        ticket.TextoIzquierda("PROVEEDOR:" + txtProveedorCompra.Text + "");
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


                                        dateTimePicker1.Refresh();
                                        dateTimePicker1.Format = DateTimePickerFormat.Custom;
                                        dateTimePicker1.CustomFormat = "yyyy-MM-dd hh:MM:ss";
                                        dateTimePicker1.Value = DateTime.Now;
                                        dateTimePicker1.ShowUpDown = false;
                                        dbProveedores xx = new dbProveedores();
                                        label5.Visible = true;
                                        comboBox2.DataSource = xx.MostrarFolioCompra();
                                        comboBox2.DisplayMember = "SUM(id)";
                                        txtSaldo.Clear();
                                        lista.Clear();
                                        dgvLista.DataSource = new ArrayList();
                                        dgvProductos.DataSource = new ArrayList();
                                        MessageBox.Show("Compra realizada con exito");
                                    }

                                    else
                                        MessageBox.Show("Error al hacer la compra");
                                else
                                    MessageBox.Show("favor de seleccionar un tipo de pago");
                            else
                                MessageBox.Show("favor de seleccionar un proveedor");
                        else
                            MessageBox.Show("Error en la creacion del folio");
                    }
                    else
                        MessageBox.Show("Hubo un error en la compra");
                }
                    else
                        MessageBox.Show("Dinero insuficiente para pagar esta cuenta");
                     
            }
            else
            {
                MessageBox.Show("Introduzca efectivo para pagar");
            }
        }
    

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            dgvProductos.DataSource = productos.getproductosFiltroInventarioC();
    
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtSaldo.Text = "";
            dgvLista.DataSource = null;
            dgvLista.ClearSelection();
            dgvProductos.DataSource = null;

            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close();
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

        private void txtDescripcionProducto_TextChanged(object sender, EventArgs e)
        {
            dbProductos xx = new dbProductos();
            dgvProductos.DataSource = xx.getproductosFiltroInventarioBusquedaC(txtDescripcionProducto.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbProveedores ff = new dbProveedores();
            dbgProveedorCompra.DataSource = ff.getproductosFiltroBusqueda(txtProveedorCompra.Text);
            txtProveedorCompra.Enabled = true;
            dbgProveedorCompra.Visible = true;
        }

        private void dbgProveedorCompra_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dbgProveedorCompra.CurrentRow != null)
            {
                txtProveedorCompra.Text = dbgProveedorCompra.CurrentRow.Cells[2].Value.ToString();
                dbgProveedorCompra.Hide();
                txtProveedorCompra.Enabled = false;

            }
        }
    }
}
