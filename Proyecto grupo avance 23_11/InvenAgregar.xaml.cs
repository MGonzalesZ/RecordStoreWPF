using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    /// Lógica de interacción para InvenAgregar.xaml
    /// </summary>
    public partial class InvenAgregar : Window
    {       
        public InvenAgregar()
        {
            InitializeComponent();
            //((INotifyCollectionChanged)MainWindow.ListaDeDiscos).CollectionChanged += ListView_CollectionChanged;
        }
        /*
        private void ListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                
            }
        }
        */

        private void btnAgregarDisco_Click(object sender, RoutedEventArgs e)
        {
            
            // FALTAN LAS VALIDACIONES
            string nom, art, gen;
            int ann, pist, dur, stk;
            double prec;
            nom = txtNombre.Text;
            art = txtArtista.Text;
            gen = txtGenero.Text;
            ann = int.Parse(txtAnio.Text);
            pist = int.Parse(txtPistas.Text);
            dur = int.Parse(txtDuracion.Text);
            prec = double.Parse(txtPrecio.Text);
            stk = int.Parse(txtStock.Text);
            Disco discoagr = new Disco(nom, art, gen, ann, pist, dur, prec, stk);

            
            if (MessageBoxResult.Yes == MessageBox.Show("Desea guardar los datos?", "Mensaje:", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                MainWindow.ListaDeDiscos.Add(discoagr);
                MessageBox.Show("El disco ha sido agregado");
                MainWindow.MiInvent.dgInventario.ItemsSource = null;
                MainWindow.MiMenu.dgInventario.ItemsSource = null;
                MainWindow.MiInvent.dgInventario.ItemsSource = MainWindow.ListaDeDiscos;
                MainWindow.MiMenu.dgInventario.ItemsSource = MainWindow.ListaDeDiscos;
                
                this.Hide();
            }          
            
            //MainWindow.MiInvent.Owner = this;
            MainWindow.MiInvent.Show();
            

        }

        private void btnCancelarAgreg_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();            

        }

        
    }
}
