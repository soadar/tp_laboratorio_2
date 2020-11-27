using Excepciones;
using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa los datos en formato XML
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    XmlSerializer texto = new XmlSerializer(typeof(T));
                    texto.Serialize(writer, datos);
                    return true;
                }
            }
            catch (Exception)
            {
                throw new ArchivosException("Error al guardar el archivo XML");
            }
        }
        /// <summary>
        /// Desealiza los datos en formato XML
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer texto = new XmlSerializer(typeof(T));
                    datos = (T)texto.Deserialize(reader);
                }
                return true;
            }
            catch (Exception)
            {
                throw new ArchivosException("Error al leer el archivo XML");
            }
        }
    }
}
