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
        public void RecorrerSets(Node NodoActual,Node raiz,Node PadreAux, bool encontrar,  ref string frase, ref string Continuar, string Q,char V,string U,string z,string E,string x, string y, string w,string P)
        {
            if(NodoActual == null)
            {
                return;
            }
            RecorrerSets(NodoActual.hijoIZ,raiz, PadreAux,encontrar, ref frase, ref Continuar,Q,V,U,z,E,x,y,w,P);
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
                                    encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], Q, V, ref z, E,ref w,ref y,ref x,P);
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
                            encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], Q, V,ref z,E,ref w,ref y,ref x,P);
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
                            encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], Q, V,ref z,E,ref w,ref y,ref x,P);
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
                                encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], Q, V, ref z, E,ref w,ref y,ref x,P);
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
                            Continuar = (z.Length == 0||w.Length==0|| x.Length == 0 || y.Length == 0) ? "PCSP" : "NPC";
                            if (Continuar == "NPC")
                            {
                                frase = Aux + frase;
                                Continuar = "PC";
                            }
                        }
                        break;
                    case "?":
                        encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], Q, V, ref z, E,ref w,ref y,ref x,P);
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
                RecorrerSets(NodoActual.hijoDR,raiz, PadreAux, encontrar, ref frase, ref Continuar, Q,V,U,z,E,x,y,w,P);
                if (NodoActual.elemento.caracter == "+" && frase.Length != 0 && NodoActual.hijoIZ.elemento.caracter==".")
                {
                    while (frase.Length!=0)
                    {
                        RecorrerSets(NodoActual.hijoIZ, raiz, PadreAux, encontrar, ref frase, ref Continuar, Q, V, U, z, E, x, y, w, P);
                    }
                }
            }
            else
            {
                return;
            }            
        }
        //Encontrar Su padre
        public void EncontrarPadre(Node NodoActual, Node Padre,ref Node PadreAux, ref bool P)
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
        public bool EncontrarCaracterAux(string cadena, char caracter, string Q, char V,ref string z,string E,ref string w,ref string y,ref string x,string P)
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
                        if (y[0] == 'E')
                        {
                            encontrado = E.Contains(caracter) ? true : false;
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
                        if (x[0] == 'E')
                        {
                            encontrado = E.Contains(caracter) ? true : false;
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
        public void RecorrerTokens(Node NodoActual, string chain, ref string NoEncontrado, char caracter, string T7,string Auxchain, char T2)
        {
            if (NodoActual == null)
            {
                return;
            }
            RecorrerTokens(NodoActual.hijoIZ, chain, ref NoEncontrado, caracter, T7,  Auxchain, T2);
            //Eliminar el nodo anterior si ya no se está eliminando
            if (NoEncontrado == "NoSeEncuentra")
            {
                NodoActual.hijoIZ = null;
            }
            //verificar en el nodo si se encuentra o no
            if (NoEncontrado != "Encontrado")
            {
                if (NodoActual.elemento.caracter != ".")
                {
                    if (NoEncontrado == "NoSeEncuentra")
                    {
                        NoEncontrado = EncontrarTokens(NodoActual, chain, NoEncontrado, caracter, T7, Auxchain, T2);
                        if (NoEncontrado == "NoSeEncuentra")
                        {
                            NoEncontrado = "CadenaError";
                        }
                    }
                    else
                    {
                        NoEncontrado = EncontrarTokens(NodoActual, chain, NoEncontrado, caracter, T7, Auxchain, T2);
                    }
                }
            }
            if (NoEncontrado == "NoSeEncuentra" || NoEncontrado == "")
            {
                chain = string.Empty;
                RecorrerTokens(NodoActual.hijoDR, chain, ref NoEncontrado, caracter, T7, Auxchain,T2);
            }
            else
            {
                return;
            }
        }
        string EncontrarTokens(Node NodoActual, string chain, string NoEncontrado, char caracter, string T7, string AuxChain, char T2)
        {
            foreach (char car in NodoActual.elemento.caracter)
            {
                chain += car;
                switch (chain)
                {
                    case "T7":
                        NoEncontrado = AuxChain=="TOKEN" ? "Encontrado" : "NoSeEncuentra";
                        chain = string.Empty;
                    break;
                    case "T2":
                        NoEncontrado = T2.Equals(caracter) ? "Encontrado" : "NoSeEncuentra";
                        chain = string.Empty;
                        break;
                    
                }
            }
            return NoEncontrado;
        }
    }
}
