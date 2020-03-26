using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLenguajesSegundaFase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            archivo.ShowDialog();
            var File = archivo.FileName;
            if (File[File.Length - 1] == 't' && File[File.Length - 2] == 'x' && File[File.Length - 3] == 't' && File[File.Length - 4] == '.')
            {
                Form2 change = new Form2(File);
                change.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("El archivo que seleccionó no es un archivo txt");
            }
        }
    }
}
