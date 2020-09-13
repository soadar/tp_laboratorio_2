using BibliotecaCalc;
using BibliotecaNum;
using System;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            //Calculadora calculadora = new Calculadora();
            Numero num1 = new Numero(txtNumero1.Text);
            Numero num2 = new Numero(txtNumero2.Text);
            lblResultado.Text = Calculadora.Operar(num1, num2, cmbOperador.Text).ToString();
        }
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
                Numero num = new Numero(lblResultado.Text);
                lblResultado.Text = num.DecimalBinario(lblResultado.Text);
        }
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
                Numero num = new Numero(lblResultado.Text);
                lblResultado.Text = num.BinarioDecimal(lblResultado.Text.Trim());
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.ExitThread();
        }
    }
}
