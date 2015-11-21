using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Protesta
    {
        public DateTime HoraProtesta { get; set; }
        public Embarcacion EmbarcacionInfractora { get; set; }
        public Embarcacion EmbarcacionDenunciante { get; set; }
        public Regla ReglaInfringida { get; set; }
        public Resolucion Resolucion { get; set; }
    }
}
