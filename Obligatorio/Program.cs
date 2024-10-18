using LogicaNegocio;
using System;
using System.ComponentModel.Design;
namespace InterfazUsuario
{
    
    internal class Program
    {
        static Sistema miSistema = new Sistema();
        static void Main(string[] args)
        {
            try
            {
                //Métodos auxiliares de control de precargas.
                //ListarArticulos();
                ListarVentas();
                ListarSubastas();
                //ListarClientes();
                //ListarAdministradores();

                int opcion = -1;
                while (opcion != 0)
                {
                    MostrarMenu();
                    Console.WriteLine("\nIngrese opción deseada");
                    string opcionSeleccionada = Console.ReadLine();
                    bool esNumero = true;
                    for(int i = 0; i < opcionSeleccionada.Length; i++)
                    {
                        if (!char.IsDigit(opcionSeleccionada[i]))
                        {
                            esNumero = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(opcionSeleccionada) && esNumero)
                    {
                        int.TryParse(opcionSeleccionada, out opcion);
                        if (opcion > -1)
                        {
                            EvaluarOpcionSeleccionada(opcion);
                        }
                        else
                        {
                            Console.WriteLine("Seleccione una opción válida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ingrese una opción del menú.");
                    }
                }                
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        static void MostrarMenu()
        {
            Console.WriteLine("************** Menú *****************\n");
            Console.WriteLine("1-Listar todos los clientes");
            Console.WriteLine("2-Listar artículos por categorías");
            Console.WriteLine("3-Alta artículo");
            Console.WriteLine("4-Listar publicaciones entre fechas");
            Console.WriteLine("5-Calcular precio publicación");
            Console.WriteLine("0-Salir");
        }

        static void EvaluarOpcionSeleccionada(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    ListarClientes();
                    break;
                case 2:
                    ListarArticulosPorCategoria();
                    break;
                case 3:
                    AltaArticulo();
                    break;
                case 4:
                    ListarPublicacionesEntreFechas();
                    break;
                case 5:
                    CalcularPrecioPublicacion();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }

        static void ListarClientes()
        {
            try
            {
                List<Cliente> clientes = miSistema.ListaClientes();
                if (clientes.Count > 0)
                {
                    Console.WriteLine("\nListado de todos los clientes del sistema:");
                    Console.WriteLine("------------------------------------------");
                    foreach (Cliente cliente in clientes)
                    {
                        Console.WriteLine(cliente.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No hay clientes registrados en el sistema.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ListarArticulosPorCategoria()
        {
            try
            {
                Console.WriteLine("Ingrese categoría de artículos");
                string categoria = Console.ReadLine();
                if (!string.IsNullOrEmpty(categoria))
                {
                    List<Articulo> articulos = miSistema.ListarArticulosPorCategoria(categoria);
                    if (articulos.Count > 0)
                    {
                        Console.WriteLine("\nLista de los artículos de la categoría: " + categoria);
                        string guiones = "";
                        for(int i = 0; i < categoria.Length; i++)
                        {
                            guiones += "-";
                        }
                        Console.WriteLine("----------------------------------------" + guiones);

                        for (int i = 0; i < articulos.Count; i++)
                        {
                            Console.WriteLine(articulos[i].ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo se encontraron artículos para esa categoría\n");
                    }
                }
                else
                {
                    Console.WriteLine("Debe ingresar una categoría.");
                }

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AltaArticulo()
        {
            try
            {
                Console.WriteLine("Ingrese nombre de artículo");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese categoría del artículo");
                string categoria = Console.ReadLine();
                Console.WriteLine("Ingrese el precio de venta del artículo");
                double.TryParse(Console.ReadLine(), out double precioVenta);
                if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(categoria) && precioVenta > 0)
                {
                    if (miSistema.AgregarArticulo(nombre, categoria, precioVenta))
                    {
                        Console.WriteLine("\nEl artículo se agregó correctamente. \n");
                    }
                    else
                    {
                        Console.WriteLine("\nEl artículo no fue agregado. \n");
                    }
                }
                else
                {
                    Console.WriteLine("\nDebe ingresar todos los datos solicitados.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void ListarPublicacionesEntreFechas()
        {
            try
            {
                Console.WriteLine("Ingrese fecha desde en formato YYYY-MM-DD");
                DateTime.TryParse(Console.ReadLine(), out DateTime fechaDesde);
                Console.WriteLine("Ingrese fecha hasta en formato YYYY-MM-DD");
                DateTime.TryParse(Console.ReadLine(), out DateTime fechaHasta);
                if (fechaDesde > DateTime.MinValue && fechaHasta > DateTime.MinValue)
                {
                    if (fechaHasta < fechaDesde)
                    {
                        DateTime fechaAux = fechaDesde;
                        fechaDesde = fechaHasta;
                        fechaHasta = fechaAux;
                    }
                    List<Publicacion> publicaciones = miSistema.PublicacionesEntreFechas(fechaDesde, fechaHasta);
                    if (publicaciones.Count() > 0)
                    {
                        Console.WriteLine("\nLista de publicaciones entre " + fechaDesde.ToShortDateString() + " y " + fechaHasta.ToShortDateString());
                        Console.WriteLine("----------------------------------------------------\n");
                        for (int i = 0; i < publicaciones.Count; i++)
                        {
                            Console.WriteLine(publicaciones[i].ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo se encontraron publicaciones entre esas fechas.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nDebe ingresar ambas fechas en formato válido para obtener la información.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
  

        #region metodos Auxiliares    
        static void ListarArticulos()
        {
            try
            {
                List<Articulo> articulos = miSistema.Articulos;
                for (int i = 0; i < articulos.Count; i++)
                {
                    Console.WriteLine(articulos[i].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
        static void ListarAdministradores()
        {
            try
            {
                List<Usuario> administradores = miSistema.ListaAdministradores();

                if (administradores.Count > 0)
                {
                    foreach (Usuario administrador in administradores)
                    {
                        Console.WriteLine(administrador.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No hay administradores registrados en el sistema.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ListarVentas()
        {
            try
            {
                List<Publicacion> publicaciones = miSistema.Publicaciones;
                if (publicaciones.Count > 0)
                {
                    for (int i = 0; i < publicaciones.Count; i++)
                    {
                        if (publicaciones[i] is Venta)
                        {
                            Console.WriteLine(((Venta)publicaciones[i]).ToString());
                            List<Articulo> articulos = publicaciones[i].Articulos;
                            if (articulos.Count() > 0)
                            {
                                for (int j = 0; j < articulos.Count(); j++)
                                {
                                    Console.WriteLine(articulos[j].ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("La venta no tiene articulos");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No hay publicaciones ingresadas");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void ListarSubastas()
        {
            try
            {
                List<Publicacion> publicaciones = miSistema.Publicaciones;
                if (publicaciones.Count > 0)
                {
                    for (int i = 0; i < publicaciones.Count; i++)
                    {
                        if (publicaciones[i] is Subasta)
                        {
                            Console.WriteLine(((Subasta)publicaciones[i]).ToString());
                            List<Articulo> articulos = publicaciones[i].Articulos;
                            List<Oferta> ofertas = ((Subasta)publicaciones[i]).Ofertas;
                            if (articulos.Count > 0)
                            {
                                Console.WriteLine("Lista de articulos de la subasta\n");
                                for (int j = 0; j < articulos.Count(); j++)
                                {
                                    Console.WriteLine(articulos[j].ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("La subasta no tiene articulos\n");
                            }
                            if (ofertas.Count > 0)
                            {
                                Console.WriteLine("Lista de ofertas de la subasta\n");
                                for (int k = 0; k < ofertas.Count; k++)
                                {
                                    Console.Write(ofertas[k].ToString() + "\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("La subasta no tiene ofertas\n");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No hay publicaciones ingresadas\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CalcularPrecioPublicacion()
        {
            try
            {
                Console.WriteLine("Ingrese id de la publicación");
                int.TryParse(Console.ReadLine(), out int idPublicacion);
                double precio = 0;
                if (idPublicacion > 0)
                {
                     precio = miSistema.CalcularPrecioPublicacion(idPublicacion);
                }
                if(precio > 0)
                {
                    string msg = "Publicacion: " + idPublicacion.ToString() + " precio: " + precio.ToString();
                    Console.WriteLine(msg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion   
    }
    
}
