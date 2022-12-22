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
            ricaribile,
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
            Contratto id = new Contratto();
            const int ncont = 3;                //numero di contratti inseriti 
            bool quit = false;
            Contratto[] archivio = new Contratto[ncont];
            int nContratti = 0;
            string[] opzioni = { "Inserimento", "Visualizza", "Modifica saldo", "Modifica abbonamento" , "Fine" };
            do
            {
                switch (Scelta(opzioni))
                {
                    case 1:
                        if(nContratti < ncont)
                        {
                            Lettura(out id);
                            if(Ricerca(archivio, id , nContratti))
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
                            Console.WriteLine("Archivio completo: non si possono più stipulare contratti");
                        }
                        
                        break;
                    case 2: ShowContatto(id); break;
                    case 3: ModSaldo(ref id);break;
                    case 4: ModAbb(ref id); break;
                    case 5:; quit = true; break;
                        default: Scelta(opzioni); break;
                }
                Console.ReadLine();
            } while (!quit);
            Console.ReadLine();
        }
        static bool Ricerca(Contratto[] archivio, Contratto id, int nContratti)
        {
            //bool trovato = false;
            int i;
            for (i = 0; i < nContratti && !(archivio[i].nCell == id.nCell); i++)
                ; ;
            return i == nContratti && nContratti != 0;
        }

        static void Menu(string[] opz)
        {
            Console.WriteLine("Menu");
            for (int i = 0; i < opz.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {opz[i]}");
            }
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

            okabb = false;
            
            do
            {
                Console.Clear();
                Console.WriteLine("scegliere il tipo di abbonamento , 1.ricaricabile , 2.abbonamento");
                scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1": id.cAbbonamento = tAbbonamento.ricaribile; break;
                    case "2": id.cAbbonamento = tAbbonamento.abbonamento; break;
                    default: okabb = true; break;
                }
            } while (okabb);
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
            Console.Clear();
            Console.WriteLine("Nome:" + vis.nome);
            Console.WriteLine("Cognome:" + vis.cognome);
            Console.WriteLine("Numero:" + vis.nCell);
            Console.WriteLine("Saldo:" + vis.credito);
            Console.WriteLine("Abbonamento:" + vis.cAbbonamento.ToString());

        }
        static void ModSaldo(ref Contratto mod)
        {
            Console.Clear();
            Console.WriteLine("Inserire nuovo saldo: ");
            double.TryParse(Console.ReadLine(), out mod.credito);
            Console.WriteLine("Il nuovo credito è di: " + mod.credito);
        }
        static void ModAbb(ref Contratto con)
        {
            string scelta;
            Console.WriteLine("scegliere il tipo di abbonamento , 1.ricaricabile , 2.abbonamento");
            scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1": con.cAbbonamento = tAbbonamento.ricaribile; break;
                case "2": con.cAbbonamento = tAbbonamento.abbonamento; break;
            }
        }
        
    }
}