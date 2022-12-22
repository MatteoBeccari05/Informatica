using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Program
    {
        delegate void Compare(int a, int b);
        static void Main(string[] args)
        {
            Compare cp;
            Console.WriteLine("Inserire il primo numero");
            int num1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Inserire il secondo numero");
            int num2 = Int32.Parse(Console.ReadLine());
            cp = Maggiore;
            cp(num1,num2);
            cp=Minore; 
            cp(num1,num2);
            cp=Uguale; 
            cp(num1,num2);
        }

        static void Maggiore(int a, int b)
        {
            if (a > b)
            {
                Console.WriteLine("primo numero maggiore del secondo");
            }
        }

        static void Minore(int a, int b)
        {
            if (a < b)
            {
                Console.WriteLine("primo numero minore del secondo");
            }
        }

        static void Uguale(int a, int b)
        {
            if (a == b)
            {
                Console.WriteLine("numeri uguali");
            }
        }

    }
}
