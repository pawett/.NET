using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regata.Negocio
{
    public class Regata
    {
        public string Nombre { get;  set; }
        public DateTime FechaInicio { get;  set; }
        public DateTime FechaFin { get;  set; }
        public Dictionary<Clase, RegataClase> RegatasClase {get;set;}
        public List<Clase> Clases {
            get {
                    if (RegatasClase != null)
                    {
                        return RegatasClase.Keys.ToList();
                    }
                    else
                    {
                        return new List<Clase>();
                    }
            } }

        public Regata()
        {
            RegatasClase = new Dictionary<Clase,RegataClase>();
        }

        public Regata(string nombre,DateTime fechaInicio, DateTime fechaFin)
        {
            this.Nombre = nombre;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            RegatasClase = new Dictionary<Clase, RegataClase>();
        }
            

        public void AñadirRegataClase(RegataClase rClase)
        {
            if (!Clases.Contains(rClase.Clase))
            {

                RegatasClase.Add(rClase.Clase, rClase);
            }
            else
            {
                throw new ArgumentException("Ya existe información para dicha clase");
            }
        }
    }
}
