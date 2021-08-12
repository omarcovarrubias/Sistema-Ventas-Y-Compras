using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class ProductoCompra
    {
        private string nombreempresa;
        private int folio;
        private int id;
        private string proveedor;
        private string vendedor;
        /*private float saldo;
        private float total;
        private float cambio;*/
        
        /*public float Cambio
        {
            get { return cambio; }
            set { cambio = value; }
        }

        public float Total
        {
            get { return total; }
            set { total = value; }
        }
        public float Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }*/

        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        public string Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }
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


        private decimal cantidad;

        public decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

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
        public int Folio
        {
            get
            {
                return folio;
            }
            set
            {
                folio = value;
            }
        }

 
        public ProductoCompra() { }

       /* public Producto(int folio, int id, string codigo, string descripcion, string nombreempresa, decimal costo, decimal precio, decimal cantidad, string cliente, string vendedor, float saldo, float total, float cambio)*/
        public ProductoCompra(int folio, int id, string codigo, string descripcion, string nombreempresa, decimal costo, decimal precio, decimal cantidad, string proveedor, string vendedor)
        {
            this.folio = folio;
            this.id = id;
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.nombreempresa = nombreempresa;
            this.costo = costo;
            this.precio = precio;
            this.cantidad = cantidad;
            this.proveedor = proveedor;
            this.vendedor = vendedor;
            /*this.vendedor = vendedor;
            this.saldo = saldo;
            this.total = total;
            this.cambio = cambio;*/
        }

        public ProductoCompra(ProductoCompra x)
        {
            this.folio = x.folio;
            this.id = x.id;
            this.codigo = x.codigo;
            this.descripcion = x.descripcion;
            this.nombreempresa = x.nombreempresa;
            this.costo = x.costo;
            this.precio = x.precio;
            this.cantidad = x.cantidad;
            this.vendedor = x.vendedor;
            this.proveedor = x.proveedor;

            /*this.cliente = x.cliente;
            this.vendedor = x.vendedor;
            this.saldo = x.saldo;
            this.total = x.total;
            this.cambio = x.cambio;*/
        }
        /*
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


          private float costo;

          public float Costo
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
          private string nombreempresa;

          public string Nombreempresa
          {
              get { return nombreempresa; }
              set { nombreempresa = value; }
          }


          public Producto()
          {

          }

          public Producto(int id, string codigo, string descripcion, float costo,  int cantidad,string nombreempresa)
          {
              this.id = id;
              this.codigo = codigo;
              this.descripcion = descripcion;
              this.costo = costo;
              this.cantidad = cantidad;
              this.nombreempresa = nombreempresa;
          }

          public Producto(Producto x)
          {
              this.id = x.id;
              this.codigo = x.codigo;
              this.descripcion = x.descripcion;
              this.costo = x.costo;
              this.cantidad = x.cantidad;
              this.nombreempresa = x.nombreempresa;
          }

          public Producto(string codigo, string descripcion, float costo, int cantidad, string nombreempresa)
          {
              this.codigo = codigo;
              this.descripcion = descripcion;
              this.costo = costo;
              this.cantidad = cantidad;
              this.nombreempresa = nombreempresa;
          }
      }*/
    }
}
