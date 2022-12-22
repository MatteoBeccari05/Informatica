using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primo_progetto
{
    class Program
    {
        enum tAbbonamento
        {
            ricaricabile,
            abbonamento
        }
        struct Contratto
        {
            public string cognome, nome, nCell;
            public double credito;
            public tAbbonamento cAbbonamento;
        }
        static void Main(string[] args)
        {
            const int nCont = 3;
            bool quit = false;
            string[] opzioni = { "Inserimento", "Visualizza", "Modifica", "Cancella", "Fine" };
            int contatore = 0;
            Contratto id = new Contratto();
            Contratto[] archivio = new Contratto[nCont];
            do
            {
                switch (Scelta(opzioni))
                {
                    case 1:
                        if (contatore < nCont)
                        {
                            Lettura(out id);
                            if (Ricerca(archivio, id, contatore))
                                Console.WriteLine("numero già presente");
                            else
                            {
                                archivio[contatore] = id;
                                contatore++;
                            }
                        }
                        else
                            Console.WriteLine("Archivio completo: non si posso più stipulare contratti");
                        break;
                    case 2:
                        if (contatore > 0)
                            ShowContatto(archivio); break;
                    case 3:
                        if (contatore > 0)
                            modifica(ref archivio, id); break;
                    case 4:
                        if (contatore > 0)
                            CancellaContratto(archivio); break;
                    case 5: quit = true; break;

                }

            } while (!quit);
        }
        static void Menu(string[] opz)
        {
            Console.WriteLine("Menu");
            for (int i = 0; i < opz.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {opz[i]}");
            }
        }

        static bool Ricerca(Contratto[] archivio, Contratto id, int Ncontratti)
        {
            // bool trovato = false;
            int i;


            for (i = 0; i < Ncontratti && !(archivio[i].nCell == id.nCell); i++)
                ; ;
            return i == Ncontratti - 1 && Ncontratti != 0;
        }
        static int Scelta(string[] opz)
        {
            int scelta = 0;

            do
            {
                Console.Clear();
                Menu(opz);
                Console.WriteLine("Scegli un'opzione");
                try
                {
                    Controlla(out scelta, opz.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }

            } while (scelta > opz.Length + 1 || scelta == 0);

            return scelta;
        }

        static void Controlla(out int opzione, int range)
        {
            opzione = 0;
            if (!int.TryParse(Console.ReadLine(), out opzione))
                throw new Exception("Tipo errato");
            else
            {
                if ((opzione < 0 || opzione > range))
                    throw new Exception("Out of range");
            }

        }
        static void Lettura(out Contratto id)
        {
            string scelta;
            bool okcredito = false;
            bool okabb;
            string numtel;

            id = new Contratto();
            do
            {
                Console.Clear();
                Console.WriteLine("Inseire il nome");
                id.nome = Console.ReadLine();

            } while (id.nome == "");

            do
            {
                Console.Clear();
                Console.WriteLine("Inseire il cognome");
                id.cognome = Console.ReadLine();
            } while (id.cognome == "");

            Console.Clear();
            Console.WriteLine("Inserire numero di telefono");
            ReadTel(out numtel, 11);

            id.nCell = numtel;

            do
            {
                Console.Clear();
                Console.WriteLine("inserire saldo");
                okcredito = double.TryParse(Console.ReadLine(), out id.credito);


            } while (!okcredito);

            id.cAbbonamento = SceltaAbbonamento();
        }
        static void ReadTel(out string numtel, int dimtel)
        {
            char chrInp;

            numtel = "";
            do
            {
                chrInp = Console.ReadKey(true).KeyChar;
                if (char.IsDigit(chrInp) && numtel.Length < dimtel)
                {
                    Console.Write(chrInp);
                    numtel += Convert.ToString(chrInp);
                }
                else
                    Console.Beep();

            } while (chrInp != 13);
        }
        static void ShowContatto(Contratto[] archivio)
        {
            Console.Clear();
            for (int i = 0; i < archivio.Length; i++)
            {
                Console.WriteLine("CONTRATTO N° " + (i + 1));
                Console.WriteLine("Nome: " + archivio[i].nome);
                Console.WriteLine("Cognome: " + archivio[i].cognome);
                Console.WriteLine("Numero di cellulare: " + archivio[i].nCell);
                Console.WriteLine("Credito: " + archivio[i].credito);
                Console.WriteLine("Tipo di abbonamento: " + archivio[i].cAbbonamento.ToString());
                Console.WriteLine("\n\n");
            }
            Console.ReadLine();
        }
        static bool RicercaPos(Contratto[] archivio, string id, int Ncontratti, out int i)
        {
            for (i = 0; i < Ncontratti && !(archivio[i].nCell == id); i++)
                ; ;
            return archivio[i].nCell == id;
        }

        static tAbbonamento SceltaAbbonamento()
        {
            string scelta;
            bool okabb = false;
            tAbbonamento myAbb = tAbbonamento.ricaricabile;
            do
            {
                Console.Clear();
                Console.WriteLine("scegliere il tipo di abbonamento , 1.ricaricabile , 2.abbonamento");
                scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1": myAbb = tAbbonamento.ricaricabile; break;
                    case "2": myAbb = tAbbonamento.abbonamento; break;
                    default: okabb = true; break;


                }

            } while (okabb);
            return myAbb;
        }
        static void CancellaContratto(Contratto[] archivio)
        {
            int scelta;
            Console.Clear();
            Console.WriteLine("Digitare il numero del contratto da cancellare:");
            for (int i=0;i<archivio.Length;i++)
            {
                Console.WriteLine("Numero di cellulare: " + archivio[i].nCell);
            }

            while (!int.TryParse(Console.ReadLine(), out scelta))
            {
                Console.WriteLine("Reinserire contratto da cancellare");
            }
            archivio[scelta-1] = new Contratto();
        }
        static void modifica(ref Contratto[] archivio, Contratto id)
        {
            int posContr;
            bool okabb = false;
            string scelta;
            Console.Clear();
            Console.WriteLine("Selezionare quale contratto modificare");

            while (int.TryParse(Console.ReadLine(), out posContr))
            {
                Console.Clear();
                Console.WriteLine("selezione errata");
                Console.WriteLine("Selezionare quale contratto modificare");
            }

            do
            {
                Console.Clear();
                Console.WriteLine("Scegliere il tipo di abbonamento , 1.ricaricabile , 2.abbonamento");
                scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1": id.cAbbonamento = tAbbonamento.ricaricabile; break;
                    case "2": id.cAbbonamento = tAbbonamento.abbonamento; break;
                    default: okabb = true; break;
                }

            } while (okabb);
            archivio[posContr].cAbbonamento = id.cAbbonamento;
            bool okcredito = false;
            do
            {
                Console.Clear();
                Console.WriteLine("inserire saldo");
                okcredito = double.TryParse(Console.ReadLine(), out id.credito);


            } while (!okcredito);
            archivio[posContr].credito = id.credito;

        }

    }
}
