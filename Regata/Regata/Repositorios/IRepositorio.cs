using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public interface IRepositorio<T>
    {
        void Guardar(T entidad);
        void Eliminar(T entidad);
        IEnumerable<T> ObtenerTodo();
        
    }
}
