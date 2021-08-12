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
    public partial class frmServicios : Form
    {
        private DataTable datos = new DataTable();

        public frmServicios()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                datos = null;
                dbProductos db = new dbProductos();
                datos = db.buscarServicio(int.Parse(txtCodigo.Text));
                if (datos.Rows.Count == 0) MessageBox.Show("No se encontro. ", "SERVICIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    btnDesHabilitar.Enabled = true;
                    dvgServicios.DataSource = datos;
                    txtCodigo.Text = datos.Rows[0]["codigo"].ToString();
                    txtDescripcion.Text = datos.Rows[0]["servicios"].ToString();                    
                    txtPrecio.Text = datos.Rows[0]["precio"].ToString();                                        
                    txtCodigo.Enabled = false;
                    btnAgregar.Enabled = false;                    
                    btnActualizar.Enabled = true;                   
                    btnBuscar.Enabled = true;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
            btnAgregar.Enabled = true;           
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            dbProductos xx = new dbProductos();
            dvgServicios.DataSource = null;
            dvgServicios.DataSource = xx.mostrarTodosServicios();

            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Servicios obj = new Servicios();
            if (txtCodigo.Text.Equals("") || txtDescripcion.Text.Equals("") || txtPrecio.Text.Equals("") )
            {
                MessageBox.Show("Falto capturar información.", "SERVICIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                obj.Codigo = txtCodigo.Text;
                obj.Descripcion = txtDescripcion.Text;
                obj.Precio = decimal.Parse(txtPrecio.Text);                                
                dbProductos db = new dbProductos();
                if (db.existeServicio(obj.Codigo)) MessageBox.Show("Ya existe.", "SERVICIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    db.AgregarServicios(obj);
                    MessageBox.Show("Se agrego con exito.", "SERVICIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dvgServicios.DataSource = null;
                    dvgServicios.DataSource = db.mostrarTodosServicios();
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Servicios obj = new Servicios();
            if (txtCodigo.Text.Equals("")|| txtDescripcion.Text.Equals("")|| txtPrecio.Text.Equals(""))
            {
                MessageBox.Show("Falto capturar información.", "SERVICIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                btnActualizar.Enabled = true;
                obj.Codigo = txtCodigo.Text;
                obj.Descripcion = txtDescripcion.Text;
                obj.Precio = decimal.Parse(txtPrecio.Text);
                dbProductos db = new dbProductos();
                //if (db.existe(obj.Codigo))  MessageBox.Show("No se encontró.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.ModificarServicios(obj);
                MessageBox.Show("Se modificó con exito", "SERVICIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dvgServicios.DataSource = null;
                dvgServicios.DataSource = db.mostrarTodosServicios();
 
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = false;
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }
        public void limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dbProductos xx = new dbProductos();
            dvgServicios.DataSource = null;
            dvgServicios.DataSource = xx.mostrarTodosServicios();
            limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "SERVICIOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close();
        }

        private void btnBuscare_Click(object sender, EventArgs e)
        {
            if (txtCodigoe.Text != "")
            {
                datos = null;
                dbProductos db = new dbProductos();
                datos = db.buscarServiciosInactivos(int.Parse(txtCodigoe.Text));
                if (datos.Rows.Count == 0) MessageBox.Show("No se encontró el servicio.", "SERVICIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    txtCodigoe.Enabled = false;
                    btnBuscare.Enabled = false;
                    dvgServicios.DataSource = datos;
                    dvgServicios.DataSource = db.mostrarTodosServiciosInactivos();
                    txtCodigoe.Text = datos.Rows[0]["codigo"].ToString();
                    txtDescripcione.Text = datos.Rows[0]["servicios"].ToString();
                    txtPrecioe.Text = datos.Rows[0]["precio"].ToString();                    
                    btnHabilitar.Enabled = true;

                }
            }
            else
            {
                MessageBox.Show("Falta capturar información.", "SERVICIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoe.Focus();
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {

            Servicios obj = new Servicios();
            if (txtCodigoe.Text.Equals(""))
            {
                MessageBox.Show("Falta capturar información", "SERVICIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = txtCodigo.Text;
                dbProductos db = new dbProductos();
                db.habilitarServicios(int.Parse(txtCodigoe.Text));
                MessageBox.Show("Se habilitó con exito", "SERVICIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dvgServiciose.DataSource = null;
                dvgServiciose.DataSource = db.mostrarTodosServiciosInactivos();                
             }
        }

        private void btnCerrare_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "SERVICIOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close();
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            btnHabilitar.Enabled = false;
            btnDesHabilitar.Enabled = false;
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = false;
            btnBuscar.Enabled = false;
            btnNuevo.Enabled = true;
            dbProductos xx = new dbProductos();
            dvgServiciose.DataSource = xx.mostrarTodosServiciosInactivos();
            dvgServicios.DataSource = xx.mostrarTodosServicios();

        }

        private void btnCancelare_Click(object sender, EventArgs e)
        {
            dbProductos xx = new dbProductos();
            dvgServiciose.DataSource = xx.mostrarTodosServiciosInactivos();
            btnHabilitar.Enabled = false;
            btnBuscare.Enabled = true;
            txtCodigoe.Enabled = true;

        }

        private void btnLimpiare_Click(object sender, EventArgs e)
        {
            txtCodigoe.Text = "";
            txtDescripcione.Text = "";
            txtPrecioe.Text = "";
        }

        private void btnDesHabilitar_Click(object sender, EventArgs e)
        {

            Servicios obj = new Servicios();
            if (txtCodigo.Text.Equals(""))
            {
                MessageBox.Show("Falta capturar informacion", "SERVICIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = txtCodigo.Text;
                dbProductos db = new dbProductos();
                db.inhabilitarServicio(int.Parse(txtCodigo.Text));
                MessageBox.Show("Se Deshabilitó con exito", "SERVICIOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dvgServicios.DataSource = null;
                dvgServiciose.DataSource = null;
                dvgServicios.DataSource = db.mostrarTodosServicios();
                dvgServiciose.DataSource = db.mostrarTodosServiciosInactivos();


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

        private void txtPrecioe_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
