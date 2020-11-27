using System.Text;

namespace EntidadesAbstractas
{
#pragma warning disable CS0659 // El tipo reemplaza a Object.Equals(object o), pero no reemplaza a Object.GetHashCode()
#pragma warning disable CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
    public abstract class Universitario : Persona
#pragma warning restore CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
#pragma warning restore CS0659 // El tipo reemplaza a Object.Equals(object o), pero no reemplaza a Object.GetHashCode()
    {
        private int legajo;
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Universitario() : base()
        {
        }
        /// <summary>
        /// constructor de instancia.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        /// <summary>
        /// Metodo abstracto.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticipaEnClase();

        /// <summary>
        /// Sobrescribe el metodo Equals, verifica si el objeto es un universitario, seran iguales si tienen el mismo dni o legajo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// 
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                Universitario uni = (Universitario)obj;
                if (uni.DNI == this.DNI || uni.legajo == this.legajo)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Metodo protected y virtual MostrarDatos, devuelve los datos del universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NUMERO: {this.legajo}");
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga ==, invoca a la sobrecarga equals.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2))
                return true;
            return false;
        }
        /// <summary>
        /// Sobrecarga de !=, invoca a la sobrecarga ==
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
