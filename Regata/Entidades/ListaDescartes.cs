using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class ListaDescartes:List<Descarte>
    {
        public int ObtenerNumeroDescartes(int numeroPruebas)
        {
            List<Descarte> descartesAplicar = this.FindAll(d => d.NumeroPruebas <= numeroPruebas);
            return descartesAplicar.Max(d => d.MangasDescartadas);
        }
    }
}
