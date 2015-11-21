using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Clasificacion
    {
        public Puntuacion SistemaPuntuacion { get; set; }
        public Dictionary<Embarcacion, double> PuntuacionFinal { get; set; }
        public Dictionary<Embarcacion, Dictionary<Manga, double>> PuntuacionesMangas { get; set; }        
    }
}
