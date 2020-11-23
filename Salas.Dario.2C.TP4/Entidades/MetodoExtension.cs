using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class MetodoExtension
    {
        public static string FormatPrecio(this double precio)
        {
            return precio.ToString("$ 0.00");
        }
    }
}
