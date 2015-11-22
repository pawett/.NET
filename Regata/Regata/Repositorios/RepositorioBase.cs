using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class RepositorioBase<T>:IRepositorio<T>
    {
        public void Guardar(T entidad)
        {
            db4oProxy.Guardar(entidad);
        }

        public void Eliminar(T entidad)
        {
           db4oProxy.Eliminar(entidad);
        }


        public IEnumerable<T> ObtenerTodo()
        {
            return db4oProxy.Query<T>(null);        }
    }
}
