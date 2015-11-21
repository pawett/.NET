using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regata.Negocio
{
    public class Protesta
    {
        public delegate void ProtestaResueltaHandler(Protesta protesta, EventArgs arg);
        public ProtestaResueltaHandler PropuestaResuelta;
        public DateTime HoraPresentacionProtesta { get; set; }
        public Embarcacion EmbarcacionInfractora { get; set; }
        public Penalizacion ReglaInfringida { get; set; }
        private bool resueltaFavorablemente = false;
        public bool ResueltaFavorablemente
        {
            get { return resueltaFavorablemente; }
            set
            {
                if (value) PropuestaResuelta(this, new EventArgs());
                resueltaFavorablemente = value;
            }

        }
    }
}
