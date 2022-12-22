using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrezzioneVerifica
{
    class Program
    {
        static void Main(string[] args)
        {
            string frase = "LAA MAMMA VA AL MERCATO COMPPRARE LE ZUCCHINE";
            Minuscolo(frase);
            
        }
        static void Minuscolo(string frase)
        {
            char carattere;
            string risultato = "";

            for (int i = 0; i < frase.Length; i++)
            {
                carattere = frase[i];
                if (carattere >= 'A' || carattere <= 'Z' && carattere!=' ')
                {
                    carattere = Convert.ToChar(carattere + 32);
                    risultato += carattere;
                }
                else
                {
                    risultato += carattere;
                }
            }
            Console.WriteLine(risultato);
            Console.ReadLine();

        }

    }
}