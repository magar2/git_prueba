//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class inventario
    {
        public int idproducto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public string descripcion { get; set; }
        public decimal prec_com { get; set; }
        public decimal prec_vent { get; set; }
        public decimal stock { get; set; }
        public int idprovedor { get; set; }
    
        public virtual provedor provedor { get; set; }
    }
}
