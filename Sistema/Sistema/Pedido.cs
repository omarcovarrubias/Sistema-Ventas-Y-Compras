using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Pedido
    {
        private string folio;
        private string servicio;
        private decimal precio;
        private string cliente;
        private string vendedor;
        private int cantidad;
        private int id;
        private int codigo_producto;
        private string descripcion;
        private string idproducto;
        private int idcliente;

        public string Idproducto
        {
            get { return idproducto; }
            set { idproducto = value; }
        }


        public int Idcliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int CodigoProducto
        {
            get { return codigo_producto; }
            set { codigo_producto = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Folio
        {
            get { return folio; }
            set { folio = value; }
        }


        public int Cantidad
        {
            get{return cantidad;}
            set { cantidad=value;}
        }

        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }
        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public string Servicio
        {
            get { return servicio; }
            set { servicio = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public Pedido(int idcliente,string idproducto,int id,int codigo_producto, string descripcion,string folio,int cantidad, string servicio,decimal precio,string cliente,string vendedor)
        {
            this.folio = folio;
            this.cantidad = cantidad;
            this.servicio = servicio;
            this.precio = precio;
            this.cliente = cliente;
            this.vendedor = vendedor;
            this.id = id;
            this.codigo_producto = codigo_producto;
            this.descripcion = descripcion;
            this.idproducto = idproducto;
            this.idcliente = idcliente;
        }

        public Pedido(Pedido x)
        {
            this.folio = x.folio;
            this.servicio = x.servicio;
            this.precio = x.precio;
            this.cliente = x.cliente;
            this.vendedor = x.vendedor;
            this.cantidad = x.cantidad;
            this.id = x.id;
            this.codigo_producto = x.codigo_producto;
            this.descripcion = x.descripcion;
            this.idproducto = x.idproducto;
            this.idcliente = x.idcliente;
        }

    }
}
