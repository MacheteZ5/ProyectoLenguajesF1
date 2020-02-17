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
            //terminologías
            var T0 = "*+?)";
            var T1 = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            var T2 = " +";
            var T3 = "0123456789";
            var T4 = "abcdefghijklmnñopqrstuvwxyz";
            var T5 = "'(T1|T3|T4)'..'(T1|T3|T4)' | '(T1|T3|T4)' | CHR(N)..CHR(N)";
            var T6 = "+";
            var T7 = "()";
            var ExpSets = "(T1+)(T2*)=(T5T6?+)";
            var ExpTokens = "";
            var ExpActions = "";
            var ExpErrors = "ERROR";
            //Listas
            var StringList = new List<string>();
            var ListaSets = new List<string>();
            var ListaTokens = new List<string>();
            var ListaActions = new List<string>();
            var ListaErrors = new List<string>();
            //Lectura de archivos en bytes 
            var File = Console.ReadLine();
            if (File[0] == '"')
            {
                File = File.Substring(1,(File.Count()-2));
            }
            AuxClass nuevo = new AuxClass();
            nuevo.LecturaArchivo(File,StringList,ref ListaSets,ref ListaTokens, ref ListaActions, ref ListaErrors);
            //Validar SETS
            if(ListaSets.Count()!=0)
            {
                //crear arbol de incersión SETS
                //Ingresar Al árbol Set
                var TreeSETS = new Tree();
                var chain = string.Empty;
                var entreparentesis = false;
                foreach (char bit in ExpSets)
                {
                    if((bit == '(')||(entreparentesis))
                    {
                        entreparentesis = true;
                        chain += bit; 
                    }
                    if(bit == ')')
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
            }
            if(!(10==-10))
            {
                int x = 0;
            }
            else
            {
                int x = 0;
            }
            //empezar a validar linea por línea de ejecución
        }
        
    }
}
