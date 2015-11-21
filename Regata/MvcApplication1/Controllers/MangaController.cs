using MvcApplication1.Datos;
using MvcApplication1.Models;
using Regata.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class MangaController : Controller
    {
        //
        // GET: /Manga/

        public ActionResult Index(string nombreRegata, string nombreClase)
        {
            Clase clase = Inicializador.clases.Find(c=>c.Nombre==nombreClase);
            List<RegataClaseViewModel> listaRegatas = new List<RegataClaseViewModel>();
            Regata.Negocio.Regata regata = Inicializador.regatas.Find(r => r.Nombre == nombreRegata);
            List<Manga> mangas = regata.RegatasClase[clase].ObtenerMangas();
            return PartialView(mangas);
        }

       

    }
}
