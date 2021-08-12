using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Usuarios
    {
        int id, id_tipo;
        string usuario, password, conPassword, nombre,permiso;

        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
        public string ConPassword { get => conPassword; set => conPassword = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }
        public int Id_tipo { get => id_tipo; set => id_tipo = value; }
        public string Permiso { get => permiso; set => permiso = value; }

    }
}
