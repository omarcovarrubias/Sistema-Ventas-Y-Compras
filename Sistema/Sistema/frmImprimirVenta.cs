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
    public partial class frmImprimirVenta : Form
    {
        public frmImprimirVenta()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal totalMonto = 0;
            foreach (DataGridViewRow row in dbgImprimirVenta.Rows)
                totalMonto += Convert.ToDecimal(row.Cells["precio"].Value);
            //Mostrar resultado
            txtTotal.Text = totalMonto.ToString("N2");

            //Creamos una instancia d ela clase CrearTicket
            crearTicket ticket = new crearTicket();
            //Ya podemos usar todos sus metodos
            ticket.AbreCajon();//Para abrir el cajon de dinero.

            //De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

            //Datos de la cabecera del Ticket.
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
            ticket.TextoIzquierda("ATENDIO: " + txtCliente.Text);
            ticket.TextoIzquierda("CLIENTE:" + txtVendedor.Text);
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
            foreach (DataGridViewRow fila in dbgImprimirVenta.Rows)
            {
              ticket.Reimprimir(fila.Cells[5].Value.ToString(),fila.Cells[6].Value.ToString(),fila.Cells[7].Value.ToString());

            }
            ticket.lineasIgual();

            //Resumen de la venta. Sólo son ejemplos
            //ticket.AgregarTotales("         SUBTOTAL......$", 100);
            //ticket.AgregarTotales("         IVA...........$", 10.04M);//La M indica que es un decimal en C#
            //double cambio = Convert.ToDouble(dbgImprimirVenta.CurrentRow.Cells[0].Value.ToString()) - Convert.ToDouble(dbgImprimirVenta.CurrentRow.Cells[0].Value.ToString());
            ticket.AgregarTotales("         TOTAL.........$",Convert.ToDecimal(txtTotal.Text));
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

        private void frmImprimirVenta_Load(object sender, EventArgs e)
        {
            // el DataGridView1.AllowUserToAddRows = False me esta permitiendo quitar la funcion de agregar columnas 
            dbgImprimirVenta.AllowUserToAddRows = false;
            dbProductos xx = new dbProductos();
            dbgImprimirVenta.DataSource = null;
             dbgImprimirVenta.DataSource = xx.MostrarDetalleVenta();
            
           /*dbgImprimirVenta.DataSource = xx.MostrarDetalleVenta();*/
             
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dbProductos xx = new dbProductos();
            dbgImprimirVenta.DataSource = xx.MostrarDetalleVenta2(textBox1.Text);
            


        }

        private void dbgImprimirVenta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dbgImprimirVenta_MarginChanged(object sender, EventArgs e)
        {

        }

        private void dbgImprimirVenta_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MANDAR DATOS DEL DATAGRID A LAS CAJAS DE TEXTO
            if (dbgImprimirVenta.CurrentRow != null)
            {
                txtVendedor.Text = dbgImprimirVenta.CurrentRow.Cells[0].Value.ToString();
                txtCliente.Text = dbgImprimirVenta.CurrentRow.Cells[1].Value.ToString();
                comboBox1.Text = dbgImprimirVenta.CurrentRow.Cells[3].Value.ToString();
               /* txtCodigo.Text = dbgImprimirVenta.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dbgImprimirVenta.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = dbgImprimirVenta.CurrentRow.Cells[2].Value.ToString();
                txtCorreo.Text = dbgEmpleados.CurrentRow.Cells[3].Value.ToString();
                txtUsuario.Text = dbgEmpleados.CurrentRow.Cells[4].Value.ToString();
                txtContra.Text = dbgEmpleados.CurrentRow.Cells[5].Value.ToString();
                comboBox1.Text = dbgEmpleados.CurrentRow.Cells[6].Value.ToString();
                txtTelefono.Text = dbgEmpleados.CurrentRow.Cells[10].Value.ToString();
                txtDireccion.Text = dbgEmpleados.CurrentRow.Cells[11].Value.ToString();
               */

            }
            decimal totalMonto = 0;
            foreach (DataGridViewRow row in dbgImprimirVenta.Rows)
                totalMonto += Convert.ToDecimal(row.Cells["precio"].Value);
            //Mostrar resultado
            txtTotal.Text = totalMonto.ToString("N2");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
