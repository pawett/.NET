using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regata.Negocio
{
    public class Manga
    {
        public DateTime horaSalida { get; private set;}
        private List<Resultado> resultados = new List<Resultado>();
        private List<Protesta> protestas = new List<Protesta>();
        public List<Resultado> Resultados { get { return resultados; } }
        public List<Protesta> Protestas { get { return protestas; } }
    
        
        public Manga(DateTime horaSalida)
        {
            this.horaSalida = horaSalida;
        }
       
        public void AñadirResultado(Resultado resultado)
        {
            resultados.Add(resultado);
        }

        public void AñadirResultado(Resultado resultado, int posicion)
        {
            if (posicion >= resultados.Count) throw new ArgumentException("No existe la posición a insertar");
            resultados.Insert(posicion, resultado);
        }

        public void ModificarResultado(Resultado resultado, int posicionActual, int posicionNueva)
        {
            if (posicionActual >= resultados.Count) throw new ArgumentException("No se encuentra el elemento en la posición indicada");

            Resultado res = resultados[posicionActual];
            resultados.RemoveAt(posicionActual);

            if (posicionNueva >= resultados.Count) throw new ArgumentException("No existe la posición nueva a insertar");

            resultados.Insert(posicionNueva, res);
        }
        public void AñadirProtesta(Protesta protesta)
        {
            protestas.Add(protesta);
            //protesta.PropuestaResuelta += new Protesta.ProtestaResueltaHandler(ModificarResultadoPorProtesta);
            protesta.PropuestaResuelta += ModificarResultadoPorProtesta; //simplified call
            protesta.PropuestaResuelta += delegate(Protesta p, EventArgs arg)
            {
                ModificarResultadoPorProtesta(p, arg);
            };

            //EventArgs args = new EventArgs();
            //protesta.PropuestaResuelta += (protesta,args) =>
            //{
            //    //do your things here
            //}

            //if (protesta.ResueltaFavorablemente)
            //{
            //    ModificarResultadoPorProtesta(protesta, new EventArgs());
            //}
        }

        private void ModificarResultadoPorProtesta(Protesta protesta, EventArgs args)
        {
             resultados.Find(r=>r.Embarcacion.Equals(protesta.EmbarcacionInfractora)).
                  Penalizacion=protesta.ReglaInfringida;
        }


        public List<Resultado> ObtenerResultados()
        {  
            foreach (Protesta protesta in protestas.FindAll(p=>p.ResueltaFavorablemente))
            {
              resultados.Find(r=>r.Embarcacion.Equals(protesta.EmbarcacionInfractora)).
                  Penalizacion=protesta.ReglaInfringida;
            }
            return resultados;
        }

    }
}
