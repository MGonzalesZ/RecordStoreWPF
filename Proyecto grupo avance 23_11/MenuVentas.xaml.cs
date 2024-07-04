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
    /// Lógica de interacción para MenuVentas.xaml
    /// </summary>
    public partial class MenuVentas : Window
    {
        public List<CestaDisco> ListaCarrito = new List<CestaDisco>();        
        public MenuVentas()
        {
            InitializeComponent();
            //txtNombre.Text = "Juan";
            //txtApellidos.Text = "Perez Salvatierra";
            //txtNIT.Text = "102398748";
            //txtDireccion.Text = "Av Arce 3498";
            //txtTelefono.Text = "22894587";
            //dpFechaNac.SelectedDate = DateTime.Parse("1-1-2000");
          
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            //MainWindow Win1 = new MainWindow();
            //Win1.Owner = this;
            //Win1.ShowDialog();
            
        }

        private void btnInventario_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow.MiInvent.Owner = this;
            if (MainWindow.NivelPermiso == 300)
            {
                MainWindow.MiInvent.Show();
            }
            else
            {
                MessageBox.Show("Solo administradores pueden modificar el inventario","Mensaje:",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NivelPermiso = -1;
            this.Hide();
            
        }

        private void btnselectAlbum_Click(object sender, RoutedEventArgs e)
        {
            if (dgInventario.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un disco", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Disco album = (Disco)dgInventario.SelectedItem;
            foreach(CestaDisco elem in ListaCarrito)
            {
                if (album.Codigo == elem.Codigo)
                {
                    MessageBox.Show("Ya ha seleccionado este disco", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            string msg = album.Nombre + "  " + album.Artista.ToString() + "  " + album.Precio.ToString() + "Bs";
            MessageBox.Show(msg, "El disco que seleccionaste:  ", MessageBoxButton.OK, MessageBoxImage.Information);
            CestaDisco discoVender = new CestaDisco(album.Codigo, album.Nombre, album.Artista, album.Precio);
            PreguntaCantidad dialogo = new PreguntaCantidad();
            dialogo.Owner = this;
            dialogo.Max = album.Stock;
            dialogo.ShowDialog();
            discoVender.Cantidad = dialogo.valor;
            discoVender.CalcularSubt();
            if (dialogo.valor > 0)
            {
                ListaCarrito.Add(discoVender);
            }
        }       
        
        private void btnContinuarPedido_Click(object sender, RoutedEventArgs e)
        {
            if (ListaCarrito.Count == 0)
            {
                MessageBox.Show("Debe Seleccionar por lo menos un disco para continuar", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe Ingresar el Nombre", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtApellidos.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe Ingresar los Apellidos", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtNIT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe Ingresar el NIT", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtDireccion.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe Ingresar la Dirección", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txtTelefono.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe Ingresar el teléfono", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (dpFechaNac.SelectedDate==null)
            {
                MessageBox.Show("Debe Ingresar elegir su fecha de nacimiento", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            PreVent CestaF = new PreVent();
            CestaF.Show();
        }
    }
}
