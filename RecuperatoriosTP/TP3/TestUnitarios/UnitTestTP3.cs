using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;
using Archivos;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTestTP3
    {
        /// <summary>
        /// Al ingresar un dni incorrecto, deberia lanzar DniInvalidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalido()
        {
            Alumno a1 = new Alumno(1, "Juan", "Perez", "656565asa", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
        }
        /// <summary>
        /// Al cargar el mismo alumno, deberia lanzar AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetido()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Perez", "35658425", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            uni += a1;
            uni += a1;
        }
        /// <summary>
        /// Al no existir el archivo deberia lanzar ArchivosException.
        /// </summary>
        [TestMethod] 
        [ExpectedException(typeof(ArchivosException))]
        public void FileNotFound()
        {
            Texto testTexto = new Texto();
            string datos;
            testTexto.Leer(@"C:\Probando.txt", out datos);
        }
        [TestMethod]
        public void ListaDeAlumnosNotNull()
        {
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, new Profesor());
            List<Alumno> alumnos = jornada.Alumnos;
            Assert.IsNotNull(alumnos);
        }
    }
}
