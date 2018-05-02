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
using Torneo.BIZ;
using Torneo.COMMON.Entidades;
using Torneo.COMMON.Interfaces;
using Torneo.DAL;

namespace Entrada
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IManejadorUsuario manejadorUsuario;

        public MainWindow()
        {
            InitializeComponent();
            manejadorUsuario = new ManejadorUsuario(new RepositorioGenerico<Usuarios>());
            cmbUsuarioInicio.ItemsSource = null;
            cmbUsuarioInicio.ItemsSource = manejadorUsuario.Listar;

        }


        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {

            if (cmbUsuarioInicio.Text == "")

            {
                MessageBox.Show("Error", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        

            if (string.IsNullOrEmpty (txtContraceñaInicio.Password))
            {
                MessageBox.Show("No a ingresado la contraceña", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (cmbUsuarioInicio.SelectedItem != null)

            { 

                Usuarios b = cmbUsuarioInicio.SelectedItem as Usuarios;
                if (txtContraceñaInicio.Password == b.Contraceña)
                {

                    capturas abrir = new capturas();
                    abrir.Show();
                    this.Close();
                    MainWindow s = new MainWindow();

                    //aqui va algo
                }
                else
                {
                    MessageBox.Show("Contraceña incorrecta", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }






            }
            else
            {
                MessageBox.Show("No a  seleccionado ningun usuario", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }








            //capturas abrir = new capturas();
            //abrir.Show();
            //this.Close();
       // }
         //   else
           // {
               
             //   MessageBox.Show("Error", "Inicio", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
         
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButton.OK, MessageBoxImage.Error);
            this.Close();
        }
    }
}
