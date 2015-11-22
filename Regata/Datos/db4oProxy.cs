using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
   public static class db4oProxy
    {
       private static IObjectContainer db = null;
       public static  IObjectContainer Db {
           get{
               if (db == null) db = Db4oEmbedded.OpenFile(Db4oEmbedded.NewConfiguration(), @"C:\Users\pawet\Documents\Regata.odb");
               return db;
              }
       }
       
      public static object Guardar(object o)
      {
          IObjectSet existentes = Obtener(o);
          if (existentes.Count > 0)
          {
              Object existente = existentes.Next();
              existente = o;
              Db.Store(existente);
              return Obtener(existente);
          }else
          {
              Db.Store(o);
              return Obtener(o);
          }
      }

      public static void Eliminar(object o)
      {
          var existente = Obtener(o).Next();
          if(existente!=null)Db.Delete(existente);
      }

      public static IObjectSet ObtenerTodos(Type type)
      {
          return Db.QueryByExample(type);
      }

      public static IObjectSet Obtener(Object o)
      {
          return Db.QueryByExample(o);
      }

      public static IEnumerable<T> Query<T>(Predicate<T> query)
      {
          if (query == null) return  Db.Query<T>();
         return  Db.Query<T>(query);
          
      }
 
    }
}
