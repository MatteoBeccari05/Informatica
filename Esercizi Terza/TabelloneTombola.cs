using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabellone_Tombola
{
    internal class Program
    {
        static bool[] nTombola = new bool[90];
        static Random estratto = new Random();
        static int[,] Scheda;
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 0; i < 90; i++)
                estrazioni();

            tabellone();
            Console.WriteLine();
            schedina();
            Console.ReadLine();
        }
        static void estrazioni()
        {
            int numero;
            do
            {
                numero = estratto.Next(1, 91);
                if (!nTombola[numero - 1])
                {
                    nTombola[numero - 1] = !nTombola[numero - 1];
                }

            } while (!nTombola[numero - 1]);
        }
        static void tabellone()
        {
            Console.WriteLine("TABELLONE");
            Console.WriteLine();
            Console.WriteLine("==========================================================");
            for (int i = 0; i < 9; i++)                  //stampa tabellone 
            {
                for (int a = 0; a < 10; a++)
                {
                    if (Tabellone[i, a] == 0)                //se il numero non è estratto non metto lo sfondo bianco
                    {
                        if (i == 0 && a < 10)
                        {
                            Console.Write("  " + (i * 10 + a) + "  ");
                        }
                        else                                                //forma del tabellone
                        {
                            Console.Write("  " + (i * 10 + a) + "  ");
                        }
                    }
                    else
                    {
                        if (i == 0 && a < 10)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("  " + (i * 10 + a) + "  ");
                            Console.ResetColor();
                        }                                                          //colori dei numeri sul tabellone
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("  " + (i * 10 + a) + "  ");
                            Console.ResetColor();
                        }

                    }
                }
                Console.WriteLine();
                Console.WriteLine("==========================================================");
            }
        }

    }
        static void schedina()
        {
            for (int i = 0; i < 10; i++)
            {
                
                
                    Console.Write(" " + Scheda[i, 0] + " ");
                
               
                
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" " + Scheda[i, 0] + " ");
                    Console.ResetColor();
                
            }
        }


    }   
   

    

