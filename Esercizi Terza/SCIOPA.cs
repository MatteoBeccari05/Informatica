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

            string[] opzioni = { "Inserimento", "Visualizza", "Modifica", "Cancella", "Visualizza Cancellati", "Fine" };
            // Contratto[] archivio = new Contratto[ncont];
            Contratto[] archivio = { new Contratto { nome = "A", cognome = "A", nCell = "1", cAbbonamento=tAbbonamento.ricaricabile, credito=12 },
            new Contratto { nome = "B", cognome = "B", nCell = "2", cAbbonamento=tAbbonamento.abbonamento, credito=20 },new Contratto { nome = "C", cognome = "C", nCell = "3", cAbbonamento=tAbbonamento.abbonamento, credito=20 }};
            Contratto[] cancellati = archivio;
            string numTel;
            int nContratti = 3;
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
                    case 4:
                        if (nContratti > 0)
                        {
                            Console.WriteLine("Inserisci il numero di telefono del contratto che vuoi cancellare");
                            ReadTel(out numTel, 11);
                            if (RicercaPos(archivio, numTel, nContratti, out i))
                            {
                                cancella(archivio, i, nContratti);
                                nContratti--;
                            }
                        }
                        else
                            Console.WriteLine("non sono stati inseriti contratti");
                        break;
                    case 5: Cancellati(cancellati, i = 0, nContratti, archivio); break;
                    case 6:; quit = true; break;
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
        //static bool Ricerca(  Contratto[]archivio, Contratto id, ref int Ncontratti )
        //{
        //    bool trovato=false;
        //   for(int i=0;i<Ncontratti&&!trovato;i++)
        //    {
        //        trovato = archivio[i].nCell == id.nCell;

        //    }



        //    return trovato;
        //}
        static bool Ricerca(Contratto[] archivio, Contratto id, int Ncontratti)
        {
            // bool trovato = false;
            int i;


            for (i = 0; i < Ncontratti && !(archivio[i].nCell == id.nCell); i++)
                ; ;
            return i == Ncontratti - 1 && Ncontratti != 0;
        }

        //Controllo con TryParse
        /*static int Scelta(string[]opz)
        {
            int scelta;
            string tmp;
            
            do
            {
                Console.Clear();
                Menu(opz);
                Console.WriteLine("Scegli un'opzione");
                if (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    Console.WriteLine("Tipo errato");
                    Console.ReadLine();

                }
                    
                else
                    if ((scelta < 0 || scelta > opz.Length))
                {
                    Console.WriteLine("Valore errato");
                    Console.ReadLine();
                }
            } while (scelta > opz.Length + 1 || scelta == 0);
     
            return scelta;
        }*/




        /*static int Scelta(string[]opz)
        {
            int scelta;
            
            do
            {
                Console.Clear();
                Menu(opz);
                Console.WriteLine("Scegli un'opzione");
                try
                {
                    scelta = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    scelta = 0;
                    Console.ReadLine();
                }
               
            } while (scelta > opz.Length + 1 || scelta == 0);
     
            return scelta;
        }*/


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
            //ritorna una stringa di max 11 caratteri 
            //utilizzando il readkey leggere i valori in input discriminando i numeri dalle cifre
            //la lettura di una cifra deve essere segnalata da un beep e non deve essere inserita nella stringa di output
            //la pressione del tasto invio determina l'acquisizione della stringa di input anche seil valore è inferiore ad 11 caratteri 
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
        static void cancella(Contratto[] archivio, int i, int nContratti)
        {
            for (int j = i; j < nContratti - 1; j++)
            {
                archivio[j] = archivio[j + 1];
            }

        }
        static void Cancellati(Contratto[] cancellati, int i, int nContratti, Contratto[] archivio)
        {
            for (int j = 0; j < cancellati.Length; j++)
            {
                Console.WriteLine("CONTRATTO N° " + (j + 1));
                Console.WriteLine("Nome: " + cancellati[j].nome);
                Console.WriteLine("Cognome: " + cancellati[j].cognome);
                Console.WriteLine("Numero di cellulare: " + cancellati[j].nCell);
                Console.WriteLine("Credito: " + cancellati[j].credito);
                Console.WriteLine("Tipo di abbonamento: " + cancellati[j].cAbbonamento.ToString());
                Console.WriteLine("\n\n");
            }
            Console.ReadLine();
            /*for (int j = i; j < nContratti - 1; j++)
            {
                Cancellati[j] = archivio[j + 1];
                archivio[j] = archivio[j + 1];
                Console.WriteLine(Cancellati[j]);
            }
            Console.ReadLine();*/
        }

    }
}
