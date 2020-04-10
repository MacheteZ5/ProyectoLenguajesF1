using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLenguajesSegundaFase
{
    public class AuxClass
    {
        public void LecturaArchivo(string File, List<string> StringList, ref List<ListNode> ListaSets, ref List<ListNode> ListaTokens, ref List<ListNode> ListaActions, ref List<ListNode> ListaErrors, ref bool sets, ref List<string> TAux, ref List<string> SAux)
        {
            var EsSETS = false;
            var EsTokens = false;
            var EsActions = false;
            var EsErrors = false;
            var contador = 1;
            using (StreamReader sr = new StreamReader(File))
            {
                var file = string.Empty;
                while ((file = sr.ReadLine()) != null)
                {
                    file = file.Trim(' ', '\t');
                    if (file != "")
                    {
                        StringList.Add(file);
                    }
                    file = string.Empty;
                }
                //Separación de caracteres por lista
                foreach (string chain in StringList)
                {
                    var ListNode = new ListNode();
                    if (contador == 1 && chain != "SETS" && chain != "TOKENS")
                    {
                        sets = true;
                    }
                    if (chain == "SETS")
                    {
                        EsSETS = true;
                    }
                    else
                    {
                        if (chain == "TOKENS")
                        {
                            EsTokens = true;
                            EsSETS = false;
                        }
                        else
                        {
                            if (chain == "ACTIONS")
                            {
                                EsActions = true;
                                EsTokens = false;
                            }
                            else
                            {
                                if (chain.Contains("ERROR"))
                                {
                                    EsErrors = true;
                                    EsActions = false;
                                }
                            }
                        }
                    }
                    ListNode.frase = chain;
                    ListNode.Nlinea = contador;
                    if (EsSETS)
                    {
                        ListaSets.Add(ListNode);
                        SAux.Add(ListNode.frase);
                    }
                    else
                    {
                        if (EsTokens)
                        {
                            ListaTokens.Add(ListNode);
                            TAux.Add(ListNode.frase);
                        }
                        else
                        {
                            if (EsActions)
                            {
                                ListaActions.Add(ListNode);
                            }
                            else
                            {
                                if (EsErrors)
                                {
                                    ListaErrors.Add(ListNode);
                                }
                            }
                        }
                    }
                    contador++;
                }
            }
        }
        Node CreateNode(string cadena)
        {
            Elements elemento = new Elements();
            elemento.caracter = cadena;
            var TreeNode = new Node(elemento);
            return TreeNode;
        }
        Stack<Node> JuntarNodos(Node Aux, Stack<Node> PS)
        {
            Node AuxN = PS.Pop();
            Aux.hijoIZ = AuxN;
            PS.Push(Aux);
            return PS;
        }
        void PopPilaT(ref Stack<Node> PS, ref Stack<char> PT)
        {
            var caracterAux = ' ';
            while (caracterAux != '(' && PT.Count() != 0)
            {
                caracterAux = PT.Pop();
                if (caracterAux != '(')
                {
                    Node HD = PS.Pop();
                    Node HI = PS.Pop();
                    //
                    var Ref = string.Empty;
                    Ref += caracterAux;
                    var TreeSETSNode = CreateNode(Ref);
                    TreeSETSNode.hijoDR = HD;
                    TreeSETSNode.hijoIZ = HI;
                    PS.Push(TreeSETSNode);
                }
            }
        }
        public Node CreateTree(string ExpSets)
        {
            var T = "(.|+?*)";
            var PT = new Stack<char>();
            var PS = new Stack<Node>();
            foreach (char caracter in ExpSets)
            {
                if (!T.Contains(caracter))
                {
                    string carct = string.Empty;
                    carct += caracter;
                    var TreeSETSNode = CreateNode(carct);
                    PS.Push(TreeSETSNode);
                }
                else
                {
                    if (caracter == '(')
                    {
                        PT.Push(caracter);
                    }
                    else
                    {
                        if (caracter == ')')
                        {
                            PopPilaT(ref PS, ref PT);
                        }
                        else
                        {
                            if (caracter == '*' || caracter == '+' || caracter == '?')
                            {
                                var carct = string.Empty;
                                carct += caracter;
                                var TreeSETSNode = CreateNode(carct);
                                PS = JuntarNodos(TreeSETSNode, PS);
                            }
                            else
                            {
                                if (PT.Count() > 0)
                                {
                                    if ((PT.First() == '.' && caracter == '.') || (PT.First() == '|' && caracter == '|'))
                                    {
                                        var carct = ' ';
                                        carct = caracter;
                                        PoPPilaT(ref PS, ref PT, carct);
                                    }
                                    else
                                    {
                                        PT.Push(caracter);
                                    }
                                }
                                else
                                {
                                    PT.Push(caracter);
                                }
                            }
                        }
                    }
                }
            }
            if (PT.Count != 0)
            {
                PopPilaT(ref PS, ref PT);
            }
            return PS.Pop();
        }
        void PoPPilaT(ref Stack<Node> PS, ref Stack<char> PT, char Aux)
        {
            string Auxiliar = string.Empty;
            Auxiliar += PT.Pop();
            var TreeSETSNode = CreateNode(Auxiliar);
            Node HD = PS.Pop();
            Node HI = PS.Pop();
            TreeSETSNode.hijoDR = HD;
            TreeSETSNode.hijoIZ = HI;
            PS.Push(TreeSETSNode);
            PT.Push(Aux);
        }

        public Node CreateTreeP2(string Exp)
        {
            var T = "(.|+?*)";
            var PT = new Stack<char>();
            var PS = new Stack<Node>();
            var X = string.Empty;
            var contador = 0;
            var nuevo = "'";
            for (int i = 0; i < Exp.Length; i++)
            {
                if (Exp[i] == nuevo[0])
                {
                    contador++;
                }
                if (T.Contains(Exp[i]) && (contador % 2 == 0 || contador == 3))
                {
                    contador = 0;
                    if (X != string.Empty)
                    {
                        var carct = string.Empty;
                        carct += Exp[i];
                        var TreeSETSNode = CreateNode(X);
                        PS.Push(TreeSETSNode);
                        X = string.Empty;
                    }
                    if (Exp[i] == '(')
                    {
                        PT.Push(Exp[i]);
                    }
                    else
                    {
                        if (Exp[i] == ')')
                        {
                            PopPilaT(ref PS, ref PT);
                        }
                        else
                        {
                            if (Exp[i] == '*' || Exp[i] == '+' || Exp[i] == '?')
                            {
                                var carct = string.Empty;
                                carct += Exp[i];
                                var TreeSETSNode = CreateNode(carct);
                                PS = JuntarNodos(TreeSETSNode, PS);
                            }
                            else
                            {
                                if (PT.Count() > 0)
                                {
                                    while (PT.Count() > 0)
                                    {
                                        if ((PT.First() == '.' && Exp[i] == '.') || (PT.First() == '|' && Exp[i] == '|') || (PT.First() == '.' && Exp[i] == '|'))
                                        {
                                            var carcter = ' ';
                                            carcter = Exp[i];
                                            PoPPilaTP2(ref PS, ref PT, carcter);
                                        }
                                        else
                                        {
                                            PT.Push(Exp[i]);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    X += Exp[i];
                }
            }
            return PS.Pop();
        }
        void PoPPilaTP2(ref Stack<Node> PS, ref Stack<char> PT, char Aux)
        {
            string Auxiliar = string.Empty;
            Auxiliar += PT.Pop();
            var TreeSETSNode = CreateNode(Auxiliar);
            Node HD = PS.Pop();
            Node HI = PS.Pop();
            TreeSETSNode.hijoDR = HD;
            TreeSETSNode.hijoIZ = HI;
            PS.Push(TreeSETSNode);
        }
    }
}
