using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regata.Negocio
{
    public static class PuntuacionFactory
    {
       private static readonly Dictionary<TipoPuntuacion,Func<int,int,PuntuacionBase>> puntuacion = new Dictionary<TipoPuntuacion,Func<int,int,PuntuacionBase>>
       {
        {TipoPuntuacion.Baja,(numeroInscritos,posicionesPenalizacion) => new PuntuacionBaja(numeroInscritos,posicionesPenalizacion)}
       };
       
        public static PuntuacionBase Crear(TipoPuntuacion tipoPuntuacion,int numeroInscritos,int posicionesPenalizacion)
        {
            return puntuacion[tipoPuntuacion](numeroInscritos,posicionesPenalizacion);
        }
       
    }
}
