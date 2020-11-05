using System;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException() : base()
        {

        }
        public ArchivosException(string message) : base(message)
        {

        }
        public ArchivosException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
