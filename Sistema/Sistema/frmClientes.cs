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
    public partial class frmClientes : Form
    {
        private DataTable datos = new DataTable();

        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();

        }
        public void nuevo()
        {
            dbClientes db = new dbClientes();
            dbgClientes.DataSource = null;
            dbgClientese.DataSource = null;
            dbgClientes.DataSource = db.mostrarTodoCliente();
            dbgClientese.DataSource = db.mostrarTodosDeshabilitadosCliente();
            btnNuevo.Enabled = false;
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnBuscar.Enabled = true;
            btnHabilitar.Enabled = false;
            btnDesHabilitar.Enabled = false;
            btnLimpiar.Enabled = true;
            txtNombre.Enabled = true;
            txtCorreo.Enabled = true;
            txtNumero.Enabled = true;
            txtCodigo.Enabled = true;
            btnCancelar.Enabled = true;
            txtApellidos.Enabled = true;
            txtCalle.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancel();
            Limpiar();
        }
        public void cancel()
        {
            txtCodigo.Text = "";
            txtNombre.Enabled = false;
            txtCorreo.Enabled = false;
            txtCalle.Enabled = false;
            txtNumero.Enabled = false;
            txtCodigo.Enabled = false;
            btnNuevo.Enabled = true;
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = false;
            btnBuscar.Enabled = true;
            btnHabilitar.Enabled = false;
            btnDesHabilitar.Enabled = false;
            btnLimpiar.Enabled = false;
            btnCancelar.Enabled = false;
            txtApellidos.Text = "";
            txtApellidos.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();

        }
        public void Limpiar()
        {
            dbgClientes.DataSource = null;
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtCalle.Text = "";
            txtNumero.Text = "";
            btnDesHabilitar.Enabled = false;
            btnActualizar.Enabled = false;
            txtApellidos.Text = "";
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            if (txtCodigo.Text.Equals("") || txtNombre.Text.Equals("") || txtCorreo.Text.Equals("")|| txtCalle.Text.Equals("") || txtNumero.Text.Equals("") || dateTimePicker1.Equals("") || dateTimePicker2.Equals("")||txtApellidos.Text.Equals(""))
            {
                MessageBox.Show("Falto capturar información.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = int.Parse(txtCodigo.Text);
                obj.Nombre = txtNombre.Text;
                obj.Correo = txtCorreo.Text;
                obj.Apellidos = txtApellidos.Text;
                obj.Colonia = txtCalle.Text;
                obj.Numero = txtNumero.Text;
                obj.Fecha = dateTimePicker1.Text;
                obj.Horario = dateTimePicker2.Text;

                dbClientes db = new dbClientes();
                if (db.existe(obj.Codigo)) MessageBox.Show("Ya existe.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    db.Agregar(obj);
                    MessageBox.Show("Se agrego con exito.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbgClientes.DataSource = null;
                    dbgClientes.DataSource = db.mostrarTodoCliente();
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
                    btnDesHabilitar.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnAgregar.Enabled = false;
                    Limpiar();

                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            if (txtCodigo.Text.Equals("") || txtNombre.Text.Equals("") || txtCorreo.Text.Equals("") || txtCalle.Text.Equals("") || txtNumero.Text.Equals("")||txtApellidos.Text.Equals(""))
            {
                MessageBox.Show("Falto capturar información.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                btnActualizar.Enabled = true;
                obj.Codigo = int.Parse(txtCodigo.Text);
                obj.Nombre = txtNombre.Text;
                obj.Apellidos = txtApellidos.Text;
                obj.Correo = txtCorreo.Text;
                obj.Colonia = txtCalle.Text;
                obj.Numero = txtNumero.Text;
                obj.Fecha = dateTimePicker1.Text;
                dbClientes db = new dbClientes();
                //if (db.existe(obj.Codigo))  MessageBox.Show("No se encontró.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.Modificar(obj);
                MessageBox.Show("Se modificó con exito", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgClientes.DataSource = null;
                dbgClientes.DataSource = db.mostrarTodoCliente();
                Limpiar();

            }
        }

        private void btnDesHabilitar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            if (txtCodigo.Text.Equals(""))
            {
                MessageBox.Show("Falta capturar informacion", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = int.Parse(txtCodigo.Text);
                dbClientes db = new dbClientes();
                db.deshabilitarCliente(int.Parse(txtCodigo.Text));
                MessageBox.Show("Se Deshabilitó con exito", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgClientes.DataSource = null;
                dbgClientese.DataSource = null;
                dbgClientes.DataSource = db.mostrarTodoCliente();
                dbgClientese.DataSource = db.mostrarTodosDeshabilitadosCliente();
                Limpiar();

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                datos = null;
                dbClientes db = new dbClientes();
                datos = db.buscarCliente(int.Parse(txtCodigo.Text));
                if (datos.Rows.Count == 0) MessageBox.Show("No se encontro. ", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    btnAgregar.Enabled = false;
                    btnEliminar.Enabled = true;
                    dbgClientes.DataSource = datos;
                    txtNombre.Text = datos.Rows[0]["nombreCliente"].ToString();
                    txtCodigo.Text=datos.Rows[0]["codigo"].ToString();
                    txtApellidos.Text = datos.Rows[0]["apellidos"].ToString();
                    txtCorreo.Text = datos.Rows[0]["correo"].ToString();
                    txtCalle.Text = datos.Rows[0]["direccion"].ToString();
                    txtNumero.Text = datos.Rows[0]["numeroCelular"].ToString();
                    dateTimePicker1.Text = datos.Rows[0]["fecha"].ToString();                    
                    txtCodigo.Enabled = false;
                    btnDesHabilitar.Enabled = true;
                    btnActualizar.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Falta capturar información.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
            }
        }

        private void btnBuscare_Click(object sender, EventArgs e)
        {
            if (txtCodigoe.Text != "")
            {
                datos = null;
                dbClientes db = new dbClientes();
                datos = db.buscarDeshabilitados(int.Parse(txtCodigoe.Text));
                if (datos.Rows.Count == 0) MessageBox.Show("No se encontró el cliente.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    dbgClientese.DataSource = datos;
                    dbgClientese.DataSource = db.mostrarTodosDeshabilitadosCliente();
                    txtNombree.Text = datos.Rows[0]["nombreCliente"].ToString();
                    txtCodigoe.Text = datos.Rows[0]["codigo"].ToString();
                    txtApellidos.Text = datos.Rows[0]["apellidos"].ToString();
                    txtCorreoElectronicoe.Text = datos.Rows[0]["correo"].ToString();
                    txtCallee.Text = datos.Rows[0]["direccion"].ToString();
                    txtNumeroe.Text = datos.Rows[0]["numeroCelular"].ToString();
                    dateTimePicker1.Text = datos.Rows[0]["fecha"].ToString();               
                    btnLimpiar2.Enabled = true;
                    btnHabilitar.Enabled = true;

                }
            }
            else
            {
                MessageBox.Show("Falta capturar información.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigoe.Focus();
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            if (txtCodigoe.Text.Equals(""))
            {
                MessageBox.Show("Falta capturar información", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = int.Parse(txtCodigoe.Text);
                dbClientes db = new dbClientes();
                db.habilitarRegistro(int.Parse(txtCodigoe.Text));
                MessageBox.Show("Se habilitó con exito", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgClientes.DataSource = null;
                dbgClientese.DataSource = null;
                dbgClientes.DataSource = db.mostrarTodoCliente();
                dbgClientese.DataSource = db.mostrarTodosDeshabilitadosCliente();
                limpiar2();
            }
        }

        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            dbgClientese.DataSource = null;
            limpiar2();
        }
        public void limpiar2()
        {
            txtCodigoe.Text = "";
            txtNombree.Text = "";
            txtCorreoElectronicoe.Text = "";
            txtColoniae.Text = "";
            txtCallee.Text = "";
            txtNumeroe.Text = "";
        }
        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            btnEliminar.Visible = false;
            btnEliminar.Enabled = false;
            dbgClientes.AllowUserToAddRows = false;
            dbgClientese.AllowUserToAddRows = false;
            dbClientes db = new dbClientes();
            dbgClientese.DataSource = db.mostrarTodosDeshabilitadosCliente();
            dbgClientes.DataSource = db.mostrarTodoCliente();
            dateTimePicker2.Visible = false;
            btnEliminar.Enabled = false;
            cancel();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dbgClientese_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void dbgClientes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            if (dbgClientes.CurrentRow != null)
            {
                txtCodigo.Text = dbgClientes.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dbgClientes.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = dbgClientes.CurrentRow.Cells[2].Value.ToString();
                txtCalle.Text = dbgClientes.CurrentRow.Cells[3].Value.ToString();
                txtCorreo.Text = dbgClientes.CurrentRow.Cells[4].Value.ToString();
                txtNumero.Text = dbgClientes.CurrentRow.Cells[5].Value.ToString();
             
            }
           
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dbClientes xx = new dbClientes();
            dbgClientes.DataSource = xx.getproductosFiltroBusqueda(txtNombre.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            if (txtCodigo.Text.Equals(""))
            {
                MessageBox.Show("Falta capturar informacion", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = int.Parse(txtCodigo.Text);
                dbClientes db = new dbClientes();
                db.EliminarCliente(int.Parse(txtCodigo.Text));
                MessageBox.Show("Se Elimino con exito", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgClientes.DataSource = null;
                dbgClientes.DataSource = db.mostrarTodoCliente();
                btnEliminar.Enabled = false;

            }

            //int idEliminar = int.Parse((dbgEmpleados.CurrentRow.Cells[0].Value.ToString()));
            //DialogResult resp;
            //resp = MessageBox.Show("¿Eliminar este usuario?", "Eliminar", MessageBoxButtons.YesNo);
            //if (resp == DialogResult.Yes)
            //{
            //    dbEmpleado x = new dbEmpleado();
            //    x.Eliminar(idEliminar);
            //    dbgEmpleados.DataSource = x.mostrarTodoEmpleado();
            //    MessageBox.Show("Usuario eliminado");

            //}
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
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
