using System.Collections.Generic;
using System.Windows;

namespace Semana04
{
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=LAB1504-27\\SQLEXPRESS;Initial Catalog=Neptuno;User Id=userTecsup;Password=12345";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MostrarProveedoresButton_Click(object sender, RoutedEventArgs e)
        {
            DataReader dataReader = new DataReader(connectionString);
            List<Producto> productos = dataReader.ListarProductos();
            ResultadosDataGrid.ItemsSource = productos;
        }

        private void MostrarProductosButton_Click(object sender, RoutedEventArgs e)
        {
            DataReader dataReader = new DataReader(connectionString);
            List<Categoria> categorias = dataReader.ListarCategorias();
            ResultadosDataGrid.ItemsSource = categorias;
        }
    }
}
