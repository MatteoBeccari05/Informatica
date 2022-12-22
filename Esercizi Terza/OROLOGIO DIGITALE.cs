using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace orologio_digitale
{
    class Program
    {
        static void Main(string[] args)
        {
            int secondi = 0;
            int ore = 0;
            int minuti = 0;

            for (int i = 0; i < 60; i++) 
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.Write($"{secondi}");
                secondi++;

            }
            for (int i = 0; i < 60; i++)
            {
                Thread.Sleep(59000);
                Console.Clear();
                Console.Write($"{minuti}");
                minuti++;

            }
            for (int i = 0; i < 24; i++) 
            {
                Thread.Sleep(3481000);
                Console.Clear();
                Console.Write($"{ore}");
                ore++;
            }
            //Console.WriteLine($"{secondi}  {minuti}  {ore}");
        }

    }
}
