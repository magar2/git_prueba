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

using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para Registros.xaml
    /// </summary>
    public partial class Registros : Window
    {

        int x = 0;

        public Registros()
        {
            InitializeComponent();



        }
        private void cambio1()
        {
            fecha.IsEnabled = true;
            fecha2.IsEnabled = true;
            txt_nom.IsEnabled = true;
            txt_domi.IsEnabled = true;
            txt_ape_mat.IsEnabled = true;
            txt_ape_pat.IsEnabled = true;
            txt_ife.IsEnabled = true;
            txt_cur.IsEnabled = true;
            txt_rfc.IsEnabled = true;
            txt_tel.IsEnabled = true;

        }
        private void cambio()
        {
            fecha.IsEnabled = false;
            fecha2.IsEnabled = false;
            txt_nom.IsEnabled = false;
            txt_domi.IsEnabled = false;
            txt_ape_mat.IsEnabled = false;
            txt_ape_pat.IsEnabled = false;
            txt_ife.IsEnabled = false;
            txt_cur.IsEnabled = false;
            txt_rfc.IsEnabled = false;
            txt_tel.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Program.z == 0)
            {


                if (Program.y == 0)
                {



                    if (x == 0)
                    {
                        if (usuario_tipo.Text == "")
                        {

                            MessageBox.Show("Selecciona un usuario");

                        }
                        else
                        {


                            guardar.Content = "Guardar";
                            x = 1;
                            cambio1();

                            using (IncerEntities5 db = new IncerEntities5())
                            {
                                var per = db.empleado.Where(d => d.nombre == usuario_tipo.Text).First();
                                txt_nom.Text = per.nombre;
                                fecha.Text = per.fecha_alta.ToString();
                                fecha2.Text = per.fecha_nac.ToString();
                                txt_domi.Text = per.domicilio;
                                txt_ape_mat.Text = per.ap_mat;
                                txt_ape_pat.Text = per.ap_pat;
                                txt_ife.Text = per.ife;
                                txt_cur.Text = per.curp;
                                txt_rfc.Text = per.rfc;
                                txt_tel.Text = per.telefono;
                            }


                        }

                    }
                    else
                    {
                        using (Model.IncerEntities5 db = new IncerEntities5())
                        {
                            var per = db.empleado.Where(d => d.nombre == usuario_tipo.Text).First();
                            per.nombre = txt_nom.Text;
                            per.fecha_alta = DateTime.Parse(fecha.Text);
                            per.fecha_nac = DateTime.Parse(fecha2.Text);
                            per.domicilio = txt_domi.Text;
                            per.ap_mat = txt_ape_mat.Text;
                            per.ap_pat = txt_ape_pat.Text;
                            per.ife = txt_ife.Text;
                            per.curp = txt_cur.Text;
                            per.rfc = txt_rfc.Text;
                            per.telefono = txt_tel.Text;

                            db.Entry(per).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            MessageBox.Show("Datos guardados satisfactorimente");
                            borra_campos();
                            x = 0;
                            this.Hide();
                        }

                    }
                }
                else if (usuario_tipo.Text == "")
                {
                    using (Model.IncerEntities5 db = new IncerEntities5())
                    {
                        var per = db.empleado.Where(d => d.nombre == usuario_tipo.Text).First();
                        per.nombre = txt_nom.Text;
                        per.fecha_alta = DateTime.Parse(fecha.Text);
                        per.fecha_nac = DateTime.Parse(fecha2.Text);
                        per.domicilio = txt_domi.Text;
                        per.ap_mat = txt_ape_mat.Text;
                        per.ap_pat = txt_ape_pat.Text;
                        per.ife = txt_ife.Text;
                        per.curp = txt_cur.Text;
                        per.rfc = txt_rfc.Text;
                        per.telefono = txt_tel.Text;

                        db.Entry(per).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    guardar.Content = "Guardar";
                    cambio1();
                    Program.z = 1;
                    using (Model.IncerEntities5 db = new IncerEntities5())
                    {
                        var tip = db.tipousuario.Where(d => d.tipo == usuario_tipo.Text).First();
                        Program.tipo = tip.idtipo;
                    }

                }



            }
            else
            {
                using (Model.IncerEntities5 db = new IncerEntities5())
                {
                    var nvo = new Model.empleado();
                    nvo.nombre = txt_nom.Text;
                    nvo.ife = txt_ife.Text;
                    nvo.ap_mat = txt_ape_mat.Text;
                    nvo.ap_pat = txt_ape_pat.Text;
                    nvo.domicilio = txt_domi.Text;
                    nvo.fecha_alta = DateTime.Parse(fecha.Text);
                    nvo.fecha_nac = DateTime.Parse(fecha2.Text);
                    nvo.telefono = txt_tel.Text;
                    nvo.rfc = txt_rfc.Text;
                    nvo.curp = txt_cur.Text;
                    nvo.idtipo = Program.tipo;


                    db.empleado.Add(nvo);
                    db.SaveChanges();
                }

                MessageBox.Show("Registrado corectamente");
                Program.z = 0;
                borra_campos();
                this.Hide();


            }
        }
        public void mostrartipo_usuario()
        {
            List<ModeloCliente> lst = new List<ModeloCliente>();
            using (IncerEntities5 db = new IncerEntities5())
            {
                lst = (from d in db.tipousuario
                       select new ModeloCliente
                       {
                           Id = d.idtipo,
                           Nombre = d.tipo
                       }).ToList();
            }
            usuario_tipo.ItemsSource = lst;
            usuario_tipo.SelectedValuePath = "Id";
            usuario_tipo.DisplayMemberPath = "Nombre";
        }
        public void cargarlosusuarios()
        {
            List<ModeloEmpleado> lst = new List<ModeloEmpleado>();
            using (IncerEntities5 db = new IncerEntities5())
            {
                lst = (from d in db.empleado
                       select new ModeloEmpleado
                       {
                           Id = d.idempleado,
                           Nombre = d.nombre

                       }).ToList();
            }
            usuario_tipo.ItemsSource = lst;
            usuario_tipo.SelectedValuePath = "Nombre";
            usuario_tipo.DisplayMemberPath = "Nombre";
        }


        private void borra_campos()
        {
            usuario_tipo.Text = "";
            fecha.Text = "";
            fecha2.Text = "";
            txt_domi.Text = "";
            txt_nom.Text = "";
            txt_ape_mat.Text = "";
            txt_ape_pat.Text = "";
            txt_cur.Text = "";
            txt_ife.Text = "";
            txt_rfc.Text = "";
            txt_tel.Text = "";
        }

       

        private void llamartipo()
        {
            using (Model.IncerEntities5 db = new IncerEntities5())
            {
                var tip = db.tipousuario.Where(d => d.tipo == usuario_tipo.Text).First();

                Program.tipo = tip.idtipo;


            }
        }
       
    }
}

