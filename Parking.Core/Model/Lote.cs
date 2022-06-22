//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parking.Core.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lote
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lote()
        {
            this.EspacioDelimitadoes = new HashSet<EspacioDelimitado>();
        }
    
        public int IdLote { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string Email { get; set; }
        public string Identificador { get; set; }
        public string Token { get; set; }
        public string Direccion { get; set; }
        public Nullable<System.DateTime> Eliminado { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string FuenteVideo { get; set; }
        public string RutaModelo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EspacioDelimitado> EspacioDelimitadoes { get; set; }
    }
}
