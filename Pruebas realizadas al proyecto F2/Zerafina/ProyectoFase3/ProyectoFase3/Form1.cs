using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ProyectoLenguajesTerceraFase
{
  public partial class Form1 : Form
  {
      public Form1()
      {
          InitializeComponent();
      }
Dictionary<string, string[]> TablaE;
List<string> Simbol = new List<string>();
string ultimoV;
List<string> ListSETS = new List<string>();
private void button1_Click(object sender, EventArgs e)
      {
List<Grafo> LNodo = new List<Grafo>();
foreach (string llave in TablaE.Keys)
{
string estado = llave.Trim(',');
string[] puntero = TablaE.FirstOrDefault(x => x.Key == llave).Value;)
for (int i = 0; i < puntero.Length; i++)
{
puntero[i] = puntero[i].Trim(',');
}
bool terminal = false;
if (estado.Contains(ultimoV))
{
terminal = true;
}
Grafo grafo = new Grafo(estado, terminal, puntero, Simbol);
LNodo.Add(grafo);
}
NGrafo grafos = new NGrafo();
var dic = new Dictionary<string, string>();
if (ListSETS != null)
{
dic = grafos.GenerarCadenasDeValidación(ListSETS);
}
var cadena = txtBox1.Text;
var verdad = grafos.Validar(LNodo, cadena, dic);
if (verdad)
{
MessageBox.Show("La frase que ingresó es valida en esta lenguaje formal");
}
else
{
MessageBox.Show("La frase que ingresó no es valida en esta lenguaje formal");
}
}
}
}
