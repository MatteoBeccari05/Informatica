using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordinamenti
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringa;
            string tmp;
            int numero=0, l;

            Console.Write("Inserire il numero di parole da inserire: ");
            numero = Convert.ToInt32(Console.ReadLine());                       //chiedo all'utente quante parole desidera mettere
            stringa = new string[numero];
            Console.Write("Inserisci {0} stringhe :\n", numero);           
            for (int i = 0; i < numero; i++)                            //inserimento e lettura delle parole
            {
                stringa[i] = Console.ReadLine();
            }
            l = stringa.Length;

            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l - 1; j++)
                {
                    if (stringa[j].CompareTo(stringa[j + 1]) > 0)     //metto le parole in ordine alfabetico usando il metodo compare
                    {
                        tmp = stringa[j];
                        stringa[j] = stringa[j + 1];              //swap
                        stringa[j + 1] = tmp;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("\nPAROLE ORDINATE : \n");
            for (int i  = 0; i < l; i++)
            {
                Console.WriteLine(stringa[i] + " ");                 //scrivo le stringhe in ordine alfabetico
            }
            Console.ReadLine();
        }
       
       
    }
}