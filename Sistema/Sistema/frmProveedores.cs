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
    public partial class frmProveedores : Form
    {
        private DataTable datos = new DataTable();

        public frmProveedores()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }
        public void nuevo()
        {
            btnAgregar.Enabled = true;        
            btnBuscar.Enabled = true;
            txtCodigo.Enabled = true;
            limpiar();
       
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedores obj = new Proveedores();
            if (txtCodigo.Text.Equals("") || txtNombre.Text.Equals("") || txtApellidos.Text.Equals("")||txtDireccion.Text.Equals("")|| txtCorreo.Text.Equals("")||txtCelular.Text.Equals("")||dateTimePicker1.Text.Equals("")||txtEmpresa.Text.Equals(""))
            {
                MessageBox.Show("Falto capturar información.", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = int.Parse(txtCodigo.Text);
                obj.Nombreproveedor = txtNombre.Text;
                obj.Apellidos = txtApellidos.Text;
                obj.Direccion = txtDireccion.Text;
                obj.Correo = txtCorreo.Text;
                obj.Numerocelular = txtCelular.Text;
                obj.Fecha = dateTimePicker1.Text;
                obj.Empresa = txtEmpresa.Text;

                dbProveedores db = new dbProveedores();
                if (db.existe(obj.Codigo)) MessageBox.Show("Ya existe.", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    db.Agregar(obj);
                    MessageBox.Show("Se agrego con exito.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbgProveedores.DataSource = null;
                    dbgProveedores.DataSource = db.mostrarTodoProveedor();
                    /* txtNombre.Text = datos.Rows[0]["Nombre"].ToString();
                   txtApellidoP.Text = datos.Rows[0]["A_Paterno"].ToString();
                   txtApellidoM.Text = datos.Rows[0]["A_Materno"].ToString();
                   txtCorreo.Text = datos.Rows[0]["Correo_Electronico"].ToString();
                   txtColonia.Text = datos.Rows[0]["Colonia"].ToString();
                   txtCalle.Text = datos.Rows[0]["Calle"].ToString();
                   txtNumero.Text = datos.Rows[0]["Numero"].ToString();
                   txtCodigo.Enabled = false;
                   */
                    //btnActualizar.Enabled = false;
                    //btnLimpiar.Enabled = false;
                    //btnActualizar.Enabled = false;
                    //btnBuscar.Enabled = false;
                    //btnDesHabilitar.Enabled = false;
                    //btnNuevo.Enabled = true;
                    //btnAgregar.Enabled = false;

                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Proveedores obj = new Proveedores();
            if (txtCodigo.Text.Equals("") || txtNombre.Text.Equals("") || txtApellidos.Text.Equals("") || txtDireccion.Text.Equals("") || txtCorreo.Text.Equals("") || txtCelular.Text.Equals("") || dateTimePicker1.Text.Equals("") || txtEmpresa.Text.Equals(""))
            {
                MessageBox.Show("Falto capturar información.", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                btnActualizar.Enabled = true;
                obj.Codigo = int.Parse(txtCodigo.Text);
                obj.Nombreproveedor = txtNombre.Text;
                obj.Apellidos = txtApellidos.Text;
                obj.Direccion = txtDireccion.Text;
                obj.Correo = txtCorreo.Text;
                obj.Numerocelular = txtCelular.Text;
                obj.Fecha = dateTimePicker1.Text;
                obj.Empresa = txtEmpresa.Text;
                dbProveedores db = new dbProveedores();
                //if (db.existe(obj.Codigo))  MessageBox.Show("No se encontró.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.Modificar(obj);
                MessageBox.Show("Se modificó con exito", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgProveedores.DataSource = null;
                dbgProveedores.DataSource = db.mostrarTodoProveedor();


            }
        }

        private void btnDesHabilitar_Click(object sender, EventArgs e)
        {
            Proveedores obj = new Proveedores();
            if (txtCodigo.Text.Equals(""))
            {
                MessageBox.Show("Falta capturar informacion", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = int.Parse(txtCodigo.Text);
                dbProveedores db = new dbProveedores();
                db.deshabilitarProveedor(int.Parse(txtCodigo.Text));
                MessageBox.Show("Se Deshabilitó con exito", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgProveedores.DataSource = null;
                dbgProveedores.DataSource = null;
                dbgProveedores.DataSource = db.mostrarTodoProveedor();
                dbgProveedorese.DataSource = db.mostrarTodosDeshabilitadosProveedor();
                limpiar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                datos = null;
                dbProveedores db = new dbProveedores();
                datos = db.buscarProveedor(int.Parse(txtCodigo.Text));
                if (datos.Rows.Count == 0) MessageBox.Show("No se encontro. ", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    dbgProveedores.DataSource = datos;
                    txtNombre.Text = datos.Rows[0]["nombreProveedor"].ToString();
                    txtCodigo.Text = datos.Rows[0]["codigo"].ToString();
                    txtApellidos.Text = datos.Rows[0]["apellidos"].ToString();
                    txtDireccion.Text = datos.Rows[0]["direccion"].ToString();
                    txtCorreo.Text = datos.Rows[0]["correo"].ToString();                    
                    txtCelular.Text = datos.Rows[0]["numeroCelular"].ToString();
                    dateTimePicker1.Text = datos.Rows[0]["fecha"].ToString();
                    txtEmpresa.Text = datos.Rows[0]["empresa"].ToString();
                    txtCodigo.Enabled = false;
                    btnDesHabilitar.Enabled = true;
                    btnActualizar.Enabled = true;
                    btnAgregar.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Falta capturar información.", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
            }
        }

        private void btnBuscare_Click(object sender, EventArgs e)
        {
            if (txtCodigoe.Text != "")
            {
                datos = null;
                dbProveedores db = new dbProveedores();
                datos = db.buscarDeshabilitados(int.Parse(txtCodigoe.Text));
                if (datos.Rows.Count == 0) MessageBox.Show("No se encontro. ", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    dbgProveedorese.DataSource = datos;
                    txtNombree.Text = datos.Rows[0]["nombreProveedor"].ToString();
                    txtCodigoe.Text = datos.Rows[0]["codigo"].ToString();
                    txtApellidose.Text = datos.Rows[0]["apellidos"].ToString();
                    txtDireccione.Text = datos.Rows[0]["direccion"].ToString();
                    txtCorreoe.Text = datos.Rows[0]["correo"].ToString();
                    txtCelulare.Text = datos.Rows[0]["numeroCelular"].ToString();
                    dateTimePicker1.Text = datos.Rows[0]["fecha"].ToString();
                    txtEmpresae.Text = datos.Rows[0]["empresa"].ToString();
                    txtCodigoe.Enabled = false;                                        
                    btnHabilitar.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Falta capturar información.", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            Proveedores obj = new Proveedores();
            if (txtCodigoe.Text.Equals(""))
            {
                MessageBox.Show("Falta capturar información", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = int.Parse(txtCodigoe.Text);
                dbProveedores db = new dbProveedores();
                db.habilitarRegistro(int.Parse(txtCodigoe.Text));
                MessageBox.Show("Se habilitó con exito", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgProveedorese.DataSource = null;
                dbgProveedorese.DataSource = null;
                dbgProveedorese.DataSource = db.mostrarTodoProveedor();
                dbgProveedorese.DataSource = db.mostrarTodosDeshabilitadosProveedor();
                
            }
        }

        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            limpiar2();
        }
        public void limpiar2()
        {
            txtNombree.Text = "";
            txtCodigoe.Text = "";
            txtApellidose.Text = "";
            txtDireccione.Text = "";
            txtCorreoe.Text = "";
            txtCelulare.Text = "";
            dateTimePicker1.Text = "";
            txtEmpresae.Text = "";
            txtCodigoe.Enabled = true;
        }

        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close(); Close();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            dbgProveedores.AllowUserToAddRows = false;
            dbgProveedorese.AllowUserToAddRows = false;
            dbProveedores db = new dbProveedores();
            dbgProveedores.DataSource = db.mostrarTodoProveedor();
            dbgProveedorese.DataSource = db.mostrarTodosDeshabilitadosProveedor();
            cancelar();
            btnHabilitar.Enabled = false;
            dateTimePicker2.Visible = false;
            dateTimePicker3.Visible = false;
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        public void limpiar()
        {
            txtNombre.Text = "";
            txtCodigo.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtCelular.Text = "";
            dateTimePicker1.Text = "";
            txtEmpresa.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }
        public void cancelar()
        {
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = false;
            btnLimpiar.Enabled = false;
            btnBuscar.Enabled = false;
            btnDesHabilitar.Enabled = false;
            btnNuevo.Enabled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close(); Close();
        }

        private void dbgProveedorese_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dbProveedores xx = new dbProveedores();
            dbgProveedores.DataSource = xx.getproductosFiltroBusqueda(txtNombre.Text);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
