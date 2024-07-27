using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class Libro
    {
        public long Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public bool EstaDisponible { get; set; }

        private static List<Libro> libros = new List<Libro>(); // Colección en memoria de libros

        public static void Agregar(Libro libro)
        {
            libros.Add(libro);
        }

        public static Libro BuscarPorIsbn(long isbn)
        {
            return libros.FirstOrDefault(l => l.Isbn == isbn);
        }

        public static bool Actualizar(Libro libroActualizado)
        {
            var libro = BuscarPorIsbn(libroActualizado.Isbn);
            if (libro != null)
            {
                libro.Titulo = libroActualizado.Titulo;
                libro.Autor = libroActualizado.Autor;
                libro.EstaDisponible = libroActualizado.EstaDisponible;
                return true;
            }
            return false;
        }

        public static bool Eliminar(long isbn)
        {
            var libro = BuscarPorIsbn(isbn);
            if (libro != null)
            {
                libros.Remove(libro);
                return true;
            }
            return false;
        }

        public static List<Libro> ObtenerTodos()
        {
            return new List<Libro>(libros);
        }
    }

}


