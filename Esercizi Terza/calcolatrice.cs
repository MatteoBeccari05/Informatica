using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcolatrice
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1=0;
            double num2=0;
            double somma = 0, sottrazione = 0, moltiplicazione = 0, divisione = 0;           
            string insTmp = "";
            inserimento(ref num1, ref num2, insTmp);
            int scelta = 0;
            bool ripetizione = false;
            while (ripetizione==false)
            {
                Console.WriteLine("Scegli l'operazione da svolgere");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1  SOMMA");
                Console.WriteLine("2  SOTTRAZIONE");                        
                Console.WriteLine("3  MOLTIPLICAZIONE");                                  
                Console.WriteLine("4  DIVISIONE");
                Console.WriteLine("5: FINE PROGRAMMA");
                Console.WriteLine("-------------------------------");

                scelta = Convert.ToInt32(Console.ReadLine());                  

                while (scelta != 1 & scelta != 2 & scelta != 3 & scelta != 4 & scelta != 5)
                {
                    Console.WriteLine("Scegliere un opzione tra quelle elencate sopra");          
                    scelta = Convert.ToInt32(Console.ReadLine());                                      
                }

                switch (scelta)
                {
                    case 1: Somma(ref num1, ref num2, out somma); break;
                    case 2: Sottrazione(ref num1, ref num2, out sottrazione); break;                  
                    case 3: Moltiplicazione(ref num1, ref num2, out moltiplicazione); break;            
                    case 4: Divisione(  ref num1, ref num2, out divisione); break;
                    case 5: ripetizione = false; break;
                }
            }
        }

        static void inserimento(ref double num1, ref double num2, string insTmp)    
        {
            Console.WriteLine("Inserire il primo numero");                 
            insTmp = Console.ReadLine();

            while (insTmp == "")
            {
                Console.WriteLine("Reinserire il numero");                       
                Console.ReadLine();                                 
                Console.Clear();                                            
                Console.WriteLine("Inserire un altro numero");
                insTmp = Console.ReadLine();
            }
            num1 = Convert.ToDouble(insTmp);
            Console.Clear();
            Console.WriteLine("Inserire il secondo numero");         
            insTmp = Console.ReadLine();                             

            while (insTmp == "")
            {
                Console.WriteLine("Reinserire il numero");
                Console.ReadLine();                                
                Console.Clear();
                Console.WriteLine("Inserire un altro numero");
                insTmp = Console.ReadLine();
            }
            num2 = Convert.ToDouble(insTmp);
            Console.Clear();
        }
        static void Somma( ref double num1, ref double num2, out double somma)        
        {
            Console.Clear();                            
            somma = num1 + num2;
            Console.WriteLine("il risultato è: " + somma);        
            Console.ReadLine();
        }

        static void Sottrazione( ref double num1, ref double num2, out double sottrazione)           

        {
            Console.Clear();                   
            sottrazione = num1 - num2;
            Console.WriteLine("il risultato è: " + sottrazione);           
            Console.ReadLine();
        }

        static void Moltiplicazione( ref double num1, ref double num2, out double moltiplicazione)       
        {
            Console.Clear();            
            moltiplicazione = num1 * num2;
            Console.WriteLine("il risultato è: " + moltiplicazione);            
            Console.ReadLine();
        }

        static void Divisione( ref double num1, ref double num2, out double divisione)   
        {
            Console.Clear();                
            while(num2==0)
            {
                Console.WriteLine("Inserire un altro numero");
                Console.WriteLine("Reinserire il secondo numero");         
                num2 = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
            }
            divisione = num1 / num2;
            Console.WriteLine("il risultato è: " + divisione);
            Console.ReadLine();                                             
            Console.Clear();                 
        }
    }
}