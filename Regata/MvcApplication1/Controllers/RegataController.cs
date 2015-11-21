using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Regata.Negocio;
using MvcApplication1.Models;
using MvcApplication1.Datos;
using MvcApplication1.Extensions;
using System.Web.UI.WebControls;

namespace MvcApplication1.Controllers
{
    public class RegataController : Controller
    {
        //
        // GET: /Regata/
       
     
        private static bool inicializado = false;

        private void Inicializar()
        {
            
            Regata.Negocio.Regata r1 = new Regata.Negocio.Regata("Regata1",DateTime.Now,DateTime.Now.AddDays(5));
            Regata.Negocio.Regata r2 = new Regata.Negocio.Regata("Regata2",r1.FechaFin,r1.FechaInicio.AddDays(2));
            Regata.Negocio.Regata r3 = new Regata.Negocio.Regata("Regata3",r2.FechaFin,r2.FechaFin.AddDays(4));
            
            Clase c1 = new Clase();
            Clase c2 = new Clase();
            Clase c3 = new Clase();
            c1.Nombre = "Optimist";
            c2.Nombre = "Laser Estándar";
            c3.Nombre = "Laser Radial";
            Manga m1 = new Manga(DateTime.Now);
            Manga m2 = new Manga(DateTime.Now.AddHours(-5));
            Manga m3 = new Manga(DateTime.Now.AddHours(-2));

            Resultado res = new Resultado();
            res.Embarcacion = new Embarcacion() { NumeroVela = "ESP-1", Clase = c1 };
            res.Posicion = 1;

            Resultado res2 = new Resultado();
            res2.Embarcacion = new Embarcacion() { NumeroVela = "ESP-2", Clase = c1 };
            res2.Posicion = 2;


            Resultado res3 = new Resultado();
            res3.Embarcacion = new Embarcacion() { NumeroVela = "ESP-3", Clase = c1 };
            res3.Posicion = 3;

            m1.AñadirResultado(res);
            m1.AñadirResultado(res2);
            m1.AñadirResultado(res3);

            m2.AñadirResultado(res);
            m2.AñadirResultado(res2);
            m2.AñadirResultado(res3);

            m3.AñadirResultado(res);
            m3.AñadirResultado(res2);
            m3.AñadirResultado(res3);

            
            RegataClase rClase = new RegataClase(c1);
            
            rClase.AñadirSistemaPuntuacion(TipoPuntuacion.Baja, 5);
            rClase.AñadirManga(m1);
            rClase.AñadirManga(m2);
            rClase.AñadirManga(m3);
            r1.AñadirRegataClase(rClase);
            r2.AñadirRegataClase(rClase);
            r3.AñadirRegataClase(rClase);
            
            Inicializador.clases = new List<Clase>() { c1, c2, c3 };
           //r1.Clases = new List<Clase>() { c1, c2 };
           // r2.Clases = new List<Clase>() { c1, c3 }; ;
           // r3.Clases = new List<Clase>() { c2 }; ;

            Inicializador.regatas.Add(r1);
            Inicializador.regatas.Add(r2);
            Inicializador.regatas.Add(r3);

            inicializado = true;
        }
        private Embarcacion GenerarEmbarcacion()
        {
            Embarcacion embarcacion = new Embarcacion();
            embarcacion.Clase = new Clase();
            embarcacion.NumeroVela = String.Concat("ESP-", new Random(34).Next(1, 100));
            return embarcacion;
        }

        public ActionResult Index()
        {
            if (!inicializado) Inicializar();

            return View(Inicializador.regatas.OrderBy(r=>r.FechaInicio));
        }
     
        public ActionResult Mostrar(string nombre)
        {
            if (nombre != null)
            {
                Regata.Negocio.Regata regataActual = Inicializador.regatas.First(r => r.Nombre.Equals(nombre));
                RegataViewModel rvm = regataActual.Mapear();
        
                return View(rvm);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Editar(string nombre)
        {
            var regataActual = Inicializador.regatas.First(r => r.Nombre.Equals(nombre));
            RegataViewModel rvm = regataActual.Mapear();
            rvm.NombreAnterior = nombre;

            rvm.ListaClases = new List<ClaseViewModel>();
                       
            foreach(var clase in Inicializador.clases )
            {
                ClaseViewModel vmcb = new ClaseViewModel();
                vmcb.Nombre = clase.Nombre;
                vmcb.Seleccionado= regataActual.Clases.Contains(clase);
                rvm.ListaClases.Add(vmcb);
            }
           
            return View(rvm);
        }

        [HttpPost]
        public ActionResult Editar(RegataViewModel regataVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Regata.Negocio.Regata regata = regataVM.Mapear();
                    Regata.Negocio.Regata indice = Inicializador.regatas.Find(r => r.Nombre == regataVM.NombreAnterior);
                    if (indice !=null)
                    {
                        regata.RegatasClase = indice.RegatasClase;
                        Inicializador.regatas.Remove(indice);
                    }
                    foreach (var clase in regataVM.ListaClases)
                    {
                        Clase oClase = Inicializador.clases.Find(c2 => c2.Nombre == clase.Nombre);
                        if (clase.Seleccionado)
                        {
                            if (!regata.Clases.Exists(c => c.Nombre == clase.Nombre))
                            {
                                regata.RegatasClase.Add(oClase, new RegataClase(oClase));
                            }
                        }
                        else if(regata.Clases.Exists(c => c.Nombre == clase.Nombre))
                        {
                            regata.RegatasClase.Remove(oClase);
                        }
                    }
                    Inicializador.regatas.Add(regata);
                }
                catch (Exception ex)
                {

                }
            }
            return RedirectToAction("Index");
        }   

        public ActionResult Crear()
        {
            RegataViewModel rvm = new Regata.Negocio.Regata().Mapear();
           
            return View(rvm);
        }

        [HttpPost]
        public ActionResult Crear(RegataViewModel regataVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Regata.Negocio.Regata regata = regataVM.Mapear();
                    Inicializador.regatas.Add(regata);
                }
                catch (Exception ex)
                {

                }   
            }
            return RedirectToAction("Index");
        }     
    }
}
