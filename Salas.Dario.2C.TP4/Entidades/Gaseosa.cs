using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum EMarca {Coca, Pepsi, Manaos}
#pragma warning disable CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
#pragma warning disable CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
    public class Gaseosa : Producto
#pragma warning restore CS0660 // El tipo define operator == or operator !=, pero no reemplaza a override Object.Equals(object o)
#pragma warning restore CS0661 // El tipo define operator == or operator !=, pero no reemplaza a Object.GetHashCode()
    {
        private EMarca marca;
        /// <summary>
        /// Devuelve el enumerado en forma de string.
        /// </summary>
        public string Marca
        {
            get
            {
                switch (marca)
                {
                    case EMarca.Coca:
                        return "Coca Cola";
                    case EMarca.Pepsi:
                        return "Pepsi";
                    case EMarca.Manaos:
                        return "Manaos";
                    default:
                        return "Otro";
                }
            }
        }
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Gaseosa()
        {

        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="inventario"></param>
        /// <param name="marca"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Gaseosa(int inventario, EMarca marca, double precio, int stock) : base(inventario, precio, stock)
        {
            this.marca = marca;
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Gaseosa(EMarca marca, double precio, int stock) : base(precio, stock)
        {
            this.marca = marca;
        }
        /// <summary>
        /// sobrescritura de MostrarDatos de la clase base, devuelve todos los datos en una string
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"------------------------");
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"Marca: {this.Marca}");
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
