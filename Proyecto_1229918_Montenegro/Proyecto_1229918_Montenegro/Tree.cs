﻿using System;
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
        public void RecorrerSets(Node NodoActual, Node raiz, Node PadreAux, bool encontrar, ref string frase, ref string Continuar, string A, char B, string C, string D, string E, string F, string G, string H, string J, string L, string M, string N, string Ñ, string O, string Q, string R, string S, string T, string P, ref int cantidad)
        {
            if (NodoActual == null)
            {
                return;
            }
            RecorrerSets(NodoActual.hijoIZ, raiz, PadreAux, encontrar, ref frase, ref Continuar, A, B, C, D, E, F, G, H, J, L, M, N, Ñ, O, Q, R, S, T, P, ref cantidad);
            //Encontrar Padre
            var X = false;
            EncontrarPadre(NodoActual, raiz, ref PadreAux, ref X);
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
                                    encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
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
                            encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
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
                            encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
                            if (encontrar)
                            {
                                frase = frase.Substring(1);
                                contador++;
                            }
                            Continuar = (contador == 1) ? "PC" : "NPC";
                        }
                        break;
                    case "|":
                        if (Continuar != "PCSP" && NodoActual.elemento.caracter != "|")
                        {
                            var Aux = string.Empty;
                            do
                            {
                                if (C.Length != 0 && D.Length != 0 && F.Length != 0 && G.Length != 0 && H.Length != 0 && J.Length != 0 && L.Length != 0 && M.Length != 0 && Ñ.Length != 0 && O.Length != 0 && Q.Length != 0 && R.Length != 0 && R.Length != 0 && S.Length != 0 && T.Length != 0)
                                {
                                    encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
                                }
                                else
                                {
                                    if (frase == string.Empty)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        if (frase[0] != '+')
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
                                if (frase.Length == 0)
                                {
                                    break;
                                }
                            }
                            while (encontrar == true && frase[0] != '+');
                            Continuar = ((C.Length == 0 || D.Length == 0 || F.Length == 0 || G.Length == 0 || H.Length == 0 || J.Length == 0 || L.Length == 0 || M.Length == 0 || Ñ.Length == 0 || O.Length == 0 || Q.Length == 0 || R.Length == 0 || R.Length == 0 || S.Length == 0 || T.Length == 0)) ? "PCSP" : "NPC";
                            cantidad = Continuar == "PCSP" ? cantidad + 1 : cantidad;
                            if (Continuar == "NPC" && NodoActual.elemento.caracter != "G")
                            {
                                frase = Aux + frase;
                                Continuar = "PC";
                            }
                        }
                        break;
                    case "?":
                        encontrar = EncontrarCaracterAux(NodoActual.elemento.caracter, frase[0], A, B, ref C, ref D, E, ref F, ref G, ref H, ref J, ref L, ref M, N, ref Ñ, ref O, ref Q, ref R, ref S, ref T, P);
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
            if (Continuar == "PC" || Continuar == "PCSP")
            {
                RecorrerSets(NodoActual.hijoDR, raiz, PadreAux, encontrar, ref frase, ref Continuar, A, B, C, D, E, F, G, H, J, L, M, N, Ñ, O, Q, R, S, T, P, ref cantidad);
                if (NodoActual.elemento.caracter == "+" && frase.Length != 0 && NodoActual.hijoIZ.elemento.caracter == ".")
                {
                    while (frase.Length != 0 && (Continuar == "PC" || Continuar == "PCSP"))
                    {
                        RecorrerSets(NodoActual.hijoIZ, raiz, PadreAux, encontrar, ref frase, ref Continuar, A, B, C, D, E, F, G, H, J, L, M, N, Ñ, O, Q, R, S, T, P, ref cantidad);
                    }
                }
            }
            else
            {
                return;
            }
        }
        private bool EncontrarCaracterAux(string cadena, char caracter, string A, char B, ref string C, ref string D, string E, ref string F, ref string G, ref string H, ref string J, ref string L, ref string M, string N, ref string Ñ, ref string O, ref string Q, ref string R, ref string S, ref string T, string P)
        {
            var encontrado = false;
            switch (cadena)
            {
                case "A":
                    encontrado = A.Contains(caracter) ? true : false;
                    break;
                case "B":
                    encontrado = B.Equals(caracter) ? true : false;
                    if (!encontrado)
                    {
                        encontrado = ("    \t".Contains(caracter)) ? true : false;
                    }
                    break;
                case "=":
                    encontrado = ('=' == caracter) ? true : false;
                    break;
                case "C":
                    encontrado = C[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        C = C.Substring(1);
                    }
                    else
                    {
                        if (C[0] == 'E')
                        {
                            encontrado = E.Contains(caracter) ? true : false;
                            C = C.Substring(1);
                        }
                    }
                    break;
                case "D":
                    encontrado = D[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        D = D.Substring(1);
                    }
                    else
                    {
                        if (D[0] == 'E')
                        {
                            encontrado = E.Contains(caracter) ? true : false;
                            D = D.Substring(1);
                        }
                    }
                    break;
                case "F":
                    encontrado = F[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        F = F.Substring(1);
                    }
                    else
                    {
                        if (F[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            F = F.Substring(1);
                        }
                    }
                    break;
                case "G":
                    encontrado = G[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        G = G.Substring(1);
                    }
                    else
                    {
                        if (G[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            G = G.Substring(1);
                        }
                    }
                    break;
                case "H":
                    encontrado = H[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        H = H.Substring(1);
                    }
                    else
                    {
                        if (H[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            H = H.Substring(1);
                        }
                    }
                    break;
                case "J":
                    encontrado = J[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        J = J.Substring(1);
                    }
                    else
                    {
                        if (J[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            J = J.Substring(1);
                        }
                    }
                    break;
                case "L":
                    encontrado = L[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        L = L.Substring(1);
                    }
                    else
                    {
                        if (L[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            L = L.Substring(1);
                        }
                    }
                    break;
                case "M":
                    encontrado = M[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        M = M.Substring(1);
                    }
                    else
                    {
                        if (M[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            M = M.Substring(1);
                        }
                    }
                    break;

                case "Ñ":
                    encontrado = Ñ[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        Ñ = Ñ.Substring(1);
                    }
                    else
                    {
                        if (Ñ[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            Ñ = Ñ.Substring(1);
                        }
                    }
                    break;
                case "O":
                    encontrado = O[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        O = O.Substring(1);
                    }
                    else
                    {
                        if (O[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            O = O.Substring(1);
                        }
                    }
                    break;
                case "Q":
                    encontrado = Q[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        Q = Q.Substring(1);
                    }
                    else
                    {
                        if (Q[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            Q = Q.Substring(1);
                        }
                    }
                    break;
                case "R":
                    encontrado = R[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        R = R.Substring(1);
                    }
                    else
                    {
                        if (R[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            R = R.Substring(1);
                        }
                    }
                    break;
                case "S":
                    encontrado = S[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        S = S.Substring(1);
                    }
                    else
                    {
                        if (S[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            S = S.Substring(1);
                        }
                    }
                    break;
                case "T":
                    encontrado = T[0] == caracter ? true : false;
                    if (encontrado)
                    {
                        T = T.Substring(1);
                    }
                    else
                    {
                        if (T[0] == 'N')
                        {
                            encontrado = N.Contains(caracter) ? true : false;
                            T = T.Substring(1);
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
        public void RecorrerTokens(Node NodoActual, Node PadreAux, bool encontrar, ref string frase, ref string Continuar, string K, char B, string N, string U, string A, string W, string I, string V, ref int cantidad, string Z, string Y)
        {
            if (NodoActual == null)
            {
                return;
            }
            RecorrerTokens(NodoActual.hijoIZ, PadreAux, encontrar, ref frase, ref Continuar, K, B, N, U, A, W, I, V, ref cantidad, Z, Y);
            var R = false;
            EncontrarPadre(NodoActual, Raiz, ref PadreAux, ref R);
            var contador = 0;
            if (frase.Length != 0)
            {
                switch (PadreAux.elemento.caracter)
                {
                    case ".":
                        if (NodoActual.elemento.caracter == "K")
                        {
                            do
                            {
                                if (K != string.Empty)
                                {
                                    encontrar = EncontrarCaracterAuxTokens(NodoActual.elemento.caracter, frase[0], K, B, N, ref U, A, W, I, V/*,ref Z,ref Y*/);
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
                            if (NodoActual.elemento.caracter == "=")
                            {
                                encontrar = EncontrarCaracterAuxTokens(NodoActual.elemento.caracter, frase[0], K, B, N, ref U, A, W, I, V/*,ref Z, ref Y*/);
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
                                encontrar = EncontrarCaracterAuxTokens(NodoActual.elemento.caracter, frase[0], K, B, N, ref U, A, W, I, V/*, ref Z , ref Y*/);
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
                            encontrar = EncontrarCaracterAuxTokens(NodoActual.elemento.caracter, frase[0], K, B, N, ref U, A, W, I, V/*, ref Z, ref Y*/);
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
                            if (NodoActual.elemento.caracter == "U")
                            {
                                do
                                {
                                    if (U.Length != 0)
                                    {
                                        encontrar = EncontrarCaracterAuxTokens(NodoActual.elemento.caracter, frase[0], K, B, N, ref U, A, W, I, V);
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
                                while (encontrar == true && U.Length != 0);
                                Continuar = ((U.Length == 0)) ? "PCSP" : "NPC";
                                cantidad = Continuar == "PCSP" ? cantidad + 1 : cantidad;
                            }
                            else
                            {
                                if (Continuar != "PCSP")
                                {
                                    do
                                    {
                                        encontrar = EncontrarCaracterAuxTokens(NodoActual.elemento.caracter, frase[0], K, B, N, ref U, A, W, I, V);
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
                                    cantidad = Continuar == "PCSP" ? cantidad + 1 : cantidad;
                                }
                            }
                            if (Continuar == "NPC" && NodoActual.elemento.caracter != "W")
                            {
                                frase = Aux + frase;
                                Continuar = "PC";
                            }
                        }
                        break;
                }
            }
            if (Continuar == "PC" || Continuar == "PCSP")
            {
                RecorrerTokens(NodoActual.hijoDR, PadreAux, encontrar, ref frase, ref Continuar, K, B, N, U, A, W, I, V, ref cantidad, Z, Y);
                if (NodoActual.elemento.caracter == "+" && frase.Length != 0 && NodoActual.hijoIZ.elemento.caracter == "|")
                {
                    while (frase.Length != 0 && (Continuar == "PC" || Continuar == "PCSP"))
                    {
                        RecorrerTokens(NodoActual.hijoIZ, PadreAux, encontrar, ref frase, ref Continuar, K, B, N, U, A, W, I, V, ref cantidad, Z, Y);
                    }
                }
            }
            else
            {
                return;
            }
        }
        private bool EncontrarCaracterAuxTokens(string cadena, char caracter, string K, char B, string N, ref string U, string A, string W, string I, string V/*,ref string Z, ref string Y*/)
        {
            var encontrado = false;
            switch (cadena)
            {
                case "K":
                    encontrado = (K[0] == caracter) ? true : false;
                    break;
                case "B":
                    encontrado = B.Equals(caracter) ? true : false;
                    if (!encontrado)
                    {
                        encontrado = ("    \t".Contains(caracter)) ? true : false;
                    }
                    break;
                case "N":
                    encontrado = N.Contains(caracter) ? true : false;
                    break;
                case "V":
                    encontrado = V.Contains(caracter) ? true : false;
                    break;
                case "=":
                    encontrado = ('=' == caracter) ? true : false;
                    break;
                case "U":
                    encontrado = U.Contains(caracter) ? true : false;
                    if (encontrado)
                    {
                        U = U.Substring(1);
                    }
                    else
                    {
                        if (U[0] == 'I')
                        {
                            encontrado = I.Contains(caracter) ? true : false;
                            U = U.Substring(1);
                        }
                    }
                    break;
                case "W":
                    encontrado = W.Contains(caracter) ? true : false;
                    break;
                case "A":
                    encontrado = A.Contains(caracter) ? true : false;
                    break;
                case "Z":
                    //encontrado = (caracter == 'I') ? false : Z.Contains(caracter);
                    //if (encontrado)
                    //{
                    //    Z = Z.Substring(1);
                    //}
                    //else
                    //{
                    //    if (Z[0] == 'I')
                    //    {
                    //        encontrado = I.Contains(caracter) ? true : false;
                    //        if (!encontrado)
                    //        {
                    //            Z = Z.Substring(1);
                    //        }
                    //    }
                    //}
                    break;
                case "Y":
                    //encontrado = (caracter == 'I') ? false : Z.Contains(caracter);
                    //if (encontrado)
                    //{
                    //    Y = Y.Substring(1);
                    //}
                    //else
                    //{
                    //    if (Y[0] == 'I')
                    //    {
                    //        encontrado = I.Contains(caracter) ? true : false;
                    //        if (!encontrado)
                    //        {
                    //            Y = Y.Substring(1);
                    //        }
                    //    }
                    //}
                    break;
            }
            return encontrado;
        }
        //Métodos para Actions
        public void RecorrerActions(Node NodoActual, Node PadreAux, bool encontrar, ref string frase, ref string Continuar, string N, char B, string A, ref int cantidad)
        {
            if (NodoActual == null)
            {
                return;
            }
            RecorrerActions(NodoActual.hijoIZ, PadreAux, encontrar, ref frase, ref Continuar, N, B, A, ref cantidad);
            var R = false;
            EncontrarPadre(NodoActual, Raiz, ref PadreAux, ref R);
            var contador = 0;
            if (frase != string.Empty)
            {
                switch (PadreAux.elemento.caracter)
                {
                    case ".":
                        if (NodoActual.elemento.caracter == "=")
                        {
                            encontrar = EncontrarCaracterAuxActions(NodoActual.elemento.caracter, frase[0], N, B, A);
                            if (encontrar)
                            {
                                frase = frase.Substring(1);
                                contador++;
                            }
                            Continuar = (contador == 1) ? "PC" : "NPC";
                        }
                        else
                        {
                            if (NodoActual.elemento.caracter == "'")
                            {
                                encontrar = EncontrarCaracterAuxActions(NodoActual.elemento.caracter, frase[0], N, B, A);
                                if (encontrar)
                                {
                                    frase = frase.Substring(1);
                                    contador++;
                                }
                                Continuar = (contador == 1) ? "PC" : "NPC";
                                cantidad = Continuar == "PC" ? cantidad + 1 : cantidad;
                            }
                        }
                        break;
                    case "+":
                        do
                        {
                            encontrar = EncontrarCaracterAuxActions(NodoActual.elemento.caracter, frase[0], N, B, A);
                            if (encontrar)
                            {
                                frase = frase.Substring(1);
                                contador++;
                            }
                            if (frase.Length == 0)
                            {
                                break;
                            }
                        }
                        while (encontrar == true);
                        Continuar = (contador >= 1) ? "PC" : "NPC";
                        break;
                    case "*":
                        do
                        {
                            encontrar = EncontrarCaracterAuxActions(NodoActual.elemento.caracter, frase[0], N, B, A);
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
            if (Continuar == "PC")
            {
                RecorrerActions(NodoActual.hijoDR, PadreAux, encontrar, ref frase, ref Continuar, N, B, A, ref cantidad);
            }
            else
            {
                return;
            }
        }
        private bool EncontrarCaracterAuxActions(string cadena, char caracter,string N,char B,string A)
        {
            var encontrado = false;
            switch (cadena)
            {
                case "N":
                    encontrado = (N.Contains(caracter)) ? true : false;
                    break;
                case "B":
                    encontrado = (B.Equals(caracter)) ? true : false;
                    if (!encontrado)
                    {
                        encontrado = ("    \t".Contains(caracter)) ? true : false;
                    }
                    break;
                case "=":
                    encontrado = ('=' == caracter) ? true : false;
                    break;
                case "'":
                    encontrado = ("'".Contains(caracter)) ? true : false;
                    break;
                case "A":
                    encontrado = (A.Contains(caracter)) ? true : false;
                    break;
            }
            return encontrado;
        }
        //Métodos para Errors
        public void RecorrerErrors(Node NodoActual, Node PadreAux, bool encontrar, ref string frase, ref string Continuar,string A, char B, string N, ref int Cantidad)
        {
            if (NodoActual == null)
            {
                return;
            }
            RecorrerErrors(NodoActual.hijoIZ, PadreAux, encontrar, ref frase, ref Continuar,A,B,N,ref Cantidad);
            var R = false;
            EncontrarPadre(NodoActual, Raiz, ref PadreAux, ref R);
            var contador = 0;
            if (frase != string.Empty)
            {
                switch (PadreAux.elemento.caracter)
                {
                    case ".":
                        if (NodoActual.elemento.caracter == "=")
                        {
                            encontrar = EncontrarCaracterAuxErrors(NodoActual.elemento.caracter, frase[0], N, B, A);
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
                            encontrar = EncontrarCaracterAuxErrors(NodoActual.elemento.caracter, frase[0], N, B, A);
                            if (encontrar)
                            {
                                frase = frase.Substring(1);
                                contador++;
                            }
                            if (frase.Length == 0)
                            {
                                break;
                            }
                        }
                        while (encontrar == true);
                        Continuar = (contador >= 1) ? "PC" : "NPC";
                        Cantidad = (Continuar == "PC") ? Cantidad + 1 : Cantidad;
                        break;
                    case "*":
                        do
                        {
                            encontrar = EncontrarCaracterAuxErrors(NodoActual.elemento.caracter, frase[0], N, B, A);
                            if (encontrar)
                            {
                                frase = frase.Substring(1);
                                contador++;
                            }
                            if (frase.Length == 0)
                            {
                                break;
                            }
                        }
                        while (encontrar == true);
                        Continuar = (contador >= 0) ? "PC" : "NPC";
                        break;
                }
            }
            if (Continuar == "PC")
            {
                RecorrerErrors(NodoActual.hijoDR, PadreAux, encontrar, ref frase, ref Continuar,A,B,N,ref Cantidad);
            }
            else
            {
                return;
            }
        }
        private bool EncontrarCaracterAuxErrors(string cadena, char caracter, string N, char B, string A)
        {
            var encontrado = false;
            switch (cadena)
            {
                case "N":
                    encontrado = (N.Contains(caracter)) ? true : false;
                    break;
                case "B":
                    encontrado = (B.Equals(caracter)) ? true : false;
                    if (!encontrado)
                    {
                        encontrado = ("    \t".Contains(caracter)) ? true : false;
                    }
                    break;
                case "=":
                    encontrado = ('=' == caracter) ? true : false;
                    break;
                case "A":
                    encontrado = (A.Contains(caracter)) ? true : false;
                    break;
            }
            return encontrado;
        }
        //Métodos Generales
        private void EncontrarPadre(Node NodoActual, Node Padre, ref Node PadreAux, ref bool P)
        {
            if (Padre == null)
            {
                return;
            }
            EncontrarPadre(NodoActual, Padre.hijoIZ, ref PadreAux, ref P);
            if (Padre.hijoIZ == NodoActual || Padre.hijoDR == NodoActual)
            {
                PadreAux = Padre;
                P = true;
            }
            if (!P)
            {
                EncontrarPadre(NodoActual, Padre.hijoDR, ref PadreAux, ref P);
            }
            else
            {
                return;
            }
        }
    }
}