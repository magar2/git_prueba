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

using CapaLogica;
using WpfApp1.Model;



namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        clsempleados E = new clsempleados();
        Registros R = new Registros();
        public Registro()
        {
            InitializeComponent();
            MostrarListadoEmpleados();
            MostrarlistaClientes();
            MostrarListaProvedores();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cargar.IsOpen = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }


        private void MostrarListadoEmpleados()
        {
            List<ModeloEmpleado> lst = new List<ModeloEmpleado>();
            using (IncerEntities5 db = new IncerEntities5())
            {
                lst = (from d in db.empleado
                       select new ModeloEmpleado
                       {
                           Nombre = d.nombre,
                           Apellido = d.ap_pat,
                           Domicilio = d.domicilio,
                           Telefono = d.telefono,
                           Id = d.idempleado



                       }).ToList();

            }

            DG01.ItemsSource = lst;


        }

        private void MostrarlistaClientes()
        {
            List<ModeloCliente> lst = new List<ModeloCliente>();
            using (IncerEntities5 db = new IncerEntities5())
            {
                lst = (from d in db.cliente
                       select new ModeloCliente
                       {
                           Nombre = d.nombre,
                           Direccion = d.direccion,
                           Telefono = d.telefono,
                           Id = d.idcliente
                       }).ToList();
            }

            DG02.ItemsSource = lst;
        }

        private void MostrarListaProvedores()
        {
            List<ModeloProvedores> lst = new List<ModeloProvedores>();
            using (IncerEntities5 db = new IncerEntities5())
            {
                lst = (from d in db.provedor
                       select new ModeloProvedores
                       {
                           Razon_social = d.rason_social,
                           Direccion = d.direccion,
                           Telefono = d.telefono,
                           Tipo = d.tipo_prod,
                           Id = d.idprovedor

                       }).ToList();
            }
            DG03.ItemsSource = lst;
        }

        private void MostrarListadetipou_suario()
        {
            
        }



        private void cargar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void nv_emp_Click(object sender, RoutedEventArgs e)
        {
            cargar.IsOpen = false;
            R.tipo.Content = "        Tipo de usuario :";
            R.mostrartipo_usuario();
            Program.y = 1;
            Program.z = 0;
            R.tipo.Content = "   Selecciona usuario :";
            R.fecha.IsEnabled = false;
            R.fecha2.IsEnabled = false;
            R.txt_nom.IsEnabled = false;
            R.txt_domi.IsEnabled = false;
            R.txt_ape_mat.IsEnabled = false;
            R.txt_ape_pat.IsEnabled = false;
            R.txt_ife.IsEnabled = false;
            R.txt_cur.IsEnabled = false;
            R.txt_rfc.IsEnabled = false;
            R.txt_tel.IsEnabled = false;
            R.guardar.Content = "Cargar";
            R.ShowDialog();
            MostrarListadoEmpleados();
        }

        private void ed_emp_Click(object sender, RoutedEventArgs e)
        {
            cargar.IsOpen = false;
            R.tipo.Content = "   Selecciona usuario :";
            R.fecha.IsEnabled = false;
            R.fecha2.IsEnabled = false;
            R.txt_nom.IsEnabled = false;
            R.txt_domi.IsEnabled = false;
            R.txt_ape_mat.IsEnabled = false;
            R.txt_ape_pat.IsEnabled = false;
            R.txt_ife.IsEnabled = false;
            R.txt_cur.IsEnabled = false;
            R.txt_rfc.IsEnabled = false;
            R.txt_tel.IsEnabled = false;
            R.guardar.Content = "Cargar";
            R.cargarlosusuarios();
            Program.y = 0;
            R.ShowDialog();
            MostrarListadoEmpleados();
           
        }

        private void eli_emp_Click(object sender, RoutedEventArgs e)
        {
            cargar.IsOpen = false;
            R.tipo.Content = "   Selecciona usuario :";
            R.fecha.IsEnabled = false;
            R.fecha2.IsEnabled = false;
            R.txt_nom.IsEnabled = false;
            R.txt_domi.IsEnabled = false;
            R.txt_ape_mat.IsEnabled = false;
            R.txt_ape_pat.IsEnabled = false;
            R.txt_ife.IsEnabled = false;
            R.txt_cur.IsEnabled = false;
            R.txt_rfc.IsEnabled = false;
            R.txt_tel.IsEnabled = false;
            R.guardar.Content = "Eliminar";
            R.cargarlosusuarios();
            R.ShowDialog();

        }
    }

    public class ModeloEmpleado
    {
        public int Id { get; set; }
       public int Tipo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Aellido2 { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Curp { get; set; }
        public string Ife { get; set; }
        public string Rfc { get; set; }
        public DateTime Fecha_nac { get; set; }
        public DateTime fecha_alta { get; set; }

    }
    public class ModeloCliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        
    } 

    public class ModeloProvedores
    {
        public int Id { get; set; }
        public string Razon_social { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Tipo { get; set; }
    }
}

