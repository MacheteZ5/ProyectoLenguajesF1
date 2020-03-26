using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLenguajesSegundaFase
{
    public class FLFN
    {
        public List<string> GenerarListaSETS(List<string> ListaSETS)
        {
            var List = new List<string>();
            var contador = 0;
            foreach (string nodo in ListaSETS)
            {
                var auxiliar = string.Empty;
                foreach (char caracter in nodo)
                {
                    if (caracter == '=')
                    {
                        auxiliar = nodo.Substring(0, contador);
                        contador = 0;
                        auxiliar = auxiliar.Trim(' ');
                        List.Add(auxiliar);
                        break;
                    }
                    else
                    {
                        contador++;
                    }
                }
            }
            return List;
        }
        public string ObtenerExpR(List<string> ListaTokens, List<string> SAux)
        {
            byte Y = 65;
            var Expression = string.Empty;
            var Final = new List<string>();
            var Aux = new List<string>();
            var List = new List<string>();
            var dic = new Dictionary<string, char>();
            if (SAux.Count() != 0)
            {
                SAux.Remove(SAux[0]);
                List = GenerarListaSETS(SAux);
            }
            foreach (string cadena in ListaTokens)
            {
                var CAux = encontrarIgual(cadena);
                Aux.Add(CAux);
            }
            //Reemplazar los valores según la tabla SETS
            var nuevo = "'";
            if (List.Count() != 0)
            {
                foreach (string cadena in Aux)
                {
                    Expression = Ajustar(cadena, List, ref dic, ref Y);
                    Final.Add(Expression);
                }
            }
            //concatenar todo en una frase
            Expression = string.Empty;
            foreach (string frase in Final)
            {
                Expression += Concatenar(frase);
                Expression += '|';
            }
            Expression = Expression.Trim('|');
            var final = "((";
            for (int i = 0; i < Expression.Length; i++)
            {
                var aux = dic.FirstOrDefault(x => x.Value == Expression[i]).Value;
                var aus = dic.FirstOrDefault(x => x.Value == Expression[i]).Key;
                if (i < Expression.Length - 1)
                {
                    if (Expression[i] == aux && Expression[i + 1] != nuevo[0])
                    {
                        var reserva = dic.FirstOrDefault(x => x.Value == Expression[i]).Key;
                        final += reserva;
                    }
                    else
                    {
                        final += Expression[i];
                    }
                }
                else
                {
                    final += Expression[i];
                }
            }
            final += ").#)";
            return final;
        }
        private string encontrarIgual(string cadena)
        {
            var numero = 0;
            var CAux = string.Empty;
            for (int i = 0; i < cadena.Length; i++)
            {
                if ((cadena[i] == '='))
                {
                    numero = i;
                    break;
                }
            }
            CAux = cadena.Substring(numero + 1);
            CAux = CAux.Trim(' ');
            return CAux;
        }
        private string Concatenar(string aux)
        {
            var caracter = "'";
            string Exp = string.Empty;
            for (int i = 0; i < aux.Length; i++)
            {
                if (aux[i] != ' ')
                {
                    if (aux[i] != '*' && aux[i] != '+' && aux[i] != '|' && aux[i] != ')' && aux[i] != '(' && aux[i] != caracter[0])
                    {
                        Exp += aux[i] + ".";
                    }
                    else
                    {
                        if (aux[i] == '(')
                        {
                            Exp += aux[i];
                        }
                        else
                        {
                            if (aux[i] == caracter[0] && i != aux.Length - 1)
                            {
                                Exp += aux[i];
                                i++;
                                Exp += aux[i];
                                i++;
                                Exp += aux[i];
                                Exp += '.';
                            }
                            else
                            {
                                if (Exp[Exp.Length - 1] == '.')
                                {
                                    Exp = Exp.Trim('.');
                                }
                                Exp += aux[i];
                            }
                        }
                    }
                }
            }
            Exp = Exp.Trim('.');
            return Exp;
        }
        private string Ajustar(string cadena, List<string> ListaSETS, ref Dictionary<string, char> dic, ref byte Y)
        {
            var Aux = string.Empty;
            foreach (string frase in ListaSETS)
            {
                var aus = string.Empty;
                if (cadena.Contains(frase) && (!dic.ContainsKey(frase)))
                {
                    aus += (Convert.ToChar(Y));
                    cadena = cadena.Replace(frase, aus);
                    dic.Add(frase, Convert.ToChar(Y));
                    Y++;
                }
                else
                {
                    if (cadena.Contains(frase) && (dic.ContainsKey(frase)))
                    {
                        aus += dic.FirstOrDefault(x => x.Key == frase).Value;
                        cadena = cadena.Replace(frase, aus);
                    }
                }
            }
            return cadena;
        }
        public void IngresarFLH(Node Actual, ref int contador)
        {
            if (Actual == null)
            {
                return;
            }
            IngresarFLH(Actual.hijoIZ, ref contador);
            if (Actual.hijoIZ == null && Actual.hijoDR == null)
            {
                Actual.elemento.First = Convert.ToString(contador);
                Actual.elemento.Last = Convert.ToString(contador);
                contador++;
            }
            IngresarFLH(Actual.hijoDR, ref contador);
        }
        public void RecorrerFLN(Node Actual)
        {
            if (Actual == null)
            {
                return;
            }
            RecorrerFLN(Actual.hijoIZ);
            RecorrerFLN(Actual.hijoDR);
            if (Actual.hijoDR == null && Actual.hijoIZ == null)
            {

            }
            else
            {
                Actual.elemento.First = (Actual.elemento.caracter == "*" || Actual.elemento.caracter == "+" || Actual.elemento.caracter == "?") ? Actual.hijoIZ.elemento.First : (Actual.elemento.caracter == "|") ? Actual.hijoIZ.elemento.First + "," + Actual.hijoDR.elemento.First : (Actual.elemento.caracter == "." && Actual.hijoIZ.elemento.Null) ? Actual.hijoIZ.elemento.First + "," + Actual.hijoDR.elemento.First : (Actual.elemento.caracter == "." && !Actual.hijoIZ.elemento.Null) ? Actual.hijoIZ.elemento.First : string.Empty;
                Actual.elemento.Last = (Actual.elemento.caracter == "*" || Actual.elemento.caracter == "+" || Actual.elemento.caracter == "?") ? Actual.hijoIZ.elemento.Last : (Actual.elemento.caracter == "|") ? Actual.hijoIZ.elemento.Last + "," + Actual.hijoDR.elemento.Last : (Actual.elemento.caracter == "." && Actual.hijoDR.elemento.Null) ? Actual.hijoIZ.elemento.Last + "," + Actual.hijoDR.elemento.Last : (Actual.elemento.caracter == "." && !Actual.hijoIZ.elemento.Null) ? Actual.hijoDR.elemento.Last : string.Empty;
                Actual.elemento.Null = (Actual.elemento.caracter == "*" || Actual.elemento.caracter == "?") ? true : (Actual.elemento.caracter == "|" && (Actual.hijoIZ.elemento.Null || Actual.hijoDR.elemento.Null)) ? true : (Actual.elemento.caracter == "." && Actual.hijoDR.elemento.Null && Actual.hijoIZ.elemento.Null) ? true : (Actual.elemento.caracter == "+" && Actual.elemento.Null) ? true : false;
            }
        }
        public Dictionary<int, string> TablaFollow(Node Actual, Dictionary<int, string> diccionario, ref int contador)
        {
            if (Actual == null)
            {
                return diccionario;
            }
            diccionario = TablaFollow(Actual.hijoIZ, diccionario, ref contador);
            diccionario = TablaFollow(Actual.hijoDR, diccionario, ref contador);
            if (Actual.hijoDR == null && Actual.hijoIZ == null)
            {

            }
            else
            {
                var vector = Actual.hijoIZ.elemento.Last.Split(',');
                if (vector.Length != 0 && vector[0] != "")
                {
                    for (int i = 0; i < vector.Length; i++)
                    {
                        var x = Convert.ToInt32(vector[i]);
                        if (Actual.elemento.caracter == ".")
                        {
                            diccionario[x] = (!diccionario[x].Contains(Actual.hijoDR.elemento.First)) ? diccionario[x] + Actual.hijoDR.elemento.First + "," : diccionario[x];
                        }
                        else
                        {
                            if (Actual.elemento.caracter == "*" || Actual.elemento.caracter == "+")
                            {
                                diccionario[x] = (!diccionario[x].Contains(Actual.hijoIZ.elemento.First)) ? diccionario[x] + Actual.hijoIZ.elemento.First + "," : diccionario[x];
                            }
                        }
                    }
                }
            }
            return diccionario;
        }
        public void MostrarFLN(Node Actual, ref List<string[]> matrix)
        {
            if (Actual == null)
            {
                return;
            }
            MostrarFLN(Actual.hijoIZ, ref matrix);
            MostrarFLN(Actual.hijoDR, ref matrix);
            var aux = new string[4];
            aux[0] = Actual.elemento.caracter;
            aux[1] = Actual.elemento.First;
            aux[2] = Actual.elemento.Last;
            aux[3] = Actual.elemento.Null.ToString();
            matrix.Add(aux);
        }

        public List<string> ObtenerSímbolos(Node Actual, List<string> Lista)
        {
            if(Actual == null)
            {
                return Lista;
            }
            Lista = ObtenerSímbolos(Actual.hijoIZ, Lista);
            Lista = ObtenerSímbolos(Actual.hijoDR, Lista);
            if(Actual.hijoIZ==null && Actual.hijoDR == null)
            {
                var Aux = Actual.elemento.caracter;
                if (!Lista.Contains(Aux))
                {
                    Lista.Add(Aux);
                }
            }
            return Lista;
        }
        public Dictionary<string, string[]> Transición(Node Actual, Dictionary<string, string[]> dic, List<string>lista, Dictionary<int, string> follow)
        {
            //revisar los caracteres de la raíz
            var c = new List<string>();
            c = dic.Keys.ToList();
            for(int w =0;w<c.Count();w++)
            {
                var contador = 0;
                var matrix = new string[lista.Count()];
                var nuevo = c[w].Split(',');
                foreach (string simbolo in lista)
                {
                    var Aux = string.Empty;
                    var cadena = string.Empty;
                    for (int i = 0; i < nuevo.Length; i++)
                    {
                        cadena = CT(Actual, cadena, simbolo, nuevo[i], follow);
                        Aux = (!Aux.Contains(cadena)) ? Aux + cadena : Aux;
                        cadena = string.Empty;
                    }
                    matrix[contador] = Aux;
                    contador++;
                }
                dic[c[w]] = matrix;
                for (int i = 0; i < matrix.Length; i++)
                {
                    if (matrix[i] != "")
                    {
                       if(!c.Contains(matrix[i]))
                       {
                            c.Add(matrix[i]);
                            dic.Add(matrix[i], null);
                       }
                    }
                }
            }
            return dic;
        }
        public string CT(Node Actual, string cadena, string símbolo, string valor, Dictionary<int, string> follow)
        {
            if (Actual == null)
            {
                return cadena;
            }
            cadena = CT(Actual.hijoIZ, cadena, símbolo, valor, follow);
            cadena = CT(Actual.hijoDR, cadena, símbolo, valor, follow);
            if (Actual.hijoIZ == null && Actual.hijoDR == null)
            {
                if (Actual.elemento.caracter == símbolo && Actual.elemento.First==valor)
                {
                    var Aux = follow[Convert.ToInt32(Actual.elemento.First)];
                    cadena = (!cadena.Contains(Aux)) ? cadena + Aux : cadena;
                }
            }
            return cadena;
        }
    }
}
