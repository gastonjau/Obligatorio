using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Venta:Publicacion
    {
        private bool _ofertaRelampago;

        public bool OfertaRelampago
        {
            get { return _ofertaRelampago; }
        }
        //Constructor 

        public Venta(string nombre, DateTime fecha, Articulo articulo, bool ofertaRelampago) :base(nombre, fecha, articulo)
        {
            _ofertaRelampago = ofertaRelampago;
        }

        public override double CalcularPrecio()
        {
            double precio = 0;
            foreach(Articulo articulo in _articulos)
            {
                precio += articulo.PrecioVenta;
            }
            if (_ofertaRelampago)
            {
                precio = precio - (precio * 0.20);
            }
            return precio;
        }
    }
}
