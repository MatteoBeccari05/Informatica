using System;
using System.Threading;

namespace macchinaCaffé
{
    class Program
    {
        static void Main(string[] args)
        {
            //dichiarazione variabili
            int cialda;
            int contenitore = 0;
            int serbatoio = 500;
            int acquaCialda = 0;
            int riscaldamento = 30; //secondi
            int acquaRiscaldata = 15; //ml/s
            bool esci=false;


            Console.WriteLine("Accensione della macchina, aspettare 30 secondi");


            //stampa più volte gli asterischi dentro la barra
            for (int i = 0; i < riscaldamento; i++)
            {
                Console.Write("*");
                Thread.Sleep(1000);
            }


            do
            {
                Console.Clear();

                Console.WriteLine("Selezionare la bevanda richiesta: ");
                Console.WriteLine("Menù: \n" +
                    " 1: orzo (50 mL) \n" +
                    " 2: deca (15 mL) \n" +
                    " 3: cappuccino (30 mL) \n" +
                    " 4: latte (5 mL) \n" +
                    " 5: cioccolata (25 mL) \n" +
                    " 6: caffé (35 mL) \n" +
                    " 7: macchiato (60 mL)");

                do
                {
                    cialda = Convert.ToInt32(Console.ReadLine());
                } while (cialda > 7 || cialda < 1);
                switch (cialda)
                {
                    case 1: //orzo
                        acquaCialda = 50; break;

                    case 2://deca
                        acquaCialda = 15; break;

                    case 3: //cappuccino
                        acquaCialda = 30; break;

                    case 4: //latte
                        acquaCialda = 5; break;

                    case 5: //cioccolata
                        acquaCialda = 25; break;

                    case 6: //caffé
                        acquaCialda = 35; break;

                    case 7: //macchiato
                        acquaCialda = 60; break;
                }


                



                if (serbatoio >= acquaCialda)
                {



                    if (contenitore < 10)
                    {

                        Console.WriteLine("Inserisci il bicchiere correttamente");
                        Console.WriteLine("\\            /");
                        Console.WriteLine(" \\          /");
                        Console.WriteLine("  \\        /");
                        Console.WriteLine("   \\______/");


                        Console.WriteLine("Sto erogando la bevanda");

                        for (int i = 0; i < 10; i++)                   //il massimo della barra è 10 asterischi, cambia solo la velocità di caricamento degli asterischi
                        {
                            Console.Write("*");
                            Thread.Sleep(((acquaCialda/acquaRiscaldata)*1000)/10);
                        }
                        Console.WriteLine();

                        contenitore = contenitore + 1;
                        serbatoio = serbatoio - acquaCialda;
                        Console.WriteLine("Preparazione finita, ritirare il caffé");
                        Console.WriteLine("Contenitore: "+contenitore+" cialde vuote");
                        Console.WriteLine("Serbatoio: " + serbatoio + " mL");
                    }
                    else
                    {
                        Console.WriteLine("Il contenitore è pieno");
                        esci = true;
                    }
                }
                else
                {
                    Console.WriteLine("L'acqua è terminata");
                    esci = true;
                }
                Console.WriteLine("Premi un tasto per continuare....");
                Console.ReadLine();
            } while (!esci);
            



        }
    }
}
