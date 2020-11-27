using System;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException() : base()
        {

        }
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
        public NacionalidadInvalidaException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
