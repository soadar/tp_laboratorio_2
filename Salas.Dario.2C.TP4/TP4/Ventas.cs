using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace TP4
{
    public partial class Ventas : Form
    {
        Archivo archivo;
        public Ventas()
        {
            InitializeComponent();
            archivo = new Archivo();
            archivo.GuardarLog += Archivo.Log;
        }
        /// <summary>
        /// pregunta si esta seguro de realizar la transaccion, si el inventario no fue encontrado, arroja un mensaje.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            DAO dao = new DAO();
            if (int.TryParse(textVender.Text, out int inventario))
            {
                DialogResult result = MessageBox.Show("Seguro que desea comprar este producto?", "Venta", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (!dao.DeleteProducto(inventario))
                        MessageBox.Show("El inventario es incorrecto");
                }
            }
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
