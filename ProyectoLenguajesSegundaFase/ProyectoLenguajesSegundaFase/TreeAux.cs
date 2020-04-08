using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
namespace ProyectoLenguajesSegundaFase
{
    public class Circulo
    {
        private Color myColor;
        private string Nombre;
        private Point Posicion;
        public Circulo(string Cadena, int PosX, int PosY)
        {
            Nombre = Cadena;
            myColor = Color.Navy;
            Posicion = new Point(PosX, PosY);
        }

        public void Dibujar(Graphics Canvas)
        {
            Brush brush = new SolidBrush(myColor);
            Brush brushstring = new SolidBrush(Color.White);
            Font fuente = new Font("Arial", 10, FontStyle.Bold);
            RectangleF rec = new RectangleF(Posicion.X, Posicion.Y, 40, 20);
            Canvas.FillEllipse(brush, rec);
            Canvas.DrawString(Nombre, fuente, brushstring, Posicion.X +10, Posicion.Y + 3);
        }
    }
    public class Linea
    {
        static Point PosicionIni = new Point();
        static Point PosicionFin = new Point();
        Color myColor;

        public Linea(int PosXI, int PosYI, int PosXF, int PosYF)
        {
            PosicionIni.X = PosXI;
            PosicionIni.Y = PosYI;
            PosicionFin.X = PosXF;
            PosicionFin.Y = PosYF;
            myColor = Color.DarkBlue;
        }

        public void Dibujar(Graphics Canvas)
        {
            Pen Lapiz = new Pen(myColor);
            Canvas.DrawLine(Lapiz, PosicionIni.X, PosicionIni.Y, PosicionFin.X, PosicionFin.Y);
        }
    }
    public class TreeAux
    {
        
    }
}
