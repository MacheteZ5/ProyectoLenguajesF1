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
    public partial class Form4 : Form
    {
        Dictionary<string, string[]> TablaE;
        List<string> Simbol = new List<string>();
        string ultimoV;
        List<string> ListSETS = new List<string>();
        List<string> ListActions = new List<string>();
        List<string> ListTokens = new List<string>();
        bool action = false;
        string Exp = string.Empty;
        public Form4(Dictionary<string, string[]> Tabla, List<string> Simbolos,int ultimovalor, List<string> lista, List<string> actions,bool act, List<string> token, string exp)
        {
            InitializeComponent();
            TablaE = Tabla;
            Simbol = Simbolos;
            ultimoV += ultimovalor;
            ListSETS = lista;
            ListActions = actions;
            action = act;
            ListTokens = token;
            Exp = exp;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pantalla1.Items.Clear();
            List<Grafo> LNodo = new List<Grafo>();
            foreach (string llave in TablaE.Keys)
            {
                string estado = llave.Trim(',');
                string[] puntero = TablaE.FirstOrDefault(x => x.Key == llave).Value;
                for(int i = 0; i < puntero.Length; i++)
                {
                    puntero[i] = puntero[i].Trim(',');
                }
                bool terminal = false;
                if (estado.Contains(ultimoV))
                {
                    terminal = true;
                }
                Grafo grafo = new Grafo(estado,terminal,puntero, Simbol);
                LNodo.Add(grafo);
            }
            //recorrer la lista
            NGrafo grafos = new NGrafo();
            var dic = new Dictionary<string,string>();
            var largo = 0;
            var dicA = new Dictionary<string, string>();
            var dicT = new Dictionary<string, string>();
            if (ListSETS != null)
            {
                dic = grafos.SETS(ListSETS);
            }
            if (action)
            {
                dicA = grafos.Actions(ListActions, ref largo);
            }
            dicT = grafos.Tokens(ListTokens);
            var cadena = txtBox1.Text;
            var verdad = false;
            var ListaAMostrar = new List<string>();
            //falta enviarle esto
            if (cadena.Length != 0)
            {
                while (cadena.Length != 0)
                {
                    var CP = cadena.Length;
                    var estado = string.Empty;
                    var cadenaeliminada = string.Empty;
                    verdad = grafos.ValidarA(LNodo, ref cadena, dic, action, dicA, largo, ref estado, ref cadenaeliminada, ref ListaAMostrar);
                    var CP2 = cadena.Length;
                    if (CP == CP2 || !verdad)
                    {
                        verdad = false;
                        break;
                    }
                    var CV = cadenaeliminada;
                    var vector = estado.Split('|');
                    vector = EncontrarV(vector);
                    var nuevo = new AuxClass();
                    var Tree = new Tree();
                    Tree.Raiz = nuevo.CreateTreeP2(Exp);
                    FLFN flfn = new FLFN();
                    var contador = 1;
                    flfn.IngresarFLH(Tree.Raiz, ref contador);
                    //segunda Prueba
                    var fin = string.Empty;
                    var Ninicial = LNodo[0].estado.Split(',');
                    Tree.Raiz.elemento.caracter = "|";
                    for (int i = 0; i < Ninicial.Length; i++)
                    {
                        var encontrado = false;
                        var ayuda = false;
                        recorrer(Tree.Raiz, Tree.Raiz, Tree.Raiz, Tree.Raiz, Ninicial[i], ref cadenaeliminada, ref encontrado, ref ayuda, dic);
                        if (encontrado)
                        {
                            fin = Ninicial[i];
                            break;
                        }
                        else
                        {
                            cadenaeliminada = CV;
                        }
                    }
                    var token = string.Empty;
                    var correcto = false;
                    Tree.Raiz.elemento.caracter = "|";
                    UltimoRecorrido(Tree.Raiz, Tree.Raiz, Tree.Raiz, fin, ref token, ref correcto);
                    token = token.Trim(' ');
                    var tv = token.Split(' ');
                    token = string.Empty;
                    for (int i = 0; i < tv.Length; i++)
                    {
                        if (tv[i] != string.Empty)
                        {
                            token += tv[i];
                        }
                    }
                    token = token.Trim(' ');
                    //REORGANIZAR TANTO TOKENS COMO LA CADENA QUE SE RECIBIÓ
                    var loencontro = false;
                    //MÉTODO para mostrar a que token pertenece
                    foreach (string llave in dicT.Keys)
                    {
                        var auxiliar = igualar(llave);
                        if (auxiliar == token)
                        {
                            loencontro = true;
                            var resultado = dicT.FirstOrDefault(x => x.Key == llave).Value;
                            foreach (char caracter in CV)
                            {
                                var lexema = string.Empty;
                                lexema = resultado + " = " + caracter;
                                ListaAMostrar.Add(lexema);
                            }
                            break;
                        }
                    }
                    if (!loencontro)
                    {
                        foreach (string llave in dicT.Keys)
                        {
                            var auxiliar = igualar(llave);
                            if (auxiliar.Contains(token))
                            {
                                var resultado = dicT.FirstOrDefault(x => x.Key == llave).Value;
                                foreach (char caracter in CV)
                                {
                                    var lexema = string.Empty;
                                    lexema = resultado + " = " + caracter;
                                    ListaAMostrar.Add(lexema);
                                }
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                if (LNodo[0].EsTerminal)
                {
                    verdad = true;
                }
            }
            if (verdad)
            {
                MessageBox.Show("La frase que ingresó es valida en esta lenguaje formal");
                foreach(string token in ListaAMostrar)
                {
                    pantalla1.Items.Add(token);
                } 
            }
            else
            {
                MessageBox.Show("La frase que ingresó no es valida en esta lenguaje formal");
            }
        }
        string igualar(string llave)
        {
            var T = "()";
            var S = "'";
            var E = "(    \t ";
            var auxiliar = string.Empty;
            for(int i = 0; i < llave.Length; i++)
            {
                if (!E.Contains(llave[i]))
                {
                    if (T.Contains(llave[i]))
                    {

                    }
                    else
                    {
                        if (S.Contains(llave[i]))
                        {
                            auxiliar += llave[i];
                            i++;
                            auxiliar += llave[i];
                            i++;
                            auxiliar += llave[i];
                        }
                        else
                        {
                            auxiliar += llave[i];
                        }
                    }
                }
            }
            return auxiliar;
        }
        string[] EncontrarV(string[] Vector)
        {
            var Lista = new List<string>();
            for (int i = 0; i < Vector.Length; i++)
            {
                if (Vector[i] != string.Empty)
                {
                    Lista.Add(Vector[i]);
                }
            }
            var auxiliar = new string[Lista.Count()];
            var contador = 0;
            foreach(string cadena in Lista)
            {
                auxiliar[contador] = cadena;
                contador++;
            }
            return auxiliar;
        }
        void EncontrarToken(Node actual,string valor,string frase,Dictionary<string,string> SETS, ref bool encontrado, Dictionary<int, string> TF,string APS)
        {
            if (actual == null)
            {
                return;
            }
            EncontrarToken(actual.hijoIZ,valor,frase,SETS,ref encontrado,TF,APS);
            EncontrarToken(actual.hijoDR, valor, frase, SETS, ref encontrado, TF,APS);
            if(!encontrado)
            {
                if (actual.hijoDR == null && actual.hijoIZ == null)
                {
                    if (actual.elemento.First == valor)
                    {
                        var auxiliar = string.Empty;
                        if (SETS.ContainsKey(actual.elemento.caracter))
                        {
                            auxiliar = SETS.FirstOrDefault(x => x.Key == actual.elemento.caracter).Value;
                        }
                        else
                        {
                            auxiliar += actual.elemento.caracter;
                            var x = "'";
                            auxiliar = auxiliar.Trim(x[0]);
                            if (auxiliar.Length == 0)
                            {
                                auxiliar += "'";
                            }
                        }
                        if (auxiliar.Contains(frase[0]))
                        {
                            if (APS.Contains(TF[Convert.ToInt32(valor)]))
                            {
                                encontrado = true;
                            }
                            return;
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }
        void recorrer(Node actual,Node Raiz,Node Padre,Node PadreAux, string VNodo,ref string frase, ref bool encontrado, ref bool ayuda, Dictionary<string, string> SETS)
        {
            if (actual == null)
            {
                return;
            }
            recorrer(actual.hijoIZ, Raiz, Padre, PadreAux, VNodo, ref frase, ref encontrado, ref ayuda, SETS);
            if(actual.elemento.caracter=="|" && ayuda && frase==string.Empty)
            {
                ayuda = false;
                encontrado = true;
            }
            else
            {
                if (actual.elemento.caracter == "|" && ayuda)
                {
                    ayuda = false;
                }
            }
            if (actual.elemento.First == VNodo)
            {
                ayuda = true;
            }
            var R = false;
            if (actual.hijoIZ == null && actual.hijoDR == null && ayuda && actual.elemento.caracter != "#")
            {
                var contador = 0;
                var CAux = string.Empty;
                var cierto = false;
                EncontrarPadre(actual, Raiz, ref Padre, ref R);
                switch (Padre.elemento.caracter)
                {
                    case "*":
                        CAux = (SETS.ContainsKey(actual.elemento.caracter)) ? SETS.FirstOrDefault(x => x.Key == actual.elemento.caracter).Value : CAux + actual.elemento.caracter[1];
                        do
                        {
                            if (frase != string.Empty && CAux.Contains(frase[0]))
                            {
                                frase = frase.Substring(1);
                            }
                            else
                            {
                                break;
                            }
                        } while (cierto == false);
                        break;
                    case "+":
                        CAux = (SETS.ContainsKey(actual.elemento.caracter)) ? SETS.FirstOrDefault(x => x.Key == actual.elemento.caracter).Value : CAux + actual.elemento.caracter[1];
                        do
                        {
                            if (frase != string.Empty && CAux.Contains(frase[0]))
                            {
                               contador++;
                            }
                            else
                            {
                                break;
                            }
                        } while (cierto == false);
                        ayuda = (contador > 0) ? true : false;
                        break;
                    case ".":
                        CAux = (SETS.ContainsKey(actual.elemento.caracter)) ? SETS.FirstOrDefault(x => x.Key == actual.elemento.caracter).Value : CAux + actual.elemento.caracter[1];
                        if (frase!= string.Empty)
                        {
                            if (CAux.Contains(frase[0]))
                            {
                                frase = frase.Substring(1);
                            }
                            else
                            {
                                ayuda = false;
                            }
                        }
                        else
                        {
                            ayuda = false;
                        }
                        if (Padre.hijoDR.elemento.caracter == "*")
                        {
                            cierto = false;
                            var value = new List<string>();
                            AuxRecorrer(Padre.hijoDR, ref value);
                            var reemplazo = false;
                            do
                            {
                                reemplazo = false;
                                foreach (string cadena in value)
                                {
                                    CAux = (SETS.ContainsKey(cadena)) ? SETS.FirstOrDefault(x => x.Key == cadena).Value : CAux +cadena[1];
                                    if (frase != string.Empty && CAux.Contains(frase[0]))
                                    {
                                        frase = frase.Substring(1);
                                        reemplazo = true;
                                    }
                                }
                                if (!reemplazo)
                                {
                                    break;
                                }
                            } while (cierto == false);
                            R = false;
                            EncontrarPadre(Padre, Raiz, ref PadreAux, ref R);
                            if (PadreAux.elemento.caracter==".")
                            {
                                actual = PadreAux;
                            }
                            else
                            {
                                R = false;
                                EncontrarPadre(PadreAux, Raiz, ref Padre, ref R);
                                actual = Padre;
                            }
                        }
                        else
                        {
                            if(Padre.hijoDR.elemento.caracter=="|"|| Padre.hijoDR.elemento.caracter == "+")
                            {
                                var value = new List<string>();
                                contador = 0;
                                AuxRecorrer(Padre.hijoDR, ref value);
                                var reemplazo = false;
                                do
                                {
                                    reemplazo = false;
                                    foreach (string cadena in value)
                                    {
                                        CAux = (SETS.ContainsKey(cadena)) ? SETS.FirstOrDefault(x => x.Key == cadena).Value : CAux + cadena[1];
                                        if (frase != string.Empty && CAux.Contains(frase[0]))
                                        {
                                            frase = frase.Substring(1);
                                            contador++;
                                            reemplazo = true;
                                        }
                                    }
                                    if (!reemplazo)
                                    {
                                        break;
                                    }
                                } while (cierto == false);
                                var XYZ = (contador>0)?true:false;
                                if (XYZ)
                                {
                                    R = false;
                                    EncontrarPadre(Padre, Raiz, ref PadreAux, ref R);
                                    if (PadreAux.elemento.caracter == ".")
                                    {
                                        actual = PadreAux;
                                    }
                                    else
                                    {
                                        R = false;
                                        EncontrarPadre(PadreAux, Raiz, ref Padre, ref R);
                                        actual = Padre;
                                    }
                                }
                            }
                        }
                        break;
                    case "|":
                        R = false;
                        EncontrarPadre(Padre, Raiz, ref PadreAux, ref R);
                        if (PadreAux.elemento.caracter == "|")
                        {
                            CAux = (SETS.ContainsKey(actual.elemento.caracter)) ? SETS.FirstOrDefault(x => x.Key == actual.elemento.caracter).Value : CAux + actual.elemento.caracter[1];
                            if (frase != string.Empty && CAux.Contains(frase[0]))
                            {
                                frase = frase.Substring(1);
                            }
                            else
                            {
                                ayuda = false;
                            }
                        }
                        break;
                }
            }
            recorrer(actual.hijoDR, Raiz, Padre, PadreAux, VNodo, ref frase, ref encontrado, ref ayuda, SETS);
        }
        void AuxRecorrer(Node actual,ref List<string> VALORES)
        {
            if (actual == null)
            {
                return;
            }
            AuxRecorrer(actual.hijoIZ,ref VALORES);
            AuxRecorrer(actual.hijoDR,ref VALORES);
            if (actual.hijoDR==null && actual.hijoIZ==null&&actual.elemento.caracter!="#")
            {
                 VALORES.Add(actual.elemento.caracter);
            }
        }
        void UltimoRecorrido(Node actual,Node Raiz,Node Padre, string inicial, ref string token,ref bool encontrado)
        {
            if (actual == null)
            {
                return;
            }
            UltimoRecorrido(actual.hijoIZ,Raiz,Padre, inicial,ref token,ref encontrado);
            if (actual.hijoIZ == null && actual.hijoDR == null)
            {
                if (actual.elemento.First == inicial)
                {
                    encontrado = true;
                }
                if (encontrado)
                {
                   token += actual.elemento.caracter + " ";
                }
            }
            else 
            {
                var R = false;
                EncontrarPadre(actual, Raiz, ref Padre, ref R);
                if (Padre.elemento.caracter == "|" && actual.elemento.caracter == "|")
                {
                    encontrado = false;
                }
                else
                {
                    if (encontrado)
                    {
                        if (actual.elemento.caracter != ".")
                        {
                            token += actual.elemento.caracter + " ";
                        }
                    }
                }
            }
            UltimoRecorrido(actual.hijoDR,Raiz,Padre, inicial,ref token,ref encontrado);
        }
        private void EncontrarPadre(Node NodoActual, Node Padre, ref Node PadreAux, ref bool P)
        {
            if (Padre == null)
            {
                return;
            }
            EncontrarPadre(NodoActual, Padre.hijoIZ, ref PadreAux, ref P);
            if (Padre.hijoIZ == NodoActual || Padre.hijoDR == NodoActual)
            {
                PadreAux = Padre;
                P = true;
            }
            if (!P)
            {
                EncontrarPadre(NodoActual, Padre.hijoDR, ref PadreAux, ref P);
            }
            else
            {
                return;
            }
        }
    }
}
