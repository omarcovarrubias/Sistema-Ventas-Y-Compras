using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Empleado
    {
        private int idempleado;
        private int codigo;
        private string nombreEmpleado;
        private string apellidos;
        private string correo;
        private string usuario;
        private string contraseña;      
        private string rol;
        private int status;
        private string telefono;
        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private string domicilio;

        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        public int Idempleado
        {
            get
            {
                return idempleado;
            }

            set
            {
                idempleado = value;
            }
        }

        public string NombreEmpleado
        {
            get
            {
                return nombreEmpleado;
            }

            set
            {
                nombreEmpleado = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return apellidos;
            }

            set
            {
                apellidos = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public string Contraseña
        {
            get
            {
                return contraseña;
            }

            set
            {
                contraseña = value;
            }
        }

        public string Rol
        {
            get
            {
                return rol;
            }

            set
            {
                rol = value;
            }
            
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public Empleado()
        {
            idempleado = 0;
            codigo = 0;
            nombreEmpleado = "";
            apellidos = "";
            correo = "";
            usuario = "";
            contraseña = "";
            rol = "";
            status = 0;
            telefono = "";
            domicilio = "";
            fecha = "";
        }
        public Empleado(int id, int cod, string nem, string ap, string co, string usu, string contra, string r, int s, string t, string doo, string fee)
        {
            idempleado = id;
            codigo = cod;
            nombreEmpleado = nem;
            apellidos = ap;
            correo = co;
            usuario = usu;
            contraseña = contra;
            rol = r;
            status = s;
            telefono = t;
            domicilio = doo;
            fecha = fee;
        }
        public Empleado(Empleado otro)
        {
            idempleado = otro.idempleado;
            codigo = otro.codigo;
            nombreEmpleado = otro.nombreEmpleado;
            apellidos = otro.nombreEmpleado;
            correo = otro.correo;
            usuario = otro.usuario;
            contraseña = otro.contraseña;
            rol = otro.rol;
            status = otro.status;
            telefono = otro.telefono;
            domicilio = otro.domicilio;
            fecha = otro.fecha;
        }

        
    }
}
