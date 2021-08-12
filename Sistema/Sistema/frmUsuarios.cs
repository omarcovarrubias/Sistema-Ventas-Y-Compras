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
    public partial class frmUsuarios : Form
    {
        Empleado emp;
        private DataTable datos = new DataTable();

        public frmUsuarios()
        {
            InitializeComponent();
            emp = new Empleado();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }
        public void nuevo()
        {
            dbEmpleado db = new dbEmpleado();
            dbgEmpleados.DataSource = null;            
            dbgEmpleados.DataSource = db.mostrarTodoEmpleado();
            btnNuevo.Enabled = false;
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnBuscar.Enabled = true;
            btnHabilitar.Enabled = false;
            btnDesHabilitar.Enabled = false;
            btnLimpiar.Enabled = true;
            btnCancelar.Enabled = true;

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
              Empleado obj = new Empleado();
            if (txtCodigo.Text.Equals("") || txtNombre.Text.Equals("") || txtApellidos.Text.Equals("") || txtDireccion.Text.Equals("") || txtUsuario.Text.Equals("") || txtContra.Text.Equals("") || txtCorreo.Text.Equals("") || comboBox1.Text.Equals("") || dateTimePicker1.Equals("") || txtTelefono.Text.Equals(""))
            {
                MessageBox.Show("Falto capturar información.", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (comboBox1.Text == "1_Administrador")
                {
                    comboBox1.Text = "1";
                }
                if (comboBox1.Text == "2_Usuario")
                {
                    comboBox1.Text = "2";
                }
                obj.Codigo = int.Parse(txtCodigo.Text);
                obj.NombreEmpleado = txtNombre.Text;
                obj.Correo = txtCorreo.Text;
                obj.Apellidos = txtApellidos.Text;
                obj.Domicilio = txtDireccion.Text;
                obj.Usuario = txtUsuario.Text;
                obj.Contraseña = txtContra.Text;
                obj.Correo = txtCorreo.Text;
                obj.Rol = comboBox1.Text;
                obj.Fecha = dateTimePicker1.Text;
                obj.Telefono = txtTelefono.Text;


                dbEmpleado db = new dbEmpleado();
                if (db.existe(obj.Codigo) || (db.existeU(obj.Usuario))) MessageBox.Show("Ya existe el codigo o usuario.", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                    else
                    {
                        db.Agregar(obj);
                        MessageBox.Show("Se agrego con exito.", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbgEmpleados.DataSource = null;
                        dbgEmpleados.DataSource = db.mostrarTodoEmpleado();

                        btnActualizar.Enabled = false;
                        btnLimpiar.Enabled = false;
                        btnActualizar.Enabled = false;
                        btnBuscar.Enabled = false;
                        btnDesHabilitar.Enabled = false;
                        btnNuevo.Enabled = true;
                        btnAgregar.Enabled = false;




                    
                }


                /*    if (db.existe(obj.Codigo)) MessageBox.Show("Ya existe el codigo.", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    else
                    {
                        db.Agregar(obj);
                        MessageBox.Show("Se agrego con exito.", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbgEmpleados.DataSource = null;
                        dbgEmpleados.DataSource = db.mostrarTodoEmpleado();
                        /* txtNombre.Text = datos.Rows[0]["Nombre"].ToString();
                       txtApellidoP.Text = datos.Rows[0]["A_Paterno"].ToString();
                       txtApellidoM.Text = datos.Rows[0]["A_Materno"].ToString();
                       txtCorreo.Text = datos.Rows[0]["Correo_Electronico"].ToString();
                       txtColonia.Text = datos.Rows[0]["Colonia"].ToString();
                       txtCalle.Text = datos.Rows[0]["Calle"].ToString();
                       txtNumero.Text = datos.Rows[0]["Numero"].ToString();
                       txtCodigo.Enabled = false;
                       */
                /*      btnActualizar.Enabled = false;
                      btnLimpiar.Enabled = false;
                      btnActualizar.Enabled = false;
                      btnBuscar.Enabled = false;
                      btnDesHabilitar.Enabled = false;
                      btnNuevo.Enabled = true;
                      btnAgregar.Enabled = false;

                  }*/
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Empleado obj = new Empleado();
            if (txtCodigo.Text.Equals("") || txtNombre.Text.Equals("") || txtApellidos.Text.Equals("") || txtDireccion.Text.Equals("") || txtUsuario.Text.Equals("") || txtContra.Text.Equals("") || txtCorreo.Text.Equals("") || comboBox1.Text.Equals("") || dateTimePicker1.Equals("") || txtTelefono.Text.Equals(""))
            {
                MessageBox.Show("Falto capturar información.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
             
                btnActualizar.Enabled = true;
                obj.Codigo = int.Parse(txtCodigo.Text);
                obj.NombreEmpleado = txtNombre.Text;
                obj.Correo = txtCorreo.Text;
                obj.Apellidos = txtApellidos.Text;
                obj.Domicilio = txtDireccion.Text;
                obj.Usuario = txtUsuario.Text;
                obj.Contraseña = txtContra.Text;
                obj.Correo = txtCorreo.Text;
                obj.Rol = comboBox1.Text;
                obj.Fecha = dateTimePicker1.Text;
                obj.Telefono = txtTelefono.Text;
                dbEmpleado db = new dbEmpleado();
                //if (db.existe(obj.Codigo))  MessageBox.Show("No se encontró.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.Modificar(obj);
                MessageBox.Show("Se modificó con exito", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgEmpleados.DataSource = null;
                dbgEmpleados.DataSource = db.mostrarTodoEmpleado();
                cancelar();
                //Limpiar();

            }
        }

        private void btnDesHabilitar_Click(object sender, EventArgs e)
        {
            Empleado obj = new Empleado();
            if (txtCodigo.Text.Equals(""))
            {
                MessageBox.Show("Falta capturar informacion", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = int.Parse(txtCodigo.Text);
                dbEmpleado db = new dbEmpleado();
                db.deshabilitarEmpleado(int.Parse(txtCodigo.Text));
                MessageBox.Show("Se Deshabilitó con exito", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgEmpleados.DataSource = null;
                dbgEmpleadoe.DataSource = null;
                dbgEmpleados.DataSource = db.mostrarTodoEmpleado();
                dbgEmpleados.DataSource = db.mostrarTodosDeshabilitadosEmpleado();
                

            }
        }

        private void btnBuscare_Click(object sender, EventArgs e)
        {
            if (txtCodigoe.Text != "")
            {
                datos = null;
                dbEmpleado db = new dbEmpleado();
                datos = db.buscarDeshabilitados(int.Parse(txtCodigoe.Text));
                if (datos.Rows.Count == 0) MessageBox.Show("No se encontro. ", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    txtCodigoe.Enabled = false;
                    btnNuevoe.Enabled = false;
                    dbgEmpleados.DataSource = datos;
                    txtNombree.Text = datos.Rows[0]["nombreEmpleado"].ToString();
                    txtApellidose.Text = datos.Rows[0]["apellidos"].ToString();
                    txtDireccione.Text = datos.Rows[0]["domicilio"].ToString();
                    txtUsuarioe.Text = datos.Rows[0]["usuario"].ToString();
                    txtContraseñae.Text = datos.Rows[0]["contraseña"].ToString();
                    txtCorreoe.Text = datos.Rows[0]["correo"].ToString();
                    txtTelefonoe.Text = datos.Rows[0]["telefono"].ToString();
                    cmbPrivilegiose.Text = datos.Rows[0]["Rol_id"].ToString();
                    dateTimePicker4.Text = datos.Rows[0]["fecha"].ToString();                 
                    btnBuscare.Enabled = true;
                    btnLimpiar.Enabled = true;
                    btnCancelar.Enabled = true;
                    button1.Enabled = true;
                    btnHabilitar.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Falta capturar información.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            Empleado obj = new Empleado();
            if (txtCodigoe.Text.Equals(""))
            {
                MessageBox.Show("Falta capturar información", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = int.Parse(txtCodigoe.Text);
                dbEmpleado db = new dbEmpleado();
                db.habilitarRegistro(int.Parse(txtCodigoe.Text));
                MessageBox.Show("Se habilitó con exito", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgEmpleadoe.DataSource = null;
                dbgEmpleadoe.DataSource = db.mostrarTodosDeshabilitadosEmpleado();
                limpiar2();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (txtCodigo.Text != "")
            {
                datos = null;
                dbEmpleado db = new dbEmpleado();
                datos = db.buscarEmpleado(int.Parse(txtCodigo.Text));
                if (datos.Rows.Count == 0) MessageBox.Show("No se encontro. ", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    dbgEmpleados.DataSource = datos;
                    txtNombre.Text = datos.Rows[0]["nombreEmpleado"].ToString();
                    txtApellidos.Text = datos.Rows[0]["apellidos"].ToString();
                    txtDireccion.Text = datos.Rows[0]["domicilio"].ToString();
                    txtUsuario.Text = datos.Rows[0]["usuario"].ToString();
                    txtContra.Text = datos.Rows[0]["contraseña"].ToString();
                    txtCorreo.Text = datos.Rows[0]["correo"].ToString();
                    txtTelefono.Text = datos.Rows[0]["telefono"].ToString();
                    comboBox1.Text = datos.Rows[0]["Rol_id"].ToString();
                    dateTimePicker1.Text = datos.Rows[0]["fecha"].ToString();
                    txtCodigo.Enabled = false;                                        
                    btnNuevo.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnActualizar.Enabled = true;
                    btnBuscar.Enabled = true;                    
                    btnDesHabilitar.Enabled = true;
                    btnLimpiar.Enabled = true;
                    btnCancelar.Enabled = true;
                    button1.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Falta capturar información.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }
        public void cancelar()
        {
            btnAgregar.Enabled = false;
            btnDesHabilitar.Enabled = false;
            btnNuevo.Enabled = true;
            btnActualizar.Enabled = false;
            btnBuscar.Enabled = false;
            btnActualizar.Enabled = false;
            btnLimpiar.Enabled = false;
            button1.Enabled = false;
            txtCodigo.Enabled = true;
            limpiar();
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        public void limpiar()
        {
            dbgEmpleados.DataSource = null;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtUsuario.Text = "";
            txtContra.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close();
        }

        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            limpiar2();
        }
        public void limpiar2()
        {
            btnNuevoe.Enabled = true;
            txtCodigoe.Enabled = true;
            btnHabilitar.Enabled = false;
            dbgEmpleadoe.DataSource = null;
            txtCodigoe.Text = "";
            txtNombree.Text = "";
            txtApellidose.Text = "";
            txtCorreoe.Text = "";
            txtUsuarioe.Text = "";
            txtContraseñae.Text = "";
            cmbPrivilegiose.Text = "";
            dateTimePicker4.Text = "";
            txtTelefonoe.Text = "";
            txtDireccione.Text = "";
        }

        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Desea cerrar la ventana?", "Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes) this.Close();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            dbgEmpleados.AllowUserToAddRows = false;
            dbgEmpleadoe.AllowUserToAddRows = false;
            btnBuscare.Enabled = false;
            btnHabilitar.Enabled = false;
            btnNuevo.Enabled = true;
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = false;
            btnBuscar.Enabled = false;
            btnHabilitar.Enabled = false;
            btnDesHabilitar.Enabled = false;
            btnLimpiar.Enabled = false;
            btnCancelar.Enabled = false;
            button1.Enabled = false;
         }

        private void dbgEmpleados_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (dbgEmpleados.CurrentRow != null)
            {
                txtCodigo.Text = dbgEmpleados.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dbgEmpleados.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = dbgEmpleados.CurrentRow.Cells[2].Value.ToString();
                txtCorreo.Text = dbgEmpleados.CurrentRow.Cells[3].Value.ToString();
                txtUsuario.Text = dbgEmpleados.CurrentRow.Cells[4].Value.ToString();
                txtContra.Text = dbgEmpleados.CurrentRow.Cells[5].Value.ToString();
                comboBox1.Text = dbgEmpleados.CurrentRow.Cells[6].Value.ToString();
                txtTelefono.Text = dbgEmpleados.CurrentRow.Cells[10].Value.ToString();
                txtDireccion.Text = dbgEmpleados.CurrentRow.Cells[11].Value.ToString();
                                               
                              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Empleado obj = new Empleado();
            if (txtCodigo.Text.Equals(""))
            {
                MessageBox.Show("Falta capturar informacion", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Codigo = int.Parse(txtCodigo.Text);
                dbEmpleado db = new dbEmpleado();
                db.EliminarEmpleado(int.Parse(txtCodigo.Text));
                MessageBox.Show("Se Elimino con exito", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbgEmpleados.DataSource = null;                
                dbgEmpleados.DataSource = db.mostrarTodoEmpleado();                

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

        private void txtNombree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnNuevoe_Click(object sender, EventArgs e)
        {
            btnBuscare.Enabled = true;
            dbEmpleado db = new dbEmpleado();
            dbgEmpleadoe.DataSource = null;
            dbgEmpleadoe.DataSource = db.mostrarTodosDeshabilitadosEmpleado();
            txtCodigoe.Enabled = true;
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

        private void txtApellidose_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
                return;
            }
        }

        private void dbgEmpleadoe_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (dbgEmpleadoe.CurrentRow != null)
            {
                txtCodigoe.Text = dbgEmpleadoe.CurrentRow.Cells[0].Value.ToString();
                txtNombree.Text = dbgEmpleadoe.CurrentRow.Cells[1].Value.ToString();
                txtApellidose.Text = dbgEmpleadoe.CurrentRow.Cells[2].Value.ToString();
                txtCorreoe.Text = dbgEmpleadoe.CurrentRow.Cells[3].Value.ToString();
                txtUsuarioe.Text = dbgEmpleadoe.CurrentRow.Cells[4].Value.ToString();
                txtContraseñae.Text = dbgEmpleadoe.CurrentRow.Cells[5].Value.ToString();
                cmbPrivilegiose.Text = dbgEmpleadoe.CurrentRow.Cells[6].Value.ToString();
                txtTelefonoe.Text = dbgEmpleadoe.CurrentRow.Cells[10].Value.ToString();
                txtDireccione.Text = dbgEmpleadoe.CurrentRow.Cells[11].Value.ToString();


            }
        }

        private void cmbPrivilegiose_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dbEmpleado xx = new dbEmpleado();
            dbgEmpleados.DataSource = xx.getproductosFiltroBusqueda(txtNombre.Text);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTelefonoe_KeyPress(object sender, KeyPressEventArgs e)
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
