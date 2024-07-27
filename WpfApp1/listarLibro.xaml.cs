using System.Collections.ObjectModel;
using System.Windows;
using WpfApp;

namespace WpfApp_libreria
{
    public partial class listarLibro : Window
    {
        private ObservableCollection<Libro> libros;

        public listarLibro(ObservableCollection<Libro> libros)
        {
            InitializeComponent();
            this.libros = libros;
            dgListadoLibros.ItemsSource = this.libros; // Asignamos la fuente de datos al DataGrid
        }

        private void CargarLibros()
        {
            // Vincula la lista de libros al DataGrid
            dgListadoLibros.ItemsSource = null;
            dgListadoLibros.ItemsSource = this.libros;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            var libroSeleccionado = dgListadoLibros.SelectedItem as Libro;
            if (libroSeleccionado != null)
            {
                libros.Remove(libroSeleccionado);
                CargarLibros();
                MessageBox.Show($"El libro '{libroSeleccionado.Titulo}' ha sido eliminado.");
            }
            else
            {
                MessageBox.Show("Selecciona un libro para eliminar.");
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el libro seleccionado
            Libro libroSeleccionado = dgListadoLibros.SelectedItem as Libro;
            if (libroSeleccionado != null)
            {
                // Abrir la ventana de ActualizarLibro
                actualizarLibro actualizarLibroWindow = new actualizarLibro(libroSeleccionado, libros);
                if (actualizarLibroWindow.ShowDialog() == true)
                {
                    // Refrescar el DataGrid
                    CargarLibros();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un libro para actualizar.");
            }
        }
    }
}

