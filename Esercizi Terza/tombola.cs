using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tombola
{
    class Program
    {
        static int[,] Tab;                      
        static int[,] Scheda;

        static void Main(string[] args)
        {
            Tab = new int[9,10];                //creiamo il tabellone (da 90 posti) e la scheda (da 15 posti, ogni posto ha un'altra casella che indica se è stata estratta oppure no)
            Scheda = new int[15,2];
            int[] vincite = new int[5];


            for (int i = 0; i < 9; i++)         //inizializzo la tabella mettendoci tutti gli 0, lo 0 indica che il numero non è stato estratto
            {
                for (int j = 0; j < 10; j++)
                {
                    Tab[i, j] = 0;
                }

            }

            Random r = new Random();           

            for (int i=0; i<15; i++)            //assegno alla scheda valori casuali e li metto a 0
            {
                Scheda[i, 0] = r.Next(1,90);    //mettiamo il numero

                Scheda[i, 1] = 0;               //metiamo 0
            }

            for (int i=0; i<90; i++)
            {
                Console.WriteLine("Tombola 2022");
                Console.WriteLine();
                StampaTabellone();
                Console.WriteLine();
                Console.WriteLine("La tua scheda");
                Console.WriteLine();
                StampaScheda();
                Console.WriteLine();
                vincite = controlloCombinazioni();
               
                if (vincite[0]==1)
                {
                  Console.WriteLine("Complimenti hai fatto ambo");
                }
                if (vincite[1] == 1)
                {
                    Console.WriteLine("Complimenti hai fatto terna");
                }
                if (vincite[2] == 1)
                {
                    Console.WriteLine("Complimenti hai fatto quaterna");
                }
                if (vincite[3] == 1)
                {
                    Console.WriteLine("Complimenti hai fatto cinquina");
                }
                if (vincite[4] == 1)
                {
                    Console.WriteLine("Complimenti hai fatto tombola");
                }

                Console.ReadLine();
                estrazioni();
                Console.Clear();
            }

        }
        static void StampaTabellone()
        {
            for (int i=0; i<9; i++)                  //stampa il tabellone formattato correttamente e con i colori dell'estrazione
            {
                for (int j=0; j<10; j++)
                {
                    if (Tab[i,j]==0)                //se non è stato estratto, non metto i colori
                    {
                        if (i==0 && j<10)
                        {
                            Console.Write("[ " + (i * 10 + j) + "]");
                        }
                        else
                        {
                            Console.Write("[" + (i * 10 + j) + "]");
                        } 
                    }
                    else
                    {
                        if (i == 0 && j < 10)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("[ " + (i * 10 + j) + "]");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("[" + (i * 10 + j) + "]");
                            Console.ResetColor();
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        static void StampaScheda()
        {
            for (int i=0; i<15; i++)                //stampa la scheda
            {
                if (Scheda[i,1]==0)                 //stampa senza colori
                {
                    Console.Write("[" + Scheda[i, 0] + "]");
                }
                else
                                                //stampa con colori
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("[" + Scheda[i, 0] + "]");
                    Console.ResetColor();
                }
                if ((i+1)%5==0)
                {
                    Console.WriteLine();
                }
            }
            
        }
        static void estrazioni()
        {
            int estratto;
            Random estrazioni = new Random();

            do                  //ciclo do while utilizzato per l'estrazione dei numeri per tabella e scheda
            {
                estratto = estrazioni.Next(1, 90);
            } while (Tab[estratto / 10, estratto % 10] == 1);       //viene estratto finché non esce un numero nuovo
                                                                        //estratto/10 (formula per trovare il numero della riga) estratto%10-1 (formula per trovare il numero della colonna)
            Tab[estratto / 10, estratto % 10] = 1;                  //ora il numero è stato effettivamente estratto
            
            for (int i=0; i<15; i++)                                    //controlla tutti i numeri della scheda
            {
                if (Scheda[i,0]==estratto)                              //se ne trova uno uguale a quello estratto lo mette a 1
                {
                    Scheda[i, 1] = 1;
                }
            }

        }
        static int[] controlloCombinazioni()
        {
            int[] vincite = new int[5];
            int riga1=0, riga2=0, riga3=0;                      //dichiaro le variabili per le combinazioni

            for (int i=0; i<15; i++)                            //ciclo for utilizzato per guardare quale numero è stato estratto
            {
                if (Scheda[i, 1] == 1)                          
                {
                    if (i < 5)
                    {
                        riga1++;
                    }
                    else if (i < 10)
                    {
                        riga2++;
                    }
                    else
                    {
                        riga3++;
                    }
                }
            }

            if (riga1==2 || riga2==2 || riga3==2)               //se il giocatore ha fatto ambo
            {
                vincite[0] = 1;
            }
            if (riga1 == 3 || riga2 == 3 || riga3 == 3)         //se il giocatore ha fatto terna
            {
                vincite[1] = 1;
            }
            if (riga1 == 4 || riga2 == 4 || riga3 == 4)         //se il giocatore ha fatto quaterna
            {
                vincite[2] = 1;
            }
            if (riga1 == 5 || riga2 == 5 || riga3 == 5)         //se il giocatore ha fatto cinquina
            {
                vincite[3] = 1;
            }
            if (riga1 == 5 && riga2 == 5 && riga3 == 5)         //se il giocatore ha fatto tombola
            {
                vincite[4] = 1;
            }

            return vincite;
        }
    }
}