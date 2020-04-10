using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLenguajesSegundaFase
{
    public partial class Form3 : Form
    {
        Node exp = default;
        public Form3(Node Expresión)
        {
            InitializeComponent();
            exp = Expresión;
        }
        private void Arbol(Node raíz, int posX, int posY, int separacion)
        {
            if (raíz != null)
            {
                Figura miCirculo = new Figura(raíz.elemento.caracter, posX, posY);
                miCirculo.Crear(Area.CreateGraphics());
                if (raíz.hijoDR != null)
                {
                    Union union = new Union(posX + 15, posY + 15, posX + separacion + 15, posY + 65);
                    union.Crear(Area.CreateGraphics());
                    Arbol(raíz.hijoDR, (posX + separacion), (posY + 50), Convert.ToInt32(separacion /1.5));
                }
                if (raíz.hijoIZ != null)
                {
                    Union union = new Union(posX + 15, posY + 15, posX - separacion +15, posY + 65);
                    union.Crear(Area.CreateGraphics());
                    Arbol(raíz.hijoIZ, (posX - separacion), (posY + 50), Convert.ToInt32(separacion/1.3));
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Area.Refresh();
            Arbol(exp, this.Width -350, 80, 250);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Visible = false;
        }
    }
}
