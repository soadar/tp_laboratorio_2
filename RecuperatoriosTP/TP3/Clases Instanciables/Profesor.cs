using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClasesInstanciables
{
#pragma warning disable CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
#pragma warning disable CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
    public sealed class Profesor : Universitario
#pragma warning restore CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
#pragma warning restore CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        /// <summary>
        /// Agrega dos clases de manera aleatoria.
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, Enum.GetNames(typeof(Universidad.EClases)).Length));
                Thread.Sleep(300);
            }
        }
        /// <summary>
        /// sobrescritura del metodo MostrarDatos, agrega datos del profesor y lo devuelve.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticipaEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// sobrecarga del operador ==, verifica si el profesor da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases cla in i.clasesDelDia)
            {
                if (cla == clase)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        protected override string ParticipaEnClase()
        {
            StringBuilder str = new StringBuilder(null);

            str.AppendLine("CLASES DEL DIA: ");
            if (this.clasesDelDia != null)
            {
                for (int i = 0; i < clasesDelDia.Count; i++)
                {
                    str.AppendLine(clasesDelDia.ElementAt(i).ToString());
                }
            }
            else
            {
                str.AppendLine("No hay clases");
            }

            return str.ToString();
        }
        static Profesor()
        {
            random = new Random();

        }
        public Profesor() : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();

        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }
        public override string ToString()
        {
            return MostrarDatos();
        }

    }
}
