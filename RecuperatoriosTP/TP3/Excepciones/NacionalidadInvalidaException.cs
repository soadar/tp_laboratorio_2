using System;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException() : base("La nacionalidad no se condice con el numero de DNI")
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
