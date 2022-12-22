using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversione_esaDec
{
    class Program
    {
        static bool corretto = true;
        static int Hex;
        static string esadecimale;       //assegnazione variabili statiche
        static char high;
        static char low;

        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il numero da converire");
            esadecimale = Console.ReadLine().ToUpper();
            if (esadecimale.Length == 2)     //controllo che siano stati inseriti due valori decimali
            {
                //prelevo le due cifre esadecimali
                high = esadecimale[0];   //parte alta
                low = esadecimale[1];   //parte bassa
                controlla();      //controllo che i caratteri inseriti siano validi
                if (corretto)      //se corretto = true  i caratteri inseriti sono validi 
                {
                    decHex();   //converte i valori esadecimali in decimali
                    Console.WriteLine("Hex:"+ esadecimale +"Dec:"+Hex);
                }
                else
                    Console.WriteLine("sbagliato");

            }
            else
                Console.WriteLine("Lunghezza errata");
            Console.ReadLine();
            while (!corretto) ;
    
        }
        static void controlla()
        {
           corretto = (low >= '0' && low <= '9' || low >= 'A' && low <= 'F' && high >= '0' && high <= '9' || high >= 'A' && high <= 'F');   
            //controllo dei caratteri inseriti
        }
        static void decHex()
        {
            if(high>='0'&& high<='9')
            {
                Hex = high - '0';
            }
            else
            {
                Hex = (high - 'A') + 10;
            }
            Hex *= 16;
            if (low <= '0' && low >= '9')
            {
                Hex = low - '0';
            }
            else
            {
                Hex += (low - 'A') + 10;
            }
        }   
    }
}