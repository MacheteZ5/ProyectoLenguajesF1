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
            var A = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            var B = ' ';
            var C = "'E'..'E'";
            var D = "'E'";
            var E = string.Empty;
            for (int po = 0; po < 256; po++)
            {
                E += Convert.ToChar(Convert.ToByte(po));
            }
            var F = "CHR(N)";
            var G = "CHR(NN)";
            var H = "CHR(NNN)";
            var J = "CHR(N)..CHR(N)";
            var L = "CHR(N)..CHR(NN)";
            var M = "CHR(N)..CHR(NNN)";
            var N = "0123456789";
            var Ñ = "CHR(NN)..CHR(N)";
            var O = "CHR(NN)..CHR(NN)";
            var Q = "CHR(NN)..CHR(NNN)";
            var R = "CHR(NNN)..CHR(N)";
            var S = "CHR(NNN)..CHR(NN)";
            var T = "CHR(NNN)..CHR(NNN)";
            var P = "+";
            //Terminologías Tokens
            var X = '"';
            var I = E + X;
            var U = "'I'";
            var K = "TOKEN";
            var V = " ";
            var W = "+*/()[]{}|?";
            //Expresiones A utilizar
            //Expresión SETS
            var ExpSets = "((A+.B*.=.B*).((C|D|J|L|M|Ñ|O|Q|R|S|T|H|F|G).B*.P?.B*)+).#";
            //EXpresión TOKENS
            var ExpTokens = "((K.B+.N+.B*.=.B*).(U|A|B|W)+).#";
            //EXpresión Actions
            var ExpActions = "(N+.B*.=.B*.'.A+.').#";
            //EXpresión Errors
            var ExpErrors = "(A+.B*.=.B*.N+).#";
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
                File = File.Substring(1, (File.Count() - 2));
            }
            //verificar archivo
            if (File[File.Length - 1] =='t'&& File[File.Length - 2] == 'x'&& File[File.Length - 3] == 't'&& File[File.Length - 4] == '.')
            {
                AuxClass nuevo = new AuxClass();
                nuevo.LecturaArchivo(File, StringList, ref ListaSets, ref ListaTokens, ref ListaActions, ref ListaErrors);
                var error = false;
                var cantidad = 0;
                if (ListaSets.Count() != 0)
                {
                    // crear Arbol de expresion
                    ListaSets.Remove(ListaSets[0]);
                    foreach (ListNode ListNode in ListaSets)
                    {
                        cantidad = 0;
                        var Continuar = string.Empty;
                        var TreeSETS = new Tree();
                        var encontrar = false;
                        TreeSETS.Raiz = nuevo.CreateTree(ExpSets);
                        TreeSETS.RecorrerSets(TreeSETS.Raiz, TreeSETS.Raiz, TreeSETS.Raiz, encontrar, ref ListNode.frase, ref Continuar, A, B, C, D, E, F, G, H, J, L, M, N, Ñ, O, Q, R, S, T, P, ref cantidad);
                        if (Continuar == "NPC" || cantidad == 0)
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
                                    cantidad = 0;
                                    var TreeTokens = new Tree();
                                    TreeTokens.Raiz = nuevo.CreateTree(ExpTokens);
                                    var encontrar = false;
                                    var Continuar = string.Empty;
                                    var contp = 0;
                                    var contll = 0;
                                    TreeTokens.RecorrerTokens(TreeTokens.Raiz, TreeTokens.Raiz, encontrar, ref ListNode.frase, ref Continuar, K, B, N, U, A, W, I, V, ref cantidad, ref contp, ref contll);
                                    if (Continuar == "NPC" || cantidad == 0||contp%2!=0||contll%2!=0)
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
                                if (error)
                                {
                                    Console.ReadLine();
                                }
                                else
                                {
                                    ListaActions.Remove(ListaActions[0]);
                                    var Reservadas = false;
                                    foreach (ListNode ListNode in ListaActions)
                                    {
                                        if (!Reservadas)
                                            Reservadas = (ListNode.frase.Contains("RESERVADAS()")) ? true : false;
                                    }
                                    if (Reservadas)
                                    {
                                        if(ListaActions[ListaActions.Count()-1].frase=="}")
                                        {
                                            while (ListaActions.Count() != 0)
                                            {
                                                if (ListaActions[0].frase.Contains("()") && ListaActions[1].frase.Contains("{"))
                                                {
                                                    ListaActions.Remove(ListaActions[0]);
                                                    ListaActions.Remove(ListaActions[0]);
                                                    foreach (ListNode ListNode in ListaActions)
                                                    {
                                                        if (ListNode.frase == "}")
                                                        {
                                                            var net = new ListNode();
                                                            net = ListNode;
                                                            ListaActions.Remove(net);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            cantidad = 0;
                                                            var TreeActions = new Tree();
                                                            TreeActions.Raiz = nuevo.CreateTree(ExpActions);
                                                            var encontrar = false;
                                                            var Continuar = string.Empty;
                                                            TreeActions.RecorrerActions(TreeActions.Raiz, TreeActions.Raiz, encontrar, ref ListNode.frase, ref Continuar, N, B, A, ref cantidad);
                                                            if (Continuar == "NPC" || cantidad < 2)
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
                                                    if (error)
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        var límite = ListaActions.Count();
                                                        for (int i = 0; i < límite; i++)
                                                        {
                                                            if (ListaActions[0].frase == "")
                                                            {
                                                                ListaActions.Remove(ListaActions[0]);
                                                            }
                                                            else
                                                            {
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("El archivo no posee la llave de inicio o no está bien escrita la funcion");
                                                    Console.ReadLine();
                                                    error = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("El archivo no posee la llave de final o su método Error está mal");
                                            Console.ReadLine();
                                            error = true;
                                        }
                                        if (error)
                                        {
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            if (ListaErrors.Count() != 0)
                                            {
                                                foreach (ListNode ListNode in ListaErrors)
                                                {
                                                    cantidad = 0;
                                                    var TreeErrors = new Tree();
                                                    TreeErrors.Raiz = nuevo.CreateTree(ExpErrors);
                                                    var encontrar = false;
                                                    var Continuar = string.Empty;
                                                    TreeErrors.RecorrerErrors(TreeErrors.Raiz, TreeErrors.Raiz, encontrar, ref ListNode.frase, ref Continuar, A, B, N, ref cantidad);
                                                    if (Continuar == "NPC" || cantidad < 1)
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
                                                if (error)
                                                {
                                                    Console.ReadLine();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Su archivo no contiene ningún error");
                                                    Console.ReadLine();
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("El archivo no contiene ningún método de ERROR");
                                                Console.ReadLine();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("El método no posee la frase RESERVADAS() o está mál escrito");
                                        Console.ReadLine();
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("El orden en el que está escrito su archivo está incorrecto");
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
            }
            else
            {
                Console.WriteLine("El archivo que ingresó no es un archivo de texto");
                Console.ReadLine();
            }
        }        
    }
}