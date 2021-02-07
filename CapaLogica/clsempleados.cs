using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;






namespace CapaLogica
{
    public class clsempleados
    {
        clsManejador M = new clsManejador();

        public int idempleado { get; set; }
        public int idtipo { get; set; }
        public string ife { get; set; }
        public string nombre { get; set; }
        public string ap_mat { get; set; }
        public string ap_pat { get; set; }
        public string domicilio { get; set; }
        public DateTime fecha_nac { get; set; }
        public string telefono { get; set; }
        public string rfc { get; set; }
        public string curp { get; set; }
        public DateTime fecha_alta { get; set; }

        public class ModeloEmpleado
        {
            public int idempleado { get; set; }
            public int idtipo { get; set; }
            public string ife { get; set; }
            public string nombre { get; set; }
            public string ap_mat { get; set; }
            public string ap_pat { get; set; }
            public string domicilio { get; set; }
            public DateTime fecha_nac { get; set; }
            public string telefono { get; set; }
            public string rfc { get; set; }
            public string curp { get; set; }
            public DateTime fecha_alta { get; set; }

        }

        public String MantenimientoEmpleados()
        {
            List<clsParametros> lst = new List<clsParametros>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametros("@idempleado", idempleado));
                lst.Add(new clsParametros("@idtipo", idtipo));
                lst.Add(new clsParametros("@ife", ife));
                lst.Add(new clsParametros("@nombre", nombre));
                lst.Add(new clsParametros("@ap_mat", ap_mat));
                lst.Add(new clsParametros("@ap_pat", ap_pat));
                lst.Add(new clsParametros("@domicilio", domicilio));
                lst.Add(new clsParametros("@fecha_nac", fecha_nac));
                lst.Add(new clsParametros("@telefono", telefono));
                lst.Add(new clsParametros("@rfc", rfc));
                lst.Add(new clsParametros("@curp", curp));
                lst.Add(new clsParametros("@fecha_alta", fecha_alta));
                lst.Add(new clsParametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.EjecutarSP("MantenimientoEmpleados", ref lst);
                return Mensaje = lst[12].Valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListadoEmpleados()
        {
            return M.Listado("ListadoEmpleados", null);
        }

        public String EliminarUsuario()
        {
            List<clsParametros> lst = new List<clsParametros>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametros("@idempleado", idempleado));
                lst.Add(new clsParametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.EjecutarSP("EliminarUsuario", ref lst);
                return Mensaje = lst[1].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String EliminarEpleado()
        {
            List<clsParametros> lst = new List<clsParametros>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametros("@idempleado", idempleado));
                lst.Add(new clsParametros("@nombre", nombre));
                lst.Add(new clsParametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.EjecutarSP("EliminarEmpleado", ref lst);
                return Mensaje = lst[2].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    
        
       
    }
}

