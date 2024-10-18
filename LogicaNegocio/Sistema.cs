using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio
{
    public class Sistema
    {   
        //Atributos y propiedades
        #region
        
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();
        private List<Articulo> _articulos = new List<Articulo>();


        public double CalcularPrecioPublicacion(int publicacionId)
        {
            double precio = 0;
            foreach(Publicacion publicacion in _publicaciones)
            {
                if(publicacion.Id == publicacionId)
                {
                    precio = publicacion.CalcularPrecio();
                }
            }
            return precio;
        }
        public List<Articulo> Articulos
        {
            get { return _articulos; }
        }

        public List<Publicacion> Publicaciones
        {
            get { return _publicaciones; }
        }
        #endregion
        
        //Constructor, se realizan las precargas solicitadas
        public Sistema()
        {
            PrecargarArticulos();  
            PrecargarClientes();
            PrecargarAdministradores();
            PrecargarVentas();       
            PrecargarSubastas();
        }

        #region Precargas
        private void PrecargarArticulos()
        {
            // Categoría: Playa
            AgregarArticulo("Sombrilla", "Playa", 1500.00);
            AgregarArticulo("Toalla", "Playa", 800.00);
            AgregarArticulo("Protector Solar", "Playa", 600.00);
            AgregarArticulo("Gafas de Sol", "Playa", 1200.00);
            AgregarArticulo("Silla de Playa", "Playa", 2000.00);

            // Categoría: Ciclismo
            AgregarArticulo("Bicicleta de Montaña", "Ciclismo", 15000.00);
            AgregarArticulo("Casco", "Ciclismo", 2500.00);
            AgregarArticulo("Guantes", "Ciclismo", 800.00);
            AgregarArticulo("Luz Frontal", "Ciclismo", 1200.00);
            AgregarArticulo("Candado", "Ciclismo", 1000.00);

            // Categoría: Electrónica
            AgregarArticulo("Smartphone", "Electrónica", 25000.00);
            AgregarArticulo("Laptop", "Electrónica", 45000.00);
            AgregarArticulo("Auriculares", "Electrónica", 3000.00);
            AgregarArticulo("Cámara", "Electrónica", 20000.00);
            AgregarArticulo("Tablet", "Electrónica", 15000.00);

            // Categoría: Hogar
            AgregarArticulo("Sofá", "Hogar", 30000.00);
            AgregarArticulo("Mesa de Comedor", "Hogar", 20000.00);
            AgregarArticulo("Lámpara", "Hogar", 5000.00);
            AgregarArticulo("Cama", "Hogar", 25000.00);
            AgregarArticulo("Refrigerador", "Hogar", 40000.00);

            // Categoría: Ropa
            AgregarArticulo("Camisa", "Ropa", 1200.00);
            AgregarArticulo("Pantalones", "Ropa", 1800.00);
            AgregarArticulo("Chaqueta", "Ropa", 3500.00);
            AgregarArticulo("Zapatos", "Ropa", 2500.00);
            AgregarArticulo("Sombrero", "Ropa", 800.00);

            // Categoría: Deportes
            AgregarArticulo("Pelota de Fútbol", "Deportes", 1000.00);
            AgregarArticulo("Raqueta de Tenis", "Deportes", 3000.00);
            AgregarArticulo("Pesas", "Deportes", 2000.00);
            AgregarArticulo("Cinta de Correr", "Deportes", 50000.00);
            AgregarArticulo("Bicicleta Estática", "Deportes", 15000.00);

            // Categoría: Juguetes
            AgregarArticulo("Muñeca", "Juguetes", 800.00);
            AgregarArticulo("Auto de Juguete", "Juguetes", 600.00);
            AgregarArticulo("Lego", "Juguetes", 2500.00);
            AgregarArticulo("Rompecabezas", "Juguetes", 1200.00);
            AgregarArticulo("Pelota", "Juguetes", 500.00);

            // Categoría: Libros
            AgregarArticulo("Novela", "Libros", 600.00);
            AgregarArticulo("Cómic", "Libros", 400.00);
            AgregarArticulo("Libro de Texto", "Libros", 1500.00);
            AgregarArticulo("Revista", "Libros", 200.00);
            AgregarArticulo("Diccionario", "Libros", 1000.00);

            // Categoría: Alimentos
            AgregarArticulo("Pan", "Alimentos", 100.00);
            AgregarArticulo("Leche", "Alimentos", 50.00);
            AgregarArticulo("Queso", "Alimentos", 200.00);
            AgregarArticulo("Carne", "Alimentos", 500.00);
            AgregarArticulo("Frutas", "Alimentos", 300.00);

            // Categoría: Bebidas
            AgregarArticulo("Agua", "Bebidas", 50.00);
            AgregarArticulo("Jugo", "Bebidas", 100.00);
            AgregarArticulo("Cerveza", "Bebidas", 150.00);
            AgregarArticulo("Vino", "Bebidas", 400.00);
            AgregarArticulo("Refresco", "Bebidas", 80.00);

            //Artículos repetidos para probar que se controla su existencia.
            AgregarArticulo("Sombrilla", "Playa", 1500.00);
            AgregarArticulo("Toalla", "Playa", 800.00);
        }

        private void PrecargarClientes()
        {
            AgregarCliente("Juan", "Perez", "jperez@gmail.com", "jp123456", 8000);
            AgregarCliente("Oscar", "Martinez", "omartinez@gmail.com", "om123456", 10000);
            AgregarCliente("Pedro", "Gonzalez", "pgonzalez@gmail.com", "pg123456", 1200);
            AgregarCliente("Daniel", "Oleaga", "doleaga@gmail.com", "do123456", 9000);
            AgregarCliente("Martin", "Gimenez", "mgimenez@gmail.com", "mg123456", 8000);
            AgregarCliente("Marta", "Gimenez", "magimenez@gmail.com", "mg1234567", 850);
            AgregarCliente("María", "Días", "mdias@gmail.com", "md123456", 600);
            AgregarCliente("Lara", "Mendez", "lmendez@gmail.com", "lm123456", 1200);
            AgregarCliente("Juana", "Clavijo", "jclavijo@gmail.com", "jc123456", 600);
            AgregarCliente("Marcela", "Rodriguez", "mrodriguez@gmail.com", "mr123456", 1300);
            AgregarCliente("Juan", "Perez", "jperez@gmail.com", "jp123456", 8000);
            AgregarCliente("Juan", "Perez", "jperez@gmail.com", "jp123456", 8000);
        }

        private void PrecargarAdministradores()
        {
            AgregarAdministrador("Mario", "Gonzalez", "mgonzalez@outlook.com", "MG123456");
            AgregarAdministrador("Mariela", "Estevez", "mestevez@outlook.com", "ME123456");
            AgregarAdministrador("Mariela", "Estevez", "mestevez@outlook.com", "ME123456");
        }

        private void PrecargarVentas()
        {
            AgregarVenta("Articulos de playa", "ABIERTA", new DateTime(2024, 09, 10), 1, true);
            AgregarArticuloAVenta(1, 2);

            AgregarVenta("Ciclismo", "ABIERTA", new DateTime(2024, 09, 12), 6, false);
            AgregarArticuloAVenta(2, 7);
            AgregarArticuloAVenta(2, 8);

            AgregarVenta("Electrónica", "ABIERTA", new DateTime(2024, 09, 14), 11, true);
            AgregarArticuloAVenta(3, 12);
            AgregarArticuloAVenta(3, 13);

            AgregarVenta("Hogar", "ABIERTA", new DateTime(2024, 09, 14), 16, false);
            AgregarArticuloAVenta(4, 17);
            AgregarArticuloAVenta(4, 18);

            AgregarVenta("Ropa", "ABIERTA", new DateTime(2024, 09, 15), 21, false);
            AgregarArticuloAVenta(5, 22);
            AgregarArticuloAVenta(5, 23);


            AgregarVenta("Articulos deportivos", "ABIERTA", new DateTime(2024, 09, 16), 26, true);
            AgregarArticuloAVenta(6, 27);

            AgregarVenta("Juguetería", "ABIERTA", new DateTime(2024, 09, 18), 31, false);
            AgregarArticuloAVenta(7, 32);
            AgregarArticuloAVenta(7, 33);

            AgregarVenta("Librería", "ABIERTA", new DateTime(2024, 09, 22), 36, true);
            AgregarArticuloAVenta(8, 37);

            AgregarVenta("Alimentos", "ABIERTA", new DateTime(2024, 09, 22), 41, false);
            AgregarArticuloAVenta(9, 42);
            AgregarArticuloAVenta(9, 43);

            AgregarVenta("Bebidas", "ABIERTA", new DateTime(2024, 09, 23), 46, true);
            AgregarArticuloAVenta(10, 47);
            AgregarArticuloAVenta(10, 48);

        }

        private void PrecargarSubastas()
        {
            AgregarSubasta("Articulos de playa", "ABIERTA", new DateTime(2024, 09, 10), 3);
            AgregarArticuloASubasta(11, 4);
            AgregarArticuloASubasta(11, 5);

            AgregarSubasta("Ciclismo", "ABIERTA", new DateTime(2024, 09, 12), 9);
            AgregarArticuloASubasta(12, 10);

            AgregarSubasta("Electrónica", "ABIERTA", new DateTime(2024, 09, 14), 14);
            AgregarArticuloASubasta(13, 15);

            AgregarSubasta("Hogar", "ABIERTA", new DateTime(2024, 09, 14), 19);
            AgregarArticuloASubasta(14, 20);

            AgregarSubasta("Ropa", "ABIERTA", new DateTime(2024, 09, 15), 24);
            AgregarArticuloASubasta(15, 25);

            AgregarSubasta("Artículos deportivos", "ABIERTA", new DateTime(2024, 09, 16), 28);
            AgregarArticuloASubasta(16, 29);
            AgregarArticuloASubasta(16, 30);

            AgregarSubasta("Juguetería", "ABIERTA", new DateTime(2024, 09, 18), 34);
            AgregarArticuloASubasta(17, 35);

            AgregarSubasta("Librería", "ABIERTA", new DateTime(2024, 09, 22), 38);
            AgregarArticuloASubasta(18, 39);
            AgregarArticuloASubasta(18, 40);

            AgregarSubasta("Alimentos", "ABIERTA", new DateTime(2024, 09, 22), 44);
            AgregarArticuloASubasta(19, 45);

            AgregarOfertaASubasta("doleaga@gmail.com", 600, new DateTime(2024, 09, 25), 19);
            AgregarOfertaASubasta("mgimenez@gmail.com", 650, new DateTime(2024, 09, 25), 19);

            AgregarSubasta("Bebidas", "ABIERTA", new DateTime(2024, 09, 23), 49);
            AgregarArticuloASubasta(20, 50);

            AgregarOfertaASubasta("jperez@gmail.com", 350, new DateTime(2024, 09, 25), 20);
            AgregarOfertaASubasta("omartinez@gmail.com", 320, new DateTime(2024, 09, 25), 20);
            AgregarOfertaASubasta("omartinez@gmail.com", 320, new DateTime(2024, 09, 25), 20);
        }
        #endregion

        //Para agregar artículos controlamos que no se repitan luego de validar sus datos, a
        //traves del método Contains de la lista para lo cual implementamos el Equals en la clase Articulo.
        //Retornamos un bool para interactuar con el usuario si se agrega o no correctamente.

        public bool AgregarArticulo(string nombre, string categoria, double precioVenta)
        {
            bool agrego = false;
            Articulo articulo = new Articulo(nombre, categoria, precioVenta);
            articulo.Validar();
            if (!_articulos.Contains(articulo))
            {
                _articulos.Add(articulo);
                agrego = true;
            }
            return agrego;
        }

        //Para agregar clientes, validamos sus datos y controlamos que no se repitan a traves del BuscarCliente.
        private void AgregarCliente(string nombre, string apellido, string mail, string contrasenia, double saldo)
        {
            Cliente clienteNuevo = new Cliente(nombre, apellido, mail, contrasenia, saldo);
            clienteNuevo.Validar();
            if (BuscarCliente(mail) == null)
            {
                _usuarios.Add(clienteNuevo);
            }
        }

        private Cliente BuscarCliente(string mail)
        {
            int i = 0;
            Cliente cliente = null;

            while (i < _usuarios.Count && cliente == null)
            {
                if (_usuarios[i] is Cliente && _usuarios[i].Mail.Trim().ToUpper() == mail.Trim().ToUpper())
                {
                    cliente = (Cliente)_usuarios[i];
                }
                i++;
            }
            return cliente;
        }

        //Para agregar administradores controlamos que no se repitan luego de validar sus datos, a
        //traves del método Contains de la lista para lo cual implementamos el Equals en la clase Usuario.
        private void AgregarAdministrador(string nombre, string apellido, string mail, string contrasenia)
        {
            Usuario administrador = new Usuario(nombre, apellido, mail, contrasenia);
            administrador.Validar();
            if (!_usuarios.Contains(administrador)) 
            {                
                _usuarios.Add(administrador);
            }
        }


        //Para agregar ventas, creamos la venta pasandole un artículo para que esta lo agregue a su lista.
        //Una vez creada la venta y validados sus datos la agregamos a la lista de publicaciones del sistema.
        private void AgregarVenta(string nombre, string estado, DateTime fecha, int articuloId, bool esOfertaRelampago)
        {
            //Acordamos con la profesora no validar existencia.
            if (articuloId > 0)
            {
                Articulo articulo = BuscarArticuloPorId(articuloId);
                if (articulo != null)
                {
                    Venta venta = new Venta(nombre, fecha, articulo, esOfertaRelampago);
                    venta.Validar();
                    _publicaciones.Add(venta);
                }
            }
        }

        private Articulo BuscarArticuloPorId(int idArticulo)
        {
            int i = 0;
            Articulo articulo = null;
            while (i < _articulos.Count && articulo == null)
            {
                if (_articulos[i].Id == idArticulo)
                {
                    articulo = _articulos[i];
                }
                i++;
            }
            return articulo;
        }

        private void AgregarArticuloAVenta(int IdVenta, int articuloId)
        {
            Venta venta = BuscarVenta(IdVenta);
            if (venta != null)
            {
                Articulo articulo = BuscarArticuloPorId(articuloId);
                if (articulo != null)
                {
                    venta.AgregarArticulo(articulo);
                }
            }
        }
        private Venta BuscarVenta(int id)
        {
            int i = 0;
            Venta venta = null;

            while (i < _publicaciones.Count() && venta == null)
            {
                if (_publicaciones[i] is Venta && _publicaciones[i].Id == id)
                {
                    venta = (Venta)_publicaciones[i];
                }
                i++;
            }
            return venta;
        }

        //Para agregar subastas, le pasamos un id de un artículo existente en la lista de artículos del sistema, 
        //buscamos el artículo y creamos la subasta con el artículo indicado. Luego la agregamos a la lista de 
        //publicaciones del sistema.
        private void AgregarSubasta(string nombre, string estado, DateTime fecha, int articuloId)
        {
            Articulo articulo = BuscarArticuloPorId(articuloId);
            if (articulo != null)
            {
                Subasta subasta = new Subasta(nombre, fecha, articulo);
                subasta.Validar();
                _publicaciones.Add(subasta);
            }
        }

        private void AgregarArticuloASubasta(int subastaId, int articuloId)
        {
            Subasta subasta = BuscarSubasta(subastaId);
            if (subasta != null)
            {
                Articulo articulo = BuscarArticuloPorId(articuloId);
                if (articulo != null)
                {
                    subasta.AgregarArticulo(articulo);
                }
            }
        }


        //Para agregar ofertas a la subasta, pasamos mail del cliente que realiza la oferta, y el id de la subasta
        //para obtener la subasta y el cliente y pedimos a la subasta que agregue la oferta a su lista de ofertas.
        private void AgregarOfertaASubasta(string mail, double monto, DateTime fecha, int idSubasta)
        {
            Subasta subasta = BuscarSubasta(idSubasta);
            Cliente cliente = BuscarCliente(mail);
            if (subasta != null && cliente != null)
            {
                subasta.AgregarOferta(cliente, monto, fecha);
            }
        }

        private Subasta BuscarSubasta(int subastaId)
        {
            int i = 0;
            Subasta subasta = null;

            while (i < _publicaciones.Count() && subasta == null)
            {
                if (_publicaciones[i] is Subasta && _publicaciones[i].Id == subastaId)
                {
                    subasta = (Subasta)_publicaciones[i];
                }
                i++;
            }
            return subasta;
        }

        public List<Articulo> ListarArticulosPorCategoria(string categoria)
        {
            List<Articulo> articulos = new List<Articulo>();
            if(_articulos.Count > 0) 
            {
                for (int i = 0; i < _articulos.Count; i++)
                {
                    if(_articulos[i].Categoria.Trim().ToUpper() == categoria.Trim().ToUpper())
                    {
                        articulos.Add( _articulos[i] );
                    }
                }           
            }
            return articulos;
        }

        public List<Publicacion> PublicacionesEntreFechas(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            if (_publicaciones.Count > 0)
            {
                for (int i = 0; i < _publicaciones.Count(); i++)
                {
                    if (_publicaciones[i].FechaAlta >= fechaDesde && _publicaciones[i].FechaAlta <= fechaHasta)
                    {
                        publicaciones.Add(_publicaciones[i]);
                    }
                } 
            }
            return publicaciones;
        }

        public List<Cliente> ListaClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            for (int i = 0; i < _usuarios.Count; i++)
            {
                if (_usuarios[i] is Cliente)
                {
                    clientes.Add((Cliente)_usuarios[i]);
                }
            }
            return clientes;
        }

        //Método auxiliar para listar los administradores.
        public List<Usuario> ListaAdministradores()
        {
            List<Usuario> administradores = new List<Usuario>();
            for (int i = 0; i < _usuarios.Count; i++)
            {
                if (!(_usuarios[i] is Cliente))
                {
                    administradores.Add(_usuarios[i]);
                }
            }
            return administradores;
        }
    }
}