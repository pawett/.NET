using AutoMapper;
using MvcApplication1.Datos;
using MvcApplication1.Models;
using Regata.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Extensions;

namespace MvcApplication1.Controllers
{
    public class ClasificacionController : Controller
    {
        //
        // GET: /Clasificacion/

        public ActionResult Index(string regata, string clase)
        {
            Clase oClase = Inicializador.clases.Find(c => c.Nombre == clase);
            List<RegataClaseViewModel> listaRegatas = new List<RegataClaseViewModel>();
            Regata.Negocio.Regata oRegata = Inicializador.regatas.Find(r => r.Nombre == regata);
            Mapper.CreateMap<RegataClase, RegataClaseViewModel>();
            RegataClaseViewModel regataVM = (oRegata.RegatasClase[oClase]).Mapear(oRegata.Nombre);

            Clasificacion clasificacion = new Clasificacion(regataVM.sistemaPuntuacion);
            clasificacion.GenerarClasificacion(regataVM.mangas);
           
            ClasificacionViewModel cvm = new ClasificacionViewModel();
            cvm.ObtenerTablaResultados(clasificacion);
            regataVM.Clasificacion = cvm;
            return PartialView(cvm.TablaResultados);
        }

    }
}
