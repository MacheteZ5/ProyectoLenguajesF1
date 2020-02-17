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
    }
}
