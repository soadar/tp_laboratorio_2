using System;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException() : base()
        {

        }
        public AlumnoRepetidoException(string message) : base(message)
        {

        }
        public AlumnoRepetidoException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
