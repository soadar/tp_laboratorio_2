using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
#pragma warning disable CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
#pragma warning disable CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
    public class Cerveza : Producto
#pragma warning restore CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
#pragma warning restore CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
    {
        private string estilo;
        private double alcohol;
        public string Estilo
        {
            get
            {
                return this.estilo;
            }
            set
            {
                this.estilo = value;
            }
        }
        public double Alochol
        {
            get
            {
                return this.alcohol;
            }
            set
            {
                this.alcohol = value;
            }
        }
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Cerveza()
        {
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="inventario"></param>
        /// <param name="estilo"></param>
        /// <param name="alcohol"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Cerveza(int inventario, string estilo, double alcohol, double precio, int stock) : base(inventario, precio, stock)
        {
            this.estilo = estilo;
            this.alcohol = alcohol;
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="estilo"></param>
        /// <param name="alcohol"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Cerveza(string estilo, double alcohol, double precio, int stock) : base(precio, stock)
        {
            this.estilo = estilo;
            this.alcohol = alcohol;
        }
        /// <summary>
        /// sobrescritura de MostrarDatos, devuelve todos los datos en una string
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"------------------------");
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"Estilo: {this.estilo}");
            sb.AppendLine($"Alcohol: {this.alcohol.ToString("0.00")}");
            sb.AppendLine($"------------------------");
            return sb.ToString();
        }
        /// <summary>
        /// sobrescritura de ToString, llama a MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
