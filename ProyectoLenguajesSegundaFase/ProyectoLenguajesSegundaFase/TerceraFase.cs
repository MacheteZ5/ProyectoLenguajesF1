using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLenguajesSegundaFase
{
    public class TerceraFase
    {
        public void PMétodo(string dirección)
        {
            FileInfo fn = new FileInfo(dirección);
            StreamWriter fi = fn.CreateText();
            fi.WriteLine("using System;");
            fi.WriteLine("using System.Collections.Generic;");
            fi.WriteLine("using System.ComponentModel;");
            fi.WriteLine("using System.Data;");
            fi.WriteLine("using System.Drawing;");
            fi.WriteLine("using System.Linq;");
            fi.WriteLine("using System.Text;");
            fi.WriteLine("using System.Threading.Tasks;");
            fi.WriteLine("using System.Windows.Forms;");
            fi.WriteLine("namespace PROYECTOFASE3");
            fi.WriteLine("{");
            fi.WriteLine("  public partial class Form1 : Form");
            fi.WriteLine("  {");
            fi.WriteLine("      public Form1()");
            fi.WriteLine("      {");
            fi.WriteLine("          InitializeComponent();");
            fi.WriteLine("      }");
            fi.Close();
        }
        public void SMétodo(string dirección, Dictionary<string, string[]> TablaE, List<string> Simbol, int ultimoV, List<string> ListSETS, List<string>ListActions, List<string>ListTokens,bool action, string Exp)
        {
            StreamWriter escribir = File.AppendText(dirección);
            escribir.WriteLine("Dictionary<string, string[]> TablaE = new Dictionary<string, string[]>();");
            escribir.WriteLine("List<string> Simbol = new List<string>();");
            escribir.WriteLine("string ultimoV = string.Empty;");
            escribir.WriteLine("List<string> ListSETS = new List<string>();");
            escribir.WriteLine("List<string> ListActions = new List<string>();");
            escribir.WriteLine("List<string> ListTokens = new List<string>();");
            escribir.WriteLine("bool action = false;");
            escribir.WriteLine("string Exp = string.Empty;");
            escribir.WriteLine("private void button1_Click(object sender, EventArgs e)");
            escribir.WriteLine("      {");
            escribir.WriteLine("TablaE = new Dictionary<string, string[]>();");
            escribir.WriteLine("Simbol = new List<string>();");
            escribir.WriteLine("ultimoV = string.Empty;");
            escribir.WriteLine("ListSETS = new List<string>();");
            escribir.WriteLine("ListActions = new List<string>();");
            escribir.WriteLine("ListTokens = new List<string>();");
            escribir.WriteLine("action = false;");
            escribir.WriteLine("Exp = string.Empty;");
            escribir.WriteLine(" string[] vec;");
            //método para escribir el dic de estados
            foreach (KeyValuePair<string, string[]> Item in TablaE)
            {
                var vector = new string[Item.Value.Length];
                escribir.WriteLine("vec = new string[" + Item.Value.Length + "];");
                var vector2 = Item.Value;
                for(int i = 0; i < Item.Value.Length; i++)
                {
                    if (vector2[i] != string.Empty)
                    {
                        vector[i] = vector2[i];
                        escribir.WriteLine("vec[" + i + "]="+'"'+ vector[i]+'"'+ ";");
                    }
                    else
                    {
                        vector[i] = vector2[i];
                        escribir.WriteLine("vec[" + i + "]=" +'"'+'"'+ ";");
                    }
                }
                //escribir.WriteLine("
                escribir.WriteLine("TablaE.Add(" +'"'+ Item.Key +'"'+",vec);");
            }
            //método para enviar símbolos
            var caracter = "'";
            foreach(string cadena in Simbol)
            {
                if(cadena[1]==caracter[0]||cadena[1] == '"')
                {
                    if(cadena[1]=='"')
                    {
                        escribir.WriteLine("var y = string.Empty;");
                        escribir.WriteLine("y +=" + "'"+'"' + "'" + ";");
                        escribir.WriteLine("Simbol.Add(y);");
                    }
                    else
                    {
                        escribir.WriteLine("var xs = " + '"' + caracter[0] + '"' + ";");
                        escribir.WriteLine("Simbol.Add(xs);");
                    }
                }
                else
                {
                    escribir.WriteLine("Simbol.Add(" + '"' + cadena + '"' + ");");
                }
            }
            //método para enviarl el último valor
            escribir.WriteLine("ultimoV = "+'"'+ultimoV+'"'+";");
            //método para enviar la ListaSETS
            foreach (string cadena in ListSETS)
            {
                escribir.WriteLine("ListSETS.Add(" +'"'+cadena+'"'+ ");");
            }
            //método para enviar la ListaActions
            foreach (string cadena in ListActions)
            {
                escribir.WriteLine("ListActions.Add(" + '"' + cadena + '"' + ");");
            }
            //método para enviar la ListaTokens
            escribir.WriteLine("var Aux = string.Empty;");
            foreach (string cadena in ListTokens)
            {
                foreach(char character in cadena)
                {
                    if (character == caracter[0])
                    {
                        escribir.WriteLine("xs = " + '"' + caracter[0] + '"' + ";");
                        escribir.WriteLine("Aux+=xs;");
                    }
                    else
                    {
                        if (character == '"')
                        {
                            escribir.WriteLine("y = string.Empty;");
                            escribir.WriteLine("y +=" + "'" + '"' + "'" + ";");
                            escribir.WriteLine("Aux+=y;");
                        }
                        else
                        {
                            escribir.WriteLine("Aux +=" + "'" + character + "';");
                        }
                    }
                }
                escribir.WriteLine("ListTokens.Add(Aux);");
                escribir.WriteLine("Aux = string.Empty;");
            }
            //método para enviar la variable de si se encuentra actions
            if (action)
            {
                escribir.WriteLine("action = true;");
            }
            else
            {
                escribir.WriteLine("action = false;");
            }
            //método para enviar la expresión
            for(int i = 0; i < Exp.Length; i++)
            {
                if (Exp[i] == caracter[0])
                {
                    escribir.WriteLine("xs = " + '"' + caracter[0] + '"' + ";");
                    escribir.WriteLine("Exp+=xs;");
                }
                else
                {
                    if (Exp[i] == '"')
                    {
                        escribir.WriteLine("y = string.Empty;");
                        escribir.WriteLine("y +=" + "'" + '"' + "'" + ";");
                        escribir.WriteLine("Exp+=y;");
                    }
                    else
                    {
                        escribir.WriteLine("Exp +=" +"'"+ Exp[i]+"';");
                    }
                }
            }
            escribir.Close();
        }
        public void TMétodo(string dirección)
        {
            StreamWriter escribir = File.AppendText(dirección);
            escribir.WriteLine("pantalla1.Items.Clear();");
            escribir.WriteLine("List <Grafo> LNodo = new List<Grafo>();");
            escribir.WriteLine("foreach (string llave in TablaE.Keys)");
            escribir.WriteLine("{");
            escribir.WriteLine("string estado = llave.Trim(',');");
            escribir.WriteLine("string[] puntero = TablaE.FirstOrDefault(x => x.Key == llave).Value;");
            escribir.WriteLine("for (int i = 0; i < puntero.Length; i++)");
            escribir.WriteLine("{");
            escribir.WriteLine("puntero[i] = puntero[i].Trim(',');");
            escribir.WriteLine("}");
            escribir.WriteLine("bool terminal = false;");
            escribir.WriteLine("if (estado.Contains(ultimoV))");
            escribir.WriteLine("{");
            escribir.WriteLine("terminal = true;");
            escribir.WriteLine("}");
            escribir.WriteLine("Grafo grafo = new Grafo(estado, terminal, puntero, Simbol);");
            escribir.WriteLine("LNodo.Add(grafo);");
            escribir.WriteLine("}");
            escribir.WriteLine("NGrafo grafos = new NGrafo();");
            escribir.WriteLine("var dic = new Dictionary<string, string>();");
            escribir.WriteLine("var largo = 0;");
            escribir.WriteLine("var dicA = new Dictionary<string, string>();");
            escribir.WriteLine("var dicT = new Dictionary<string, string>();");
            escribir.WriteLine("if (ListSETS != null)");
            escribir.WriteLine("{");
            escribir.WriteLine("dic = grafos.SETS(ListSETS);");
            escribir.WriteLine("}");
            escribir.WriteLine("if (action)");
            escribir.WriteLine("{");
            escribir.WriteLine("dicA = grafos.Actions(ListActions, ref largo);");
            escribir.WriteLine("}");
            escribir.WriteLine("dicT = grafos.Tokens(ListTokens);");
            escribir.WriteLine("var cadena = textBox1.Text;");
            escribir.WriteLine("var verdad = false;");
            escribir.WriteLine("var ListaAMostrar = new List<string>();");
            escribir.WriteLine("if (cadena.Length != 0)");
            escribir.WriteLine("{");
            escribir.WriteLine("while (cadena.Length != 0)");
            escribir.WriteLine("{");
            escribir.WriteLine("var CP = cadena.Length;");
            escribir.WriteLine("var estado = string.Empty;");
            escribir.WriteLine("var cadenaeliminada = string.Empty;");
            escribir.WriteLine("verdad = grafos.ValidarA(LNodo, ref cadena, dic, action, dicA, largo, ref estado, ref cadenaeliminada, ref ListaAMostrar);");
            escribir.WriteLine("var CP2 = cadena.Length;");
            escribir.WriteLine("if (CP == CP2 || !verdad)");
            escribir.WriteLine("{");
            escribir.WriteLine("verdad = false;");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("var CV = cadenaeliminada;");
            escribir.WriteLine("var vector = estado.Split('|');");
            escribir.WriteLine("vector = EncontrarV(vector);");
            escribir.WriteLine("var nuevo = new AuxClass();");
            escribir.WriteLine("var Tree = new Tree();");
            escribir.WriteLine("Tree.Raiz = nuevo.CreateTreeP2(Exp);");
            escribir.WriteLine("FLFN flfn = new FLFN();");
            escribir.WriteLine(" var contador = 1;");
            escribir.WriteLine("flfn.IngresarFLH(Tree.Raiz, ref contador);");
            //segunda Prueba
            escribir.WriteLine("var fin = string.Empty;");
            escribir.WriteLine("var Ninicial = LNodo[0].estado.Split(',');");
            escribir.WriteLine("Tree.Raiz.elemento.caracter = " +'"'+"|"+'"'+";");
            escribir.WriteLine("for (int i = 0; i < Ninicial.Length; i++)");
            escribir.WriteLine("{");
            escribir.WriteLine("var encontrado = false;");
            escribir.WriteLine("var ayuda = false;");
            escribir.WriteLine("recorrer(Tree.Raiz, Tree.Raiz, Tree.Raiz, Tree.Raiz, Ninicial[i], ref cadenaeliminada, ref encontrado, ref ayuda, dic);");
            escribir.WriteLine("if (encontrado)");
            escribir.WriteLine("{");
            escribir.WriteLine("fin = Ninicial[i];");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("cadenaeliminada = CV;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("var token = string.Empty;");
            escribir.WriteLine("var correcto = false;");
            escribir.WriteLine("Tree.Raiz.elemento.caracter = " + '"' + "|" + '"' + ";");
            escribir.WriteLine("UltimoRecorrido(Tree.Raiz, Tree.Raiz, Tree.Raiz, fin, ref token, ref correcto);");
            escribir.WriteLine("token = token.Trim(' ');");
            escribir.WriteLine("var tv = token.Split(' ');");
            escribir.WriteLine("token = string.Empty;");
            escribir.WriteLine("for (int i = 0; i < tv.Length; i++)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (tv[i] != string.Empty)");
            escribir.WriteLine("{");
            escribir.WriteLine("token += tv[i];");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("token = token.Trim(' ');");
            //REORGANIZAR TANTO TOKENS COMO LA CADENA QUE SE RECIBIÓ
            escribir.WriteLine("var loencontro = false;");
            //MÉTODO para mostrar a que token pertenece
            escribir.WriteLine("foreach (string llave in dicT.Keys)");
            escribir.WriteLine("{");
            escribir.WriteLine("var auxiliar = igualar(llave);");
            escribir.WriteLine("if (auxiliar == token)");
            escribir.WriteLine("{");
            escribir.WriteLine("loencontro = true;");
            escribir.WriteLine("var resultado = dicT.FirstOrDefault(x => x.Key == llave).Value;");
            escribir.WriteLine("foreach (char caracter in CV)");
            escribir.WriteLine("{");
            escribir.WriteLine("var lexema = string.Empty;");
            escribir.WriteLine("lexema = resultado + "+'"'+" ="+'"'+ " + caracter;");
            escribir.WriteLine("ListaAMostrar.Add(lexema);");
            escribir.WriteLine("}");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("if (!loencontro)");
            escribir.WriteLine("{");
            escribir.WriteLine("foreach (string llave in dicT.Keys)");
            escribir.WriteLine("{");
            escribir.WriteLine("var auxiliar = igualar(llave);");
            escribir.WriteLine("if (auxiliar.Contains(token))");
            escribir.WriteLine("{");
            escribir.WriteLine("var resultado = dicT.FirstOrDefault(x => x.Key == llave).Value;");
            escribir.WriteLine("foreach (char caracter in CV)");
            escribir.WriteLine("{");
            escribir.WriteLine("var lexema = string.Empty;");
            escribir.WriteLine("lexema = resultado + "+'"'+ "="+'"' +" + caracter;");
            escribir.WriteLine("ListaAMostrar.Add(lexema);");
            escribir.WriteLine("}");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine(" if (LNodo[0].EsTerminal)");
            escribir.WriteLine("{");
            escribir.WriteLine("verdad = true;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("if (verdad)");
            escribir.WriteLine("{");
            escribir.WriteLine("MessageBox.Show("+'"'+"La frase que ingresó es valida en esta lenguaje formal"+'"'+");");
            escribir.WriteLine("foreach (string token in ListaAMostrar)");
            escribir.WriteLine("{");
            escribir.WriteLine("pantalla1.Items.Add(token);");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("MessageBox.Show(" + '"' + "La frase que ingresó no es valida en esta lenguaje formal" + '"' + ");");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.Close();
        }
        public void CMétodo(string dirección)
        {
            StreamWriter escribir = File.AppendText(dirección);
            //Método Grafo
            escribir.WriteLine("public class Grafo");
            escribir.WriteLine("{");
            escribir.WriteLine("public string estado;");
            escribir.WriteLine("public bool EsTerminal;");
            escribir.WriteLine("public string[] Apuntadores;");
            escribir.WriteLine("public List<string> simbolos;");
            escribir.WriteLine("public Grafo(string cadena, bool terminal, string[] estados, List<string> Sim)");
            escribir.WriteLine("{");
            escribir.WriteLine("estado = cadena;");
            escribir.WriteLine("EsTerminal = terminal;");
            escribir.WriteLine("Apuntadores = estados;");
            escribir.WriteLine("simbolos = Sim;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            //método para pasar el Tree
            escribir.WriteLine("public struct Elements");
            escribir.WriteLine("{");
            escribir.WriteLine("public string caracter;");
            escribir.WriteLine("public string First;");
            escribir.WriteLine("public string Last;");
            escribir.WriteLine("public bool Null;");
            escribir.WriteLine("}");
            escribir.WriteLine("public class Node");
            escribir.WriteLine("{");
            escribir.WriteLine("public Elements elemento;");
            escribir.WriteLine("public Node hijoIZ;");
            escribir.WriteLine("public Node hijoDR;");
            escribir.WriteLine("public Node(Elements elementos)");
            escribir.WriteLine("{");
            escribir.WriteLine("elemento = elementos;");
            escribir.WriteLine("hijoIZ = null;");
            escribir.WriteLine("hijoDR = null;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("public class Tree");
            escribir.WriteLine("{");
            escribir.WriteLine("public Node Raiz;");
            escribir.WriteLine("}");
            //método NGrafo
            escribir.WriteLine("public class NGrafo");
            escribir.WriteLine("{");
            escribir.WriteLine("public Dictionary<string, string> Actions(List<string> Actions, ref int largo)");
            escribir.WriteLine("{");
            escribir.WriteLine("var dic = new Dictionary<string, string>();");
            escribir.WriteLine("var caracter ="+ '"'+"'"+'"'+";");
            escribir.WriteLine("foreach (string cadena in Actions)");
            escribir.WriteLine("{");
            escribir.WriteLine("for (int i = 0; i < cadena.Length; i++)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (cadena[i] == '=')");
            escribir.WriteLine("{");
            escribir.WriteLine("var aux = cadena.Substring((i + 1));");
            escribir.WriteLine("var aux2 = cadena.Substring(0, i);");
            escribir.WriteLine("aux = aux.Trim(' ', caracter[0]);");
            escribir.WriteLine("aux2 = aux2.Trim(' ', '=');");
            escribir.WriteLine("if (largo < aux.Length)");
            escribir.WriteLine("{");
            escribir.WriteLine("largo = aux.Length;");
            escribir.WriteLine("}");
            escribir.WriteLine("dic.Add(aux, aux2);");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("return dic;");
            escribir.WriteLine("}");
            escribir.WriteLine("public Dictionary<string, string> Tokens(List<string> LT)");
            escribir.WriteLine("{");
            escribir.WriteLine("var dic = new Dictionary<string, string>();");
            escribir.WriteLine("foreach (string cadena in LT)");
            escribir.WriteLine("{");
            escribir.WriteLine("for (int i = 0; i < cadena.Length; i++)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (cadena[i] == '=')");
            escribir.WriteLine("{");
            escribir.WriteLine("var aux = cadena.Substring((i + 1));");
            escribir.WriteLine("var aux2 = cadena.Substring(0, i);");
            escribir.WriteLine("aux = aux.Trim(' ');");
            escribir.WriteLine("aux2 = aux2.Trim(' ', '=');");
            escribir.WriteLine("dic.Add(aux, aux2);");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("return dic;");
            escribir.WriteLine("}");
            escribir.WriteLine("public Dictionary<string, string> SETS(List<string> LS)");
            escribir.WriteLine("{");
            escribir.WriteLine("var LAux = new List<string>();");
            escribir.WriteLine("var Aux = new List<string>();");
            escribir.WriteLine("var SET = new List<string>();");
            escribir.WriteLine("var dic = new Dictionary<string, string>();");
            escribir.WriteLine("var aux = "+'"'+"'"+'"'+";");
            escribir.WriteLine("foreach (string cadena in LS)");
            escribir.WriteLine("{");
            escribir.WriteLine("var auxiliar = string.Empty;");
            escribir.WriteLine("var AUX = string.Empty;");
            escribir.WriteLine("for (int i = 0; i < cadena.Length; i++)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (cadena[i] == '=')");
            escribir.WriteLine("{");
            escribir.WriteLine("auxiliar = cadena.Substring(i + 1);");
            escribir.WriteLine("AUX = cadena.Substring(0, i - 1);");
            escribir.WriteLine("AUX = AUX.Trim(' ');");
            escribir.WriteLine("auxiliar = auxiliar.Trim(' ');");
            escribir.WriteLine("Aux.Add(auxiliar);");
            escribir.WriteLine("SET.Add(AUX);");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("foreach (string cadena in Aux)");
            escribir.WriteLine("{");
            escribir.WriteLine("var CAux = string.Empty;");
            escribir.WriteLine("if (cadena.Contains(" + '"' + "CHR" + '"' + "))");
            escribir.WriteLine("{");
            escribir.WriteLine("var respaldo = string.Empty;");
            escribir.WriteLine("CAux = cadena.Trim(' ');");
            escribir.WriteLine("while (CAux.Length != 0)");
            escribir.WriteLine("{");
            escribir.WriteLine("CAux = cadena.Trim(' ');");
            escribir.WriteLine("int r1 = 0;");
            escribir.WriteLine("int r2 = 0;");
            escribir.WriteLine("int r3 = 0;");
            escribir.WriteLine("intervalo(CAux, ref r1, ref r2);");
            escribir.WriteLine("r3 = r2 - r1;");
            escribir.WriteLine("var inicial = CAux.Substring(r1, r3);");
            escribir.WriteLine("CAux = CAux.Substring(r2 + 1);");
            escribir.WriteLine("var final = string.Empty;");
            escribir.WriteLine("if (CAux[0] == '.')");
            escribir.WriteLine("{");
            escribir.WriteLine(" r1 = 0;");
            escribir.WriteLine("r2 = 0;");
            escribir.WriteLine("r3 = 0;");
            escribir.WriteLine("intervalo(CAux, ref r1, ref r2);");
            escribir.WriteLine("r3 = r2 - r1;");
            escribir.WriteLine("final = CAux.Substring(r1, r3);");
            escribir.WriteLine("CAux = CAux.Substring(r2 + 1);");
            escribir.WriteLine("}");
            escribir.WriteLine("var verdad1 = false;");
            escribir.WriteLine(" var verdad = false;");
            escribir.WriteLine("while (!verdad)");
            escribir.WriteLine("{");
            escribir.WriteLine("for (int j = 0; j < 256; j++)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (j == Convert.ToInt32(inicial) && !verdad1)");
            escribir.WriteLine("{");
            escribir.WriteLine("respaldo += Convert.ToChar(j);");
            escribir.WriteLine("verdad1 = true;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (final == string.Empty && verdad1)");
            escribir.WriteLine("{");
            escribir.WriteLine("verdad = true;");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (final != string.Empty && verdad1 && j == Convert.ToInt32(final))");
            escribir.WriteLine("{");
            escribir.WriteLine(" respaldo += Convert.ToChar(j);");
            escribir.WriteLine("verdad = true;");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (final != string.Empty && verdad1)");
            escribir.WriteLine("{");
            escribir.WriteLine("respaldo += Convert.ToChar(j);");
            escribir.WriteLine("verdad = true;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("CAux = respaldo;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine(" for (int i = 0; i < cadena.Length; i++)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (cadena[i] == aux[0])");
            escribir.WriteLine("{");
            escribir.WriteLine("i++;");
            escribir.WriteLine("var inicial = string.Empty;");
            escribir.WriteLine("inicial += cadena[i];");
            escribir.WriteLine("i++;");
            escribir.WriteLine("var final = string.Empty;");
            escribir.WriteLine("if (i + 1 < cadena.Length)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (cadena[i + 1] == '.')");
            escribir.WriteLine("{");
            escribir.WriteLine("i = i + 4;");
            escribir.WriteLine("final += cadena[i];");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("i++;");
            escribir.WriteLine("var verdad1 = false;");
            escribir.WriteLine("var verdad = false;");
            escribir.WriteLine("while (!verdad)");
            escribir.WriteLine("{");
            escribir.WriteLine("for (int j = 0; j < 256; j++)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (Convert.ToChar(j) == inicial[0] && !verdad1)");
            escribir.WriteLine("{");
            escribir.WriteLine(" CAux += inicial[0];");
            escribir.WriteLine("verdad1 = true;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (final == string.Empty && verdad1)");
            escribir.WriteLine("{");
            escribir.WriteLine("verdad = true;");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (final != string.Empty && verdad1 && Convert.ToChar(j) == final[0])");
            escribir.WriteLine("{");
            escribir.WriteLine("CAux += Convert.ToChar(j);");
            escribir.WriteLine("verdad = true;");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (final != string.Empty && verdad1)");
            escribir.WriteLine("{");
            escribir.WriteLine("CAux += Convert.ToChar(j);");
            escribir.WriteLine("verdad = true;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("LAux.Add(CAux);");
            escribir.WriteLine("}");
            escribir.WriteLine("for (int i = 0; i < SET.Count(); i++)");
            escribir.WriteLine("{");
            escribir.WriteLine("dic.Add(SET[i], LAux[i]);");
            escribir.WriteLine("}");
            escribir.WriteLine("return dic;");
            escribir.WriteLine("}");
            escribir.WriteLine("void intervalo(string cadena, ref int r1, ref int r2)");
            escribir.WriteLine("{");
            escribir.WriteLine("for (int j = 0; j < cadena.Length; j++)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (cadena[j] == '(')");
            escribir.WriteLine("{");
            escribir.WriteLine("r1 = j + 1;");
            escribir.WriteLine("}");
            escribir.WriteLine("if (cadena[j] == ')')");
            escribir.WriteLine("{");
            escribir.WriteLine("r2 = j;");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("public bool ValidarA(List<Grafo> Grafo, ref string cadena, Dictionary<string, string> dic, bool Act, Dictionary<string, string> dicA, int largo, ref string Estados, ref string eliminada, ref List<string> lista)");
            escribir.WriteLine("{");
            escribir.WriteLine("var valido = false;");
            escribir.WriteLine("var EstadoActual = Grafo[0].estado;");
            escribir.WriteLine(" Estados += EstadoActual + "+'"'+ "|" +'"'+";");
            escribir.WriteLine("var terminal = false;");
            escribir.WriteLine("var fin = false;");
            escribir.WriteLine("while (!valido)");
            escribir.WriteLine("{");
            escribir.WriteLine("foreach (Grafo grafo in Grafo)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (grafo.estado == EstadoActual)");
            escribir.WriteLine("{");
            escribir.WriteLine("var Incorrecto = 0;");
            escribir.WriteLine("if (cadena.Length == 0)");
            escribir.WriteLine("{");
            escribir.WriteLine("terminal = grafo.EsTerminal;");
            escribir.WriteLine("fin = terminal ? true : false;");
            escribir.WriteLine("valido = true;");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("cadena = cadena.Trim(' ');");
            escribir.WriteLine("var cierto = false;");
            escribir.WriteLine("if (Act)");
            escribir.WriteLine("{");
            escribir.WriteLine("var ups = string.Empty;");
            escribir.WriteLine("cierto = ACT(ref cadena, largo, dicA, ref Incorrecto, ref ups);");

                                escribir.WriteLine("if (cierto)");

                                    escribir.WriteLine("{");
    
                                            escribir.WriteLine("var ac = " + '"' + "Actions ="+'"'+" + dicA.FirstOrDefault(x => x.Key == ups).Value;");
            escribir.WriteLine("lista.Add(ac);");

            escribir.WriteLine("Incorrecto++;");

            escribir.WriteLine("}");


            escribir.WriteLine("}");


        escribir.WriteLine("if (!cierto)");

        escribir.WriteLine("{");


            escribir.WriteLine("for (int i = 0; i < grafo.Apuntadores.Length; i++)");

            escribir.WriteLine("{");


                escribir.WriteLine("if (cadena.Length == 0)");

                escribir.WriteLine("{");


                    escribir.WriteLine("break;");

                escribir.WriteLine("}");


                escribir.WriteLine("else");

                escribir.WriteLine("if (grafo.Apuntadores[i] != string.Empty)");


                    escribir.WriteLine("{");


                    escribir.WriteLine("var nuevo = "+'"'+"'"+'"'+";");

                escribir.WriteLine("var Aux = string.Empty;");

                escribir.WriteLine("var A1 = grafo.simbolos[i].Trim(nuevo[0]);");

                escribir.WriteLine("if (dic.Count() != 0)");

                    escribir.WriteLine("{");


                        escribir.WriteLine("Aux = (dic.ContainsKey(A1)) ? dic.FirstOrDefault(x => x.Key == A1).Value : A1;");

                    escribir.WriteLine("}");


                    escribir.WriteLine("else");

                    escribir.WriteLine("{");


                        escribir.WriteLine("Aux = A1;");

                    escribir.WriteLine("}");


                    escribir.WriteLine("if (Aux.Length == 0)");

                    escribir.WriteLine("{");


                        escribir.WriteLine("Aux += "+'"'+"'"+'"'+";");

                    escribir.WriteLine("}");


                    escribir.WriteLine("if (Aux.Contains(cadena[0]))");

                    escribir.WriteLine("{");


                        escribir.WriteLine("eliminada += cadena[0];");
                        
                    escribir.WriteLine("EstadoActual = grafo.Apuntadores[i];");

                    escribir.WriteLine("Estados += EstadoActual + "+'"'+ "|"+'"'+ ";");

                    escribir.WriteLine("cadena = cadena.Substring(1);");

                    escribir.WriteLine("Incorrecto++;");

                    escribir.WriteLine("terminal = grafo.EsTerminal;");

                    escribir.WriteLine("break;");

                    escribir.WriteLine("}");


                    escribir.WriteLine(" }");


                 escribir.WriteLine("}");


            escribir.WriteLine("}");


        escribir.WriteLine("}");


    escribir.WriteLine("cadena = cadena.Trim(' ');");

escribir.WriteLine("if (Incorrecto == 0)");

    escribir.WriteLine("{");


        escribir.WriteLine("fin = (grafo.EsTerminal) ? true : false;");

    escribir.WriteLine("valido = true;");

    escribir.WriteLine("break;");

    escribir.WriteLine("}");


    escribir.WriteLine("}");


escribir.WriteLine("}");


escribir.WriteLine("}");


escribir.WriteLine("valido = (fin) ? true : false;");

escribir.WriteLine("return valido;");

escribir.WriteLine("}");


escribir.WriteLine("bool ACT(ref string cadena, int largo, Dictionary<string, string> dicA, ref int Incorrecto, ref string ups)");

escribir.WriteLine("{");

escribir.WriteLine("var cierto = false;");

escribir.WriteLine("var Aux = (largo < cadena.Length) ? cadena.Substring(0, largo) : cadena.Substring(0, cadena.Length);");

escribir.WriteLine("while (Aux.Length != 0)");

escribir.WriteLine("{");


escribir.WriteLine("if (dicA.ContainsKey(Aux))");

escribir.WriteLine("{");

escribir.WriteLine("cierto = true;");

escribir.WriteLine("cadena = cadena.Substring(Aux.Length);");

escribir.WriteLine("Incorrecto++;");

escribir.WriteLine(" break;");


escribir.WriteLine("}");


escribir.WriteLine("else");
escribir.WriteLine("{");

escribir.WriteLine("Aux = Aux.Substring(0, Aux.Length - 1);");

escribir.WriteLine("}");


escribir.WriteLine("}");


escribir.WriteLine("ups = Aux;");

escribir.WriteLine("return cierto;");

escribir.WriteLine("}");


escribir.WriteLine("}");
            escribir.Close();
        }
        public void QMétodo(string dirección)
        {
            StreamWriter escribir = File.AppendText(dirección);
            //métodos del último form
            escribir.WriteLine("string igualar(string llave)");
            escribir.WriteLine("{");
            escribir.WriteLine("var T = "+'"'+"()"+'"'+";");
            escribir.WriteLine("var S = "+'"'+"'"+'"'+";");
            escribir.WriteLine("var E = "+'"'+"(    \t "+'"'+";");
            escribir.WriteLine("var auxiliar = string.Empty;");
            escribir.WriteLine("for (int i = 0; i < llave.Length; i++)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (!E.Contains(llave[i]))");
            escribir.WriteLine("{");
            escribir.WriteLine("if (T.Contains(llave[i]))");
            escribir.WriteLine("{");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (S.Contains(llave[i]))");
            escribir.WriteLine("{");
            escribir.WriteLine("auxiliar += llave[i];");
            escribir.WriteLine("i++;");
            escribir.WriteLine("auxiliar += llave[i];");
            escribir.WriteLine("i++;");
            escribir.WriteLine("auxiliar += llave[i];");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("auxiliar += llave[i];");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("return auxiliar;");
            escribir.WriteLine("}");
            escribir.WriteLine("string[] EncontrarV(string[] Vector)");
            escribir.WriteLine("{");
            escribir.WriteLine("var Lista = new List<string>();");
            escribir.WriteLine("for (int i = 0; i < Vector.Length; i++)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (Vector[i] != string.Empty)");
            escribir.WriteLine("{");
            escribir.WriteLine("Lista.Add(Vector[i]);");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("var auxiliar = new string[Lista.Count()];");
            escribir.WriteLine("var contador = 0;");
            escribir.WriteLine("foreach (string cadena in Lista)");
            escribir.WriteLine("{");
            escribir.WriteLine("auxiliar[contador] = cadena;");
            escribir.WriteLine("contador++;");
            escribir.WriteLine("}");
            escribir.WriteLine("return auxiliar;");
            escribir.WriteLine("}");
            escribir.WriteLine("void EncontrarToken(Node actual, string valor, string frase, Dictionary<string, string> SETS, ref bool encontrado, Dictionary<int, string> TF, string APS)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (actual == null)");
            escribir.WriteLine("{");
            escribir.WriteLine("return;");
            escribir.WriteLine("}");
            escribir.WriteLine("EncontrarToken(actual.hijoIZ, valor, frase, SETS, ref encontrado, TF, APS);");
            escribir.WriteLine("EncontrarToken(actual.hijoDR, valor, frase, SETS, ref encontrado, TF, APS);");
            escribir.WriteLine("if (!encontrado)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (actual.hijoDR == null && actual.hijoIZ == null)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (actual.elemento.First == valor)");
            escribir.WriteLine("{");
            escribir.WriteLine("var auxiliar = string.Empty;");
            escribir.WriteLine("if (SETS.ContainsKey(actual.elemento.caracter))");
            escribir.WriteLine("{");
            escribir.WriteLine("auxiliar = SETS.FirstOrDefault(x => x.Key == actual.elemento.caracter).Value;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("auxiliar += actual.elemento.caracter;");
                                 escribir.WriteLine("var x = "+'"'+"'"+'"'+";");
            escribir.WriteLine("auxiliar = auxiliar.Trim(x[0]);");
            escribir.WriteLine("if (auxiliar.Length == 0)");
            escribir.WriteLine("{");
                                     escribir.WriteLine("auxiliar += "+'"'+"'"+'"'+";");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("if (auxiliar.Contains(frase[0]))");
            escribir.WriteLine("{");
            escribir.WriteLine("if (APS.Contains(TF[Convert.ToInt32(valor)]))");
            escribir.WriteLine("{");
            escribir.WriteLine("encontrado = true;");
            escribir.WriteLine("}");
            escribir.WriteLine("return;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("return;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("void recorrer(Node actual, Node Raiz, Node Padre, Node PadreAux, string VNodo, ref string frase, ref bool encontrado, ref bool ayuda, Dictionary<string, string> SETS)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (actual == null)");
            escribir.WriteLine("{");
            escribir.WriteLine("return;");
            escribir.WriteLine("}");
            escribir.WriteLine("recorrer(actual.hijoIZ, Raiz, Padre, PadreAux, VNodo, ref frase, ref encontrado, ref ayuda, SETS);");
            escribir.WriteLine("if (actual.elemento.caracter == "+'"'+ "|"+'"'+ " && ayuda && frase == string.Empty)");
            escribir.WriteLine("{");
            escribir.WriteLine("ayuda = false;");
            escribir.WriteLine("encontrado = true;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (actual.elemento.caracter == "+'"'+ "|"+'"'+ " && ayuda)");
            escribir.WriteLine("{");
            escribir.WriteLine("ayuda = false;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("if (actual.elemento.First == VNodo)");
            escribir.WriteLine("{");
            escribir.WriteLine("ayuda = true;");
            escribir.WriteLine("}");
            escribir.WriteLine("var R = false;");
                 escribir.WriteLine("if (actual.hijoIZ == null && actual.hijoDR == null && ayuda && actual.elemento.caracter != "+'"'+"#"+'"'+")");
            escribir.WriteLine("{");
            escribir.WriteLine("var contador = 0;");
            escribir.WriteLine("var CAux = string.Empty;");
            escribir.WriteLine("var cierto = false;");
            escribir.WriteLine(" EncontrarPadre(actual, Raiz, ref Padre, ref R);");
            escribir.WriteLine("switch (Padre.elemento.caracter)");
            escribir.WriteLine("{");
            escribir.WriteLine("case " + '"' + "*" + '"' + ":");
            escribir.WriteLine("CAux = (SETS.ContainsKey(actual.elemento.caracter)) ? SETS.FirstOrDefault(x => x.Key == actual.elemento.caracter).Value : CAux + actual.elemento.caracter[1];");
                             escribir.WriteLine("do");
            escribir.WriteLine("{");
            escribir.WriteLine("if (frase != string.Empty && CAux.Contains(frase[0]))");
            escribir.WriteLine("{");
            escribir.WriteLine("frase = frase.Substring(1);");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("} while (cierto == false);");
            escribir.WriteLine("break;");
            escribir.WriteLine("case " + '"' + "+" + '"' + ":");
            escribir.WriteLine("CAux = (SETS.ContainsKey(actual.elemento.caracter)) ? SETS.FirstOrDefault(x => x.Key == actual.elemento.caracter).Value : CAux + actual.elemento.caracter[1];");
            escribir.WriteLine("do");
            escribir.WriteLine("{");
            escribir.WriteLine("if (frase != string.Empty && CAux.Contains(frase[0]))");
            escribir.WriteLine("{");
            escribir.WriteLine("contador++;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine(" } while (cierto == false);");
            escribir.WriteLine("ayuda = (contador > 0) ? true : false;");
            escribir.WriteLine("break;");
            escribir.WriteLine("case " + '"' + "." + '"' + ":");
            escribir.WriteLine("CAux = (SETS.ContainsKey(actual.elemento.caracter)) ? SETS.FirstOrDefault(x => x.Key == actual.elemento.caracter).Value : CAux + actual.elemento.caracter[1];");
            escribir.WriteLine("if (frase != string.Empty)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (CAux.Contains(frase[0]))");
            escribir.WriteLine("{");
            escribir.WriteLine("frase = frase.Substring(1);");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("ayuda = false;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("ayuda = false;");
            escribir.WriteLine("}");
            escribir.WriteLine("if (Padre.hijoDR.elemento.caracter == " + '"' + "*" + '"' + ")");
            escribir.WriteLine("{");
            escribir.WriteLine("cierto = false;");
            escribir.WriteLine("var value = new List<string>();");
            escribir.WriteLine("AuxRecorrer(Padre.hijoDR, ref value);");
            escribir.WriteLine("var reemplazo = false;");
            escribir.WriteLine("do");
            escribir.WriteLine("{");
            escribir.WriteLine("reemplazo = false;");
            escribir.WriteLine("foreach (string cadena in value)");
            escribir.WriteLine("{");
            escribir.WriteLine("CAux = (SETS.ContainsKey(cadena)) ? SETS.FirstOrDefault(x => x.Key == cadena).Value : CAux + cadena[1];");
            escribir.WriteLine("if (frase != string.Empty && CAux.Contains(frase[0]))");
            escribir.WriteLine("{");
            escribir.WriteLine("frase = frase.Substring(1);");
            escribir.WriteLine("reemplazo = true;");
            escribir.WriteLine(" }");
            escribir.WriteLine("}");
            escribir.WriteLine("if (!reemplazo)");
            escribir.WriteLine("{");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("} while (cierto == false);");
            escribir.WriteLine("R = false;");
            escribir.WriteLine("EncontrarPadre(Padre, Raiz, ref PadreAux, ref R);");
            escribir.WriteLine("if (PadreAux.elemento.caracter == "+'"'+"."+'"'+")");
            escribir.WriteLine("{");
            escribir.WriteLine("actual = PadreAux;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("R = false;");
            escribir.WriteLine("EncontrarPadre(PadreAux, Raiz, ref Padre, ref R);");
            escribir.WriteLine("actual = Padre;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (Padre.hijoDR.elemento.caracter == " + '"' + "|" + '"' + " || Padre.hijoDR.elemento.caracter == " + '"' + "+" + '"' + ")");
            escribir.WriteLine("{");
            escribir.WriteLine("var value = new List<string>();");
            escribir.WriteLine("contador = 0;");
            escribir.WriteLine("AuxRecorrer(Padre.hijoDR, ref value);");
            escribir.WriteLine("var reemplazo = false;");
            escribir.WriteLine("do");
            escribir.WriteLine("{");
            escribir.WriteLine("reemplazo = false;");
            escribir.WriteLine("foreach (string cadena in value)");
            escribir.WriteLine("{");
            escribir.WriteLine("CAux = (SETS.ContainsKey(cadena)) ? SETS.FirstOrDefault(x => x.Key == cadena).Value : CAux + cadena[1];");
            escribir.WriteLine("if (frase != string.Empty && CAux.Contains(frase[0]))");
            escribir.WriteLine("{");
            escribir.WriteLine("frase = frase.Substring(1);");
            escribir.WriteLine("contador++;");
            escribir.WriteLine("reemplazo = true;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("if (!reemplazo)");
            escribir.WriteLine("{");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("} while (cierto == false);");
            escribir.WriteLine("var XYZ = (contador > 0) ? true : false;");
            escribir.WriteLine("if (XYZ)");
            escribir.WriteLine("{");
            escribir.WriteLine("R = false;");
            escribir.WriteLine("EncontrarPadre(Padre, Raiz, ref PadreAux, ref R);");
            escribir.WriteLine("if (PadreAux.elemento.caracter == " + '"' + "." + '"' + ")");
            escribir.WriteLine("{");
            escribir.WriteLine("actual = PadreAux;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("R = false;");
            escribir.WriteLine("EncontrarPadre(PadreAux, Raiz, ref Padre, ref R);");
            escribir.WriteLine("actual = Padre;");
            escribir.WriteLine(" }");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("break;");
            escribir.WriteLine("case " + '"' + "|" + '"' + ":");
            escribir.WriteLine("R = false;");
            escribir.WriteLine("EncontrarPadre(Padre, Raiz, ref PadreAux, ref R);");
            escribir.WriteLine("if (PadreAux.elemento.caracter == " + '"' + "|" + '"' + ")");
            escribir.WriteLine("{");
            escribir.WriteLine("CAux = (SETS.ContainsKey(actual.elemento.caracter)) ? SETS.FirstOrDefault(x => x.Key == actual.elemento.caracter).Value : CAux + actual.elemento.caracter[1];");
            escribir.WriteLine("if (frase != string.Empty && CAux.Contains(frase[0]))");
            escribir.WriteLine("{");
            escribir.WriteLine("frase = frase.Substring(1);");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("ayuda = false;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("recorrer(actual.hijoDR, Raiz, Padre, PadreAux, VNodo, ref frase, ref encontrado, ref ayuda, SETS);");
            escribir.WriteLine("}");
            escribir.WriteLine("void AuxRecorrer(Node actual, ref List<string> VALORES)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (actual == null)");
            escribir.WriteLine("{");
            escribir.WriteLine("return;");
            escribir.WriteLine("}");
            escribir.WriteLine("AuxRecorrer(actual.hijoIZ, ref VALORES);");
            escribir.WriteLine("AuxRecorrer(actual.hijoDR, ref VALORES);");
            escribir.WriteLine("if (actual.hijoDR == null && actual.hijoIZ == null && actual.elemento.caracter != " + '"' + "#" + '"' + ")");
            escribir.WriteLine("{");
            escribir.WriteLine("VALORES.Add(actual.elemento.caracter);");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("void UltimoRecorrido(Node actual, Node Raiz, Node Padre, string inicial, ref string token, ref bool encontrado)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (actual == null)");
            escribir.WriteLine("{");
            escribir.WriteLine("return;");
            escribir.WriteLine("}");
            escribir.WriteLine("UltimoRecorrido(actual.hijoIZ, Raiz, Padre, inicial, ref token, ref encontrado);");
            escribir.WriteLine("if (actual.hijoIZ == null && actual.hijoDR == null)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (actual.elemento.First == inicial)");
            escribir.WriteLine("{");
            escribir.WriteLine("encontrado = true;");
            escribir.WriteLine("}");
            escribir.WriteLine("if (encontrado)");
            escribir.WriteLine("{");
            escribir.WriteLine("token += actual.elemento.caracter + "+'"'+" "+'"'+ ";");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("var R = false;");
            escribir.WriteLine("EncontrarPadre(actual, Raiz, ref Padre, ref R);");
            escribir.WriteLine("if (Padre.elemento.caracter == " + '"' + "|" + '"' + " && actual.elemento.caracter == " + '"' + "|" + '"' + ")");
            escribir.WriteLine("{");
            escribir.WriteLine("encontrado = false;");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (encontrado)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (actual.elemento.caracter != " + '"' + "." + '"' + ")");
            escribir.WriteLine("{");
            escribir.WriteLine("token += actual.elemento.caracter + "+'"'+" "+'"'+";");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("UltimoRecorrido(actual.hijoDR, Raiz, Padre, inicial, ref token, ref encontrado);");
            escribir.WriteLine("}");
            escribir.WriteLine("private void EncontrarPadre(Node NodoActual, Node Padre, ref Node PadreAux, ref bool P)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (Padre == null)");
            escribir.WriteLine("{");
            escribir.WriteLine("return;");
            escribir.WriteLine("}");
            escribir.WriteLine("EncontrarPadre(NodoActual, Padre.hijoIZ, ref PadreAux, ref P);");
            escribir.WriteLine("if (Padre.hijoIZ == NodoActual || Padre.hijoDR == NodoActual)");
            escribir.WriteLine("{");
            escribir.WriteLine("PadreAux = Padre;");
            escribir.WriteLine("P = true;");
            escribir.WriteLine("}");
            escribir.WriteLine("if (!P)");
            escribir.WriteLine("{");
            escribir.WriteLine("EncontrarPadre(NodoActual, Padre.hijoDR, ref PadreAux, ref P);");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("return;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.Close();
        }
        public void SEMétodo(string dirección)
        {
            StreamWriter escribir = File.AppendText(dirección);
            //método Aux
            escribir.WriteLine("public class AuxClass");
            escribir.WriteLine("{");
            escribir.WriteLine("public Node CreateTreeP2(string Exp)");
            escribir.WriteLine("{");
            escribir.WriteLine("var T = " + '"' + "(.|+?*)" + '"' + ";");
            escribir.WriteLine("var PT = new Stack<char>();");
            escribir.WriteLine("var PS = new Stack<Node>();");
            escribir.WriteLine("var X = string.Empty;");
            escribir.WriteLine("var contador = 0;");
            escribir.WriteLine("var nuevo = " + '"' + "'" + '"' + ";");
            escribir.WriteLine("for (int i = 0; i < Exp.Length; i++)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (Exp[i] == nuevo[0])");
            escribir.WriteLine("{");
            escribir.WriteLine("contador++;");
            escribir.WriteLine("}");
            escribir.WriteLine("if (T.Contains(Exp[i]) && (contador % 2 == 0 || contador == 3))");
            escribir.WriteLine("{");
            escribir.WriteLine("contador = 0;");
            escribir.WriteLine("if (X != string.Empty)");
            escribir.WriteLine("{");
            escribir.WriteLine("var carct = string.Empty;");
            escribir.WriteLine("carct += Exp[i];");
            escribir.WriteLine("var TreeSETSNode = CreateNode(X);");
            escribir.WriteLine("PS.Push(TreeSETSNode);");
            escribir.WriteLine("X = string.Empty;");
            escribir.WriteLine("}");
            escribir.WriteLine("if (Exp[i] == '(')");
            escribir.WriteLine("{");
            escribir.WriteLine("PT.Push(Exp[i]);");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (Exp[i] == ')')");
            escribir.WriteLine("{");
            escribir.WriteLine("PopPilaT(ref PS, ref PT);");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (Exp[i] == '*' || Exp[i] == '+' || Exp[i] == '?')");
            escribir.WriteLine("{");
            escribir.WriteLine("var carct = string.Empty;");
            escribir.WriteLine("carct += Exp[i];");
            escribir.WriteLine("var TreeSETSNode = CreateNode(carct);");
            escribir.WriteLine("PS = JuntarNodos(TreeSETSNode, PS);");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("if (PT.Count() > 0)");
            escribir.WriteLine("{");
            escribir.WriteLine("while (PT.Count() > 0)");
            escribir.WriteLine("{");
            escribir.WriteLine("if ((PT.First() == '.' && Exp[i] == '.') || (PT.First() == '|' && Exp[i] == '|') || (PT.First() == '.' && Exp[i] == '|'))");
            escribir.WriteLine("{");
            escribir.WriteLine("var carcter = ' ';");
            escribir.WriteLine("carcter = Exp[i];");
            escribir.WriteLine(" PoPPilaTP2(ref PS, ref PT, carcter);");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("PT.Push(Exp[i]);");
            escribir.WriteLine("break;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("else");
            escribir.WriteLine("{");
            escribir.WriteLine("X += Exp[i];");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("return PS.Pop();");
            escribir.WriteLine("}");
            escribir.WriteLine("void PoPPilaTP2(ref Stack<Node> PS, ref Stack<char> PT, char Aux)");
            escribir.WriteLine("{");
            escribir.WriteLine("string Auxiliar = string.Empty;");
            escribir.WriteLine("Auxiliar += PT.Pop();");
            escribir.WriteLine("var TreeSETSNode = CreateNode(Auxiliar);");
            escribir.WriteLine("Node HD = PS.Pop();");
            escribir.WriteLine("Node HI = PS.Pop();");
            escribir.WriteLine("TreeSETSNode.hijoDR = HD;");
            escribir.WriteLine("TreeSETSNode.hijoIZ = HI;");
            escribir.WriteLine("PS.Push(TreeSETSNode);");
            escribir.WriteLine("}");
            escribir.WriteLine("Node CreateNode(string cadena)");
            escribir.WriteLine("{");
            escribir.WriteLine("Elements elemento = new Elements();");
            escribir.WriteLine("elemento.caracter = cadena;");
            escribir.WriteLine("var TreeNode = new Node(elemento);");
            escribir.WriteLine("return TreeNode;");
            escribir.WriteLine("}");
            escribir.WriteLine("void PopPilaT(ref Stack<Node> PS, ref Stack<char> PT)");
            escribir.WriteLine("{");
            escribir.WriteLine("var caracterAux = ' ';");
            escribir.WriteLine("while (caracterAux != '(' && PT.Count() != 0)");
                escribir.WriteLine("{");
            escribir.WriteLine("caracterAux = PT.Pop();");
            escribir.WriteLine("if (caracterAux != '(')");
            escribir.WriteLine("{");
            escribir.WriteLine("Node HD = PS.Pop();");
            escribir.WriteLine("Node HI = PS.Pop();");
            //
            escribir.WriteLine("var Ref = string.Empty;");
            escribir.WriteLine("Ref += caracterAux;");
            escribir.WriteLine("var TreeSETSNode = CreateNode(Ref);");
            escribir.WriteLine("TreeSETSNode.hijoDR = HD;");
            escribir.WriteLine("TreeSETSNode.hijoIZ = HI;");
            escribir.WriteLine("PS.Push(TreeSETSNode);");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("Stack <Node> JuntarNodos(Node Aux, Stack<Node> PS)");
            escribir.WriteLine("{");
            escribir.WriteLine("Node AuxN = PS.Pop();");
            escribir.WriteLine("Aux.hijoIZ = AuxN;");
            escribir.WriteLine("PS.Push(Aux);");
            escribir.WriteLine("return PS;");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            //Ingresar Fln
            escribir.WriteLine("public class FLFN");
            escribir.WriteLine("{");
            escribir.WriteLine("public void IngresarFLH(Node Actual, ref int contador)");
            escribir.WriteLine("{");
            escribir.WriteLine("if (Actual == null)");
            escribir.WriteLine("{");
            escribir.WriteLine("return;");
            escribir.WriteLine("}");
            escribir.WriteLine("IngresarFLH(Actual.hijoIZ, ref contador);");
            escribir.WriteLine("if (Actual.hijoIZ == null && Actual.hijoDR == null)");
            escribir.WriteLine("{");
            escribir.WriteLine("Actual.elemento.First = Convert.ToString(contador);");
            escribir.WriteLine("Actual.elemento.Last = Convert.ToString(contador);");
            escribir.WriteLine("contador++;");
            escribir.WriteLine("}");
            escribir.WriteLine("IngresarFLH(Actual.hijoDR, ref contador);");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.WriteLine("}");
            escribir.Close();
        
        }
    }
}
