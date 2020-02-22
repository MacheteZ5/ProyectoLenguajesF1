using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Proyecto_1229918_Montenegro
{
    class Program
    {
        static void Main(string[] args)
        {
            //terminologías que se van a utilizar
            //Terminologias SETS
            var Q = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            var V = ' ';
            var U = "'";
            var N = "0123456789";
            var E = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789_+-*/";
            var z = "'E'..'E'";
            var w = "'E'";
            var y = "CHR(N)";
            var x = "CHR(NN)..CHR(NNN)";
            var P = "+";
            //Terminologías Tokens
            //Terminologías ACTIONS
            //Terminologías ERROR
            var T6 = ".";
            var T7 = "TOKEN";
            //Expresiones A utilizar
            //Expresión SETS
            var ExpSets = "((Q+.V*.=.V*).((z|w|x|y).P?)+).#";
            //EXpresión TOKENS
            var ExpTokens = "";
            var ExpActions = "";
            var ExpErrors = "";
            //Listas
            var StringList = new List<string>();
            var ListaSets = new List<ListNode>();
            var ListaTokens = new List<ListNode>();
            var ListaActions = new List<ListNode>();
            var ListaErrors = new List<ListNode>();
            //Lectura de archivos en bytes 
            var File = Console.ReadLine();
            if (File[0] == '"')
            {
                File = File.Substring(1,(File.Count()-2));
            }
            AuxClass nuevo = new AuxClass();
            nuevo.LecturaArchivo(File,StringList,ref ListaSets,ref ListaTokens, ref ListaActions, ref ListaErrors);
            if (ListaSets.Count() != 0)
            {
                //crear Arbol de expresion
                ListaSets.Remove(ListaSets[0]);
                foreach (ListNode ListNode in ListaSets)
                {
                    var Continuar = string.Empty;
                    var TreeSETS = new Tree();
                    var encontrar = false;
                    TreeSETS.Raiz = nuevo.CreateTree(ExpSets);
                    TreeSETS.RecorrerSets(TreeSETS.Raiz, TreeSETS.Raiz,TreeSETS.Raiz,encontrar,ref ListNode.frase, ref Continuar, Q,V,U,z,E,x,y,w,P);
                    if (Continuar == "NPC")
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Su texto, la linea 1, no posee bien escrito la palabra SETS o no la posee");
                Console.ReadLine();
            }
            if (ListaTokens.Count()!=0)
            {
                ListaTokens.Remove(ListaTokens[0]);
                foreach (ListNode ListNode in ListaTokens)
                {
                    //var TreeTokens = nuevo.CreaciónArbol(ExpTokens);
                    var contador = 0;
                    var Auxchain = string.Empty;
                    var NoEncontrado = string.Empty;
                    foreach (char caracter in ListNode.frase)
                    {
                        if(caracter==' '&& contador ==0)
                        {
                            var chains = string.Empty;
                            NoEncontrado = string.Empty;
                            //TreeTokens.RecorrerTokens(TreeTokens.Raiz, chains, ref NoEncontrado, caracter, T7, Auxchain,T2);
                            if(NoEncontrado== "CadenaError")
                            {
                                Console.WriteLine("Su Linea: "+ListNode.Nlinea+" Posee un error");
                                Console.ReadLine();
                                break;
                            }
                            NoEncontrado = string.Empty;
                            Auxchain = string.Empty;
                           // TreeTokens.RecorrerTokens(TreeTokens.Raiz, chains, ref NoEncontrado, caracter, T7, Auxchain,T2);
                            contador++;
                        }
                        else
                        {
                            if(contador>0)
                            {
                                var chains = string.Empty;
                                NoEncontrado = string.Empty;
                             //   TreeTokens.RecorrerTokens(TreeTokens.Raiz, chains, ref NoEncontrado, caracter, T7, Auxchain,T2);
                            }
                        }
                        Auxchain += caracter;
                    }
                    if (NoEncontrado == "CadenaError")
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("La palabra Tokens no está escrita correctamente");
                Console.ReadLine();
            }
        }
    }
}
