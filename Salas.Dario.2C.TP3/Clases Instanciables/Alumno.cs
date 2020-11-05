using EntidadesAbstractas;
using System.Text;

namespace ClasesInstanciables
{
#pragma warning disable CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
#pragma warning disable CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
    public sealed class Alumno : Universitario
#pragma warning restore CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
#pragma warning restore CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Enumerado de estados de cuenta.
        /// </summary>
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        /// <summary>
        /// constructor por defecto.
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Consturctor de incancia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor de instancia 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// sobrescribe el metodo MostrarDatos, devuelve informacion de alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine(ParticipaEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga de ==, verifica si el alumno toma esa clase y no es deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }
        /// <summary>
        /// Sobrecarga de !=, verifica si el alumno no toma esa clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase)
                return true;
            return false;
        }
        /// <summary>
        /// Sobrecarga del metodo ParticipaEnClase, devuelve la clase que toma
        /// </summary>
        /// <returns></returns>
        protected override string ParticipaEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"TOMA CLASES DE: {this.claseQueToma}");
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga del metodo ToString, invoca al metodo protected MostrarDatos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
