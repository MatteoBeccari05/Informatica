using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendario_1
{
    internal class Program
    {
        struct Evento
        {
            public string id;
            public string inizio;
            public string fine;
            public string descrizione;
            public bool promemoria;
            public string titolo;
        }
        enum Giorni
        {
            lunedi,
            martedi,
            mercoledi,
            giovedi,
            venerdi,
            sabato,
            domenica
        }
        enum Mesi
        {
            gennaio, 
            febbraio,
            marzo,
            aprile,
            maggio,
            giugno,
            luglio,
            agosto,
            settembre,
            ottobre,
            novembre,
            dicembre
        }

        static void Main(string[] args)
        {
            int anno = 0;
            int mese = 0;
            int[,] calendario = new int[6, 7];
            Console.Write("Inserisci l'anno:  ");
            anno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Inserisci il mese: ");
            mese = Convert.ToInt32(Console.ReadLine());

            Intestazione(mese, anno);
            RiempiCalendario(anno, mese, calendario);
            ScriviCalendario(calendario);
            Console.ReadLine();
        }
        static void Intestazione(int mese, int anno)
        {
            Console.Clear();
            if (mese == 1)
            {
                Console.WriteLine("  Gennaio " + anno);
            }
            if (mese == 2)
            {
                Console.WriteLine("  Febbraio " + anno);
            }
            if (mese == 3)
            {
                Console.WriteLine("  Marzo " + anno);
            }
            if (mese == 4)
            {
                Console.WriteLine("  Aprile " + anno);
            }
            if (mese == 5)
            {
                Console.WriteLine("  Maggio " + anno);
            }
            if (mese == 6)
            {
                Console.WriteLine("  Giugno " + anno);
            }
            if (mese == 7)
            {
                Console.WriteLine("  Luglio " + anno);
            }
            if (mese == 8)
            {
                Console.WriteLine("  Agosto " + anno);
            }
            if (mese == 9)
            {
                Console.WriteLine("  Settembre " + anno);
            }
            if (mese == 10)
            { 
                Console.WriteLine("  Ottobre " + anno);
            }
            if (mese == 11)
            {
                Console.WriteLine("  Novembre " + anno);
            }
            if (mese == 12)
            { 
                Console.WriteLine("  Dicembre " + anno);
            }
            Console.WriteLine("Lu Ma Me Gi Ve Sa Do");
        }
        static void RiempiCalendario(int anno, int mese, int[,] calendario)
        {
            int giorni = DateTime.DaysInMonth(anno, mese);
            int giornoCorrente = 1;
            for (int i = 0; i < calendario.GetLength(0); i++)
            {
                for (int j = 0; j < calendario.GetLength(1) && giornoCorrente <= giorni; j++)
                {
                    if (i == 0 && mese > j)
                    {
                        calendario[i, j] = 0;
                    }
                    else
                    {
                        calendario[i, j] = giornoCorrente;
                        giornoCorrente++;
                    }
                }
            }
        }
        static void ScriviCalendario(int[,] calendario)
        {
            for (int i = 0; i < calendario.GetLength(0); i++)
            {
                for (int j = 0; j < calendario.GetLength(1); j++)
                {
                    if (calendario[i, j] > 0)
                    {
                        if (calendario[i, j] < 10)
                        {
                            Console.Write(" " + calendario[i, j] + " ");
                        }
                        else
                        {
                            Console.Write(calendario[i, j] + " ");
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}