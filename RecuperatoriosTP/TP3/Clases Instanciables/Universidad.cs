using Archivos;
using Excepciones;
using System.Collections.Generic;
using System.Text;

namespace ClasesInstanciables
{
#pragma warning disable CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
#pragma warning disable CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
    public class Universidad
#pragma warning restore CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
#pragma warning restore CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        /// <summary>
        /// Enumerado de clases.
        /// </summary>
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                return jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        /// <summary>
        /// Guarda los datos en un archivo XML.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> serializador = new Xml<Universidad>();
            //return serializador.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Universidad.xml", uni);
            return serializador.Guardar("Universidad.xml", uni);
        }
        /// <summary>
        /// Lee datos en un archivo XML.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public Universidad Leer()
        {
            Xml<Universidad> deserializador = new Xml<Universidad>();
            Universidad uni;
            //deserializador.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Universidad.xml", out uni);
            deserializador.Leer("Universidad.xml", out uni);
            return uni;
        }
        /// <summary>
        /// Sobrecarga operador ==, verifica si el alumno se encuentra en el listado de la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador !=, invoca a la sobrecarga ==.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Sobrecarga operador ==, verifica si el profesor se encuentra en el listado de la universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profe in g.Instructores)
            {
                if (profe == i)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador !=, invoca a la sobrecarga ==.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Sobrecarga operador ==, retorna el primer profesor en dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profe in u.Instructores)
            {
                if (profe == clase)
                    return profe;
            }
            throw new SinProfesorException("No hay Profesor para la clase.");
        }
        /// <summary>
        /// Sobrecarga operador ==, retorna el primer profesor en no dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor profe in u.Instructores)
            {
                if (profe != clase)
                    return profe;
            }
            throw new SinProfesorException("No hay Profesor para la clase.");
        }
        /// <summary>
        /// Sobrecarga del operador +, se genera una nueva jordana, agregando la clase nueva y un profesor que pueda brindarla.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profe = g == clase;
            Jornada jornada = new Jornada(clase, profe);
            foreach (Alumno alumnos in g.Alumnos)
            {
                if (alumnos == clase)
                    jornada.Alumnos.Add(alumnos);
            }
            g.jornada.Add(jornada);
            return g;
        }
        /// <summary>
        /// Sobrecarga del operador +, agrega un alumno si no se encuentra en el listado.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
                throw new AlumnoRepetidoException("Alumno repetido.");
            u.Alumnos.Add(a);
            return u;
        }
        /// <summary>
        /// Sobrecarga del operador +, agrega un profesor si no se encuentra en el listado.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            return u;
        }
        /// <summary>
        /// Sobrescritura del metodo MostrarDatos, devuelve los datos de la jornada.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Jornadas: ");
            foreach (Jornada jorna in uni.Jornadas)
            {
                sb.AppendLine(jorna.ToString());
                sb.AppendLine("<------------------------------------------->");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Sobrescritura del metodo ToString, invoca al metodo privado MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
    }
}
