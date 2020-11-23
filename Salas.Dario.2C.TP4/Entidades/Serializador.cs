using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public static class Serializador
    {
        /// <summary>
        /// Genera dos archivos XML en la carpeta seleccionada.
        /// </summary>
        /// <param name="objeto"></param>
        /// <param name="archivo"></param>
        public static void Serializar(List<Object> objeto, string archivo)
        {
            using (XmlTextWriter writer = new XmlTextWriter(archivo + @"\Cervezas.XML", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Cerveza>));
                List<Cerveza> listCervezas = new List<Cerveza>();
                foreach (Object item in objeto)
                {
                    if (item is Cerveza)
                    {
                        listCervezas.Add((Cerveza)item);
                    }
                }
                serializer.Serialize(writer, listCervezas);
            }
            using (XmlTextWriter writer = new XmlTextWriter(archivo + @"\Gaseosas.XML", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Gaseosa>));
                List<Gaseosa> listCervezas = new List<Gaseosa>();
                foreach (Object item in objeto)
                {
                    if (item is Gaseosa)
                    {
                        listCervezas.Add((Gaseosa)item);
                    }
                }
                serializer.Serialize(writer, listCervezas);
            }
        }
    }
}
