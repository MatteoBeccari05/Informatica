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
            Contratto id;
            const int ncont = 3; //numero di contratti inseriti
            bool quit = false;

            string[] opzioni = { "Inserimento", "Visualizza", "Modifica", "Fine" };
            // Contratto[] archivio = new Contratto[ncont];
            Contratto[] archivio = { new Contratto { nome = "A", cognome = "A", nCell = "1", cAbbonamento=tAbbonamento.ricaricabile, credito=12 },
            new Contratto { nome = "B", cognome = "B", nCell = "2", cAbbonamento=tAbbonamento.abbonamento, credito=20 }};
            string numTel;
            int nContratti = 2;
            int i;
            do
            {
                switch (Scelta(opzioni))
                {
                    case 1:
                        if (nContratti < ncont)
                        {
                            Lettura(out id);

                            if (Ricerca(archivio, id, nContratti))
                            {
                                Console.WriteLine("Numero già presente");

                            }
                            else
                            {
                                archivio[nContratti] = id;
                                nContratti++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Archivio completo: non si possono più stipolare contratti");
                        }
                        break;
                    case 2: Visualizza(archivio, nContratti); break;
                    case 3:
                        Console.WriteLine("Inserisci il numero di telefono del contratto che vuoi cambiare");
                        ReadTel(out numTel, 11);
                        if (RicercaPos(archivio, numTel, nContratti, out i))
                        {
                            string[] opz = { "Abbonamento", "Credito" };
                            switch (Scelta(opz))
                            {
                                case 1:
                                    archivio[i].cAbbonamento = SceltaAbbonamento();
                                    break;
                                case 2:
                                    bool okcredito = false;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("inserire saldo");
                                        okcredito = double.TryParse(Console.ReadLine(), out archivio[i].credito);


                                    } while (!okcredito);
                                    break;
                            }
                        }
                            ; break;

                    case 4:; quit = true; break;
                        //default: Scelta(opzioni); break;
                }
                Console.ReadLine();
            } while (!quit);

            Console.ReadLine();

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
                Console.WriteLine("inseire il nome");
                id.nome = Console.ReadLine();

            } while (id.nome == "");

            do
            {
                Console.Clear();
                Console.WriteLine("inseire il cognome");
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
        static void ShowContatto(Contratto vis)
        {
            Console.WriteLine("Nome:" + vis.nome);
            Console.WriteLine("Cognome:" + vis.cognome);
            Console.WriteLine("Numero:" + vis.nCell);
            Console.WriteLine("Saldo:" + vis.credito);
            Console.WriteLine("Abbonamento:" + vis.cAbbonamento.ToString());

        }
        static void Visualizza(Contratto[] archivio, int nContratti)
        {
            for (int i = 0; i < nContratti; i++)
            {
                ShowContatto(archivio[i]);
            }
        }
        static bool RicercaPos(Contratto[] archivio, string id, int Ncontratti, out int i)
        {
            // bool trovato = false;


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

    }
}