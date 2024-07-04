using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_grupo_PRG2
{
    /// <summary>
    /// Lógica de interacción para Inventario.xaml
    /// </summary>
    public partial class Inventario : Window
    {       
        public static InvenAgregar VentanaAgr = new InvenAgregar();
        public static InvenEliminar VentanaElim = new InvenEliminar();
        public Inventario()
        {
            InitializeComponent();  
        }

        private void btnAgregarDisco_Click(object sender, RoutedEventArgs e)
        {            
            VentanaAgr.Owner = this;
            VentanaAgr.ShowDialog();
        }

        private void btnEliminarDisco_Click(object sender, RoutedEventArgs e)
        {
            if (dgInventario.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un disco para eliminarlo", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                Disco DiscElim = (Disco)dgInventario.SelectedItem;
                string msje = DiscElim.Codigo + "\n De Titulo: " + DiscElim.Nombre + "\nY Artista: " + DiscElim.Artista;
                if (MessageBoxResult.Yes == MessageBox.Show("Desea eliminar el disco " + msje + " ?", "Mensaje:", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {
                    MainWindow.ListaDeDiscos.Remove(DiscElim);
                    MainWindow.MiInvent.dgInventario.ItemsSource = null;
                    MainWindow.MiMenu.dgInventario.ItemsSource = null;
                    MainWindow.MiInvent.dgInventario.ItemsSource = MainWindow.ListaDeDiscos;
                    MainWindow.MiMenu.dgInventario.ItemsSource = MainWindow.ListaDeDiscos;
                }
            }
            
        }

        private void btnEliminarXCod_Click(object sender, RoutedEventArgs e)
        {            
            VentanaElim.Owner = this;
            VentanaElim.ShowDialog();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            //MainWindow.MiMenu.Owner = this;
            MainWindow.MiMenu.Show();
        }
        
    }
}
