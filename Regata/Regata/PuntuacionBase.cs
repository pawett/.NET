using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regata.Negocio
{
    public enum TipoPuntuacion
    {
        Baja
    }
    
    public class PuntuacionBase
    {  
       private int numeroInscritos;
       private int? posicionesPenalizacion;
       public PuntuacionBase(int numeroInscritos, int? posicionesPenalizacion)
        {
            this.numeroInscritos = numeroInscritos;
            this.posicionesPenalizacion = posicionesPenalizacion;
        }

        public double ObtenerPuntuacion(Resultado resultado)
        {
            switch (resultado.Penalizacion)
            {
                case Penalizacion.No:
                    return ObtenerPuntosPorPosicion(resultado.Posicion);
                case Penalizacion.ZFP:
                    return resultado.Posicion + PosicionesPenalizacion();
                default:
                    return numeroInscritos + 1;
            }
        }

        protected virtual double ObtenerPuntosPorPosicion(int posicion)
        {
            return posicion;
        }

        private double PosicionesPenalizacion()
        {
            if (posicionesPenalizacion.HasValue)
            {
                return posicionesPenalizacion.Value;
            }
            else
            {
                return Math.Ceiling(numeroInscritos * 1.2);
            }
        }

    }
}
