using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Regata.Negocio;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class RegataViewModel
    {
        public string Nombre { get; set; }
        public string NombreAnterior { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        public List<Clase> Clases { get; set; }
        public List<ClaseViewModel> ListaClases { get; set; }
    }
}