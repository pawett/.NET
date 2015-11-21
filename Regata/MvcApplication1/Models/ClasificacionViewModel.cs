using Regata.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ClasificacionViewModel
    {
        public DataTable TablaResultados { get; set; }

        public void ObtenerTablaResultados(Clasificacion clasificacion)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("Embarcacion"));
            int numeroManga = 1;
            foreach (var manga in clasificacion.PuntuacionesMangas()[clasificacion.PuntuacionesMangas().Keys.First()])
            {
                tabla.Columns.Add(new DataColumn(String.Concat("Manga ",numeroManga++)));
                
            }
            tabla.Columns.Add(new DataColumn("Total"));
           
            foreach(Embarcacion em in clasificacion.PuntuacionesMangas().Keys)
            {
                DataRow dr = tabla.NewRow();
                dr["Embarcacion"] = em.NumeroVela;
                numeroManga = 1;
                foreach (Manga manga in clasificacion.PuntuacionesMangas()[em].Keys)
                {
                    string puntuacion = clasificacion.PuntuacionesMangas()[em][manga].ToString();
                    dr[String.Concat("Manga ", numeroManga++)] = puntuacion;
                }
                dr["Total"] = clasificacion.ObtenerClasificacionGeneral()[em];
                tabla.Rows.Add(dr);
            }
          
            
           
            TablaResultados = tabla;
        }
    }
}