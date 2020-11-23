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
    public partial class AgregarStock : Form
    {
        Archivo archivo;
        public AgregarStock()
        {
            InitializeComponent();

            archivo = new Archivo();
            archivo.GuardarLog += Archivo.Log;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbProducto.Text))
                if (AgregarProducto(cmbProducto.Text))
                    this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AgregarStock_Load(object sender, EventArgs e)
        {
            DesactivaCampos();
        }
        /// <summary>
        /// Una vez que elije el producto a cargar, se habilita la carga de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProducto_SelectedValueChanged(object sender, EventArgs e)
        {
            textCantidad.Enabled = true;
            textPrecio.Enabled = true;
            cmbEstilo.Enabled = true;
            cmbEstilo.Text = "";
            if (cmbProducto.SelectedItem.ToString() == "Gaseosa")
                EligeGaseosa();
            else
                EligeCerveza();
        }
        /// <summary>
        /// Modifica los valores para cargar una gaseosa
        /// </summary>
        public void EligeGaseosa()
        {
            textAlcohol.Enabled = false;
            lblEstilo.Text = "Marca";
            cmbEstilo.Items.Clear();
            cmbEstilo.Items.Add(EMarca.Coca);
            cmbEstilo.Items.Add(EMarca.Manaos);
            cmbEstilo.Items.Add(EMarca.Pepsi);
        }
        /// <summary>
        /// Modifica los valores para cargar una cerveza
        /// </summary>
        public void EligeCerveza()
        {
            textAlcohol.Enabled = true;
            lblEstilo.Text = "Estilo";
            cmbEstilo.Items.Clear();
            cmbEstilo.Items.Add("IPA");
            cmbEstilo.Items.Add("Porter");
            cmbEstilo.Items.Add("Scottish");
        }
        /// <summary>
        /// Desactiva todos los campos hasta que elija un producto
        /// </summary>
        public void DesactivaCampos()
        {
            textAlcohol.Enabled = false;
            textCantidad.Enabled = false;
            textPrecio.Enabled = false;
            cmbEstilo.Enabled = false;
        }
        /// <summary>
        /// agrega un producto a la base de datos y se suscribe al evento GuardarEvent, verifica que todos los campos esten completos
        /// </summary>
        /// <param name="eleccion"></param>
        public bool AgregarProducto(string eleccion)
        {
            DAO dao = new DAO();
            if (!string.IsNullOrEmpty(eleccion) && !string.IsNullOrEmpty(cmbEstilo.Text) && !string.IsNullOrEmpty(textPrecio.Text) && !string.IsNullOrEmpty(textCantidad.Text) && cmbProducto.SelectedItem.ToString() == "Cerveza")
            {
                Cerveza birra = new Cerveza(cmbEstilo.SelectedItem.ToString(), Convert.ToDouble(textAlcohol.Text), Convert.ToDouble(textPrecio.Text), Convert.ToInt32(textCantidad.Text));
                dao.InsertarProducto(birra);
                archivo.GuardarEvent(birra);
                return true;
            }
            else if (!string.IsNullOrEmpty(eleccion) && !string.IsNullOrEmpty(cmbEstilo.Text) && !string.IsNullOrEmpty(textPrecio.Text) && !string.IsNullOrEmpty(textCantidad.Text) && cmbProducto.SelectedItem.ToString() == "Gaseosa")
            {
                Gaseosa gaseosa = new Gaseosa((EMarca)cmbEstilo.SelectedItem, Convert.ToDouble(textPrecio.Text), Convert.ToInt32(textCantidad.Text));
                dao.InsertarProducto(gaseosa);
                archivo.GuardarEvent(gaseosa);
                return true;
            }
            else
            {
                MessageBox.Show("Quedaron campos sin completar");
                return false;
            }
        }
    }
}
