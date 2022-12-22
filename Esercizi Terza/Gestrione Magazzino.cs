using System;



struct Prodotto
{
    public int codice;
    public string descrizione;
    public double quantità;
    public double prezzo;
}

namespace GestioneMagazzino
{
    class Program
    {
        static void Main(string[] args)
        {
            const int dimensione = 3;
            Prodotto[] magazzino = new Prodotto[dimensione];
            string[] opzioni = { "Inserimento", "Visualizza", "Rimuovi", "Ricerca", "Modifica", "Fine" };
            string[] possibilita = { "prezzo", "quantità" };
            bool uscita = false;
            int scelta;
            int contatore = 0;
            bool doppio = false;

            do
            {
                scelta = Menù(40, 10, opzioni, 20, '*');

                switch (scelta)
                {
                    case 1:
                        Prodotto articolo;
                        if (contatore < dimensione)
                        {
                            Inserimento(out articolo, false);
                            if (!RicercaP(magazzino, articolo, dimensione))
                            {
                                magazzino[contatore] = articolo;
                                contatore++;
                            }
                            else
                                Console.WriteLine("Articolo già presente");
                            
                        }
                        else
                        {
                            Console.WriteLine("Magazzino pieno");
                        }
                        break;
                    case 2:
                        Visualizza(magazzino, dimensione); break;
                    case 3: Rimuovi(magazzino); break;
                    case 4: Ricerca(magazzino); break;
                    case 5: Inserimento(out articolo, true);
                            if (FindPos(magazzino, articolo, dimensione) != -1)
                            {
                            
                            if (Menù(40, 10, possibilita, 20, '*') == 1)
                            {
                                Console.WriteLine("Inserisci nuovo prezzo");
                                magazzino[FindPos(magazzino, articolo, dimensione)].prezzo = double.Parse(Console.ReadLine());
                            }
                            else
                            {
                                Console.WriteLine("Inserisci nuova quantità di merce");
                                magazzino[FindPos(magazzino, articolo, dimensione)].quantità = int.Parse(Console.ReadLine());
                            }
                        }
                            ; break;
                    default: break;
                }
                Console.ReadLine();
            } while (!uscita);
        }

        static void Inserimento(out Prodotto articolo, bool VisCod)
        {
            articolo = new Prodotto();

            Console.Write("Inserisci il codice dell'articolo: ");
            articolo.codice = int.Parse(Console.ReadLine());
            if (!VisCod)
            {
                Console.Write("Inserisci la descrizione dell'articolo: ");
                articolo.descrizione = Console.ReadLine();

                Console.Write("Inserisci la quantità dell'articolo: ");
                articolo.quantità = double.Parse(Console.ReadLine());

                Console.Write("Inserisci il prezzo dell'articolo: ");
                articolo.prezzo = double.Parse(Console.ReadLine());
            }

        }

        static void Visualizza(Prodotto[] magazzino, int dimensione)
        {
            bool prodotti = false;

            Console.Clear();
            for (int i = 0; i < dimensione && magazzino[i].codice != 0; i++)
            {
                Console.WriteLine("\n\nProdotto n. " + (i + 1));
                Console.WriteLine($"Codice: {magazzino[i].codice}");
                Console.WriteLine($"Descrizione: {magazzino[i].descrizione}");
                Console.WriteLine($"Quantità: {magazzino[i].quantità} ");
                Console.WriteLine($"Prezzo: {magazzino[i].prezzo}");
                prodotti = true;
            }
            if (!prodotti)
                Console.WriteLine("Non ci sono ancora prodotti nel magazzino");

        }

        static void Rimuovi(Prodotto[] magazzino)
        {
            int tmp;
            bool prodotti = false;

            Console.Clear();
            for (int i = 0; i < magazzino.Length && magazzino[i].codice != 0; i++)
            {
                Console.WriteLine("Prodotto n. " + (i + 1));
                Console.WriteLine(magazzino[i].descrizione + "\n");
                prodotti = true;
            }

            if (prodotti)
            {
                Console.WriteLine("\n \n");
                Console.WriteLine("Inserisci il numero del prodotto che vuoi rimuovere");
                tmp = Convert.ToInt32(Console.ReadLine());
                magazzino[tmp - 1].codice = 0;
            }
            else
                Console.WriteLine("Non ci sono ancora prodotti nel magazzino");
        }

        static void Ricerca(Prodotto[] magazzino)
        {
            int tmpInt;
            string tmpString;

            Console.Clear();
            Console.WriteLine("Eseguire la ricerca per descrizione(1) o per codice(2)");
            tmpInt = Convert.ToInt32(Console.ReadLine());
            switch (tmpInt)
            {
                case 1:
                    Console.WriteLine("\nInserire la descrizione che si vuole ricercare");
                    tmpString = Console.ReadLine();
                    Console.WriteLine("\n\nProdotto trovati:");
                    for (int i = 0; i < magazzino.Length && tmpString == magazzino[i].descrizione; i++)
                    {
                        Console.WriteLine($"Codice: {magazzino[i].codice}");
                        Console.WriteLine($"Descrizione: {magazzino[i].descrizione}");
                        Console.WriteLine($"Quantità: {magazzino[i].quantità} ");
                        Console.WriteLine($"Prezzo: {magazzino[i].prezzo}");
                    }
                    break;
                case 2:
                    Console.WriteLine("\nInserire il codice che si vuole ricercare");
                    tmpInt = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n\nProdotto trovati:");
                    for (int i = 0; i < magazzino.Length && tmpInt == magazzino[i].codice; i++)
                    {
                        Console.WriteLine($"Codice: {magazzino[i].codice}");
                        Console.WriteLine($"Descrizione: {magazzino[i].descrizione}");
                        Console.WriteLine($"Quantità: {magazzino[i].quantità} ");
                        Console.WriteLine($"Prezzo: {magazzino[i].prezzo}");
                    }
                    break;
                default: return;

            }
        }

        static bool RicercaP(Prodotto[] magazzino,Prodotto articolo, int dimensione)
        {
            bool presente = false;

            for (int i =0; i<dimensione && !presente; i++)  
                    presente = magazzino[i].codice == articolo.codice;
            
            return presente;

        }

        static int FindPos(Prodotto[] magazzino, Prodotto articolo, int dimensione)
        {
            int posizione = -1;
            bool presente = false;
            int i;

            for (i = 0; i < dimensione && !presente; i++)
                presente = magazzino[i].codice == articolo.codice;

            if (presente)
                posizione = --i;

            return posizione;
        }







        public static void DisegnaRiga(int x, int y, int dim, char car)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < dim; i++)
            {
                Console.Write(car);
            }
        }
        public static int Menù(int x, int y, string[] opz, int dim, char car)
        {
            int scelta = 0;
            int offset = 4;
            do
            {
                Console.Clear();
                DisegnaRiga(x, y, dim, car);
                for (int i = 0; i < opz.Length; i++)
                {
                    Console.SetCursorPosition(x + offset, ++y);
                    Console.WriteLine(i + 1 + "-" + opz[i]);
                }
                DisegnaRiga(x, ++y, dim, car);
                Console.WriteLine("");
                scelta = Convert.ToInt32(Console.ReadLine());
            } while (scelta < 1 && scelta > opz.Length);
            return scelta;
        }
    }
}
