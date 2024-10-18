using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio
{
    public abstract class Publicacion : IValidate
    {
        #region atributos
        private int _id;
        private static int s_ultimoId = 1;
        private string _nombre;
        private Estado _estado = Estado.ABIERTA;
        private DateTime _fechaAlta;
        private Cliente? _cliente;
        private Usuario? _usuarioFinalizador;
        private DateTime? _fechaBaja;
        protected List<Articulo> _articulos = new List<Articulo>();
        #endregion

        public int Id 
        { 
            get { return _id; } 
        }   

        public DateTime FechaAlta
        {
            get { return _fechaAlta; }
        }

        public List<Articulo> Articulos
        {
            get { return _articulos; }
        }


        //Constructor 

        public Publicacion(string nombre, DateTime fechaAlta, Articulo articulo)
        {
            _nombre = nombre;
            _fechaAlta = fechaAlta;
            _articulos.Add(articulo);
            _id = Publicacion.s_ultimoId;
            Publicacion.s_ultimoId++;
        }

        public void AgregarArticulo(Articulo articulo)
        {
            if (BuscarArticulo(articulo.Id) == null)
            {
                _articulos.Add(articulo);
            }
        }

        public Articulo BuscarArticulo(int id)
        {
            Articulo articulo = null;
            int i = 0;
            while (i < _articulos.Count() && articulo == null)
            {
                if (_articulos[i].Id == id)
                {
                    articulo = _articulos[i];
                }
                i++;
            }
            return articulo;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }

            if (_fechaAlta < DateTime.MinValue)
            {
                throw new Exception("La fecha no es válida");
            }
        }

        public abstract double CalcularPrecio();

        public override string ToString()
        {
            return "Publicación Id: " + _id + ", Nombre: " + _nombre + ", Estado: " + _estado + ", Fecha Alta: " + _fechaAlta.ToShortDateString() + "\n";
        }

    }
}
