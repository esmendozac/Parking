using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Core.Model
{
    public class ResumenTransaccion
    {

        public string Guid { get; set; }
        public string Placa { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public decimal? Tiempo { get; set; }
        public decimal TarifaFraccion { get; set; }
        public decimal TarifaFija { get; set; }
        public decimal? Valor { get; set; }
    }
}