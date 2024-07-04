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
    /// Lógica de interacción para InvenEliminar.xaml
    /// </summary>
    public partial class InvenEliminar : Window
    {
        public InvenEliminar()
        {
            InitializeComponent();
        }

        private void btnEliminarDisco_Click(object sender, RoutedEventArgs e)
        {
            string cod = txtCodELim.Text;
            int pos = -1;
            foreach (Disco elem in MainWindow.ListaDeDiscos)
            {
                if (elem.Codigo == cod)
                {
                    pos = MainWindow.ListaDeDiscos.IndexOf(elem);
                }
            }
            if (pos == -1)
            {
                MessageBox.Show("Debe ingresar un codigo correcto", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (MessageBoxResult.Yes == MessageBox.Show("Desea eliminar el disco de codigo: " + cod + " ?", "Mensaje:", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                MainWindow.ListaDeDiscos.RemoveAt(pos);
                MainWindow.MiInvent.dgInventario.ItemsSource = null;
                MainWindow.MiMenu.dgInventario.ItemsSource = null;
                MainWindow.MiInvent.dgInventario.ItemsSource = MainWindow.ListaDeDiscos;
                MainWindow.MiMenu.dgInventario.ItemsSource = MainWindow.ListaDeDiscos;
            }
        }
        private void btnCancelarElim_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            this.Hide();
            //MainWindow.MiInvent.Owner = this;
            MainWindow.MiInvent.Show();
        }
    }
}
