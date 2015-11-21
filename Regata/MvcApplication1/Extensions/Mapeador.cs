using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Regata.Negocio;

namespace MvcApplication1.Extensions
{
 
    public static class MapeadorRegata
    {
        public static RegataViewModel Mapear(this Regata.Negocio.Regata regata)
        {
            Mapper.CreateMap<Regata.Negocio.Regata, RegataViewModel>();
            Mapper.CreateMap<RegataClase, RegataClaseViewModel>();
            RegataViewModel rvm = Mapper.Map<RegataViewModel>(regata);
            rvm.Clases = regata.RegatasClase.Keys.ToList();
            return rvm;
        }

        public static Regata.Negocio.Regata Mapear(this RegataViewModel regata)
        {
            Mapper.CreateMap<RegataViewModel,Regata.Negocio.Regata>();
            return Mapper.Map<Regata.Negocio.Regata>(regata);

    
        }

        public static RegataClaseViewModel Mapear(this RegataClase regataClase,string nombreRegata)
        {
            Mapper.CreateMap<RegataClase, RegataClaseViewModel>();
            RegataClaseViewModel regataVM = Mapper.Map<RegataClaseViewModel>(regataClase);
            regataVM.mangas = regataClase.ObtenerMangas();
            regataVM.TituloRegata = nombreRegata;
            return regataVM;
        }
    }

}