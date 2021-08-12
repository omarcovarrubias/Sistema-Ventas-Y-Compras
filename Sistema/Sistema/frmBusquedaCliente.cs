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
    public partial class frmBusquedaCliente : Form
    {
        public frmBusquedaCliente()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dbClientes xx = new dbClientes();
            dbgBusquedaClientes.DataSource = xx.getproductosFiltroBusqueda(textBox1.Text);
        }

        private void frmBusquedaCliente_Load(object sender, EventArgs e)
        {
            dbClientes xx = new dbClientes();
            dbgBusquedaClientes.DataSource = xx.mostrarTodoCliente();
        }

        private void dbgBusquedaClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
                textBox1.Text = dbgBusquedaClientes.CurrentRow.Cells[1].Value.ToString();
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVenta fventa = new frmVenta();
            fventa.txtClienteVenta.Text = dbgBusquedaClientes.CurrentCell.Value.ToString();
            fventa.txtClienteVenta.Text = textBox1.Text;
            textBox1.Text = dbgBusquedaClientes.CurrentRow.Cells[1].Value.ToString();

        }

        private void dbgBusquedaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmVenta fventa = new frmVenta();
            fventa.txtClienteVenta.Text = dbgBusquedaClientes.CurrentCell.Value.ToString();
            fventa.txtClienteVenta.Text = textBox1.Text;
            textBox1.Text = dbgBusquedaClientes.CurrentRow.Cells[1].Value.ToString();

        }
    }
    
}
