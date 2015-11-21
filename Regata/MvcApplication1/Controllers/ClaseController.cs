using Regata.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ClaseController : Controller
    {
        //
        // GET: /Clase/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MostrarTodas()
        {
            Clase c1 = new Clase();
                Clase c2 = new Clase();
                Clase c3 = new Clase();
                c1.Nombre = "Optimist";
                c2.Nombre = "Laser Estándar";
                c3.Nombre = "Laser Radial";
                var listClases =  new List<Clase>() { c1, c2, c3 };
                return View(listClases);
        }
        public ActionResult Create()
        {
            return View();
        }

    }
}
