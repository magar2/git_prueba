using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaLogica
{
   public  class clsUsuarios
   {
        clsManejador M = new clsManejador();

        public int IdEmpleado { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public String RegistrarUsuarios()
        {
            List<clsParametros> lst = new List<clsParametros>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametros("@idempleado", IdEmpleado));
                lst.Add(new clsParametros("@usuario", User));
                lst.Add(new clsParametros("@password", Password));
                lst.Add(new clsParametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("RegistrarUsuario", ref lst);
                return Mensaje = lst[3].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String IniciarSesion()
        {
            List<clsParametros> lst = new List<clsParametros>();
            String Mensaje = "";
            try
            {
                lst.Add(new clsParametros("@usuario", User));
                lst.Add(new clsParametros("@password", Password));
                lst.Add(new clsParametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                M.EjecutarSP("Login", ref lst);
                return Mensaje = lst[2].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DevolverDatosSesion(String objUser, String objPassword)
        {
            List<clsParametros> lst = new List<clsParametros>();
            try
            {
                lst.Add(new clsParametros("@usuario", objUser));
                lst.Add(new clsParametros("@password", objPassword));
                return M.Listado("DevolverDatosSesion", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
