using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLenguajesSegundaFase
{
    public class NGrafo
    {
        public Dictionary<string,string> Actions(List<string> Actions, ref int largo)
        {
            var dic = new Dictionary<string, string>();
            var caracter = "'";
            foreach(string cadena in Actions)
            {
                for(int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i] == '=')
                    {
                        var aux = cadena.Substring((i+1));
                        var aux2 = cadena.Substring(0, i);
                        aux = aux.Trim(' ',caracter[0]);
                        aux2 = aux2.Trim(' ','=');
                        if (largo < aux.Length)
                        {
                            largo = aux.Length;
                        }
                        dic.Add(aux, aux2);
                        break;
                    }
                }
            }
            return dic;
        }
        public Dictionary<string, string> Tokens(List<string> LT)
        {
            var dic = new Dictionary<string, string>();
            foreach (string cadena in LT)
            {
                for (int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i] == '=')
                    {
                        var aux = cadena.Substring((i + 1));
                        var aux2 = cadena.Substring(0, i);
                        aux = aux.Trim(' ');
                        aux2 = aux2.Trim(' ', '=');
                        dic.Add(aux, aux2);
                        break;
                    }
                }
            }
            return dic;
        }
        public Dictionary<string, string> SETS(List<string> LS)
        {
            var LAux = new List<string>();
            var Aux = new List<string>();
            var SET = new List<string>();
            var dic = new Dictionary<string, string>();
            var aux = "'";
            foreach(string cadena in LS)
            {
                var auxiliar = string.Empty;
                var AUX = string.Empty;
                for(int i = 0; i < cadena.Length; i++)
                {
                    if(cadena[i] == '=')
                    {
                        auxiliar = cadena.Substring(i + 1);
                        AUX = cadena.Substring(0,i - 1);
                        AUX = AUX.Trim(' ');
                        auxiliar = auxiliar.Trim(' ');
                        Aux.Add(auxiliar);
                        SET.Add(AUX);
                        break;
                    }
                }
            }
            foreach(string cadena in Aux)
            {
                var CAux = string.Empty;
                if(cadena.Contains("CHR"))
                {
                    var respaldo = string.Empty;
                    CAux = cadena.Trim(' ');
                    while (CAux.Length != 0)
                    {
                        CAux = cadena.Trim(' ');
                        int r1 = 0;
                        int r2 = 0;
                        int r3 = 0;
                        intervalo(CAux,ref r1,ref r2);
                        r3= r2 - r1;
                        var inicial = CAux.Substring(r1, r3);
                        CAux = CAux.Substring(r2+1);
                        var final = string.Empty;
                        if (CAux[0]=='.')
                        {
                            r1 = 0;
                            r2 = 0;
                            r3 = 0;
                            intervalo(CAux, ref r1, ref r2);
                            r3 = r2 - r1;
                            final= CAux.Substring(r1, r3);
                            CAux = CAux.Substring(r2 + 1);
                        }
                        var verdad1 = false;
                        var verdad = false;
                        while (!verdad)
                        {
                            for (int j = 0; j < 256; j++)
                            {
                                if (j == Convert.ToInt32(inicial) && !verdad1)
                                {
                                    respaldo += Convert.ToChar(j);
                                    verdad1 = true;
                                }
                                else
                                {
                                    if (final == string.Empty && verdad1)
                                    {
                                        verdad = true;
                                        break;
                                    }
                                    else
                                    {
                                        if (final != string.Empty && verdad1 && j == Convert.ToInt32(final))
                                        {
                                            respaldo += Convert.ToChar(j);
                                            verdad = true;
                                            break;
                                        }
                                        else
                                        {
                                            if (final != string.Empty && verdad1)
                                            {
                                                respaldo += Convert.ToChar(j);
                                                verdad = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    CAux = respaldo;
                }
                else
                {
                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (cadena[i] == aux[0])
                        {
                            i++;
                            var inicial = string.Empty;
                            inicial += cadena[i];
                            i++;
                            var final = string.Empty;
                            if (i + 1 < cadena.Length)
                            {
                                if (cadena[i + 1] == '.')
                                {
                                    i = i + 4;
                                    final += cadena[i];
                                }
                            }
                            i++;
                            var verdad1 = false;
                            var verdad = false;
                            while (!verdad)
                            {
                                for (int j = 0; j < 256; j++)
                                {
                                    if (Convert.ToChar(j) == inicial[0] && !verdad1)
                                    {
                                        CAux += inicial[0];
                                        verdad1 = true;
                                    }
                                    else
                                    {
                                        if (final == string.Empty && verdad1)
                                        {
                                            verdad = true;
                                            break;
                                        }
                                        else
                                        {
                                            if (final != string.Empty && verdad1 && Convert.ToChar(j) == final[0])
                                            {
                                                CAux += Convert.ToChar(j);
                                                verdad = true;
                                                break;
                                            }
                                            else
                                            {
                                                if (final != string.Empty && verdad1)
                                                {
                                                    CAux += Convert.ToChar(j);
                                                    verdad = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                LAux.Add(CAux);
            }
            for(int i = 0; i < SET.Count(); i++)
            {
                dic.Add(SET[i], LAux[i]);
            }
            return dic;
        }
        void intervalo(string cadena,ref int r1, ref int r2)
        {
            for (int j = 0; j < cadena.Length; j++)
            {
                if (cadena[j] == '(')
                {
                    r1 = j+1;
                }
                if (cadena[j] == ')')
                {
                    r2 = j;
                    break;
                }
            }
        }
        public bool ValidarA(List<Grafo> Grafo, ref string cadena, Dictionary<string, string> dic, bool Act, Dictionary<string, string> dicA, int largo, ref string Estados,ref string eliminada,ref List<string> lista)
        {
            var valido = false;
            var EstadoActual = Grafo[0].estado;
            Estados += EstadoActual+"|";
            var terminal = false;
            var fin = false;
            while (!valido)
            {
                foreach (Grafo grafo in Grafo)
                {
                    if (grafo.estado == EstadoActual)
                    {
                        var Incorrecto = 0;
                        if (cadena.Length == 0)
                        {
                            terminal = grafo.EsTerminal;
                            fin = terminal ? true : false;
                            valido = true;
                            break;
                        }
                        else
                        {
                            cadena = cadena.Trim(' ');
                            var cierto = false;
                            if (Act)
                            {
                                var ups = string.Empty;
                                cierto = ACT(ref cadena, largo, dicA, ref Incorrecto, ref ups);
                                if (cierto)
                                {
                                    var ac = "Actions = " + dicA.FirstOrDefault(x => x.Key == ups).Value;
                                    lista.Add(ac);
                                    Incorrecto++;
                                }
                            }
                            if (!cierto)
                            {
                                for (int i = 0; i < grafo.Apuntadores.Length; i++)
                                {
                                    if (cadena.Length == 0)
                                    {
                                        break;
                                    }
                                    else
                                    if (grafo.Apuntadores[i] != string.Empty)
                                    {
                                        var nuevo = "'";
                                        var Aux = string.Empty;
                                        var A1 = grafo.simbolos[i].Trim(nuevo[0]);
                                        if (dic.Count() != 0)
                                        {
                                            Aux = (dic.ContainsKey(A1)) ? dic.FirstOrDefault(x => x.Key == A1).Value : A1;
                                        }
                                        else
                                        {
                                            Aux = A1;
                                        }
                                        if (Aux.Length == 0)
                                        {
                                            Aux += "'";
                                        }
                                        if (Aux.Contains(cadena[0]))
                                        {
                                            eliminada += cadena[0];
                                            EstadoActual = grafo.Apuntadores[i];
                                            Estados += EstadoActual + "|";
                                            cadena = cadena.Substring(1);
                                            Incorrecto++;
                                            terminal = grafo.EsTerminal;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        cadena = cadena.Trim(' ');
                        if (Incorrecto == 0)
                        {
                            fin = (grafo.EsTerminal) ? true : false;
                            valido = true;
                            break;
                        }
                    }
                }
            }
            valido = (fin) ? true : false;
            return valido;
        }
        bool ACT(ref string cadena, int largo, Dictionary<string,string> dicA, ref int Incorrecto, ref string ups)
        {
            var cierto = false;
            var Aux = (largo < cadena.Length) ? cadena.Substring(0, largo) : cadena.Substring(0, cadena.Length);
            while (Aux.Length!=0)
            {
                if (dicA.ContainsKey(Aux))
                {
                    cierto = true;
                    cadena = cadena.Substring(Aux.Length);
                    Incorrecto++;
                    break;
                }
                else
                {
                    Aux = Aux.Substring(0,Aux.Length-1);
                }
            }
            ups = Aux;
            return cierto;
        }
    }
    public class Grafo
    {
        public string estado;
        public bool EsTerminal;
        public string[] Apuntadores;
        public List<string> simbolos;
        public Grafo(string cadena, bool terminal, string[] estados, List<string> Sim)
        {
            estado = cadena;
            EsTerminal = terminal;
            Apuntadores = estados;
            simbolos = Sim;
        }
    }
}
