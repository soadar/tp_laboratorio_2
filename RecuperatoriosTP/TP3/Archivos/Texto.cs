using Excepciones;
using System;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos en archivo de texto.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    writer.WriteLine(datos);
                }
                return true;
            }
            catch (Exception)
            {

                throw new ArchivosException("Error al guardar el archivo TXT");
            }
        }
        /// <summary>
        /// Lee los datos de un archivo de texto.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    datos = reader.ReadToEnd();
                }
                return true;
            }
            catch (Exception)
            {
                throw new ArchivosException("Error al leer el archivo TXT");
            }
        }
    }
}
