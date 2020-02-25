using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1229918_Montenegro
{
    public struct Elements
    {
        public string caracter;
    }
    public class Node        
    {
        public Elements elemento;
        public Node hijoIZ;
        public Node hijoDR;
        public Node(Elements elementos)
        {
            elemento = elementos;
            hijoIZ = null;
            hijoDR = null;
        }
    }
    public class Tree
    {
        public Node Raiz;
        //Método para Sets
        public void RecorrerSets(Node NodoActual,Node raiz,Node PadreAux, bool encontrar,  ref string frase, ref string Continuar, string Q,char V,string U,string z,string E,string x, string y, string w,string P, string N)
        {
            if(NodoActual == null)
            {
                return;
            }
            RecorrerSets(NodoActual.hijoIZ,raiz, PadreAux,encontrar, ref frase, ref Continuar,Q,V,U,z,E,x,y,w,P,N);
            //Encontrar Padre
            var R = false;
            EncontrarPadre(NodoActual, raiz,ref PadreAux, ref R);
            var contador = 0;
            if (frase.Length != 0)
            {
                switch (PadreAux.elemento.caracter)
                {
                    case "+":
                        if (frase.Length != 0)
                        {
                            if (PadreAux.hijoIZ.elemento.caracter == "." && Continuar == "PCSP")
                            {
                                //No va a pasar nada 
                            }
                            else
                            {
                                do
                                {
                                    encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], Q, V, ref z, E,ref w,ref y,ref x,P,N);
                                    if (encontrar == true)
                                    {
                                        frase = frase.Substring(1);
                                        contador++;
                                    }
                                }
                                while (encontrar == true);
                                Continuar = (contador >= 1) ? "PC" : "NPC";
                            }
                        }
                        break;
                    case "*":
                        do
                        {
                            encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], Q, V,ref z,E,ref w,ref y,ref x,P,N);
                            if (encontrar)
                            {
                                frase = frase.Substring(1);
                                contador++;
                            }
                        }
                        while (encontrar == true);
                        Continuar = (contador >= 0) ? "PC" : "NPC";
                        break;
                    case ".":
                        if (NodoActual.elemento.caracter == "=")
                        {
                            encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], Q, V,ref z,E,ref w,ref y,ref x,P,N);
                            if (encontrar)
                            {
                                frase = frase.Substring(1);
                                contador++;
                            }
                            Continuar = (contador == 1) ? "PC" : "NPC";
                        }
                        break;
                    case "|":
                        if (Continuar!= "PCSP"&&NodoActual.elemento.caracter!="|")
                        {
                            var Aux = string.Empty;
                            do
                            {
                                if (z.Length != 0 && w.Length != 0 && x.Length != 0 && y.Length != 0)
                                {
                                    encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], Q, V, ref z, E, ref w, ref y, ref x, P, N);
                                }
                                else
                                {
                                    if (frase==string.Empty)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        if (frase[0]!='+')
                                        {
                                            encontrar = false;
                                            break;
                                        }
                                    }
                                }
                                if (encontrar)
                                {
                                    Aux += frase[0];
                                    frase = frase.Substring(1);
                                }
                                if(frase.Length == 0)
                                {
                                    break;
                                }
                            }
                            while (encontrar == true&&frase[0]!='+');
                            Continuar = ((z.Length == 0||w.Length==0|| x.Length == 0 || y.Length == 0)) ? "PCSP" : "NPC";
                            if (Continuar == "NPC"&&NodoActual.elemento.caracter!="y")
                            {
                                frase = Aux + frase;
                                Continuar = "PC";
                            }
                        }
                        break;
                    case "?":
                        encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], Q, V, ref z, E,ref w,ref y,ref x,P,N);
                        if (encontrar)
                        {
                            frase = frase.Substring(1);
                            contador++;
                        }
                        Continuar = (contador >= 0) ? "PC" : "NPC";
                        break;
                }
            }
            else
            {
                return;
            }
            if (Continuar == "PC"||Continuar== "PCSP")
            {
                RecorrerSets(NodoActual.hijoDR,raiz, PadreAux, encontrar, ref frase, ref Continuar, Q,V,U,z,E,x,y,w,P,N);
                if (NodoActual.elemento.caracter == "+" && frase.Length != 0 && NodoActual.hijoIZ.elemento.caracter==".")
                {
                    while (frase.Length!=0&&(Continuar =="PC"||Continuar == "PCSP"))
                    {
                        RecorrerSets(NodoActual.hijoIZ, raiz, PadreAux, encontrar, ref frase, ref Continuar, Q, V, U, z, E, x, y, w, P,N);
                    }
                }
            }
            else
            {
                return;
            }            
        }
        private void EncontrarPadre(Node NodoActual, Node Padre,ref Node PadreAux, ref bool P)
        {
            if (Padre == null)
            {
                return;
            }
            EncontrarPadre(NodoActual, Padre.hijoIZ,ref PadreAux, ref P);
            if (Padre.hijoIZ == NodoActual || Padre.hijoDR==NodoActual)
            {
                PadreAux = Padre;
                P = true;
            }
            if (!P)
            {
                EncontrarPadre(NodoActual, Padre.hijoDR,ref PadreAux, ref P);
            }
            else
            {
                return;
            }
        }
        private bool EncontrarCaracterAux(string cadena, char caracter, string Q, char V,ref string z,string E,ref string w,ref string y,ref string x,string P,string N)
        {
            var encontrado = false; 
            switch (cadena)
            {
                case "Q":
                    encontrado = Q.Contains(caracter) ? true : false;
                    break;
                case "V":
                    encontrado = V.Equals(caracter) ? true : false;
                    break;
                case "=":
                    encontrado = ('='==caracter) ? true : false;
                    break;
                case "z":
                    encontrado = z[0]==caracter ? true : false;
                    if (encontrado)
                    {
                        z = z.Substring(1);
                    }
                    else
                    {
                        if (z[0] == 'E')
                        {
                            encontrado = E.Contains(caracter) ? true : false;
                            z = z.Substring(1);
                        }
                    }
                    break;
                case "w":
                        encontrado = w[0] == caracter ? true : false;
                        if (encontrado)
                        {
                            w = w.Substring(1);
                        }
                        else
                        {
                            if (w[0] == 'E')
                            {
                                encontrado = E.Contains(caracter) ? true : false;
                                w = w.Substring(1);
                            }
                        }
                    break;
                case "y":
                    encontrado = y[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        y = y.Substring(1);
                    }
                    else
                    {
                        if (y[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            y = y.Substring(1);
                        }
                    }
                    break;
                case "x":
                    encontrado = x[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        x = x.Substring(1);
                    }
                    else
                    {
                        if (x[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            x = x.Substring(1);
                        }
                    }
                    break;
                case "P":
                    encontrado = P.Contains(caracter) ? true : false;
                    break;
            }
            return encontrado;
        }
        //Métodos para tokens
        public void RecorrerTokens(Node NodoActual, Node PadreAux, bool encontrar, ref string frase, ref string Continuar,string K,char V,string N,string H, string Q, string A,string G,string C)
        {
            if (NodoActual == null)
            {
                return;
            }
            RecorrerTokens(NodoActual.hijoIZ, PadreAux, encontrar, ref frase, ref Continuar,K,V,N,H,Q,A,G,C);
            var R = false;
            EncontrarPadreTokens(NodoActual, Raiz, ref PadreAux, ref R);
            var contador = 0;
            if (frase.Length != 0)
            {
                switch (PadreAux.elemento.caracter)
                {
                    case ".":
                        if(NodoActual.elemento.caracter=="K")
                        {
                            do
                            {
                                if (K != string.Empty)
                                {
                                    encontrar = EncontrarCaracterAuxTokens(NodoActual.elemento.caracter, frase[0], K,V,N,ref H,Q,A,G,C);
                                }
                                else
                                {
                                    break;
                                }
                                if (encontrar)
                                {
                                    frase = frase.Substring(1);
                                    K = K.Substring(1);
                                    contador++;
                                }
                            }
                            while (encontrar == true);
                            Continuar = (contador == 5) ? "PC" : "NPC";
                        }
                        else
                        {
                            if(NodoActual.elemento.caracter == "=")
                            {
                                encontrar = EncontrarCaracterAuxTokens(NodoActual.elemento.caracter, frase[0], K,V,N,ref H,Q,A,G,C);
                                if (encontrar)
                                {
                                    frase = frase.Substring(1);
                                    contador++;
                                }
                                Continuar = (contador == 1) ? "PC" : "NPC";
                            }
                        }
                        break;
                    case "+":
                        if (NodoActual.elemento.caracter != "|")
                        {
                            do
                            {
                                encontrar = EncontrarCaracterAuxTokens(NodoActual.elemento.caracter, frase[0], K, V, N, ref H, Q, A, G, C);
                                if (encontrar)
                                {
                                    frase = frase.Substring(1);
                                    contador++;
                                }
                            }
                            while (encontrar == true);
                            Continuar = (contador >= 1) ? "PC" : "NPC";
                        }
                        break;
                    case "*":
                        do
                        {
                            encontrar = EncontrarCaracterAuxTokens(NodoActual.elemento.caracter, frase[0], K,V,N,ref H,Q,A,G,C);
                            if (encontrar)
                            {
                                frase = frase.Substring(1);
                                contador++;
                            }
                        }
                        while (encontrar == true);
                        Continuar = (contador >= 0) ? "PC" : "NPC";
                        break;
                    case "|":
                        if (NodoActual.elemento.caracter != "|")
                        {
                            var Aux = string.Empty;
                            if (NodoActual.elemento.caracter == "H")
                            {
                                do
                                {
                                    if (H.Length != 0)
                                    {
                                        encontrar = EncontrarCaracterAuxTokens(NodoActual.elemento.caracter, frase[0], K, V, N, ref H, Q, A, G, C);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                    if (encontrar)
                                    {
                                        Aux += frase[0];
                                        frase = frase.Substring(1);
                                        contador++;
                                    }
                                    if (frase.Length == 0)
                                    {
                                        break;
                                    }
                                }
                                while (encontrar == true && H.Length != 0);
                                Continuar = ((H.Length == 0)) ? "PCSP" : "NPC";
                            }
                            else
                            {
                                if (Continuar != "PCSP")
                                {
                                    do
                                    {
                                        encontrar = EncontrarCaracterAuxTokens(NodoActual.elemento.caracter, frase[0], K, V, N, ref H, Q, A, G, C);
                                        if (encontrar)
                                        {
                                            Aux += frase[0];
                                            frase = frase.Substring(1);
                                            contador++;
                                        }
                                        if (frase.Length == 0)
                                        {
                                            break;
                                        }
                                    }
                                    while (encontrar == true);
                                    Continuar = ((contador >= 1)) ? "PCSP" : "NPC";
                                }
                            }
                            if (Continuar == "NPC" && NodoActual.elemento.caracter != "G")
                            {
                                frase = Aux + frase;
                                Continuar = "PC";
                            }
                        }
                        break;
                }
            }
            if (Continuar=="PC"||Continuar=="PCSP")
            {
                RecorrerTokens(NodoActual.hijoDR, PadreAux, encontrar, ref frase, ref Continuar,K,V,N,H,Q,A,G,C);
                if (NodoActual.elemento.caracter == "+" && frase.Length != 0 && NodoActual.hijoIZ.elemento.caracter == "|")
                {
                    while (frase.Length != 0 && (Continuar == "PC" || Continuar == "PCSP"))
                    {
                        RecorrerTokens(NodoActual.hijoIZ, PadreAux, encontrar, ref frase, ref Continuar, K, V, N, H, Q, A, G, C);
                    }
                }
            }
            else
            {
                return;
            }
        }
        private void EncontrarPadreTokens(Node NodoActual, Node Padre, ref Node PadreAux, ref bool P)
        {
            if (Padre == null)
            {
                return;
            }
            EncontrarPadreTokens(NodoActual, Padre.hijoIZ, ref PadreAux, ref P);
            if (Padre.hijoIZ == NodoActual || Padre.hijoDR == NodoActual)
            {
                PadreAux = Padre;
                P = true;
            }
            if (!P)
            {
                EncontrarPadreTokens(NodoActual, Padre.hijoDR, ref PadreAux, ref P);
            }
            else
            {
                return;
            }
        }
        private bool EncontrarCaracterAuxTokens(string cadena, char caracter, string K,char V,string N,ref string H, string Q, string A,string G,string C)
        {
            var encontrado = false;
            switch (cadena)
            {
                case "K":
                    encontrado = (K[0]==caracter) ? true : false;
                    break;
                case "V":
                    encontrado = V.Equals(caracter) ? true : false;
                    break;
                case "N":
                    encontrado = N.Contains(caracter) ? true : false;
                    break;
                case "=":
                    encontrado = ('=' == caracter) ? true : false;
                    break;
                case "H":
                    encontrado = H.Contains(caracter) ? true : false;
                    if (encontrado)
                    {
                        H = H.Substring(1);
                    }
                    else
                    {
                        if (H[0] == 'C')
                        {
                            encontrado = C.Contains(caracter) ? true : false;
                            H = H.Substring(1);
                        }
                    }
                    break;
                case "Q":
                    encontrado = Q.Contains(caracter) ? true : false;
                    break;
                case "A":
                    encontrado = A.Contains(caracter) ? true : false;
                    break;
                case "G":
                    encontrado = G.Contains(caracter) ? true : false;
                    break;
            }
            return encontrado;
        }
        //Métodos para Actions
        public void RecorrerActions(Node NodoActual, Node PadreAux, bool encontrar, ref string frase, ref string Continuar,string N,char V,string B)
        {
            if (NodoActual == null)
            {
                return;
            }
            RecorrerActions(NodoActual.hijoIZ, PadreAux, encontrar, ref frase, ref Continuar,N,V,B);
            var R = false;
            EncontrarPadreActions(NodoActual, Raiz, ref PadreAux, ref R);
            var contador = 0;
            if (frase.Length != 0)
            {
                switch (PadreAux.elemento.caracter)
                {
                    case ".":
                        if (NodoActual.elemento.caracter == "="|| NodoActual.elemento.caracter == "'")
                        {
                            encontrar = EncontrarCaracterAuxActions(NodoActual.elemento.caracter, frase[0],N,V,B);
                            if (encontrar)
                            {
                                frase = frase.Substring(1);
                                contador++;
                            }
                            Continuar = (contador == 1) ? "PC" : "NPC";
                        }
                        break;
                    case "+":
                            do
                            {
                                encontrar = EncontrarCaracterAuxActions(NodoActual.elemento.caracter, frase[0],N,V,B);
                                if (encontrar)
                                {
                                    frase = frase.Substring(1);
                                    contador++;
                                }
                            }
                            while (encontrar == true);
                            Continuar = (contador >= 1) ? "PC" : "NPC";
                        break;
                    case "*":
                        do
                        {
                            encontrar = EncontrarCaracterAuxActions(NodoActual.elemento.caracter, frase[0],N,V,B);
                            if (encontrar)
                            {
                                frase = frase.Substring(1);
                                contador++;
                            }
                        }
                        while (encontrar == true);
                        Continuar = (contador >= 0) ? "PC" : "NPC";
                        break;
                }
            }
            if (Continuar == "PC" || Continuar == "PCSP")
            {
                RecorrerActions(NodoActual.hijoDR, PadreAux, encontrar, ref frase, ref Continuar,N,V,B);
                if (NodoActual.elemento.caracter == "+" && frase.Length != 0 && NodoActual.hijoIZ.elemento.caracter == "|")
                {
                    while (frase.Length != 0 && (Continuar == "PC" || Continuar == "PCSP"))
                    {
                        RecorrerActions(NodoActual.hijoIZ, PadreAux, encontrar, ref frase, ref Continuar,N,V,B);
                    }
                }
            }
            else
            {
                return;
            }
        }
        private void EncontrarPadreActions(Node NodoActual, Node Padre, ref Node PadreAux, ref bool P)
        {
            if (Padre == null)
            {
                return;
            }
            EncontrarPadreActions(NodoActual, Padre.hijoIZ, ref PadreAux, ref P);
            if (Padre.hijoIZ == NodoActual || Padre.hijoDR == NodoActual)
            {
                PadreAux = Padre;
                P = true;
            }
            if (!P)
            {
                EncontrarPadreActions(NodoActual, Padre.hijoDR, ref PadreAux, ref P);
            }
            else
            {
                return;
            }
        }
        private bool EncontrarCaracterAuxActions(string cadena, char caracter,string N,char V,string B)
        {
            var encontrado = false;
            switch (cadena)
            {
                case "N":
                    encontrado = (N.Contains(caracter)) ? true : false;
                    break;
                case "V":
                    encontrado = (V.Equals(caracter)) ? true : false;
                    break;
                case "=":
                    encontrado = ('=' == caracter) ? true : false;
                    break;
                case "'":
                    encontrado = ("'".Contains(caracter)) ? true : false;
                    break;
                case "B":
                    encontrado = (B.Contains(caracter)) ? true : false;
                    break;
            }
            return encontrado;
        }
    }
}
