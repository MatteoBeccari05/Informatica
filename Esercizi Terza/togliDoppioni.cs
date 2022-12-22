using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doppioni
{
    class Program
    {
        static void Main(string[] args)
        {
            string frase = "LA MAAMMA VA AL MERCATO A COMPERARRE LE ZUCCHINE";
            Console.WriteLine(Doppioni(frase));
            Console.ReadLine();
        }
        static string Doppioni(string frase)
        {
            string fnuova = frase[0].ToString();
            for (int i = 1; i < frase.Length; i++)
            {
                if (frase[i]!=frase[i-1])
                {
                    fnuova += frase[i];
                }
            }
            return fnuova;
            
        }
    }
}