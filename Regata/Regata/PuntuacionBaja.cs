using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regata.Negocio
{
   public class PuntuacionBaja:PuntuacionBase
    {
        private int numeroInscritos;
        private int posicionesPenalizacion;

       public PuntuacionBaja(int numeroInscritos, int posicionesPenalizacion):base(numeroInscritos,posicionesPenalizacion)
       {
       }
       


    }
}
