using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace TP4
{
    public partial class Cerveceria : Form
    {
        delegate void Callback();
        Thread thread;
        public Cerveceria()
        {
            InitializeComponent();
            thread = new Thread(ActualizaGrid);
        }
        /// <summary>
        /// Carga de formulario, lanza el hilo ACtualizarGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cerveceria_Load(object sender, EventArgs e)
        {
            dataGridInforme.Visible = false;
            if (!thread.IsAlive)
            {
                thread.Start();
            }
        }
        /// <summary>
        /// Oculta y muestra el DataGrid con los datos de la bd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInforme_Click(object sender, EventArgs e)
        {
            if (dataGridInforme.Visible)
                dataGridInforme.Visible = false;
            else
            {
                dataGridInforme.Visible = true;
                DAO dao = new DAO();
                dataGridInforme.DataSource = dao.ListarProductos();
            }
        }
        private void btnAgregarStock_Click(object sender, EventArgs e)
        {
            AgregarStock agregaStock = new AgregarStock();
            DialogResult result = agregaStock.ShowDialog();
        }
        /// <summary>
        /// Antes de salir chequea que no haya ningun hilo corriendo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntSalir_Click(object sender, EventArgs e)
        {
            if (thread.IsAlive)
            {
                thread.Abort();
            }
            Application.ExitThread();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            DialogResult result = ventas.ShowDialog();
        }
        /// <summary>
        /// Metodo que es llamado por el thread, invoca a run
        /// </summary>
        public void ActualizaGrid()
        {
            while (true)
            {
                run();
                Thread.Sleep(500);
            }
        }
        /// <summary>
        /// Actualiza el DataGrid en tiempo de ejecucion
        /// </summary>
        public void run()
        {
            if (dataGridInforme.InvokeRequired)
            {
                Callback callback = new Callback(run);
                this.Invoke(callback);
            }
            else
            {
                DAO dao = new DAO();
                this.dataGridInforme.DataSource = dao.ListarProductos();
            }
        }

        private void Cerveceria_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread.IsAlive)
            {
                thread.Abort();
            }
        }

        private void bntLog_Click(object sender, EventArgs e)
        {
            Log log = new Log();
            DialogResult result = log.ShowDialog();
        }
    }
}
