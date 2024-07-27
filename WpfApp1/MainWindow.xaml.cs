using System.Collections.ObjectModel;
using System.Windows;
using WpfApp;
using WpfApp_libreria;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Libro> libros;

        public MainWindow()
        {
            InitializeComponent();
            libros = new ObservableCollection<Libro>();
            dgListadoLibros.ItemsSource = libros;
        }

        private void optAgregarLibro_Click(object sender, RoutedEventArgs e)
        {
            agregarLibro agregarLibroWindow = new agregarLibro(libros);
            agregarLibroWindow.ShowDialog();
        }

        private void optListarLibros_Click(object sender, RoutedEventArgs e)
        {
            listarLibro listarLibroWindow = new listarLibro(libros);
            listarLibroWindow.ShowDialog();
        }

        private void optReportes_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para la acción del evento
        }
    }
}
