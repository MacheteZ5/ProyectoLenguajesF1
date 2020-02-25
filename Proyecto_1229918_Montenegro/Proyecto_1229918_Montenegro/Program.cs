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
            var E = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789_+-*/{}[]><.()&%$,\n\";=:";
            var z = "'E'..'E'";
            var w = "'E'";
            var y = "CHR(NN)";
            var x = "CHR(NN)..CHR(NNN)";
            var P = "+";
            //Terminologías Tokens
            var X = '"';
            var C = E + X;
            var H = "'C'";
            var K = "TOKEN";
            var G = " ";
            var A = "+*/()[]{}|?";
            //Terminologías ACTIONS
            var B = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            //Terminologías ERROR

            //Expresiones A utilizar
            //Expresión SETS
            var ExpSets = "((Q+.V*.=.V*).((z|w|x|y).P?)+).#";
            //EXpresión TOKENS
            var ExpTokens = "((K.V+.N+.V*.=.V*).(H|Q|A|G)+).#";
            //EXpresión Actions
            var ExpActions = "((N+.V*.=.V*).('.B+.')).#";
            //EXpresión Errors
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
            var error = false;
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
                    TreeSETS.RecorrerSets(TreeSETS.Raiz, TreeSETS.Raiz,TreeSETS.Raiz,encontrar,ref ListNode.frase, ref Continuar, Q,V,U,z,E,x,y,w,P,N);
                    if (Continuar == "NPC")
                    {
                        Console.WriteLine("La linea " + ListNode.Nlinea + " del texto contiene un error");
                        error = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("La linea " + ListNode.Nlinea + " del texto no contiene error");
                    }
                }
            }
            else
            {
                Console.WriteLine("Su texto, la linea 1, no posee bien escrito la palabra SETS o no la posee");
                Console.ReadLine();
            }
            if (error)
            {
                Console.ReadLine();
            }
            else
            {
                if (ListaTokens.Count() != 0)
                {
                    if (ListaActions.Count() != 0)
                    {
                        if (ListaTokens[0].Nlinea < ListaActions[0].Nlinea)
                        {
                            ListaTokens.Remove(ListaTokens[0]);
                            foreach (ListNode ListNode in ListaTokens)
                            {
                                var TreeTokens = new Tree();
                                TreeTokens.Raiz = nuevo.CreateTree(ExpTokens);
                                var encontrar = false;
                                var Continuar = string.Empty;
                                TreeTokens.RecorrerTokens(TreeTokens.Raiz, TreeTokens.Raiz, encontrar, ref ListNode.frase, ref Continuar,K,V,N,H,Q,A,G,C);
                                if (Continuar == "NPC")
                                {
                                    Console.WriteLine("La linea " + ListNode.Nlinea + " del texto contiene un error");
                                    error = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("La linea " + ListNode.Nlinea + " del texto no contiene error");
                                }
                            }
                            if (ListaActions[1].frase == "RESERVADAS()")
                            {
                                if(ListaActions[2].frase == "{")
                                {
                                    if (ListaActions.Last().frase == "}")
                                    {
                                        ListaActions.Remove(ListaActions[0]);
                                        ListaActions.Remove(ListaActions[0]);
                                        ListaActions.Remove(ListaActions[0]);
                                        ListaActions.Remove(ListaActions.Last());
                                        foreach (ListNode ListNode in ListaActions)
                                        {
                                            var TreeActions = new Tree();
                                            TreeActions.Raiz = nuevo.CreateTree(ExpActions);
                                            var encontrar = false;
                                            var Continuar = string.Empty;
                                            TreeActions.RecorrerActions(TreeActions.Raiz, TreeActions.Raiz, encontrar, ref ListNode.frase, ref Continuar, N,V,B);
                                            if (Continuar == "NPC")
                                            {
                                                Console.WriteLine("La linea " + ListNode.Nlinea + " del texto contiene un error");
                                                error = true;
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("La linea " + ListNode.Nlinea + " del texto no contiene error");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("El archivo no posee la llave final");
                                        Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("El archivo no posee la llave de inicio");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("El método no posee la frase RESERVADAS() o está mál escrito");
                                Console.ReadLine();
                            }

                        }
                        else
                        {
                            Console.WriteLine("El orden en el que está escrito su archivo está incorrecto");
                            Console.ReadLine();
                        }
                        if (error)
                        {
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("La palabra Actions no está escrita correctamente o su archivo no posee el método Actions");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("La palabra Tokens no está escrita correctamente o su Archivo no posee el método Tokens");
                    Console.ReadLine();
                }
            }
            Console.ReadKey();
        }
    }
}
