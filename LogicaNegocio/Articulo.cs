using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Articulo:IValidate
    {
        #region atributos
        private int _id;    
        private static int s_ultimoId = 1;
        private string _nombre;
        private string _categoria;
        private double _precioVenta;
        #endregion

        public int Id
        {
            get { return _id; }
        }
        public string Categoria
        {
            get { return _categoria; }
        }

        public double PrecioVenta
        {
            get { return _precioVenta; }
        }

        public Articulo(string nombre, string categoria, double precioVenta)
        {
            _nombre = nombre;   
            _categoria = categoria;
            _precioVenta = precioVenta;
            _id = Articulo.s_ultimoId;
            Articulo.s_ultimoId++;
        }

        public void Validar() 
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }
            if (string.IsNullOrEmpty(_categoria))
            {
                throw new Exception("La categoría es obligatoria");
            }
            if(_precioVenta <= 0)
            {
                throw new Exception("El precio de venta es obligatorio");
            }
        }

        public override string ToString()
        {
            return "Datos del artículo:" + "\n" + "-------------------\n" + "Id: " + _id.ToString() +  "\n" + "Nombre: " + _nombre + "\n"+ "Categoría: " + _categoria + "\n" + "Precio: "+ _precioVenta.ToString() + "\n";
        }

        public override bool Equals(object obj)
        {
            Articulo articulo = obj as Articulo;
            return articulo != null && _nombre.Trim().ToUpper() == articulo._nombre.Trim().ToUpper();
        }
    }


    
}
