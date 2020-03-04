using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1229918_Montenegro
{
    public class AuxClass
    {
        //desde aquí
        public void LecturaArchivo(string File, List<string> StringList, ref List<ListNode> ListaSets, ref List<ListNode> ListaTokens, ref List<ListNode> ListaActions, ref List<ListNode> ListaErrors, ref bool sets)
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
                    }
                    else
                    {
                        if (EsTokens)
                        {
                            ListaTokens.Add(ListNode);
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
            while (caracterAux != '('&&PT.Count()!=0)
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
                            if (caracter == '*' || caracter == '+'|| caracter == '?')
                            {
                                var carct = string.Empty;
                                carct += caracter;
                                var TreeSETSNode = CreateNode(carct);
                                PS = JuntarNodos(TreeSETSNode, PS);
                            }
                            else
                            {
                                if (PT.Count()>0)
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
    }
}
