using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regata.Negocio
{
    
    public class RegataClase
    {
        private List<Manga> mangas = new List<Manga>();
        public Clase Clase { get; private set; }
        public List<Embarcacion> EmbarcacionesInscritas { get; private set; }
        public PuntuacionBase sistemaPuntuacion;

        public RegataClase(Clase clase)
        {
            this.Clase = clase;
        }

        public void AñadirSistemaPuntuacion(TipoPuntuacion tipoPuntuacion, int posicionesPenalizacion)
        {
            if (EmbarcacionesInscritas == null) EmbarcacionesInscritas = new List<Embarcacion>();
            if (sistemaPuntuacion == null)
            {
                sistemaPuntuacion = PuntuacionCreador.Crear(tipoPuntuacion, EmbarcacionesInscritas.Count, posicionesPenalizacion);
            }
        }

        public void InscribirEmbarcacion(Embarcacion embarcacion)
        {
                if (EmbarcacionesInscritas==null)
                {
                    EmbarcacionesInscritas = new List<Embarcacion>();
                }
                if (embarcacion.Clase.Equals(this.Clase))
                {
                    EmbarcacionesInscritas.Add(embarcacion);
                }
                else
                {
                    throw new ArgumentException("La embarcación no pertenece a la misma clase que la regata");
                }
        }

        public void AñadirManga(Manga manga)
        {        
            mangas.Add(manga); 
        }

        public List<Manga> ObtenerMangas()
        {
            return mangas;
        }

        public Clasificacion ObtenerClasificacion()
        {
            var clasificacion = new Clasificacion(sistemaPuntuacion);
            clasificacion.GenerarClasificacion(mangas);
            return clasificacion;
        }
    }
}
