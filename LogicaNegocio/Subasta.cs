using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Subasta:Publicacion
    {
        //Las subastas se instancian con el dato de la lista de ofertas vacío. 
        private List<Oferta>? _ofertas = new List<Oferta>();
        
        public List<Oferta> Ofertas
        {
            get { return _ofertas; }
        }

        //Constructor 

        public Subasta(string nombre, DateTime fecha, Articulo articulo) :base(nombre, fecha, articulo)
        {
              
        }

        public override string ToString()
        {
            return base.ToString();
        }

        //En la oferta hay que controlar que la oferta sea mayor a la mayor y que el cliente tenga saldo
        public void AgregarOferta(Usuario usuario, double monto, DateTime fecha)
        {
            Oferta oferta = new Oferta(usuario, monto, fecha);
            if (!_ofertas.Contains(oferta))
            {
                _ofertas.Add(oferta);
            }
        }

        public override double CalcularPrecio()
        {
            double precio = 0;
            foreach(Oferta oferta in _ofertas)
            {
                if(oferta.Monto > precio)
                {   
                    precio = oferta.Monto;
                }            
            }
            return precio;
        }
    }
}
