using NDatabase;
using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regata.Negocio;

namespace Datos
{
    public  class DARegata
    {
       
        public  void Guardar(Regata.Negocio.Regata regata)
        {
            
            // Open the database
            using (var odb = OdbFactory.Open("Regata.db"))
            {
                // Store the object
               var resultado =  odb.Store(regata);
               var elementos = odb.Query<Regata.Negocio.Regata>();
            }
        }

        public Regata.Negocio.Regata ObtenerRegata()
        {

            // Open the database
            using (var odb = OdbFactory.Open("Regata.db"))
            {
               
               var elemento = odb.AsQueryable<Regata.Negocio.Regata>().FirstOrDefault();
               return elemento;
            }
        }
    }
}
