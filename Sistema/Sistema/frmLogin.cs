using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Sistema
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();

        }
        int intentos = 1;

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtcontra.Text;

            try
            {
                Control ctrl = new Control();
                string respuesta = ctrl.ctrlLogin(usuario, password);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (intentos < 3)
                    {
                        MessageBox.Show("Incorrecto, te quedan " + (3 - intentos) + " intentos más", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Has exedido tu número máximo de intentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Application.Exit();
                    }
                    intentos++;
                }
                else
                {
                    MessageBox.Show("Bienvenido(a): " + Session.nombre + "", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMenu frm = new frmMenu();
                    frm.Visible = true;
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (intentos < 3)
                {
                    MessageBox.Show("Incorrecto, te quedan " + (3 - intentos) + " intentos más", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Has exedido tu número máximo de intentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
                intentos++;
            }
        }
    
    /*
    if(txtUsuario.Text=="")
    {
        MessageBox.Show("Falto ingresar informacion", "Q'KARNE", MessageBoxButtons.OK, MessageBoxIcon.Information);                
        errorProvider1.SetError(txtUsuario, "Porfavor Ingresa el usuario!");                    
    }
    if (txtcontra.Text == "")
    {
        MessageBox.Show("Falto ingresar informacion", "Q'KARNE", MessageBoxButtons.OK, MessageBoxIcon.Information);                
        errorProvider1.SetError(txtcontra, "Porfavor Ingresa la contraseña!");
    }
    BaseDatos BD = new BaseDatos();
    if (BD.Conectar())
    {
        MySqlCommand comando = new MySqlCommand();
        MySqlDataReader lector;                                
        comando.Connection = BD.con;
        comando.CommandText = "SELECT * FROM empleado WHERE Rol_id='"+cmbPermisos.Text+"' AND usuario='" + txtUsuario.Text + "' AND contraseña = '" + txtcontra.Text + "'";
        lector = comando.ExecuteReader();

        if (lector.HasRows)
        {
            if(cmbPermisos.Text=="1")
            {
                MessageBox.Show("Bienvenido", "Q'KARNE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMenu menu = new frmMenu();
                //menu.label1.Text = txtUsuario.Text;   
                this.Hide();
                menu.Show();
                frmMenu ff = new frmMenu();
                ff.textBox1.Text = txtUsuario.Text;

            }
            if (cmbPermisos.Text=="2")
            {
                MessageBox.Show("Bienvenido", "Q'KARNE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmClientes cli = new frmClientes();
                //menu.label1.Text = txtUsuario.Text;
                this.Hide();
                cli.Show();
            }



        }                    

        else
        {
            if (intentos < 8)
            {
                MessageBox.Show("Incorrecto, te quedan " + (8 - intentos) + " intentos más", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Has exedido tu número máximo de intentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }   
            intentos++;

        }                
    }
 */

        private void button2_Click(object sender, EventArgs e)
        {
           /*
            BaseDatos BD = new BaseDatos();
            if (BD.Conectar())
            {
                MySqlCommand comando = new MySqlCommand();
                MySqlDataReader lector;
                comando.Connection = BD.con;
                comando.CommandText = "SELECT * FROM empleado WHERE Rol_id='" + comboBox1.Text + "' AND usuario='" +txtUsuario2.Text  + "' AND contraseña = '" + txtcontra2.Text + "'";
                lector = comando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (comboBox1.Text == "2")
                    {
                        MessageBox.Show("Bienvenido", "Q'KARNE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmMenuUsuario cli = new frmMenuUsuario();
                        //menu.label1.Text = txtUsuario.Text;
                        this.Hide();
                        cli.Show();
                        
                       
                    }


                }

                else
                {
                    if (intentos < 8)
                    {
                        MessageBox.Show("Incorrecto, te quedan " + (8 - intentos) + " intentos más", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Has exedido tu número máximo de intentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Application.Exit();
                    }
                    intentos++;

                }
            }*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Seguro que desea salir del sistema?", "DIGITS AND BITS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes)
            {
                Application.Exit();
                this.Close();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtUsuario.Text == "")
            {
            }
            string carac = "qwertyuiopasdfghjklñzxcvbnm1234567890 " + (char)8;
            if (!carac.Contains(e.KeyChar))
            {
                e.Handled = true;
                buttonIngresar.PerformClick();
            }
        }

        private void txtcontra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtcontra.Text == "")
            {
            }
            string carac = "qwertyuiopasdfghjklñzxcvbnm1234567890 " + (char)8;
            if (!carac.Contains(e.KeyChar))
            {
                e.Handled = true;
                buttonIngresar.PerformClick();
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Seguro que desea salir del sistema?", "DIGIT AND BITS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (opcion == DialogResult.Yes)
            {
                Application.Exit();
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cmbPermisos.Visible = false;
            comboBox1.Visible = false;
            tabControl1.TabPages.Remove(tabPage2);
            

        }
       
        private void checkVerPasw_CheckedChanged(object sender, EventArgs e)
        {
           if(checkVerPasw.Checked==true)
           {
               if (txtcontra.PasswordChar == '*')
               {
                   txtcontra.PasswordChar = '\0';
               }
               else
               {
                   txtcontra.PasswordChar = '*';
               }
           }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                if (txtcontra2.PasswordChar == '*')
                {
                    txtcontra2.PasswordChar = '\0';
                }
                else
                {
                    txtcontra2.PasswordChar = '*';
                }
            }
        }
    }
}
