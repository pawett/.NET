using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regata.Negocio
{
   public class Resultado
    {
       public int Posicion { get; set; } 
       public Embarcacion Embarcacion { get; set; }
        public Penalizacion Penalizacion { get; set; }
        public DateTime? HoraLlegada {get;set;}        
    }
}
