using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Productos
    {
        private string nombreempresa;
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private decimal precio;

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private decimal costo;

        public decimal Costo
        {
            get { return costo; }
            set { costo = value; }
        }


        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private decimal stock;
        public string Nombreempresa
        {
            get
            {
                return nombreempresa;
            }

            set
            {
                nombreempresa = value;
            }
        }

        public decimal Stock { get => stock; set => stock = value; }

        public Productos() { }

        public Productos(int id, string codigo,string nombreempresa, string descripcion, decimal costo, decimal precio, int cantidad,decimal stock)
        {
            this.id = id;
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.costo = costo;
            this.precio = precio;
            this.cantidad = cantidad;
            this.stock = stock;
            this.nombreempresa = nombreempresa;
        }

        public Productos(Productos x)
        {
            this.id = x.id;
            this.codigo = x.codigo;
            this.descripcion = x.descripcion;
            this.costo = x.costo;
            this.precio = x.precio;
            this.cantidad = x.cantidad;
            this.stock = x.stock;
            this.nombreempresa = x.nombreempresa;
        }
    }
}
