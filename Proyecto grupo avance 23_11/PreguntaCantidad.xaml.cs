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
    /// Lógica de interacción para PreguntaCantidad.xaml
    /// </summary>
    public partial class PreguntaCantidad : Window
    {
        public int Max { get; set; }
        public int valor { get; set; }
        public PreguntaCantidad()
        {
            InitializeComponent();
        }

        public void btnCantidad_Click(object sender, RoutedEventArgs e)
        {
            
            if (int.Parse(txtCantidad.Text) <= Max)
            {
                MessageBox.Show("Cantidad aceptada", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
                valor= int.Parse(txtCantidad.Text);
                txtCantidad.Text = "";
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se cuenta con esta cantidad en stock", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Error);
                valor = -1;
            }
        }

        private void btncancelPreg_Click(object sender, RoutedEventArgs e)
        {
            valor = -1;
            txtCantidad.Text = "";
            this.Hide();
        }
    }
}
