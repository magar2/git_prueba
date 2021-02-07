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

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
            num_emple.Content = Program.IdEmpleadoLogueado;
            nom_emple.Content = Program.NombreEmpleadoLogueado;
            ape_emple.Content = Program.ApellidoEmpleadoLogueado;
            fecha.Content = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void registro_Click(object sender, RoutedEventArgs e)
        {
            Registro frm = new Registro();
            frm.ShowDialog();
        }
    }
}
