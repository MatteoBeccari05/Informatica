using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numerobin2
{
    class Program
    {
        static bool ripetizione = false;
        static string esadecNum;
        static int selezione;

        static int numero;
        static void Main(string[] args)
        {
            int scelta = 0;
            while (ripetizione == false)
            {
                Console.WriteLine("Scegli l'operazione da svolgere");
                Console.WriteLine("1  CONVERSIONE BINARIO DECIMALE");
                Console.WriteLine("2  CONVERSIONE DECIMALE BINARIO");
                Console.WriteLine("3  CONVERSIONE DECIMALE ESADECIMALE");
                Console.WriteLine("4  CONVERSIONE ESADECIMALE DECIMALE");
                Console.WriteLine("===============================");

                scelta = Convert.ToInt32(Console.ReadLine());
                while (scelta != 1 & scelta != 2 & scelta != 3 & scelta != 4)
                {
                    Console.WriteLine("Errore. Scelta non valida. Scegliere tra le opzioni che ci sono");
                    scelta = Convert.ToInt32(Console.ReadLine());
                }

                switch (scelta)
                {
                    case 1: BinDec(); break;
                    case 2: DecBin(); break;
                    case 3: DecEsa(); break;
                    case 4: EsaDec(); break;
                }
                
                ripetizione = true;
            }
            while (ripetizione == true)
            {
                Console.WriteLine("Scegli l'operazione da svolgere");
                Console.WriteLine("1  CONVERSIONE BINARIO DECIMALE");
                Console.WriteLine("2  CONVERSIONE DECIMALE BINARIO");
                Console.WriteLine("3  CONVERSIONE DECIMALE ESADECIMALE");
                Console.WriteLine("4  CONVERSIONE ESADECIMALE DECIMALE");
                Console.WriteLine("5  FINE PROGRAMMA");
                Console.WriteLine("===============================");

                scelta = Convert.ToInt32(Console.ReadLine());

                while (scelta != 1 & scelta != 2 & scelta != 3 & scelta != 4 & scelta != 5)
                {
                    Console.WriteLine("Scegliere un opzione tra quelle elencate sopra");
                    scelta = Convert.ToInt32(Console.ReadLine());
                }

                switch (scelta)
                {
                    case 1: BinDec(); break;
                    case 2: DecBin(); break;
                    case 3: DecEsa(); break;
                    case 4: EsaDec(); break;
                    case 5: ripetizione = false; break;
                }
                Console.Clear();

                if (selezione < 1 || selezione > 5)
                {
                    Console.WriteLine("INSRIRE UN VALORE TRA QUELLI DISPONIBILI ");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Inserire il numero da convertire: ");
                    if (selezione == 3)
                    {
                        esadecNum = Console.ReadLine();
                    }
                    numero = Convert.ToInt32(Console.ReadLine());
                }

            }
        }
        static void BinDec()
        {
            long numeroBin;
            long NumDecimale = 0;
            long base1 = 1;

            Console.Write("Inserisci il numero binario: ");
            numeroBin = Convert.ToInt64(Console.ReadLine());

            while (numeroBin > 0)
            {
                long r = numeroBin % 10;
                numeroBin = numeroBin / 10;
                Convert.ToInt64(numeroBin);
                Convert.ToInt64(r);
                Convert.ToInt64(base1);
                NumDecimale += r * base1;
                base1 = base1 * 2;
            }

            if (NumDecimale <= 255)
            {
                Console.WriteLine("Il valore inserito è un byte");
                Console.WriteLine($"Valore Decimale: {NumDecimale} ");

            }
            else
            {
                Console.WriteLine("Il valore inserito non è un byte");
                Console.WriteLine("Non è possibile convertire il valore");
            }
            Console.WriteLine("Premere invio per far ripartire il programma");
            Console.ReadLine();
            Console.Clear();
        }

        static void DecBin()
        {
            int numero;
            string binario;

            Console.Write("Inserisci il numero decimale:");
            numero = Convert.ToInt32(Console.ReadLine());
            binario = Convert.ToString(numero, 2);

            Console.WriteLine("Il numero binario di {0} è: {1}", numero, binario);
            Console.WriteLine("Premere invio per far ripartire il programma");
            Console.ReadLine();
            Console.Clear();
        }
        static void EsaDec()
        {

            string copiaNumero = esadecNum;
            int risult = 0;

            for (int i = 0; i < copiaNumero.Length; i++)
            {
                int valore;

                switch (copiaNumero[i])
                {
                    case 'A': valore = 10; break;
                    case 'B': valore = 11; break;
                    case 'C': valore = 12; break;
                    case 'D': valore = 13; break;
                    case 'E': valore = 14; break;
                    case 'F': valore = 15; break;
                    default: valore = Convert.ToInt32(copiaNumero[i]); break;
                }
                risult += valore * (int)Math.Pow(16, copiaNumero.Length - 1 - i);
            }

        }
        static void DecEsa()
        {
            int copiaNumero = numero;
            int resto = 0;
            string risultato = "", lettera = "";

            if (copiaNumero >= 0 && copiaNumero <= 255)
            {
                while (copiaNumero != 0)
                {
                    resto = copiaNumero % 16;
                    copiaNumero = copiaNumero / 16;

                    if (resto > 9)
                    {
                        switch (resto)
                        {
                            case 10:
                                lettera = "A";
                                break;
                            case 11:
                                lettera = "B";
                                break;
                            case 12:
                                lettera = "C";
                                break;
                            case 13:
                                lettera = "D";
                                break;
                            case 14:
                                lettera = "E";
                                break;
                            case 15:
                                lettera = "F";
                                break;
                        }
                        risultato = lettera + risultato;
                    }
                    else
                        risultato = resto + risultato;
                }
            }
            else
            {
                risultato = "errore";
            }


        }
    }
}