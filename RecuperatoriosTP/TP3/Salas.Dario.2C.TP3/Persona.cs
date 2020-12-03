using Excepciones;
using System.Text;

namespace EntidadesAbstractas
{
    public class Persona
    {
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        public enum ENacionalidad { Argentino, Extranjero }
        /// <summary>
        /// Propiedad int DNI, antes de guardar valida si es un dato valido
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad string DNI, antes de guardar valida si es un dato valido
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad Nombre, valida si tiene caracteres validos
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApeliido(value);
            }
        }
        /// <summary>
        /// Propiedad Apellido, valida si tiene caracteres validos
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApeliido(value);
            }
        }
        /// <summary>
        /// Propiedad nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// Constructor de instancia, inicializa los atributos a travez de sus propiedades
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor de instancia, inicializa los atributos a travez de sus propiedades
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            DNI = dni;
        }
        /// <summary>
        /// Constructor de instancia, inicializa los atributos a travez de sus propiedades
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni;
        }
        /// <summary>
        /// Sobrescribe el metodo ToString, devuelve los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");
            return sb.ToString();
        }
        /// <summary>
        /// Valida el dni
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
                return dato;
            else if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
                return dato;
            throw new NacionalidadInvalidaException();
        }
        /// <summary>
        /// Valida si el string recibido es un dni valido.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (dato.Length == 8 && int.TryParse(dato, out int dni))
            {
                ValidarDni(nacionalidad, dni);
                return dni;
            }
            else
                throw new DniInvalidoException("Se detectaron caracteres invalidos");
        }
        /// <summary>
        /// Valida si el string contiene solo letras o espacios
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApeliido(string dato)
        {
            foreach (char letra in dato)
            {
                if (!char.IsLetter(letra) || char.IsWhiteSpace(letra))
                {
                    return "DatoInvalido";
                }
            }
            return dato;
        }
    }
}
