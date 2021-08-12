using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Proveedores
    {
        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private int idProveedor;

        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string nombreproveedor;

        public string Nombreproveedor
        {
            get { return nombreproveedor; }
            set { nombreproveedor = value; }
        }
        private string apellidos;

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        private string empresa;

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private string numerocelular;

        public string Numerocelular
        {
            get { return numerocelular; }
            set { numerocelular = value; }
        }
        public Proveedores()
        {
            idProveedor = 0;
            codigo = 0;
            nombreproveedor = "";
            apellidos = "";
            correo = "";
            empresa = "";
            direccion = "";
            numerocelular = "";
            status = 0;
            fecha = "";
        }
        public Proveedores(int i,int c,string np,string ap,string co,string em,string di,string num,int s,string fe)
        {
            idProveedor = i;
            codigo = c;
            nombreproveedor = np;
            apellidos = ap;
            correo = co;
            empresa = em;
            direccion = di;
            numerocelular = num;
            status = s;
            fecha = fe;
        }
        public Proveedores(Proveedores otro)
        {
            idProveedor = otro.idProveedor;
            codigo = otro.codigo;
            nombreproveedor = otro.nombreproveedor;
            apellidos = otro.apellidos;
            correo = otro.correo;
            empresa = otro.empresa;
            direccion = otro.direccion;
            numerocelular = otro.numerocelular;
            status = otro.status;
            fecha = otro.fecha;
        }

    
    }
}
