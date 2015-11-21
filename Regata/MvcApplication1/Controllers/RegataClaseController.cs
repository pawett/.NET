using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Regata.Negocio;
using MvcApplication1.Datos;
using AutoMapper;
using MvcApplication1.Models;
using MvcApplication1.Extensions;

namespace MvcApplication1.Controllers
{
    public class RegataClaseController : Controller
    {
        //
        // GET: /RegataClase/

        public ActionResult Index(string nombre)
        {
            List<RegataClaseViewModel> listaRegatas = new List<RegataClaseViewModel>();
            Regata.Negocio.Regata regata = Inicializador.regatas.Find(r => r.Nombre == nombre);
            foreach (var claseRegata in regata.RegatasClase.Keys)
            {
                RegataClaseViewModel regataVM = (regata.RegatasClase[claseRegata]).Mapear(regata.Nombre);
                listaRegatas.Add(regataVM);
            }
            return View(listaRegatas);
        }        

        public ActionResult Mostrar(string regata, string clase)
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
            return View(regataVM);
        }

    }
}
