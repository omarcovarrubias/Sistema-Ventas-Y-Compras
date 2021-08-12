using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Servicios
    {
        private string descripcion;
        private decimal precio;
        private int status;
        private string codigo;

        public string Codigo
        {
            set { codigo = value; }
            get { return codigo; }
        }

        public string Descripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }

        public decimal Precio
        {
            set { precio = value; }
            get { return precio; }
        }
        public int Status
        {
            set { status = value; }
            get { return status; }
        }

        public Servicios()
        {
            codigo = "";
            descripcion = "";
            precio = 0;
            status = 0;        
        }
        public Servicios(string codigo,string descripcion,decimal precio,int status)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.precio = precio;
            this.status = status;
        }

        public Servicios(Servicios x)
        {
            this.codigo = x.codigo;
            this.descripcion = x.descripcion;
            this.precio = x.precio;
            this.status = x.status;
        }







    }
}
