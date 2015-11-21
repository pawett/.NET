using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Manga
    {
        public Clase clase { get; set; }
        public DateTime HoraSalida { get; set;}
        public List<Resultado> Resultados { get; set; }
        public List<Protesta> Protestas { get; set; }

    }
}
