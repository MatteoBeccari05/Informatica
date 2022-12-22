using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verifica_2603
{
    class Program
    {
        static void Main(string[] args)
        {
            int inserimento = 0;
            int[] vettore = new int[inserimento];
            CaricaVettori(out vettore, ref inserimento);
            VisualizzaVettore(ref vettore);
        }
        static void CaricaVettori(out int[] vettore, ref int inserimento)        
        {
            int numeri = 0;
            Console.WriteLine("Inserire la capienza del vettore:");
            int j = int.Parse(Console.ReadLine());
            vettore = new int[j];
            Console.Clear();
            for (int i = 0; i < j; i++)
            {
                Console.WriteLine("Inserire i numeri da mettere nel vettore:");
                numeri = int.Parse(Console.ReadLine());
                Console.Clear();
                vettore[i] = numeri;
            }    
        }
        static void VisualizzaVettore(ref int[] vettore)     
        {
            Console.WriteLine("Vettore: ");
            foreach (int i in vettore)          
            {
                Console.Write(i + " ");
            }
            Console.ReadLine();
        } 
        static void Riordina()
        {

        }
    }
}