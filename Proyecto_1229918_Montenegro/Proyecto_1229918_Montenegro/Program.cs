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
            //Lectura de archivos en bytes 
            var File = string.Empty;
            File = Console.ReadLine();
            using (var stream = new FileStream(File, FileMode.Open))
            {
                var bufferLengt = 1000000;
                using (var reader = new BinaryReader(stream))
                {
                    var byteBuffer = new byte[bufferLengt];
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        byteBuffer = reader.ReadBytes(bufferLengt);
                        foreach (byte bit in byteBuffer)
                        {

                        }
                    }
                }
            }
            //Ingresar Al árbol
            var tree = new Tree();
            var element = new Elements();
            element.caracter = '5';
            var NNode = new Node(element);
            tree.Ingresar(NNode);
            tree.Ingresar(NNode);
            tree.Ingresar(NNode);
            tree.Ingresar(NNode);
        }
    }
}
