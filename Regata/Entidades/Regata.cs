using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Regata
    {
        public Dictionary<Clase, List<Manga>> mangas { get; set; }
        public List<Clase> Clases { get; set; }
        public Dictionary<Clase, List<Embarcacion>> embarcacionesInscritas { get; set; }
        public Puntuacion SistemaPuntuacion { get; set; }
        public Clasificacion clasificacion { get; set; }
    }
}
