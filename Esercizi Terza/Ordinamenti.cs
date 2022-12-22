using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordinamenti
{
    class Program
    {
        static int[] numeri_disordinati = new int[] { 60, 40, 30, 20, 9, 2 };
        static int contatore = 0;
        static void Main(string[] args)
        {
            menu();
            foreach (int i in numeri_disordinati)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Numeri cicli: " + contatore);
            Console.ReadLine();
        }
        static void menu()
        {
            string risposta;
            Console.WriteLine("Quale metodo vuoi scegliere Sort, Bubble sort e Insertion sort");
            risposta = Console.ReadLine();
            switch (risposta)
            {
                case "1": sort(); break;
                case "2": bubblesort(); break;
                case "3": insertionsort(); break;
            }
        }
        static void sort()
        {

            int tmp;
            contatore = 0;
            Console.WriteLine("Selection sort");
            Console.Write("Numeri ordinati: ");
            for (int i = 0; i < numeri_disordinati.Length; i++)
            {
                contatore++;
                for (int j = i + 1; j < numeri_disordinati.Length; j++)
                {
                    contatore++;
                    if (numeri_disordinati[j] < numeri_disordinati[i])
                    {
                        tmp = numeri_disordinati[i];
                        numeri_disordinati[i] = numeri_disordinati[j];
                        numeri_disordinati[j] = tmp;
                    }
                }
            }
        }
        static void bubblesort()
        {
            int tmp;
            bool continua = true;
            contatore = 0;
            Console.WriteLine("Bubble sort");
            Console.WriteLine("Numeri ordinati:");
            for (int i = 0; i < numeri_disordinati.Length && continua; i++)
            {
                contatore++;
                continua = false;
                for (int j = 0; j < (numeri_disordinati.Length - 1 - i); j++)
                {
                    contatore++;
                    if (numeri_disordinati[j] > numeri_disordinati[j + 1])
                    {
                        tmp = numeri_disordinati[j + 1];
                        numeri_disordinati[j + 1] = numeri_disordinati[j];
                        numeri_disordinati[j] = tmp;
                        continua = true;
                    }
                }
            }
        }
        static void insertionsort()
        {
            int tmp;
            int k;
            int j = 0;
            contatore = 0;
            Console.WriteLine("Insertion sort");
            Console.WriteLine("Numeri ordinati: ");

            for (int i = 1; i < numeri_disordinati.Length; i++)
            {
                k = numeri_disordinati[i];
                contatore++;
                for (j = i - 1; j >= 0 && k < numeri_disordinati[j]; j--)
                {
                    contatore++;
                    numeri_disordinati[j + 1] = numeri_disordinati[j];
                    //numeri_disordinati[j]= k;
                }
                if (i != j + 1)
                    numeri_disordinati[j + 1] = k;
            }
        }
    }
}

