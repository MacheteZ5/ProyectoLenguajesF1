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
        
        public void Ingresar(Node valor)
        {
            if(Raiz == null)
            {
                Elements elemento = new Elements();
                elemento.caracter = ".";
                Node NRaiz = new Node(elemento);
                NRaiz.hijoIZ = valor;
                Raiz = NRaiz;
            }
            else
            {
                IngresarAux(valor);
                
            }
        }
        void IngresarAux(Node Value)
        {
            Node VAux = new Node(Value.elemento);
            if (Raiz.hijoDR == null)
            {
                Raiz.hijoDR = VAux;
            }
            else
            {
                Elements elemento = new Elements();
                elemento.caracter = ".";
                Node NRaiz = new Node(elemento);
                NRaiz.hijoIZ = Raiz;
                NRaiz.hijoDR = VAux;
                Raiz = NRaiz;
            }
        }
        public void RecorrerSets(Node NodoActual, string chain, ref string NoEncontrado, char caracter, string T1, char T2, string T3, string T4, string T5,ref string CAUT5yT6)
        {
            if (NodoActual == null)
            {
                return;
            }
            RecorrerSets(NodoActual.hijoIZ, chain, ref NoEncontrado,caracter,T1, T2,T3,T4,T5, ref CAUT5yT6);
            //Eliminar el nodo anterior si ya no se está eliminando
            if (NoEncontrado == "NoSeEncuentra")
            {
                NodoActual.hijoIZ = null;
            }
            //verificar en el nodo si se encuentra o no
            if (NoEncontrado!="Encontrado")
            {
                if(NodoActual.elemento.caracter != ".")
                {
                    if (NoEncontrado == "NoSeEncuentra")
                    {
                        NoEncontrado = EncontrarSETS(NodoActual, chain, NoEncontrado, caracter, T1, T2, T3, T4, T5, ref CAUT5yT6);
                        if (NoEncontrado == "NoSeEncuentra")
                        {
                            NoEncontrado = "CadenaError";
                        }
                    }
                    else
                    {
                        NoEncontrado = EncontrarSETS(NodoActual, chain, NoEncontrado, caracter, T1, T2, T3, T4, T5, ref CAUT5yT6);
                    }
                }
            }
            if (NoEncontrado=="NoSeEncuentra"||NoEncontrado=="")
            {
                chain = string.Empty;
                RecorrerSets(NodoActual.hijoDR, chain, ref NoEncontrado, caracter, T1, T2, T3, T4, T5, ref CAUT5yT6);
            }
            else
            {
                return;
            }
        }
        string EncontrarSETS(Node NodoActual, string chain, string NoEncontrado, char caracter, string T1, char T2, string T3, string T4, string T5, ref string CAUT5yT6)
        {
            foreach (char car in NodoActual.elemento.caracter)
            {
                    chain += car;
                    switch (chain)
                    {
                        case "T1":

                            NoEncontrado = T1.Contains(caracter) ? "Encontrado" : "NoSeEncuentra";
                            chain = string.Empty;
                            break;
                        case "T2":
                            NoEncontrado = T2.Equals(caracter) ? "Encontrado" : "NoSeEncuentra";
                            chain = string.Empty;
                            break;
                        case "=":
                        NoEncontrado = car==caracter ? "Encontrado" : "NoSeEncuentra";
                        break;
                        case "T5":
                        var arreglo = T5.Split('-');
                        var Op1 = arreglo[1];
                        var Op2 = arreglo[2];
                        var Op3 = arreglo[3];
                        if(Op1.Contains(caracter))
                        {
                            
                        }
                        else
                        {
                            if (Op3.Contains(caracter))
                            {
                                CAUT5yT6 = Op3;
                                NoEncontrado = T1.Contains(caracter) ? "Encontrado" : "NoSeEncuentra";
                            }
                        }
                        break;
                    }
            }
            return NoEncontrado;
        }
    
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
