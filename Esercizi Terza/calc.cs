using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcolatrice
{
    class Program
    {
        static double num1;
        static double num2;                                //assegnazione variabili statiche
        static string insTmp;
        static bool ripetizione = false;

        static void Main(string[] args)
        {
            inserimento();
            int scelta = 0;
            while (ripetizione == false)
            {
                Console.WriteLine("Scegli l'operazione da svolgere");
                Console.WriteLine("1  SOMMA");                                                //primo men�
                Console.WriteLine("2  SOTTRAZIONE");
                Console.WriteLine("3  MOLTIPLICAZIONE");
                Console.WriteLine("4  DIVISIONE");

                scelta = Convert.ToInt32(Console.ReadLine());
                while (scelta != 1 & scelta != 2 & scelta != 3 & scelta != 4)
                {
                    Console.WriteLine("Errore. Scelta non valida. Scegliere tra le opzioni che ci sono");          //controllo che la scelta del men� sia corretta 
                    scelta = Convert.ToInt32(Console.ReadLine());
                }

                switch (scelta)
                {
                    case 1: somma(); break;
                    case 2: sottrazione(); break;                   //men� con switch case
                    case 3: moltiplicazione(); break;
                    case 4: divisione(); break;
                }
                ripetizione = true;
            }
            
            while(ripetizione==true)
            {
                Console.WriteLine("Scegli l'operazione da svolgere");
                Console.WriteLine("1  SOMMA");
                Console.WriteLine("2  SOTTRAZIONE");
                Console.WriteLine("3  MOLTIPLICAZIONE");                  //secondo men� con anche la scelta di fine programma 
                Console.WriteLine("4  DIVISIONE");
                Console.WriteLine("5: FINE PROGRAMMA");

                scelta = Convert.ToInt32(Console.ReadLine());

                while (scelta != 1 & scelta != 2 & scelta != 3 & scelta != 4 & scelta != 5)
                {
                    Console.WriteLine("Scegliere un opzione tra quelle elencate sopra");               //controllo che le scelte siano corrette
                    scelta = Convert.ToInt32(Console.ReadLine());
                }

                switch (scelta)
                {
                    case 1: somma(); break;
                    case 2: sottrazione(); break;
                    case 3: moltiplicazione(); break;            //secondo men� con switch case 
                    case 4: divisione(); break;
                    case 5: ripetizione = false; break;
                }
            }
        }

        static void inserimento()
        {
            Console.WriteLine("Inserire il primo numero");           //inserimento primo numero
            insTmp = Console.ReadLine();

            while (insTmp == "")
            {
                Console.WriteLine("Reinserire il numero");                       
                Console.ReadLine();
                Console.Clear();                                             //controllo primo numero
                Console.WriteLine("Inserire un altro numero");
                insTmp = Console.ReadLine();
            }
            num1 = Convert.ToDouble(insTmp);
            Console.Clear();
            Console.WriteLine("Inserire il secondo numero");          //inserimento secondo numero 
            insTmp = Console.ReadLine();

            while (insTmp == "")
            {
                Console.WriteLine("Reinserire il numero");
                Console.ReadLine();                                //controllo secondo numero
                Console.Clear();
                Console.WriteLine("Inserire un altro numero");
                insTmp = Console.ReadLine();
            }
            num2 = Convert.ToDouble(insTmp);
            Console.Clear();
        }
        static void somma()
        {
            Console.Clear();
            double somma = 0;                             //metodo somma
            somma = num1 + num2;
            Console.WriteLine("il risultato �: " + somma);
            Console.ReadLine();
        }

        static void sottrazione()

        {
            Console.Clear();
            double sottrazione = 0;                   //metodo sottrazione
            sottrazione = num1 - num2;
            Console.WriteLine("il risultato �: " + sottrazione);
            Console.ReadLine();
        }

        static void moltiplicazione()
        {
            Console.Clear(); 
            double moltiplicazione = 0;              //metodo moltiplicazione 
            moltiplicazione = num1 * num2;
            Console.WriteLine("il risultato �: " + moltiplicazione);
            Console.ReadLine();
        }

        static void divisione()
        {
            Console.Clear();                  //metodo divisione 
            double divisione = 0;
            while(num2==0)
            {
                Console.WriteLine("Inserire un altro numero");
                Console.WriteLine("Reinserire il secondo numero");           //controllo che il secondo numero della divisione non sia zero 
                num2 = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
            }
            divisione = num1 / num2;
            Console.WriteLine("il risultato �: " + divisione);
            Console.ReadLine();
            Console.Clear();

        }
    }
}
