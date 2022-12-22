using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordine_di_numeri
{
    class Program
    {
         static int[] numeri = new int[] { 10, 44, 33, 70, 32, 65, 19, 59, 2, 98, 43, 99, 14, 50 };
        static void Main(string[] args)
        {
            
            for (int i = 0; i < numeri.Length; i++)
            {
                Array.Sort(numeri);
            }
            scritturaarray();

        }
        static void scritturaarray()
        {
            Console.WriteLine("Array con i numeri in ordine: \n");
            foreach (int value in numeri)
            {
                Console.Write(value + " ");
                Console.ReadLine();
            }
        }
    }
}