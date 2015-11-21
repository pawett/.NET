using Regata.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class RegataClaseViewModel
    {
        public string TituloRegata { get; set; }
        public List<Manga> mangas { get; set; }
        public Clase Clase { get; set; }
        public List<Embarcacion> EmbarcacionesInscritas { get; set; }
        public PuntuacionBase sistemaPuntuacion{ get; set; }
        public List<Clase> TodasClases { get; set; }
        public List<PuntuacionBase> TodosSistemasPuntuacion { get; set; }
        public ClasificacionViewModel Clasificacion { get; set; }
    }
}