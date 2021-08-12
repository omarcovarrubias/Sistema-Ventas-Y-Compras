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
    public partial class frmProductos : Form
    {
        private DataTable datos = new DataTable();

        public frmProductos()
        {
            InitializeComponent();
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = true;
            txtStock.Text = "";
            btnAgregar.Enabled = true;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtCosto.Text = "";
            txtPrecio.Text = "";
            cmbnombreempresa.Text = "";
            txtBuscar.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Productos obj = new Productos();
            if (txtCodigo.Text.Equals("") || txtDescripcion.Text.Equals("") || txtCosto.Text.Equals("") || txtPrecio.Text.Equals("") || cmbnombreempresa.Text.Equals("")||txtStock.Text.Equals(""))
            {
                MessageBox.Show("Falto capturar información.", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                obj.Codigo = txtCodigo.Text;
                obj.Descripcion = txtDescripcion.Text;
                obj.Costo = decimal.Parse(txtCosto.Text);
                obj.Precio = decimal.Parse(txtPrecio.Text);
                obj.Stock = decimal.Parse(txtStock.Text);
                obj.Nombreempresa = cmbnombreempresa.Text;
                dbProductos db = new dbProductos();
                if (db.existe(obj.Codigo)) MessageBox.Show("Ya existe.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    db.Agregar(obj);
                    MessageBox.Show("Se agrego con exito.", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbgProductos.DataSource = null;
                    dbgProductos.DataSource = db.mostrarTodoProducto();
                    /* txtNombre.Text = datos.Rows[0]["Nombre"].ToString();
                   txtApellidoP.Text = datos.Rows[0]["A_Paterno"].ToString();
                   txtApellidoM.Text = datos.Rows[0]["A_Materno"].ToString();
                   txtCorreo.Text = datos.Rows[0]["Correo_Electronico"].ToString();
                   txtColonia.Text = datos.Rows[0]["Colonia"].ToString();
                   txtCalle.Text = datos.Rows[0]["Calle"].ToString();
                   txtNumero.Text = datos.Rows[0]["Numero"].ToString();
                   txtCodigo.Enabled = false;
                   */
                    btnNuevo.Enabled = true;
                    btnAgregar.Enabled = false;

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //ESTA OPCION FUE CAMBIADA DE ELIMINAR A DESHABILITAR YA QUE NO SE PUEDE ELIMINAR UN PRODUCTO QUE YA FUE ENLAZADO A OTRA TABLA COMO LA VENTA Y COMPRA

            Producto obj = new Producto();
            if (txtCodigo.Text.Equals(""))
            {
                MessageBox.Show("Falta capturar informacion", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = txtCodigo.Text;
                dbProductos db = new dbProductos();
                db.deshabilitarProducto(int.Parse(txtCodigo.Text));
                MessageBox.Show("Se Deshabilitó con exito", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgProductos.DataSource = null;
                dbgProductos.DataSource = db.mostrarTodoProducto();
 
            }

            //ESTA OPCION FUE CAMBIADA DE ELIMINAR A DESHABILITAR YA QUE NO SE PUEDE ELIMINAR UN PRODUCTO QUE YA FUE ENLAZADO A OTRA TABLA COMO LA VENTA Y COMPRA
            /*
                Producto obj = new Producto();
                if (txtCodigo.Text.Equals(""))
                {
                    MessageBox.Show("Falta capturar informacion", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    obj.Codigo = (txtCodigo.Text);
                    dbProductos db = new dbProductos();
                    db.EliminarProducto(int.Parse(txtCodigo.Text));
                    MessageBox.Show("Se Elimino con exito", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbgProductos.DataSource = null;
                    dbgProductos.DataSource = db.mostrarTodoProducto();

                }*/
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = false;



            txtCodigo.Enabled = true;
            txtStock.Text = "";
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtCosto.Text = "";
            txtPrecio.Text = "";
            cmbnombreempresa.Text = "";
            txtBuscar2.Text = "";

        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
         
                   
 
            
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            
              
            dbgProductos.AllowUserToAddRows = false;
            Proveedores x = new Proveedores();
            cmbnombreempresa.Text = x.Empresa;
            dbProveedores xx = new dbProveedores();
            cmbnombreempresa.DataSource = xx.MostrarEmpresa();
            //cmbnombreempresa.ValueMember = "idproveedor";
            cmbnombreempresa.DisplayMember = "empresa";            
        }

        private void cmbnombreempresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dbProductos pp = new dbProductos();
            dbgProductos.DataSource = null;
            dbgProductos.DataSource=pp.mostrarTodoProducto();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Productos obj = new Productos();
            if (txtCodigo.Text.Equals("") || txtDescripcion.Text.Equals("") || txtCosto.Text.Equals("") || txtPrecio.Text.Equals("") || txtStock.Text.Equals("") || cmbnombreempresa.Text.Equals(""))
            {
                MessageBox.Show("Falto capturar información.", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                btnModificar.Enabled = true;
                obj.Codigo = txtCodigo.Text;
                obj.Descripcion = txtDescripcion.Text;
                obj.Costo = decimal.Parse(txtCosto.Text);
                obj.Precio = decimal.Parse(txtPrecio.Text);                
                obj.Stock = decimal.Parse(txtStock.Text);
                obj.Nombreempresa = cmbnombreempresa.Text;
                dbProductos db = new dbProductos();
                //if (db.existe(obj.Codigo))  MessageBox.Show("No se encontró.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.Modificar(obj);
                MessageBox.Show("Se modificó con exito", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgProductos.DataSource = null;
                dbgProductos.DataSource = db.mostrarTodoProducto();

                txtCodigo.Enabled = true;
                txtStock.Text = "";
                txtCodigo.Text = "";
                txtDescripcion.Text = "";
                txtCosto.Text = "";
                txtPrecio.Text = "";
                cmbnombreempresa.Text = "";
                txtBuscar2.Text = "";
            }
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                datos = null;
                dbProductos db = new dbProductos();
                datos = db.buscarProducto(int.Parse(txtCodigo.Text));
                if (datos.Rows.Count == 0) MessageBox.Show("No se encontro. ", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {

                    dbgProductos.DataSource = datos;
                    txtCodigo.Text = datos.Rows[0]["codigo"].ToString();
                    txtDescripcion.Text = datos.Rows[0]["descripcion"].ToString();
                    txtCosto.Text = datos.Rows[0]["costo"].ToString();
                    txtPrecio.Text = datos.Rows[0]["precio"].ToString();
                    txtStock.Text = datos.Rows[0]["stock"].ToString();
                    cmbnombreempresa.Text = datos.Rows[0]["nombreempresa"].ToString();                    
                    txtCodigo.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnModificar.Enabled = true;
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnBuscar.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Falta capturar información.", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            dbProductos xx = new dbProductos();
            dbgProductos.DataSource = xx.getproductosFiltroBusqueda(txtDescripcion.Text);
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            dbProductos xx = new dbProductos();
            dbgProductos.DataSource = xx.getproductosFiltroBusqueda(txtCodigo.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHabilitar_Click(object sender, EventArgs e)
        {
            Producto obj = new Producto();
            if (txtCodigoe.Text.Equals(""))
            {
                MessageBox.Show("Falta capturar información", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = txtCodigoe.Text;
                dbProductos db = new dbProductos();
                db.habilitarProducto(int.Parse(txtCodigoe.Text));
                MessageBox.Show("Se habilitó con exito", "Producots", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgProductose.DataSource = null;
                 dbgProductose.DataSource = db.mostrarTodoProductoDeshabilitados();
             }
        }

        private void txtNuevoe_Click(object sender, EventArgs e)
        {
            txtCodigoe.Enabled = true;
            txtStocke.Text = "";
            txtCodigoe.Text = "";
            txtDescripcione.Text = "";
            txtCostoe.Text = "";
            txtPrecioe.Text = "";
            comboBox1.Text = "";
            txtBuscar2.Text = "";
        }

        private void txtBuscare_Click(object sender, EventArgs e)
        {
            if (txtCodigoe.Text != "")
            {
                datos = null;
                dbProductos db = new dbProductos();
                datos = db.buscarProductoDeshabilitados(int.Parse(txtCodigoe.Text));
                if (datos.Rows.Count == 0) MessageBox.Show("No se encontró el producto.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                     dbgProductose.DataSource = db.mostrarTodoProductoDeshabilitados();
                    txtCodigoe.Text = datos.Rows[0]["codigo"].ToString();
                    txtDescripcione.Text = datos.Rows[0]["descripcion"].ToString();
                    txtCostoe.Text = datos.Rows[0]["costo"].ToString();
                    txtPrecioe.Text = datos.Rows[0]["precio"].ToString();
                    txtStocke.Text = datos.Rows[0]["stock"].ToString();
                    comboBox1.Text = datos.Rows[0]["nombreempresa"].ToString();


                }
            }
            else
            {
                MessageBox.Show("Falta capturar información.", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoe.Focus();
            }
        }

        private void txtDescripcione_TextChanged(object sender, EventArgs e)
        {
            dbProductos xx = new dbProductos();
            dbgProductose.DataSource = null;
            dbgProductose.DataSource = xx.getproductosFiltroBusquedaDeshabilitado(txtDescripcione.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dbProductos xx = new dbProductos();
            dbgProductose.DataSource = xx.mostrarTodoProductoDeshabilitados();
        }

        private void txtCodigoe_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCerrar_Click(object sender, EventArgs e)
        {

            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close();
        }

        private void txtCancelar_Click(object sender, EventArgs e)
        {
            txtCodigoe.Enabled = true;
            txtStocke.Text = "";
            txtCodigoe.Text = "";
            txtDescripcione.Text = "";
            txtCostoe.Text = "";
            txtPrecioe.Text = "";
            comboBox1.Text = "";
            txtBuscar2.Text = "";
        }

        private void txtCodigoe_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDescripcione_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtCostoe_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
