using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Pedidos
    {
        private int idpedido;
        private int codigo;
        private string nombreCarne;
        private float precio;
        private float pesokg;
        private string fecha;
        private string horaentrega;
        private int idcliente;
         

        
        public int Idpedido
        {
            get
            {
                return idpedido;
            }

            set
            {
                idpedido = value;
            }
        }

        public string NombreCarne
        {
            get
            {
                return nombreCarne;
            }

            set
            {
                nombreCarne = value;
            }
        }

        public float Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public float Pesokg
        {
            get
            {
                return pesokg;
            }

            set
            {
                pesokg = value;
            }
        }

        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string Horaentrega
        {
            get
            {
                return horaentrega;
            }

            set
            {
                horaentrega = value;
            }
        }

        public int Idcliente
        {
            get
            {
                return idcliente;
            }

            set
            {
                idcliente = value;
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
        public Pedidos()
        {
            idpedido = 0;
            codigo = 0;
            nombreCarne = "";
            precio = 0.0f;
            pesokg = 0.0f;
            fecha = "";
            horaentrega = "";
            idcliente = 0;

        }
        public Pedidos(int idp,int id,int cod,string nc,float pe,float pk,string fe,string hora,int ic)
        {
            idpedido = idp;            
            codigo = cod;
            nombreCarne = nc;
            precio = pe;
            pesokg = pk;
            fecha = fe;
            horaentrega = hora;
            idcliente = ic;
        }
        public Pedidos(Pedidos otro)
        {
            idpedido = otro.idpedido;
            codigo = otro.codigo;
            nombreCarne = otro.nombreCarne;
            precio = otro.precio;
            pesokg = otro.pesokg;
            fecha = otro.fecha;
            horaentrega = otro.horaentrega;
            idcliente = otro.idcliente;
        }
    }
}
