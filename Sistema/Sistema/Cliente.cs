using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Cliente
    {
        private string apellidos;

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        private string horario;
        public string Horario
        {
            get { return horario; }
            set { horario = value; }
        }
        private string fecha;
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int idCliente;

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private int codigo;


        private string calle;

        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }
        private string numero;

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string colonia;

        public string Colonia
        {
            get { return colonia; }
            set { colonia = value; }
        }
        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
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

        private int status;

        public Cliente()
        {
            idCliente = 0;
            codigo = 0;
            nombre = "";
            correo = "";
            colonia = "";
            calle = "";
            numero = "";
            status = 0;
            fecha = "";
            horario = "";
            apellidos = "";
        }
        public Cliente(string ap,int i, int c, string n, string co, string col, string call, string num, int s, string fe, string ho)
        {
            idCliente = s;
            codigo = c;
            nombre = n;
            correo = co;
            colonia = col;
            calle = call;
            numero = num;
            status = s;
            fecha = fe;
            horario = ho;
            apellidos = ap;

        }
        public Cliente(Cliente otro)
        {
            idCliente = otro.idCliente;
            codigo = otro.codigo;
            nombre = otro.nombre;
            correo = otro.correo;
            colonia = otro.colonia;
            calle = otro.calle;
            numero = otro.numero;
            status = otro.status;
            fecha = otro.fecha;
            horario = otro.horario;
            apellidos = otro.apellidos;
        }



    }
}
