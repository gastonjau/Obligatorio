using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Oferta:IValidate, IEquatable<Oferta>
    {
        #region atributos
        private int _id;
        private static int s_ultimoId = 1;
        private Usuario _usuario;
        private double _monto;
        private DateTime _fecha;
        #endregion

        public double Monto
        {
            get { return _monto; }
        }
        //Constructor 

        public Oferta(Usuario usuario, double monto, DateTime fecha)
        {
            _usuario = usuario;
            _monto = monto;
            _fecha = fecha;
            _id = Oferta.s_ultimoId;
            Oferta.s_ultimoId++;
        }

        public int Id
        {
            get { return _id; }
        }


        public void Validar()
        {
            //¿Aceptar ofertas de $0? y ¿agregar validación para que el monto ofrecido sea mayor a la última oferta de + valor?
            if(_monto <= 0)
            {
                throw new Exception("La oferta debe ser mayor a 0");
            }
            if(_fecha < DateTime.MinValue)
            {
                throw new Exception("La fecha no es válida");
            }
            if (_usuario == null)
            {
                throw new Exception("El usuario es obligatorio");
            }
        }

        //Definimos el Equals con la opción IEquatable para controlar que no se agregue la misma oferta a la lista de ofertas de una subasta.
        public bool Equals(Oferta? other)
        {
            return _usuario.Equals(other._usuario) && _monto == other._monto && _fecha.ToShortDateString() == other._fecha.ToShortDateString();
        }

        public override string ToString()
        {
            return _usuario.ToString() + "Oferta:" + "\n-------" + "\nMonto ofrecido: " + _monto.ToString() + "\n" + "Fecha: " + _fecha.ToShortDateString() + "\n";
        }

    }
}
