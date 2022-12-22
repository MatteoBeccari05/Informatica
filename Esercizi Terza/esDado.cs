using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dado_corretto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int NumGiocatore;
            int numNemico;
            int puntiGiocatore = 0;
            int puntiNemico = 0;
            Random random = new Random();

            for (int i = 0; i < 10; i++) ;
            {
                Console.WriteLine("Premi un pulsante per lanciare i dadi ");
                Console.ReadKey();

                NumGiocatore = random.Next(1, 7);
                Console.WriteLine("è uscito il numero: "  + NumGiocatore);

                Console.WriteLine("...");
                Thread.Sleep(1000);

                numNemico= random.Next(1, 7);
                Console.WriteLine("per il nemico è uscito il numero: " + numNemico);

                if(puntiGiocatore>numNemico)
                {
                    puntiGiocatore++;
                    Console.WriteLine("HAI VINTO QUESTO ROUND!");
                }
                else if(NumGiocatore<numNemico)
                {
                    puntiNemico++;
                    Console.WriteLine("NEMICO VINCE QUESTO ROUND!");
                }
                else
                {
                    Console.WriteLine("PAREGGIO!");
                }

                Console.WriteLine("PUNTEGGIO: GIOCATORE:" + puntiGiocatore + "NEMICO:" + puntiNemico);
                Console.WriteLine();
                
            }

            if (puntiGiocatore>puntiNemico)
            {
                Console.WriteLine("HAI VINTO!");
            }
            else if (puntiGiocatore<puntiNemico)
            {
                Console.WriteLine("HAI PERSO!");
            }
            else
            {
                Console.WriteLine("PAREGGIO");
            }

            Console.ReadKey();
        }

    }
}
