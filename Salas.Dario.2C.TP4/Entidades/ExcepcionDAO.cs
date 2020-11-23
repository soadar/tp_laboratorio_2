using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExcepcionDAO : Exception
    {
        public ExcepcionDAO(string message) : base(message)
        {
        }
        public ExcepcionDAO(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
