using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Sistema
{
    public partial class frmMenu : Form
    {
        frmClientes cliente;
        frmUsuarios usuario;
        frmProveedores proveedor;
        frmProductos productos;
        frmVenta ventas;
        frmCompra compras;
        frmPedido pedidos;
        frmRespaldo respaldo;
        frmInventario inventario;
        frmReporteClientes reportcliences;
        frmReporteEmpleado reportempleado;
        frmReporteInventario reportinventario;
        frmReporteProductos reporteproductos;
        frmReporteProveedores reportproveedores;
        frmDetalleCompras detallecompras;
        frmDetalleVentas detalleventas;
        frmImprimirCompra imrpimircompra;
        frmImprimirVenta imrpimirventa;
        frmImprimirPedido imprimirpedido;
        frmProductoCliente productocliente;
        frmServicios servicios;
        public frmMenu()
        {
            int tipoUsuario;

            InitializeComponent();

            textBox1.Text = Session.nombre;            
            tipoUsuario = Session.id_tipo;                                   
            


            if (tipoUsuario == 1)
            {
                /* ADMINISTRADOR CON ACCESO TOTAL AL SISTEMA*/
                /*this.toolStripMenuItem2.Visible = true;*/
                txtTipo.Text = "Administrador";
                /* MessageBox.Show("Bienvenido", "Q'KARNE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 frmMenu menu = new frmMenu();
                 //menu.label1.Text = txtUsuario.Text;
                 this.Hide();
                 menu.Show();*/
               
               
  
            }
            if(tipoUsuario==2)
            {
                txtTipo.Text ="Vendedor";
                this.personalToolStripMenuItem.Visible = false;
                this.proveedoresToolStripMenuItem.Visible = false;
                this.registroProuctosToolStripMenuItem.Visible = false;
                this.comprasToolStripMenuItem.Visible = false;
                this.comprasRealizadasToolStripMenuItem.Visible = false;
                this.ventasRealizadasToolStripMenuItem.Visible = false;
                this.reportesVentasToolStripMenuItem.Visible = false;
                this.reporteComprasToolStripMenuItem.Visible = false;
                this.reporteDeClientesToolStripMenuItem.Visible = false;
                this.toolStripMenuItem3.Visible = false;
                this.toolStripMenuItem2.Visible = false;
                this.toolStripMenuItem4.Visible = false;
                this.toolStripMenuItem1.Visible = false;
                this.toolStripMenuItem5.Visible = false;
                this.toolStripMenuItem7.Visible = false;
                this.toolStripMenuItem6.Visible = false;
                this.toolStripMenuItem8.Visible = false;
                this.toolStripMenuItem9.Visible = false;
                this.desarrolladoresToolStripMenuItem.Visible = false;



            }

            else
            {
                /*AQUI VALIDAREMOS LOS PERMISOS DEL USUARIO NORMAL*/
                /*    this.subMenuRegistrarUsuario.Visible = false;
                    this.menuConfiguracion.Visible = false;*/
                this.desarrolladoresToolStripMenuItem.Visible = false;
 
            }
        }
        
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(cliente==null)
            {
                cliente = new frmClientes();
                cliente.MdiParent = this;
                cliente.FormClosed += new FormClosedEventHandler(CuandoSeCierraClientes);
                cliente.Show();
            }

            //frmClientes cli = new frmClientes();
            //cli.StartPosition = FormStartPosition.CenterParent;
            //cli.Show();
            //cli.MdiParent = this;
        }
        void CuandoSeCierraClientes(object sender, EventArgs e)
        {
            cliente = null;
        }

        private void cerrarSecionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Seguro que deseas iniciar una nueva sesion?", "DIGITS AND BITS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes)
            {
                this.Close();
                frmLogin lo = new frmLogin();
                lo.Show();
             
            }
            
        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usuario == null)
            {
                usuario = new frmUsuarios();
                usuario.MdiParent = this;
                usuario.FormClosed += new FormClosedEventHandler(CuandoSeCierraUsuario);
                usuario.Show();
            }

        }
        void CuandoSeCierraUsuario(object sender, EventArgs e)
        {
            usuario = null;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Seguro que deseas salir del sistema?", "DIGITS AND BITS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes)
            {
                Application.Exit();                
            }
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (proveedor == null)
            {
                proveedor = new frmProveedores();
                proveedor.MdiParent = this;
                proveedor.FormClosed += new FormClosedEventHandler(CuandoSeCierraProveedor);
                proveedor.Show();
            }


        }
        void CuandoSeCierraProveedor(object sender, EventArgs e)
        {
            usuario = null;
        }

        private void registroProuctosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productos == null)
            {
                productos = new frmProductos();
                productos.MdiParent = this;
                productos.FormClosed += new FormClosedEventHandler(CuandoSeCierraProductos);
                productos.Show();
            }
        }

        void CuandoSeCierraProductos(object sender, EventArgs e)
        {
            productos = null;
        }

        private void inventarioProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inventario == null)
            {
                inventario = new frmInventario();
                inventario.MdiParent = this;
                inventario.FormClosed += new FormClosedEventHandler(CuandoSeCierraInventario);
                inventario.Show();
            }

        }
        void CuandoSeCierraInventario(object sender, EventArgs e)
        {
            inventario = null;
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

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            if (respaldo == null)
            {
                respaldo = new frmRespaldo();
                respaldo.MdiParent = this;
                respaldo.FormClosed += new FormClosedEventHandler(CuandoSeCierraRespaldo);
                respaldo.Show();
            }
        }
        void CuandoSeCierraRespaldo(object sender, EventArgs e)
        {
            respaldo = null;
        }

        private void reporteDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reportcliences == null)
            {
                reportcliences = new frmReporteClientes();
                reportcliences.MdiParent = this;
                reportcliences.FormClosed += new FormClosedEventHandler(CuandoSeCierraReporteCliente);
                reportcliences.Show();
            }
        }
        void CuandoSeCierraReporteCliente(object sender, EventArgs e)
        {
            reportcliences = null;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (reporteproductos == null)
            {
                reporteproductos = new frmReporteProductos();
                reporteproductos.MdiParent = this;
                reporteproductos.FormClosed += new FormClosedEventHandler(CuandoSeCierraReporteProductos);
                reporteproductos.Show();
            }
        }
        void CuandoSeCierraReporteProductos(object sender, EventArgs e)
        {
            reporteproductos = null;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (reportproveedores == null)
            {
                reportproveedores = new frmReporteProveedores();
                reportproveedores.MdiParent = this;
                reportproveedores.FormClosed += new FormClosedEventHandler(CuandoSeCierraReporteProveedores);
                reportproveedores.Show();
            }

        }
        void CuandoSeCierraReporteProveedores(object sender, EventArgs e)
        {
            reportproveedores = null;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            if (reportempleado == null)
            {
                reportempleado = new frmReporteEmpleado();
                reportempleado.MdiParent = this;
                reportempleado.FormClosed += new FormClosedEventHandler(CuandoSeCierraReporteEmpleado);
                reportempleado.Show();
            }

        }
        void CuandoSeCierraReporteEmpleado(object sender, EventArgs e)
        {
            reportempleado = null;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (reportinventario == null)
            {
                reportinventario = new frmReporteInventario();
                reportinventario.MdiParent = this;
                reportinventario.FormClosed += new FormClosedEventHandler(CuandoSeCierraReporteInventario);
                reportinventario.Show();
            }


        }
        void CuandoSeCierraReporteInventario(object sender, EventArgs e)
        {
            reportinventario = null;
        }

        private void reportesVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (detalleventas == null)
            {
                detalleventas = new frmDetalleVentas();
                detalleventas.MdiParent = this;
                detalleventas.FormClosed += new FormClosedEventHandler(CuandoSeCierraReporteVentas);
                detalleventas.Show();
            }
        }
        void CuandoSeCierraReporteVentas(object sender, EventArgs e)
        {
            detalleventas = null;
        }
        private void reporteComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (detallecompras == null)
            {
                detallecompras = new frmDetalleCompras();
                detallecompras.MdiParent = this;
                detallecompras.FormClosed += new FormClosedEventHandler(CuandoSeCierraCompra);
                detallecompras.Show();
            }
        }
        void CuandoSeCierraReporteCompra(object sender, EventArgs e)
        {
            detallecompras = null;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            frmLogin lo = new frmLogin();
        }
        void CuandoSeCierraImprimirVenta(object sender, EventArgs e)
        {
            imrpimirventa = null;
        }

        private void ventasRealizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (imrpimirventa == null)
            {
                imrpimirventa = new frmImprimirVenta();
                imrpimirventa.MdiParent = this;
                imrpimirventa.FormClosed += new FormClosedEventHandler(CuandoSeCierraImprimirVenta);
                imrpimirventa.Show();
            }
        }

        void CuandoSeCierraImprimirCompra(object sender, EventArgs e)
        {
            imrpimircompra = null;
        }
        private void comprasRealizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imrpimircompra == null)
            {
                imrpimircompra = new frmImprimirCompra();
                imrpimircompra.MdiParent = this;
                imrpimircompra.FormClosed += new FormClosedEventHandler(CuandoSeCierraImprimirCompra);
                imrpimircompra.Show();
            }
        }

        private void desarrolladoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        void CuandoSeCierraPedidos(object sender, EventArgs e)
        {
            pedidos = null;
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (pedidos == null)
            {
                pedidos = new frmPedido();
                pedidos.MdiParent = this;
                pedidos.FormClosed += new FormClosedEventHandler(CuandoSeCierraPedidos);
                pedidos.Show();
            }
        }

        void CuandoSeCierraImprimirPedido(object sender, EventArgs e)
        {
            imprimirpedido = null;
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (imprimirpedido == null)
            {
                imprimirpedido = new frmImprimirPedido();
                imprimirpedido.MdiParent = this;
                imprimirpedido.FormClosed += new FormClosedEventHandler(CuandoSeCierraImprimirPedido);
                imprimirpedido.Show();
            }
        }
        void CuandoSeCierraProductoCliente(object sender, EventArgs e)
        {
            productocliente = null;
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {

            if (productocliente == null)
            {
                productocliente = new frmProductoCliente();
                productocliente.MdiParent = this;
                productocliente.FormClosed += new FormClosedEventHandler(CuandoSeCierraProductoCliente);
                productocliente.Show();
            }
        }
        void CuandoSeCierraServicios(object sender, EventArgs e)
        {
            servicios = null;
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

            if (servicios == null)
            {
                servicios = new frmServicios();
                servicios.MdiParent = this;
                servicios.FormClosed += new FormClosedEventHandler(CuandoSeCierraServicios);
                servicios.Show();
            }
        }
    }
}

