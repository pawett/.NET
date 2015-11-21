using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regata.Negocio
{
    public class Clasificacion
    {
        private PuntuacionBase sistemaPuntuacion;
        private Dictionary<Embarcacion, double> puntuacionFinal;
        private Dictionary<Embarcacion, Dictionary<Manga, double>> puntuacionesMangas;

        public Clasificacion(PuntuacionBase sistemaPuntuacion)
        {
            this.sistemaPuntuacion = sistemaPuntuacion;
            puntuacionesMangas = new Dictionary<Embarcacion, Dictionary<Manga, double>>();
            puntuacionFinal = new Dictionary<Embarcacion, double>();
        }

        public Dictionary<Embarcacion, Dictionary<Manga, double>> PuntuacionesMangas()
        {
            return puntuacionesMangas;
        }

        public Dictionary<Embarcacion, double> ObtenerClasificacionGeneral()
        {
            return puntuacionFinal;
        }

    
        public void GenerarClasificacion(List<Manga> mangas )
        {
            foreach (Manga m in mangas)
            {
                AñadirResultadosManga(m, ObtenerClasificacionManga(m));
            }
        }

        private Dictionary<Embarcacion, double> ObtenerClasificacionManga(Manga m)
        {
            Dictionary<Embarcacion, double> resultadosManga = new Dictionary<Embarcacion, double>();
            int posicion = 1;
            foreach (Resultado resultado in m.ObtenerResultados())
            { 
                resultadosManga.Add(resultado.Embarcacion, sistemaPuntuacion.ObtenerPuntuacion(resultado));
                posicion++;
            }
            return resultadosManga;
        }

        private void AñadirResultadosManga(Manga manga, Dictionary<Embarcacion, double> resultadosManga)
        {
            foreach (var resultadoManga in resultadosManga)
            {
                Embarcacion embarcacion = resultadoManga.Key;
                double puntuacionEmbarcacion = resultadoManga.Value;

                if (!puntuacionesMangas.ContainsKey(embarcacion))
                {
                    puntuacionesMangas.Add(embarcacion, new Dictionary<Manga, double>
                   {
                       {manga,puntuacionEmbarcacion}
                   });
                }
                else
                {
                    puntuacionesMangas[embarcacion].Add(manga, puntuacionEmbarcacion);
                }
                    AñadirMangaResultadoFinal(embarcacion, puntuacionEmbarcacion);
            }
        }

        private void AñadirMangaResultadoFinal(Embarcacion embarcacion, double puntuacion)
        {

            if (!puntuacionFinal.ContainsKey(embarcacion)) puntuacionFinal.Add(embarcacion, 0);
            double puntuacionInicial = puntuacionFinal[embarcacion];
            puntuacionFinal[embarcacion] = puntuacionInicial + puntuacion;

        }
    }
}
