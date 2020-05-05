using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLenguajesSegundaFase
{
    public partial class Form2 : Form
    {
        List<string> DICTOK = new List<string>();
        List<string> DICACT = new List<string>();
        string File = string.Empty;
        Node Ex = default;
        Dictionary<string, string[]> DIC = new Dictionary<string, string[]>();
        List<string> ListSimbol = new List<string>();
        List<string> LS = new List<string>();
        int ultimoV = 0;
        bool Tok = false;
        string expression = string.Empty;
        Dictionary<int, string> TF= new Dictionary<int, string>();
        public Form2(string archivo)
        {
            InitializeComponent();
            File = archivo;
            //aquí debo de meter mís datos
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
            // Expresión Arbol Total
            //Listas
            var StringList = new List<string>();
            var ListaSets = new List<ListNode>();
            var ListaTokens = new List<ListNode>();
            var ListaActions = new List<ListNode>();
            var ListaErrors = new List<ListNode>();
            var TAux = new List<string>();
            var SAux = new List<string>();
            var sets = false;
            AuxClass nuevo = new AuxClass();
            FLFN flfn = new FLFN();
            nuevo.LecturaArchivo(File, StringList, ref ListaSets, ref ListaTokens, ref ListaActions, ref ListaErrors, ref sets, ref TAux, ref SAux,ref DICACT);
            var error = false;
            var cantidad = 0;

            //corregir todo esto
            if (!sets)
            {
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
                        TreeSETS.RecorrerS(TreeSETS.Raiz, TreeSETS.Raiz, TreeSETS.Raiz, encontrar, ref ListNode.frase, ref Continuar, A, B, C, D, E, F, G, H, J, L, M, N, Ñ, O, Q, R, S, T, P, ref cantidad);
                        if (Continuar == "NPC" || cantidad == 0)
                        {
                            MessageBox.Show("La linea " + ListNode.Nlinea + " del texto contiene un error");
                            error = true;
                            break;
                        }
                        else
                        {
                            pantalla1.Items.Add("La linea " + ListNode.Nlinea + " del texto no contiene error");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Su texto, la linea 1, no posee bien escrito la palabra SETS o no la posee");
                }
                if (!error)
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
                                    if (Continuar == "NPC" || cantidad == 0 || contp % 2 != 0 || contll % 2 != 0)
                                    {
                                        MessageBox.Show("La linea " + ListNode.Nlinea + " del texto contiene un error");
                                        error = true;
                                        break;
                                    }
                                    else
                                    {
                                        pantalla1.Items.Add("La linea " + ListNode.Nlinea + " del texto no contiene error");
                                    }
                                }
                                if (!error)
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
                                        if (ListaActions[ListaActions.Count() - 1].frase == "}")
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
                                                            TreeActions.RecorrerA(TreeActions.Raiz, TreeActions.Raiz, encontrar, ref ListNode.frase, ref Continuar, N, B, A, ref cantidad);
                                                            if (Continuar == "NPC" || cantidad < 2)
                                                            {
                                                                MessageBox.Show("La linea " + ListNode.Nlinea + " del texto contiene un error");
                                                                error = true;
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                pantalla1.Items.Add("La linea " + ListNode.Nlinea + " del texto no contiene error");
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
                                                    MessageBox.Show("El archivo no posee la llave de inicio o no está bien escrita la funcion");
                                                    error = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("El archivo no posee la llave de final o su método Error está mal");
                                            error = true;
                                        }
                                        if (!error)
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
                                                        MessageBox.Show("La linea " + ListNode.Nlinea + " del texto contiene un error");
                                                        error = true;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        pantalla1.Items.Add("La linea " + ListNode.Nlinea + " del texto no contiene error");
                                                    }
                                                }
                                                if (error)
                                                {
                                                }
                                                else
                                                {
                                                    pantalla1.Items.Add("Su archivo no contiene ningún error");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("El archivo no contiene ningún método de ERROR");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El método no posee la frase RESERVADAS() o está mál escrito");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El orden en el que está escrito su archivo está incorrecto");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La palabra Actions no está escrita correctamente o su archivo no posee el método Actions");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La palabra Tokens no está escrita correctamente o su Archivo no posee el método Tokens");
                    }
                }
            }
            else
            {
                MessageBox.Show("El archivo que ingresó, está mal implementado su método SETS o está mal implementado su método TOKENS");
            }
            if (!error)
            {
                //Generar expresión Tokens
                Tok = false;
                TAux.Remove(TAux[0]);
                DICTOK = TAux;
                var Exp = flfn.ObtenerExpR(TAux, SAux,ref Tok);
                LS = SAux;
                if(Exp != string.Empty)
                {
                    Expr.Text=(Exp);
                    expression = Exp;
                    //crear el arbol de expresiones First, Last, Nullable
                    var Tree = new Tree();
                    Tree.Raiz = nuevo.CreateTreeP2(Exp);
                    Ex = Tree.Raiz;
                    var contador = 1;
                    flfn.IngresarFLH(Tree.Raiz, ref contador);
                    flfn.RecorrerFLN(Tree.Raiz);
                    var diccionario = new Dictionary<int, string>();
                    for (int x = 1; x < contador; x++)
                    {
                        diccionario.Add(x, string.Empty);
                    }
                    //generar tabla follow
                    diccionario = flfn.TablaFollow(Tree.Raiz, diccionario, ref contador);
                    TF = diccionario;
                    //generar tabla de S (tabla de estados)
                    var ListaSimbolos = new List<string>();
                    ListaSimbolos = flfn.ObtenerSímbolos(Tree.Raiz, ListaSimbolos);
                    ListaSimbolos.Remove(ListaSimbolos.Last());
                    var dic = new Dictionary<string, string[]>();
                    dic.Add(Tree.Raiz.elemento.First, null);
                    dic = flfn.Transición(Tree.Raiz, dic, ListaSimbolos, diccionario);
                    //Mostrar Tabla FLN
                    var matrix = new List<string[]>();
                    flfn.MostrarFLN(Tree.Raiz, ref matrix);
                    DataGridViewRow Matriz = new DataGridViewRow();
                    Matriz.CreateCells(FLN1);
                    Matriz.Cells[0].Value = "Símbolo";
                    Matriz.Cells[1].Value = "First";
                    Matriz.Cells[2].Value = "Last";
                    Matriz.Cells[3].Value = "Nullable";
                    for (int i = 0; i < matrix.Count(); i++)
                    {
                        FLN1.Rows.Add();
                        var aux = matrix[i];
                        FLN1.Rows[i].Cells[0].Value = aux[0];
                        FLN1.Rows[i].Cells[1].Value = aux[1];
                        FLN1.Rows[i].Cells[2].Value = aux[2];
                        FLN1.Rows[i].Cells[3].Value = aux[3];
                    }
                    //Mostrar Tabla Follow
                    contador = 1;
                    while (contador < diccionario.Count())
                    {
                        diccionario[contador] = diccionario[contador].Trim(',');
                        contador++;
                    }
                    var z = 0;
                    foreach (int clave in diccionario.Keys)
                    {
                        Follow.Rows.Add();
                        var valor = diccionario.FirstOrDefault(x => x.Key == clave).Value;
                        Follow.Rows[z].Cells[0].Value = clave;
                        Follow.Rows[z].Cells[1].Value = valor;
                        z++;
                    }
                    //mostrar tabla de estados
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = "ESTADOS";
                    col.Width = 200;
                    estado.Columns.Add(col);
                    foreach (string simbol in ListaSimbolos)
                    {
                        DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                        columna.HeaderText = simbol;
                        columna.Width = 200;
                        estado.Columns.Add(columna);
                    }
                    z = 0;
                    foreach (string clave in dic.Keys)
                    {
                        estado.Rows.Add();
                        var valor = dic.FirstOrDefault(x => x.Key == clave).Value;
                        estado.Rows[z].Cells[0].Value = clave;
                        var cont = 1;
                        for (int x = 0; x < valor.Length; x++)
                        {
                            estado.Rows[z].Cells[cont].Value = valor[x];
                            cont++;
                        }
                        z++;
                    }
                    DIC = dic;
                    ListSimbol = ListaSimbolos;
                    ultimoV = contador;
                }
                else
                {
                    MessageBox.Show("El archivo contiene valores en TOKENS que no están escritos en SETS");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(Ex);
            form.Show();
            this.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4(DIC,ListSimbol,ultimoV,LS,DICACT, Tok,DICTOK,expression);
            form.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Start = Application.StartupPath;
            var directorio = Start + "/PROYECTOFASE3";
            var dirección = Start + "/PROYECTOFASE3/PROYECTOFASE3/Form1.cs";
            TerceraFase TF = new TerceraFase();
            TF.PMétodo(dirección);
            TF.SMétodo(dirección,DIC,ListSimbol,ultimoV,LS,DICACT,DICTOK,Tok,expression);
            TF.TMétodo(dirección);
            TF.CMétodo(dirección);
            TF.QMétodo(dirección);
            TF.SEMétodo(dirección);
            //para guardar el archivo con un nombre nuevo
            SaveFileDialog salvar = new SaveFileDialog();
            salvar.ShowDialog();
            var File = salvar.FileName;
            var fuente = new DirectoryInfo(directorio);
            var objetivo = new DirectoryInfo(File);
            CopyAll(fuente,objetivo);
        }
        void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);
            //encuentra todos los archivos
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }
            //Encuentra todos los subdirectorios
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}

