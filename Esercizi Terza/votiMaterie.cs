using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voti_materie
{
    internal class Program
    {
        static string risposta;
        static double numero = 0;
        static double media = 0;
        static double sommaNumeri = 0;
        static double contaNumeri = 0;
        static bool ripetizione = false;
        static string[,] nomi = new string[5, 5];
        static string[] materie = new string[] { "Nomi", "Matematica", "Italiano", "Storia", "Inglese" };
        static void Main(string[] args)
        {
            int scelta = 0;
            while (ripetizione == false)
            {
                Console.WriteLine("--------------MENU--------------");
                Console.WriteLine("1  INSERIRE VOTI");
                Console.WriteLine("2  INSERIRE ALUNNI");
                Console.WriteLine("3  MEDIA VOTI");
                Console.WriteLine("4  TABELLONE");
                Console.WriteLine("--------------------------------");

                scelta = Convert.ToInt32(Console.ReadLine());
                while (scelta != 1 & scelta != 2 & scelta != 3 & scelta != 4)
                {
                    Console.WriteLine("Errore. Scelta non valida. Scegliere tra le opzioni che ci sono");
                    scelta = Convert.ToInt32(Console.ReadLine());
                }

                switch (scelta)
                {
                    case 1: inserimentoVoti(); break;
                    case 2: inserimentoAlunni(); break;
                    case 3: mediaVoti(); break;
                    case 4: tabellone(); break;
                }
                ripetizione = true;
            }
        }
        static void mediaVoti()
        {
            /*while (contaNumeri < 2)
            {
                Console.WriteLine("Inserisci un numero");
                risposta = Console.ReadLine();
                numero = Convert.ToDouble(risposta);
                contaNumeri = contaNumeri + 1;
                sommaNumeri = sommaNumeri + numero;
            }*/

            while (contaNumeri >= 2)
            {
                Console.WriteLine("Vuoi inserire un nuovo numero ? (S/N)");
                risposta = Console.ReadLine();
                while (risposta == "S" || risposta == "s")
                {
                    sommaNumeri = sommaNumeri + numero;
                    contaNumeri = contaNumeri + 1;
                    Console.WriteLine("Inserisci un numero");
                    risposta = Console.ReadLine();
                    numero = Convert.ToDouble(risposta);
                    Console.WriteLine("vuoi inserire un nuovo numero ? (S/N)");
                    risposta = Console.ReadLine();
                    while (risposta == "N" || risposta == "n")
                    {
                        media = sommaNumeri / contaNumeri;
                        Console.WriteLine("Hai inserito " + contaNumeri.ToString() + " numeri, la cui media e'" + media.ToString());
                        Console.Read();
                    }
                    if (risposta != "s" | risposta != "S" | risposta != "n" | risposta != "N")
                    {
                        Console.WriteLine("Tasto non ammesso");
                        risposta = Console.ReadLine();
                        Console.WriteLine("vuoi inserire un nuovo numero ? (S/N)");
                        risposta = Console.ReadLine();
                    }
                }
            }
        }
        static void inserimentoVoti()
        {
            double somma = 0;
            for (int alunno = 1; alunno < nomi.GetLength(0); alunno++)
            {
                Console.WriteLine($"Inserisici i voti di {nomi[alunno, 0]}");
                for (int voti = 1; voti < nomi.GetLength(1) - 1; voti++)
                {
                    Console.WriteLine(materie[voti]);
                    nomi[alunno, voti] = Console.ReadLine();
                    somma += Convert.ToDouble(nomi[alunno, voti]);
                    //nomi[alunno, voti + 1] = somma / nomi.GetLength(1) - 2;
                }

            }
        }

        static void inserimentoAlunni()
        {

        }

        static void tabellone()
        {
            for (int j = 0; j < nomi.GetLength(0); j++)
            {
                for (int i = 0; i < nomi.GetLength(1); i++)
                {
                    Console.Write(nomi[j, i]);
                    Console.Write("\t");
                    Console.ReadLine();
                }
                Console.Write("\n");
                Console.ReadLine();

            }
           
        }
    }
}