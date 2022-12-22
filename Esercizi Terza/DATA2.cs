using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Program
    {
        static void Main()
        {
            int giorni = 0;
            int mesi = 0;
            int anno = 0;
            Inserimento(ref giorni, ref mesi, ref anno);
            ConversioneData(ref giorni,ref mesi, ref anno);
        }
        static void Inserimento(ref int giorni, ref int mesi, ref int anno)
        {
            Console.WriteLine("Inserire il giorno:");
            giorni = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserire il numero del mese:");
            mesi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserire l'anno:");
            anno = Convert.ToInt32(Console.ReadLine());
        }
        static void ConversioneData(ref int giorni, ref int mesi, ref int anno)
        {
            
            Console.Clear();
            if (giorni > 0 && giorni < 32)
            {
                if (mesi >= 1 && mesi <= 12)
                {
                    Console.Write(giorni);
                    if (mesi == 1)
                    {
                        Console.Write("Gennaio");
                    }
                    if (mesi == 2)
                    {
                        Console.Write(" Febbraio ");
                    }
                    if (mesi == 3)
                    {
                        Console.Write(" Marzo ");
                    }
                    if (mesi == 4)
                    {
                        Console.Write(" Aprile ");
                    }
                    if (mesi == 5)
                    {
                        Console.Write(" Maggio ");
                    }
                    if (mesi == 6)
                    {
                        Console.Write(" Giugno ");
                    }
                    if (mesi == 7)
                    {
                        Console.Write(" Luglio ");
                    }
                    if (mesi == 8)
                    {
                        Console.Write(" Agosto ");
                    }
                    if (mesi == 9)
                    {
                        Console.Write(" Settembre ");
                    }
                    if (mesi == 10)
                    {
                        Console.Write(" Ottobre ");
                    }
                    if (mesi == 11)
                    {
                        Console.Write(" Novembre ");
                    }
                    if (mesi == 12)
                    {
                        Console.Write(" Dicembre ");
                    }
                }
                else
                {
                    Console.WriteLine("E' stato inserito un mese sbagliato, rimettere la data");
                    Main();
                }
            }
            else
            {
                Console.WriteLine("E' stato inserito un giorno sbagliato, rimettere la data");
                Main();
            }
            Console.Write(anno);
            Console.ReadLine();
        }
    }
}