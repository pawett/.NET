using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regata.Negocio
{
    class ProtestaEmbarcacion:Protesta
    { 
        public Embarcacion EmbarcacionDenunciante { get; set; }
    }
}
