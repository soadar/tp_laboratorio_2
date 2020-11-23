using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExcepcionFile : Exception
    {
        public ExcepcionFile(string message) : base(message)
        {

        }
        public ExcepcionFile(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
