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
        public void LecturaArchivo(string File, List<string> StringList, ref List<ListNode> ListaSets, ref List<ListNode> ListaTokens, ref List<ListNode> ListaActions, ref List<ListNode> ListaErrors)
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
        public Tree CreaciónArbol(string ExpSets)
        {
            var TreeSETS = new Tree();
            var chain = string.Empty;
            var entreparentesis = false;
            foreach (char bit in ExpSets)
            {
                if ((bit == '(') || (entreparentesis))
                {
                    entreparentesis = true;
                    chain += bit;
                }
                if (bit == ')')
                {
                    char[] Aux = { '(', ')' };
                    chain = chain.Trim(Aux);
                    Elements elemento = new Elements();
                    elemento.caracter = chain;
                    Node NAux = new Node(elemento);
                    TreeSETS.Ingresar(NAux);
                    entreparentesis = false;
                    chain = string.Empty;
                }
            }
            return TreeSETS;
        }

        public Tree Crear(string EXP)
        {
            var TreeSETS = new Tree();
            var Pila = new Stack<string>();
            var Encontrar = false;
            var cadena = string.Empty;
            foreach(char car in EXP)
            {
                if (car =='(')
                {
                    Encontrar = true;
                }
                if(Encontrar&&car!='(')
                {
                    cadena += car;
                }
                else
                {
                }
            }
            return TreeSETS;
        }
        //desde aquí
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
            var T = "(.|";
            var S = "+?*";
            var PT = new Stack<char>();
            var PS = new Stack<Node>();
            foreach (char caracter in ExpSets)
            {
                if (T.Contains(caracter))
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
                        if (S.Contains(caracter))
                        {
                            var carct = string.Empty;
                            carct += caracter;
                            var TreeSETSNode = CreateNode(carct);
                            PS = JuntarNodos(TreeSETSNode, PS);
                        }
                        else
                        {
                            string carct = string.Empty;
                            carct += caracter;
                            var TreeSETSNode = CreateNode(carct);
                            PS.Push(TreeSETSNode);
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
    }
}
