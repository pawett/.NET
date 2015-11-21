using Regata.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Datos
{
    public static class Inicializador
    {
        public static List<Regata.Negocio.Regata> regatas = new List<Regata.Negocio.Regata>();
        public static List<Clase> clases = new List<Clase>();
    }
}