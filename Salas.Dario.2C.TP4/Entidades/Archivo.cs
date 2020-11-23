using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Entidades
{
    public class Archivo : ILog<string>
    {
        public delegate void DelegadoGuardar(Object obj);
        public event DelegadoGuardar GuardarLog;
        /// <summary>
        /// se suscribe al evento
        /// </summary>
        /// <param name="cerveza"></param>
        public void GuardarEvent(Object obj)
        {
            if (this.GuardarLog != null)
                this.GuardarLog.Invoke(obj);
        }
        /// <summary>
        /// Guarda los datos en un archivo de texto
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Guardar(Object obj)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Log.txt", true))
                {
                    writer.WriteLine(obj.ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ExcepcionFile("Error al guardar el archivo TXT", ex);
            }
        }
        /// <summary>
        /// Lee los datos de un archivo de texto.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public string Leer(string ruta)
        {
            try
            {
                if (File.Exists(ruta))
                {
                    using (StreamReader reader = new StreamReader(ruta))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionFile("Error al abrir el archivo TXT", ex);
            }
            return string.Empty;
        }
        /// <summary>
        /// guarda un log de cada carga realizada.
        /// </summary>
        /// <param name="obj"></param>
        public static void Log(Object obj)
        {
            Archivo file = new Archivo();
            file.Guardar(obj);
        }
    }
}
