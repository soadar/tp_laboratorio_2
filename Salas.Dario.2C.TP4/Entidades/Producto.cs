using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        private double precio;
        private int stock;
        private int inventario;
        public double Precio
        {
            get 
            {
                return this.precio;
            }

            set
            {
                this.precio = value;
            }
        }
        public int Stock
        {
            get
            {
                return this.stock;
            }

            set
            {
                this.stock = value;
            }
        }
        public int Inventario
        {
            get
            {
                return this.inventario;
            }

            set
            {
                this.inventario = value;
            }
        }
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Producto()
        {

        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="inventario"></param>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Producto(int inventario, double precio, int stock)
        {
            this.precio = precio;
            this.inventario = inventario;
            this.stock = stock;
        }
        /// <summary>
        /// contructor
        /// </summary>
        /// <param name="precio"></param>
        /// <param name="stock"></param>
        public Producto(double precio, int stock)
        {
            this.precio = precio;
            this.stock = stock;
        }
        /// <summary>
        /// informa los datos del producto
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{DateTime.Now}");
            sb.AppendLine($"Se cargaron los siguientes datos:");
            sb.AppendLine($"Precio: {this.Precio.FormatPrecio()}");
            sb.Append($"Stock: {this.Stock}");
            return sb.ToString();
        }
    }
}
