using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Control
    {
        public string ctrlRegistro(Usuarios usuario)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario.Usuario) || string.IsNullOrEmpty(usuario.Password) || string.IsNullOrEmpty(usuario.ConPassword) || string.IsNullOrEmpty(usuario.Nombre))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                if (usuario.Password == usuario.ConPassword)
                {
                    if (modelo.existeUsuario(usuario.Usuario))
                    {
                        respuesta = "El usuario ya existe";
                    }
                    else
                    {
                        usuario.Password = (usuario.Password);
                        usuario.Id_tipo = 2;
                        modelo.registro(usuario);
                    }
                }
                else
                {
                    respuesta = "Las contraseña no coinciden";
                }
            }
            return respuesta;

        }

        public string ctrlLogin(string usuario, string password)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            Usuarios datosUsuario = null;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                datosUsuario = modelo.porUsuario(usuario);

                if (datosUsuario == null)
                {
                    respuesta = "El usuario no existe";
                }
                else
                {
                    if (datosUsuario.Password != (password))
                    {
                        respuesta = "El usuario y/o contraseña no coinciden";
                    }
                    else
                    {
                        Session.id = datosUsuario.Id;
                        Session.usuario = usuario;
                        Session.nombre = datosUsuario.Nombre;
                        Session.id_tipo = datosUsuario.Id_tipo;
                        Session.permiso = datosUsuario.Permiso;
                    }
                }
            }
            return respuesta;
        }

       

    }
}

