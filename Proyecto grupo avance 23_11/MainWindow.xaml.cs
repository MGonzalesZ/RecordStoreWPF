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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_grupo_PRG2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public static int NivelPermiso = -1;

        public static Inventario MiInvent = new Inventario();
        public static MenuVentas MiMenu = new MenuVentas();     
        public static List<Disco> ListaDeDiscos = new List<Disco>();

        public static List<Disco> Carrito = new List<Disco>();

        
        public MainWindow()
        {
            InitializeComponent();
            
            Disco Disco01 = new Disco("Plastic Heart", "Miley Cirus", "rock, pop, synth-pop, glam-rock", 2020, 15, 38, 60.5, 11);
            Disco Disco02 = new Disco("Equals", "Ed Sheeran", "pop, new wave, contemporary, R&B", 2021, 14, 48, 70, 2);
            Disco Disco03 = new Disco("Happier than ever", "Billie Eilish", "pop, electro pop", 2021, 16, 56, 80, 3);
            Disco Disco04 = new Disco("Sentir Flamenco", "Manfariel Gitano", "flamenco", 2021, 12, 56, 65, 5);
            Disco Disco05 = new Disco("Sour", "Olivia Rodrigo", "pop, alternative pop, bedroom pop, pop punk", 2021, 11, 34, 65.8, 6);
            Disco Disco06 = new Disco("30", "Adele", "pop, soul, jazz", 2021, 15, 58, 92, 4);
            Disco Disco07 = new Disco("Red (Taylor's Version)", "Taylor Swift", "pop", 2021, 30, 130, 60, 10);
            Disco Disco08 = new Disco("24k Magic", "Bruno Mars", "R&B, soul, funk, pop, disco, new jack swing", 2016, 9, 33, 82, 18);
            Disco Disco09 = new Disco("Aires Andinos", "Pirai Vaca", "Clásica", 2010, 16, 61, 73, 2);
            Disco Disco10 = new Disco("After Hours", "The Weekend", "R&B, new wave, dream pop, electro pop, synth pop, alternative pop", 2020, 14, 56, 70, 5);
            //ListaDeDiscos.Add(Disco01);
            ListaDeDiscos.AddRange(new List<Disco>
            {
                Disco01,Disco02,Disco03,Disco04,Disco05,Disco06,Disco07,
                Disco08,Disco09,Disco10
            });
            
            MiInvent.dgInventario.ItemsSource = ListaDeDiscos;
            MiMenu.dgInventario.ItemsSource = ListaDeDiscos;

            //Usuario usuario1 = new Usuario("admin", "admin", "123456");
            //Usuario usuario2 = new Usuario("", "", "");
            //Usuario usuario3 = new Usuario("", "", "");
            //Usuario usuario4 = new Usuario("", "", "");
        }

        private void Btn_Registrar_Click(object sender, RoutedEventArgs e)
        {
            if (TBox_Usuario.Text == "admin" && PB_Contrasena.Password == "admin")
            {
                NivelPermiso = 300;
            }
            else if (TBox_Usuario.Text == "vendedor" && PB_Contrasena.Password == "vendedor")
            {
                NivelPermiso = 200;
            }

            if (NivelPermiso != -1)
            {
                MiMenu.Show();
                TBox_Usuario.Text = "";
                PB_Contrasena.Password = "";
            }
            else
            {
                MessageBox.Show("No es un usuario válido", "Mensaje:", MessageBoxButton.OK, MessageBoxImage.Error);
                TBox_Usuario.Text = "";
                PB_Contrasena.Password = "";
            }
            
        }

        private void Btn_ModInv_Click(object sender, RoutedEventArgs e)
        {
            if (TBox_Usuario.Text == "admin" && PB_Contrasena.Password == "admin")
            {
                NivelPermiso = 300;
            }
            else if (TBox_Usuario.Text == "vendedor" && PB_Contrasena.Password == "vendedor")
            {
                NivelPermiso = 200;
            }

            if (NivelPermiso == 300)
            {
                MiInvent.Show();
                TBox_Usuario.Text = "";
                PB_Contrasena.Password = "";
            }
            else
            {
                MessageBox.Show("Solo administradores pueden modificar el inventario", "Mensaje:", MessageBoxButton.OK, MessageBoxImage.Error);
                TBox_Usuario.Text = "";
                PB_Contrasena.Password = "";
            }
        }   
        
        //public class Usuario
        //{
        //    public string Nombre { get; set; }
        //    public string User { get; set; }
        //    public string Pass { get; set; }
        //    public Usuario(string nom, string us, string pass)
        //    {
        //        Nombre = nom;
        //        User = us;
        //        Pass = pass;
        //    }
        //}
    }
}
