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
    
    public partial class VehiculoTransaccion
    {
        public int IdTransaccion { get; set; }
        public string Placa { get; set; }
        public string TipoTransaccion { get; set; }
        public System.DateTime Fecha { get; set; }
        public int IdLote { get; set; }
        public Nullable<System.DateTime> Eliminado { get; set; }
    
        public virtual Vehiculo Vehiculo { get; set; }
        public virtual Lote Lote { get; set; }
    }
}
