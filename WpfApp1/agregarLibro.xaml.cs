using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WpfApp;

namespace WpfApp_libreria
{
    public partial class agregarLibro : Window
    {
        private ObservableCollection<Libro> libros;

        public agregarLibro(ObservableCollection<Libro> libros)
        {
            InitializeComponent();
            this.libros = libros;
        }

        private void btnAgregarLibro_Click(object sender, RoutedEventArgs e)
        {
            long isbn;
            if (!long.TryParse(txtIsbn.Text, out isbn))
            {
                MessageBox.Show("Por favor, ingrese un ISBN válido.");
                return;
            }

            string titulo = txtTituloLibro.Text;
            string autor = txtAutorLibro.Text;
            bool estaDisponible = chkDisponible.IsChecked == true;

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            Libro nuevoLibro = new Libro
            {
                Isbn = isbn,
                Titulo = titulo,
                Autor = autor,
                EstaDisponible = estaDisponible
            };

            libros.Add(nuevoLibro);
            MessageBox.Show($"Libro '{titulo}' ha sido agregado exitósamente!");
            this.DialogResult = true;
            this.Close();
        }
        private void CheckTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+"); // Solo permite números
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

