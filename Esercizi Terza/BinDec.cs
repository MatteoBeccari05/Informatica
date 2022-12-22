using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int numeroDaConvertire, valoreConvertito;
        static bool valido=true;
        
        static void Main(string[] args)
        {
            Console.Write("Inserire un numero in base 2 da convertire in base 10: ");
            numeroDaConvertire = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            while (numeroDaConvertire > 11111111 || numeroDaConvertire < 0)
            {
                Console.Write("Non è possibile convertire il numero inserito poichè non rientra nell'intervallo 0-255, inserire di nuovo: ");
                numeroDaConvertire = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
            Conversione_B2_B10();
           
            if (!valido) 
                Console.Write("Il numero inserito non è corretto");
          
            else
                Console.Write("Il numero è stato convertito in base 10: " + valoreConvertito);
            Console.ReadLine();
        }
        static void Conversione_B2_B10()
        {
            int posizioneCifra = 0;
            
           
            do
            {
                
                valido = numeroDaConvertire % 10 <2;
                
                if (numeroDaConvertire % 10 == 1)
                        valoreConvertito += (int)Math.Pow(2, posizioneCifra);
                    
                    numeroDaConvertire /= 10;
                    
                    posizioneCifra++;
                
            } while (valido && numeroDaConvertire > 0);
        }
    }
}