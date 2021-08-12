using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class ProductosClientes
    {
        private string codigo;
        private string descripcion;
        private string cliente;
        private string fecha;

        

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public ProductosClientes()
        {
            codigo = "";
            descripcion = "";
            cliente = "";
            fecha = "";
        }
        public ProductosClientes(string codigo,string descripcion,string cliente,string fecha)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.cliente = cliente;
            this.fecha = fecha;
        }

        public ProductosClientes(ProductosClientes x)
        {
            this.codigo = x.codigo;
            this.descripcion = x.descripcion;
            this.cliente = x.cliente;
            this.fecha = x.fecha;
        }

    }
}
