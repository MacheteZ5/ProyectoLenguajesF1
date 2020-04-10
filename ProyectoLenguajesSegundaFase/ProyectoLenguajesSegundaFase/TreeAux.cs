using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
namespace ProyectoLenguajesSegundaFase
{
    public class Figura
    {
        private Color Color;
        private Point Pos;
        private string simbolo;
        
        public Figura(string Cadena, int PX, int PY)
        {
            simbolo = Cadena;
            Color = Color.LightGreen;
            Pos = new Point(PX, PY);
        }

        public void Crear(Graphics figura)
        {
            Brush CS = new SolidBrush(Color.Black);
            Brush C = new SolidBrush(Color);
            Font fuente = new Font("Arial", 10, FontStyle.Bold);
            RectangleF RF = new RectangleF(Pos.X, Pos.Y, 40, 20);
            figura.FillEllipse(C, RF);
            figura.DrawString(simbolo, fuente, CS, Pos.X +10, Pos.Y + 3);
        }
    }
    public class Union
    {
        static Point PosI = new Point();
        static Point PosF = new Point();
        Color Color;

        public Union(int PosXI, int PosYI, int PosXF, int PosYF)
        {
            PosI.X = PosXI;
            PosI.Y = PosYI;
            PosF.X = PosXF;
            PosF.Y = PosYF;
            Color = Color.Black;
        }

        public void Crear(Graphics linea)
        {
            Pen pen = new Pen(Color);
            linea.DrawLine(pen, PosI.X, PosI.Y, PosF.X, PosF.Y);
        }
    }
    public class TreeAux
    {
        
    }
}
