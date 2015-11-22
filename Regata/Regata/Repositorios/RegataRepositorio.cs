using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    using Regata.Negocio;

    public class RegataRepositorio:RepositorioBase<Regata>,IRepositorio<Regata>
    {
        public IEnumerable<Regata> ObtenerPorNombre(string nombre)
        {
           return db4oProxy.Query<Regata>(r => r.Nombre.Equals(nombre));
        }

        public IEnumerable<Regata> ObtenerPorRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return db4oProxy.Query<Regata>(r => r.FechaInicio <= fechaInicio && r.FechaFin <= fechaFin);
        }
    }
}
