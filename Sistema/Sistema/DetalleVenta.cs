namespace FrmCliente
{
    class DetalleVenta
    {
        private int iddetalleventa;
        private int idventa;
        private int idcliente;
        private int idpedido;
        private float pesokg;
        private float precio;
        private string fecha;

        public int Iddetalleventa
        {
            get
            {
                return iddetalleventa;
            }

            set
            {   
                iddetalleventa = value;
            }
        }

        public int Idventa
        {
            get
            {
                return idventa;
            }

            set
            {
                idventa = value;
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
        public DetalleVenta()
        {
            iddetalleventa = 0;
            idventa = 0;
            idcliente = 0;
            idpedido = 0;
            pesokg = 0.0f;
            precio = 0.0f;
            fecha = "";


        }
        public DetalleVenta(int id)
        {

        }
    }
}
