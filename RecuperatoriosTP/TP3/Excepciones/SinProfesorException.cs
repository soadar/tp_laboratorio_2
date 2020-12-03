using System;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException() : base("No hay Profesor para la clase.")
        {

        }
        public SinProfesorException(string message) : base(message)
        {

        }
        public SinProfesorException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
