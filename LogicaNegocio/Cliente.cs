using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Cliente:Usuario, IValidate
    {
        #region atributos        
        private double _saldo;
        #endregion


        #region propiedades
        public double Saldo
        {
            get { return _saldo; }
        }
        #endregion



        //Constructor 

        //:base() es la sintaxis para el metodo constructor de las clases hijas?
        public Cliente(string nombre, string apellido, string mail, string contrasenia, double saldo):base(nombre, apellido, mail, contrasenia)
        {
            _saldo = saldo;
            
        }

        public override string ToString()
        {
            return base.ToString() + "Saldo: " + _saldo.ToString() + "\n";
        }

        public void Validar() 
        {
            if (_saldo < 0)
            {
                throw new Exception("El saldo debe ser mayor o igual a 0");
            }
        }


    }
}
