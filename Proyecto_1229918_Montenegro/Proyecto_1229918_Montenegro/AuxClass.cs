using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1229918_Montenegro
{
    public class AuxClass
    {
        public void LecturaArchivo(string File, List<string> StringList, ref List<string> ListaSets, ref List<string> ListaTokens, ref List<string> ListaActions, ref List<string> ListaErrors)
        {
            var EsSETS = false;
            var EsTokens = false;
            var EsActions = false;
            var EsErrors = false;
            using (StreamReader sr = new StreamReader(File))
            {
                var file = string.Empty;
                while ((file = sr.ReadLine()) != null)
                {
                    if ((file != "") && (file != "\n\r"))
                    {
                        file = file.Trim(' ');
                        if (file != "")
                        {
                            StringList.Add(file);
                        }
                        file = string.Empty;
                    }
                }
                //Separación de caracteres por lista
                foreach (string chain in StringList)
                {
                    if (chain == "SETS")
                    {
                        EsSETS = true;
                    }
                    else
                    {
                        if (chain == "TOKENS")
                        {
                            EsTokens = true;
                            EsSETS = false;
                        }
                        else
                        {
                            if (chain == "ACTIONS")
                            {
                                EsActions = true;
                                EsTokens = false;
                            }
                            else
                            {
                                if (chain.Contains("ERROR"))
                                {
                                    EsErrors = true;
                                    EsActions = false;
                                }
                            }
                        }
                    }
                    if (EsSETS)
                    {
                        ListaSets.Add(chain);
                    }
                    else
                    {
                        if (EsTokens)
                        {
                            ListaTokens.Add(chain);
                        }
                        else
                        {
                            if (EsActions)
                            {
                                ListaActions.Add(chain);
                            }
                            else
                            {
                                if (EsErrors)
                                {
                                    ListaErrors.Add(chain);
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
