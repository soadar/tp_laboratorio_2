using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestCerveceria
{
    [TestClass]
    public class UnitTestCerveceria
    {
        /// <summary>
        /// Comprueba si al tratar de eliminar un producto que no existe, devuelve false
        /// </summary>
        [TestMethod]
        public void ValidarBorrado()
        {
            Cerveza cerveza = new Cerveza(1, "IPA", 5.5, 6.6, 9);
            Cerveza cerveza2 = new Cerveza(1, "Porter", 4.4, 3.3, 5);
            DAO dao = new DAO();
            Assert.IsFalse(dao.DeleteProducto(0));
        }

        [TestMethod]
        public void ValidaLog()
        {
            Archivo archivo = new Archivo();
            string texto = archivo.Leer(@"C:\Probando.txt");
            Assert.AreEqual(texto, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDAO))]

        public void DAOTest()
        {
            Cerveza cerveza2 = new Cerveza("IPA", 77777.8, 180.50888, 1022);
            DAO dao = new DAO();
            dao.InsertarProducto(cerveza2);
        }
    }
}
