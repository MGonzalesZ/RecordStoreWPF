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
    /// Lógica de interacción para PreVent.xaml
    /// </summary>
    public partial class PreVent : Window
    {
        public double Total;
        public int contar;
        public PreVent()
        {
            InitializeComponent();
            dgCesta.ItemsSource = MainWindow.MiMenu.ListaCarrito;
            Total = 0;
            contar = 0;
            foreach(CestaDisco elem in MainWindow.MiMenu.ListaCarrito)
            {
                Total = Total + elem.Subtotal;
                contar++;
            }
            lblTotal.Content = Total.ToString()+" Bs.";
            lblItems.Content = contar.ToString();
        }

        private void btnCancelarPedido_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBoxResult.Yes==MessageBox.Show("Esta seguro de Cancelar el pedido?", "Mensaje", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            {
                MessageBox.Show("Pedido Cancelado", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow.MiMenu.ListaCarrito.RemoveRange(0,MainWindow.MiMenu.ListaCarrito.Count);
                this.Hide();
            }

        }

        private void btnConfirmarPedido_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Esta seguro de hacer el pedido?", "Mensaje", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            {
                
                this.Hide();
                Factura nuevaFactura = new Factura();
                nuevaFactura.Show();
            }
        }
    }
}
