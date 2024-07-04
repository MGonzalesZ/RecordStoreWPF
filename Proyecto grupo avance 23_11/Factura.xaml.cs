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
    /// Lógica de interacción para Factura.xaml
    /// </summary>
    public partial class Factura : Window
    {
        private static int nroFact=1000;
        public double TotalParc;
        public Factura()
        {
            InitializeComponent();
            nroFact++;
            lblfecha.Content = DateTime.Now.ToString();
            lblfacturan.Content = nroFact;
            lblNITcli.Content = "NIT: "+MainWindow.MiMenu.txtNIT.Text.ToUpper();
            lblnomcli.Content = "Nombre: "+MainWindow.MiMenu.txtNombre.Text.ToUpper()+" "+MainWindow.MiMenu.txtApellidos.Text.ToUpper();
            lblDirecli.Content = "Dirección: " + MainWindow.MiMenu.txtDireccion.Text.ToUpper();
            lblTelfcli.Content = "Teléfono: " + MainWindow.MiMenu.txtTelefono.Text;
            DateTime? fechaNac = MainWindow.MiMenu.dpFechaNac.SelectedDate;
            lblEdadcli.Content = "Edad: "+(DateTime.Now.Year - fechaNac.Value.Year).ToString()+" años";
            dgfactura.ItemsSource = MainWindow.MiMenu.ListaCarrito;
            TotalParc = 0;
            foreach(CestaDisco elem in MainWindow.MiMenu.ListaCarrito)
            {
                TotalParc = TotalParc + elem.Subtotal;
            }
            lblTotParc.Content = Math.Round(TotalParc,2).ToString();
            lblDesc.Content = "0.00";
            lblIva.Content = "13%";
            lblTotal.Content = Math.Round(TotalParc * 1.13,2).ToString();
            lblFechaLimite.Content = "Fecha límite de emisión: 10/01/2022";

        }

        private void btnImprimirFactura_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("Esta seguro de realizar la transacción?", "Mensaje", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            {
                foreach (CestaDisco elem1 in MainWindow.MiMenu.ListaCarrito)
                {
                    foreach(Disco dis in MainWindow.ListaDeDiscos)
                    {
                        if (elem1.Codigo == dis.Codigo)
                        {
                            dis.Stock = dis.Stock - elem1.Cantidad;
                        }
                    }
                }
                MainWindow.MiMenu.dgInventario.ItemsSource = null;
                MainWindow.MiInvent.dgInventario.ItemsSource = null;
                MainWindow.MiMenu.dgInventario.ItemsSource = MainWindow.ListaDeDiscos;
                MainWindow.MiInvent.dgInventario.ItemsSource = MainWindow.ListaDeDiscos;
                MainWindow.MiMenu.ListaCarrito.RemoveRange(0, MainWindow.MiMenu.ListaCarrito.Count);
                MainWindow.MiMenu.txtNombre.Text = "";
                MainWindow.MiMenu.txtApellidos.Text = "";
                MainWindow.MiMenu.txtDireccion.Text = "";
                MainWindow.MiMenu.txtNIT.Text = "";
                MainWindow.MiMenu.txtTelefono.Text = "";
                MessageBox.Show("La venta ha sido efectuada", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Hide();
                MainWindow.MiMenu.Show();
            }
        }
    }
}
