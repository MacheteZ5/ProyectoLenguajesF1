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
    }
}
