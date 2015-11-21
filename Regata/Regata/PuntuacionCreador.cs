using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regata.Negocio
{
    public static class PuntuacionCreador
    {
       
        public static PuntuacionBase Crear(TipoPuntuacion tipoPuntuacion,int numeroInscritos,int posicionesPenalizacion)
        {
            switch (tipoPuntuacion)
            {
                case TipoPuntuacion.Baja:
                default:
                    return new PuntuacionBaja(numeroInscritos, posicionesPenalizacion);
            }
        }
       
    }
}
