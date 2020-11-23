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
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            Archivo archivo = new Archivo();
            if (archivo.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Log.txt") != string.Empty)
                richTextLog.Text = archivo.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Log.txt");
        }
    }
}
