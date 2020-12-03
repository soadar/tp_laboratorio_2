using System;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException() : base("DNI invalido")
        {

        }
        public DniInvalidoException(string message) : base(message)
        {

        }
        public DniInvalidoException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
