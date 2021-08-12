using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class frmProductoCliente : Form
    {
        private DataTable datos = new DataTable();

        public frmProductoCliente()
        {
            InitializeComponent();
            txtEmpleado.Text = Session.nombre;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                datos = null;
                dbProductos db = new dbProductos();
                datos = db.buscarProductoCliente(int.Parse(txtCodigo.Text));
                if (datos.Rows.Count == 0) MessageBox.Show("No se encontro. ", "Productos Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    btnAgregar.Enabled = false;
                    //btnEliminar.Enabled = true;
                    dbgProductoCliente.DataSource = datos;
                    txtCodigoCliente.Text = datos.Rows[0]["cliente_id"].ToString();
                    txtCodigo.Text = datos.Rows[0]["codigo"].ToString();
                    txtDescripcion.Text = datos.Rows[0]["descripcion"].ToString();
                    dateTimePicker1.Text = datos.Rows[0]["fecha"].ToString();
                    txtCodigo.Enabled = false;
                    //btnDesHabilitar.Enabled = true;
                    btnActualizar.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Falta capturar información.", "Productos Clientes ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigoCliente.Text = "";
            btnAgregar.Enabled = true;
            btnBuscar.Enabled = true;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductosClientes obj = new ProductosClientes();
            if (txtCodigo.Text.Equals("") || txtDescripcion.Text.Equals("")|| txtCodigoCliente.Text.Equals(""))
            {
                MessageBox.Show("Falto capturar información.", " Producto Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = txtCodigo.Text;
                obj.Descripcion = txtDescripcion.Text;
                obj.Cliente = txtCodigoCliente.Text;
                obj.Fecha = dateTimePicker1.Text;
                dbProductos db = new dbProductos();
                if (db.existeProductoCliente(obj.Codigo)) MessageBox.Show("Ya existe.", "Producto Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    db.AgregarProductosClientes(obj);
                    MessageBox.Show("Se agrego con exito.", "Prodcuto Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbgProductoCliente.DataSource = null;
                    dbgProductoCliente.DataSource = db.mostrarTodoProductosClientes();
                    txtCodigoCliente.Text = "";
                    /* txtNombre.Text = datos.Rows[0]["Nombre"].ToString();
                   txtApellidoP.Text = datos.Rows[0]["A_Paterno"].ToString();
                   txtApellidoM.Text = datos.Rows[0]["A_Materno"].ToString();
                   txtCorreo.Text = datos.Rows[0]["Correo_Electronico"].ToString();
                   txtColonia.Text = datos.Rows[0]["Colonia"].ToString();
                   txtCalle.Text = datos.Rows[0]["Calle"].ToString();
                   txtNumero.Text = datos.Rows[0]["Numero"].ToString();
                   txtCodigo.Enabled = false;
                   */
                    btnActualizar.Enabled = false;
                    btnLimpiar.Enabled = false;
                    btnActualizar.Enabled = false;
                    btnBuscar.Enabled = false;
                    //btnDesHabilitar.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnAgregar.Enabled = false;
                    //Limpiar();


                       //Mostrar resultado
                     //Creamos una instancia d ela clase CrearTicket
                    crearTicket ticket = new crearTicket();
                    //Ya podemos usar todos sus metodos
                    ticket.AbreCajon();//Para abrir el cajon de dinero.

                    //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

                    //Datos de la cabecera del Ticket.
                    ticket.TextoCentro(" ");
                    ticket.TextoCentro("'DB'");
                    ticket.TextoCentro("COL. CENTRO, A. #####");
                    ticket.TextoCentro("MAZATLAN, SINALOA");
                    ticket.TextoCentro("TEL. (666) - 666 - 6666");
                    ticket.TextoIzquierda("EXPEDIDO EN: DB");
                    ticket.TextoIzquierda("");
                    ticket.TextoExtremos("FECHA: " + DateTime.Now.ToShortDateString(), "HORA: " + DateTime.Now.ToShortTimeString());
                    ticket.lineasAsteriscos();

                    //Sub cabecera.
                    ticket.TextoIzquierda("");
                    ticket.TextoIzquierda("ATENDIO: " + txtEmpleado.Text);
                    ticket.TextoIzquierda("CLIENTE:" + txtCliente.Text);
                    ticket.TextoIzquierda("CODIGO DEL CLIENTE:" + txtCodigo.Text);

                    ticket.TextoIzquierda("");

                    ticket.lineasAsteriscos();

                    //Articulos a vender.                    
                    ticket.EncabezadoProductoCliente();//NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
                    ticket.lineasAsteriscos();
                    //Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
                    //foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
                    //{
                    //ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
                    //decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
                    //}
                      
                   ticket.ImprimirTicketProductoCliente(txtDescripcion.Text,txtCodigo.Text,txtCodigoCliente.Text);
                   ticket.lineasIgual();
                    //Resumen de la venta. Sólo son ejemplos
                    //ticket.AgregarTotales("         SUBTOTAL......$", 100);
                    //ticket.AgregarTotales("         IVA...........$", 10.04M);//La M indica que es un decimal en C#
                    //double cambio = Convert.ToDouble(dbgImprimirVenta.CurrentRow.Cells[0].Value.ToString()) - Convert.ToDouble(dbgImprimirVenta.CurrentRow.Cells[0].Value.ToString());
                     //ticket.AgregarTotales("         EFECTIVO......$", Convert.ToDecimal(dbgImprimirVenta.CurrentRow.Cells[0].Value.ToString()));
                    // ticket.AgregarTotales("         CAMBIO........$", Convert.ToDecimal(cambio));

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

                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ProductosClientes obj = new ProductosClientes();
            if (txtCodigo.Text.Equals("") || txtDescripcion.Text.Equals("") || txtCodigoCliente.Text.Equals(""))
            {
                MessageBox.Show("Falto capturar información.", "Prodcutos Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                btnActualizar.Enabled = true;
                obj.Codigo = txtCodigo.Text;
                obj.Descripcion = txtDescripcion.Text;
                obj.Cliente = txtCodigoCliente.Text;
                obj.Fecha = dateTimePicker1.Text;
                dbProductos db = new dbProductos();
                //if (db.existe(obj.Codigo))  MessageBox.Show("No se encontró.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.ModificarProductoCliente(obj);
                MessageBox.Show("Se modificó con exito", "Productos Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgProductoCliente.DataSource = null;
                dbgProductoCliente.DataSource = db.mostrarTodoProductosClientes();
                //Limpiar();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
             dbProductos xx = new dbProductos();
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            //txtCodigoCliente.Text = "";
            txtCodigo.Enabled = true;
            dbgProductoCliente.DataSource = null;
            btnActualizar.Enabled = false;
            btnAgregar.Enabled = false;            
            dbgProductoCliente.DataSource = xx.mostrarTodoProductosClientes();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dbProductos refresh = new dbProductos();
            dbgProductoCliente.DataSource = refresh.mostrarTodoProductosClientes();
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtCodigoCliente.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "Productos Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close();
        }

        private void frmProductoCliente_Load(object sender, EventArgs e)
        {
            /*EN LA CONSULTA DEL CMBPRODUCTOSCLIENTES MANDAR  A LLAMAR A LA TABLA 
            RELACIONADA CLIENTE - PRODUCTOSCLIENTES PARA AGREGAR EL ID*/
            dbgProductoCliente.AllowUserToAddRows = false;
            /*   ProductosClientes x = new ProductosClientes();
               cmbProductoCliente.Text = x.Cliente;
               dbProductos xx = new dbProductos();
               cmbProductoCliente.DataSource = xx.mostrarClienteP();
               //cmbnombreempresa.ValueMember = "idproveedor";
               cmbProductoCliente.DisplayMember = "nombreCliente";
               cmbProductoCliente.ValueMember = "idcliente";*/
            
                /*string cantidad = dvgInventario.CurrentRow.Cells[5].Value.ToString();
                string stock= dvgInventario.CurrentRow.Cells[4].Value.ToString();
                decimal cantidad2 = Convert.ToDecimal(stock);
                decimal stock2 = Convert.ToDecimal(stock);
                decimal total = (cantidad2 - stock2);
                decimal total2 = (total/stock2)*(100);
                //if (Convert.ToDecimal(row.Cells["stock"].Value)< 10)*/
                 //if (Convert.ToDateTime(row.Cells["fecha"].Value) > Convert.ToDateTime(dateTimePicker1.Text))
                
                 

        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            dbClientes cli = new dbClientes();
            dbgProductoCliente.DataSource = cli.mostrarTodoCliente();

        }

        private void dbgProductoCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (dbgProductoCliente.CurrentRow != null)
            {
                txtCodigoCliente.Text = dbgProductoCliente.CurrentRow.Cells[0].Value.ToString();
                txtCliente.Text = dbgProductoCliente.CurrentRow.Cells[2].Value.ToString();


            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
