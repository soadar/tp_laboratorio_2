using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cerveza> cervezas = new List<Cerveza>();
            Archivo archivo = new Archivo();
            DAO dao = new DAO();

            Cerveza cerveza = new Cerveza("IPA", 7.8, 180.50, 10);
            Gaseosa gaseosa = new Gaseosa(EMarca.Coca, 120.50, 23);

            //Agrega los productos, invoca evento del log en el escritorio

            dao.InsertarProducto(cerveza);
            Archivo.Log(cerveza);
            dao.InsertarProducto(gaseosa);
            Archivo.Log(gaseosa);

            cervezas = dao.ListarProductos();

            // imprime los productos
            Console.WriteLine("-------------Primer informe -------------");
            foreach (Cerveza item in cervezas)
            {
                Console.WriteLine(item.ToString());
            }
            //vacia la bd // 
            foreach (Cerveza item in cervezas)
            {
                dao.DeleteProducto(item.Inventario);
            }
            cervezas.Clear();
            Console.WriteLine("-------------Segundo informe  (deberia estar vacio)-------------");
            foreach (Cerveza item in cervezas)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("-------------Lectura del Archivo LOG -------------");
            string log = archivo.Leer((Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Log.txt"));
            Console.WriteLine(log);

            /// hay que comentar el "if File.Exist" de la clase archivo para que aparezca la excepcion
            try
            {
                File.Delete((Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Log.txt"));
                string lectura = archivo.Leer((Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Log.txt"));
            }
            catch (ExcepcionFile ex)
            {

                Console.WriteLine(ex.Message);
            }

            try
            {
                Cerveza cerveza2 = new Cerveza("IPA", 77777.8, 180.50888, 1022);
                dao.InsertarProducto(cerveza2);
            }
            catch (ExcepcionDAO ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
