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
    public partial class frmMenuUsuario : Form
    {
        frmVenta ventas;
        frmCompra compras;
        frmInventario inventario;
        public frmMenuUsuario()
        {
            InitializeComponent();
        }

        private void cerrarSecionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Seguro que deseas iniciar una nueva sesion?", "Q'KARNE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes)
            {
                this.Close();
                frmLogin lo = new frmLogin();
                lo.Show();

            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult opcion;
            opcion = MessageBox.Show("¿Seguro que deseas salir del sistema?", "Q'KARNE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ventas == null)
            {
                ventas = new frmVenta();
                ventas.MdiParent = this;
                ventas.FormClosed += new FormClosedEventHandler(CuandoSeCierraVenta);
                ventas.Show();
            }
        }
        void CuandoSeCierraVenta(object sender, EventArgs e)
        {
            ventas = null;
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (compras == null)
            {
                compras = new frmCompra();
                compras.MdiParent = this;
                compras.FormClosed += new FormClosedEventHandler(CuandoSeCierraCompra);
                compras.Show();
            }
        }
        void CuandoSeCierraCompra(object sender, EventArgs e)
        {
            compras = null;
        }

        private void inventarioProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (compras == null)
            {
                inventario = new frmInventario();
                inventario.MdiParent = this;
                inventario.FormClosed += new FormClosedEventHandler(CuandoSeCierraCompra);
                inventario.Show();
            }
        }
        void CuandoSeCierraInventario(object sender, EventArgs e)
        {
            inventario = null;
        }
    }
}
