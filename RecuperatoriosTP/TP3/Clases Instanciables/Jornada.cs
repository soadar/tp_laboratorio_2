using Archivos;
using System.Collections.Generic;
using System.Text;


namespace ClasesInstanciables
{
#pragma warning disable CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
#pragma warning disable CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
    public class Jornada
#pragma warning restore CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
#pragma warning restore CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
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
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto file = new Texto();
            return file.Guardar("Jornada.txt", jornada.ToString());
        }
        /// <summary>
        /// Lee un archivo de texto.
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            Texto file = new Texto();
            file.Leer("Jornada.txt", out string datos);
            return datos;
        }
        /// <summary>
        /// Sobrecarga del operador ==, verifica si el alumno esta en la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// sobrecarga del operador !=, invoca a la sobrecarga ==.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Sobrecarga del operador +, agrega un alumno a la jornada, si no se encontraba en ella.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.alumnos)
            {
                if (alumno == a)
                    return j;
            }
            j.alumnos.Add(a);
            return j;
        }
        /// <summary>
        /// Sobrescritura del metodo ToString, agrega datos de la jornada y lo devuelve.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DE " + this.Clase + " POR " + Instructor.ToString());
            if (this.Alumnos.Count != 0)
            {
                sb.AppendLine("Alumnos: ");
                foreach (Alumno alumno in this.Alumnos)
                {
                    sb.AppendLine(alumno.ToString());
                }
            }
            return sb.ToString();
        }
    }
}
