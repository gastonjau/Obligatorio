using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Usuario:IValidate
    {
        #region atributos
        private int _id;
        private static int s_ultimoId= 1;
        private string _nombre;
        private string _apellido;
        private string _mail;
        private string _contrasenia;
        #endregion

        public string Mail
        {
            get { return _mail; }
        }

        public Usuario(string nombre, string apellido, string mail, string contrasenia) 
        {
            _nombre = nombre;
            _apellido = apellido;
            _mail = mail;
            _contrasenia = contrasenia;
            _id = Usuario.s_ultimoId;
            Usuario.s_ultimoId++;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }
            if (string.IsNullOrEmpty(_apellido))
            {
                throw new Exception("El apellido es obligatorio");
            }
            if (string.IsNullOrEmpty(_mail))
            {
                throw new Exception("El correo electrónico es obligatorio");
            }
            if (string.IsNullOrEmpty(_contrasenia) || _contrasenia.Length < 8)
            {
                throw new Exception("La contraseña es obligatoria y debe contener al menos 8 caracteres.");
            }

        }

        public override string ToString()
        {
            string ret = "Datos del administrador: \n------------------------";
            if (this is Cliente)
            {
                ret = "Datos del cliente: \n------------------";
            }
            return ret + "\n" + "Id: " + _id.ToString() + "\n" + "Nombre: " + _nombre + "\n" + "Apellido: " + _apellido + "\n" + "Email: " + _mail + "\n";
        }

        public override bool Equals(object obj)
        {
            Usuario usuario = obj as Usuario;
            return usuario != null && _mail.Trim().ToUpper() == usuario._mail.Trim().ToUpper();
        }
    }
}
