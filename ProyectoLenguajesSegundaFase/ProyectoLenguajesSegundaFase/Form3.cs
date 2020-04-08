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
        private void DibujarArbol(Node p_arbol, int posX, int posY, int separacion)
        {
            if (p_arbol != null)
            {
                Circulo miCirculo = new Circulo(p_arbol.elemento.caracter, posX, posY);
                miCirculo.Dibujar(pnlArea.CreateGraphics());
                if (p_arbol.hijoDR != null)
                {
                    Linea union = new Linea(posX + 15, posY + 15, posX + separacion + 15, posY + 65);
                    union.Dibujar(pnlArea.CreateGraphics());
                    DibujarArbol(p_arbol.hijoDR, (posX + separacion), (posY + 50), Convert.ToInt32(separacion /1.5));
                }

                if (p_arbol.hijoIZ != null)
                {
                    Linea union = new Linea(posX + 15, posY + 15, posX - separacion +15, posY + 65);
                    union.Dibujar(pnlArea.CreateGraphics());
                    DibujarArbol(p_arbol.hijoIZ, (posX - separacion), (posY + 50), Convert.ToInt32(separacion/1.3));
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pnlArea.Refresh();
            DibujarArbol(exp, this.Width -350, 80, 250);
        }
    }
}
