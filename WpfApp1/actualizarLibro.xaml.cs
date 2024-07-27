using System.Collections.ObjectModel;
using System.Windows;
using WpfApp;

namespace WpfApp_libreria
{
    public partial class actualizarLibro : Window
    {
        private Libro libro;
        private ObservableCollection<Libro> libros;

        public actualizarLibro(Libro libro, ObservableCollection<Libro> libros)
        {
            InitializeComponent();
            this.libro = libro;
            this.libros = libros;
            txtIsbn.Text = libro.Isbn.ToString();
            txtTituloLibro.Text = libro.Titulo;
            txtAutorLibro.Text = libro.Autor;
            chkDisponible.IsChecked = libro.EstaDisponible;
        }

        private void btnActualizarLibro_Click(object sender, RoutedEventArgs e)
        {
            string titulo = txtTituloLibro.Text;
            string autor = txtAutorLibro.Text;
            bool estaDisponible = chkDisponible.IsChecked == true;

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            libro.Titulo = titulo;
            libro.Autor = autor;
            libro.EstaDisponible = estaDisponible;

            // Encuentra el índice del libro en la colección y actualiza el elemento
            int index = libros.IndexOf(libro);
            if (index != -1)
            {
                libros[index] = libro;
            }

            MessageBox.Show($"Libro '{titulo}' ha sido actualizado exitósamente!");
            this.DialogResult = true;
            this.Close();
        }
    }
}
