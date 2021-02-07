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

using System.Data;
using CapaLogica;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        clsUsuarios U = new clsUsuarios();

        int x = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {


            if (txtusuario1.Text.Trim() != "")
            {
                if (txtpass.Password.Trim() != "")
                {
                    String Mensaje = "";
                    U.User = txtusuario1.Text;
                    U.Password = txtpass.Password;
                    Mensaje = U.IniciarSesion();
                    if (Mensaje == "Su Contraseña es Incorrecta.")
                    {
                        cargar.IsOpen = true;
                        texto.Text = Mensaje;
                        boton.Content = "Regresar";
                        txtpass.Clear();
                        txtpass.Focus();
                    }
                    else if (Mensaje == "El Nombre de Usuario no Existe.")
                    {
                        cargar.IsOpen = true;
                        texto.Text = Mensaje;
                        boton.Content = "Regresar";
                        txtusuario1.Clear();
                        txtpass.Clear();
                        txtusuario1.Focus();
                    }
                    else
                    {
                        cargar.IsOpen=true;
                        texto.Text = Mensaje;
                         x = 1;
                        boton.Content = "Bienvenido";
                        RecuperarDatosSesion();


                    }
                }
                else
                {
                    
                    cargar.IsOpen = true;
                    texto.Text = "Pro favor Ingresa tu contraseña.";
                    boton.Content = "Regresar";
                    txtpass.Focus();
                }
            }
            else
            {
                cargar.IsOpen = true;
                texto.Text = "No puedes dejar campos en blanco.";
                boton.Content = "Regresar";
                txtusuario1.Focus();
            }
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void boton_Click(object sender, RoutedEventArgs e)
        {
            if (x == 1)
            {
                cargar.IsOpen = false;
                this.Hide();
                Principal frm = new Principal();
                frm.Show();
            }
            else
            {
                cargar.IsOpen = false;
            }
            

        }
        private void RecuperarDatosSesion()
        {
            DataRow row;
            DataTable dt = new DataTable();
            dt = U.DevolverDatosSesion(txtusuario1.Text, txtpass.Password);
            if (dt.Rows.Count == 1)
            {
                row = dt.Rows[0];
                Program.IdEmpleadoLogueado = Convert.ToInt32(row[0].ToString());
                Program.NombreEmpleadoLogueado = row[1].ToString();
                Program.ApellidoEmpleadoLogueado = row[2].ToString();
            }

        }
    }
}
