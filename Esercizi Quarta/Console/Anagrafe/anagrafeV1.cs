using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrafe
{
    class Program
    {
        /// <summary>
        /// Enum per il sesso della persona
        /// </summary>
        enum Sesso
        {
            Maschio,
            Femmina
        }

        /// <summary>
        /// Enum per i vari stati civili che può assumere una persona
        /// </summary>
        enum StatoCivile
        {
            Celibe,
            Nubile,
            Coniugato,
            Divorziato,
            Separato
        }

        enum Stato
        {
            Libero, Occupato, Cancellato
        }


        /// <summary>
        /// Struct persona dove sono inseriti tutti i parametri che può avere una persona
        /// </summary>
        struct Persona
        {
            public string nome;
            public string cognome;
            public DateTime dataNascita;
            public int eta;
            public int etaNoDT;
            public string luogoNascita;
            public string codiceCatastale;
            public Sesso sesso;
            public StatoCivile statoCivile;
            public string cittadinanza;
            public string codiceFiscale;
            public Stato stato;
        }
        static void Main(string[] args)
        {
            const int nCont = 3;
            bool quit = false;
            int x = 7;
            int y = 2;
            int contatore = 0;
            const string TITOLO = "===== Anagrafe di Rovigo =====";
            ConsoleColor coloreforeground = ConsoleColor.Green;     //colore testo
            ConsoleColor coloreback = ConsoleColor.Black;           //colore sfondo 
            string[] opzioni = { "Inserimento", "Modifica", "Visualizza", "Visualizza Età", "Elimina", "Chiudi" };
            Persona[] cittadini = new Persona[nCont];
            Persona cittadino = new Persona();
            do
            {
                switch (Scelta(opzioni, TITOLO, x, y, coloreforeground, coloreback))
                {
                    case 1:
                        if (contatore < nCont)
                        {
                            if (cittadini[contatore].stato != Stato.Occupato)
                            {
                                Lettura(out cittadino, x, y);
                                if (ControlloCodice(cittadini, cittadino, contatore))
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine("Codice fiscale già presente, impossibile inserire la persona");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    cittadini[contatore] = cittadino;
                                    cittadini[contatore].stato = Stato.Occupato;
                                    contatore++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Impossibile inserire altre persone");
                                Console.ReadLine();
                            }
                            
                        }
                        break;

                    case 2:
                        if (contatore > 0)
                        {
                            Modifica(cittadini, cittadino);
                        }
                        else
                        {
                            Console.Clear();
                            Console.SetCursorPosition(x, y);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Non ci sono persone da modificare");
                            Console.ReadLine();
                        }
                        break;

                    case 3:
                        if (contatore > 0)
                        {
                            Visualizza(cittadini);
                        }
                        else
                        {
                            Console.Clear();
                            Console.SetCursorPosition(x, y);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Nessuna persona da visualizzare");
                            Console.ReadLine();
                        }
                        break;

                    case 4:
                        if (contatore > 0)
                        {
                            Eta(cittadini);
                        }
                        else
                        {
                            Console.Clear();
                            Console.SetCursorPosition(x, y);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Nessuna persona da visualizzare");
                            Console.ReadLine();
                        }
                        break;

                    case 5:
                        if (contatore > 0)
                        {
                            if (Elimina(cittadini))
                            {
                                
                                contatore--;
                                cittadini[contatore].stato = Stato.Cancellato;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(x, y);
                            Console.WriteLine("Non ci sono persone da eliminare");
                            Console.ReadLine();
                        }
                        break;

                    case 6: Esci(); break;
                }

            } while (!quit);

            Console.ReadLine();
        }

        /// <summary>
        /// Metodo che stampa il menù di scelta e ritorna la scelta dell'utente
        /// </summary>
        /// <param name="opz"></param>
        /// <param name="intestazione"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="coloreforeground"></param>
        /// <param name="colorebackground"></param>
        /// <returns></returns>
        static int Scelta(string[] opz, string intestazione, int x, int y, ConsoleColor coloreforeground, ConsoleColor colorebackground)
        {
            int scelta = 0;

            do
            {
                x = 7;
                y = 2;
                Console.Clear();
                Console.ForegroundColor = coloreforeground;
                Console.BackgroundColor = colorebackground;
                Console.SetCursorPosition(x, y++);
                Console.WriteLine(intestazione);
                for (int i = 0; i < opz.Length; i++)
                {
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine($"({i + 1}) {opz[i]}");
                }
                Console.SetCursorPosition(x, y++);
                Console.WriteLine("==============================");
                Console.SetCursorPosition(x, y++);
                Console.Write("Scegli un'opzione: ");
                try
                {
                    Controlla(out scelta, opz.Length, x, y);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }

            } while (scelta > opz.Length + 1 || scelta == 0);

            return scelta;
        }

        /// <summary>
        /// Metodo che controlla la scelta dell'utente nel menù
        /// </summary>
        /// <param name="opzione"></param>
        /// <param name="range"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <exception cref="Exception"></exception>
        static void Controlla(out int opzione, int range, int x, int y)    //controllo le scelte del menù
        {
            opzione = 0;
            if (!int.TryParse(Console.ReadLine(), out opzione))
            {
                Console.SetCursorPosition(x, y);
                throw new Exception("Tipo errato");
            }
            else
            {
                if ((opzione < 0 || opzione > range))
                {
                    Console.SetCursorPosition(x, y);
                    throw new Exception("Scelta errata");
                }
            }
        }

        /// <summary>
        /// Metodo che inserisce una persona (scelta da utente) nell'anagrafe
        /// </summary>
        /// <param name="cittadino"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        static void Lettura(out Persona cittadino, int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            int sceltaStato;
            string sceltaSesso;
            bool okdata;
            cittadino = new Persona();


            do   //inserimento nome
            {
                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write("Inseire il nome: ");
                cittadino.nome = Console.ReadLine();

            } while (cittadino.nome == "");

            do   //inserimento cognome
            {
                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write("Inseire il cognome: ");
                cittadino.cognome = Console.ReadLine();

            } while (cittadino.cognome == "");


            do   //inserimento data di nascita
            {
                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write("Inserire la data di nascita (gg/mm/aaaa): ");
                cittadino.dataNascita = new DateTime();
                okdata = DateTime.TryParse(Console.ReadLine(), out cittadino.dataNascita);

            } while (cittadino.dataNascita.ToString() == null && okdata == true);

            do     //inserimento sesso 
            {
                Console.Clear();
                Console.WriteLine("Inserire il sesso:");
                Console.WriteLine("1) Maschio ");
                Console.WriteLine("2) Femmina ");
                Console.Write("Scelta: ");
                sceltaSesso = Console.ReadLine();

                switch (sceltaSesso)
                {
                    case "1": cittadino.sesso = Sesso.Maschio; break;
                    case "2": cittadino.sesso = Sesso.Femmina; break;
                }

            } while (sceltaSesso != "1" && sceltaSesso != "2");

            do     //inserimento stato civile
            {
                Console.Clear();
                Console.WriteLine("Inserire lo stato civile:");
                Console.WriteLine("1) Celibe");
                Console.WriteLine("2) Nubile");
                Console.WriteLine("3) Coniugato");
                Console.WriteLine("4) Divorziato");
                Console.WriteLine("5) Separato");
                Console.Write("Scelta: ");
                bool ok = int.TryParse(Console.ReadLine(), out sceltaStato);

                if (ok)
                {
                    switch (sceltaStato)
                    {

                        case 1: cittadino.statoCivile = StatoCivile.Celibe; break;
                        case 2: cittadino.statoCivile = StatoCivile.Nubile; break;
                        case 3: cittadino.statoCivile = StatoCivile.Coniugato; break;
                        case 4: cittadino.statoCivile = StatoCivile.Divorziato; break;
                        case 5: cittadino.statoCivile = StatoCivile.Separato; break;
                    }
                }

            } while (sceltaStato != 1 && sceltaStato != 2 & sceltaStato != 3 && sceltaStato != 4 && sceltaStato != 5);

            do   //inserimento cittadinanza
            {
                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write("Inserire la cittadinanza: ");
                cittadino.cittadinanza = Console.ReadLine();

            } while (cittadino.cittadinanza == "");

            do   //inserimento luogo nascita
            {
                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write("Inserire il luogo di nascita: ");
                cittadino.luogoNascita = Console.ReadLine();

            } while (cittadino.luogoNascita == "");

            do   //inserimento codice catastale
            {
                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write("Inserire il codice catastale della città di nascita: ");
                cittadino.codiceCatastale = Console.ReadLine();

            } while (cittadino.codiceCatastale == "");

            cittadino.codiceFiscale = CalcoloCodiceFiscale(cittadino, cittadino.codiceCatastale);
        }

        /// <summary>
        /// Metodo che controlla che i codici fiscali non siano duplicati
        /// </summary>
        /// <param name="cittadini"></param>
        /// <param name="persona"></param>
        /// <param name="nPers"></param>
        /// <returns></returns>
        static bool ControlloCodice(Persona[] cittadini, Persona persona, int nPers)      //controllo i codici fiscali 
        {
            int i;

            for (i = 0; i < nPers && !(cittadini[i].codiceFiscale == persona.codiceFiscale); i++)
                ; ;
            return i == nPers - 1 && nPers != 0;
        }

        /// <summary>
        /// Metodo che visualizza l'intera anagrafe 
        /// </summary>
        /// <param name="cittadino"></param>
        static void Visualizza(Persona[] cittadino)             //visualizzazione di tutto l'array
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < cittadino.Length; i++)
            {
                Console.WriteLine("Cittadino numero: " + (i + 1));
                Console.WriteLine("Nome: " + cittadino[i].nome);
                Console.WriteLine("Cognome: " + cittadino[i].cognome);
                Console.WriteLine("Data di nascita: " + cittadino[i].dataNascita.ToShortDateString());
                Console.WriteLine("Luogo di nascita: " + cittadino[i].luogoNascita);
                Console.WriteLine("Sesso: " + cittadino[i].sesso.ToString());
                Console.WriteLine("Stato civile: " + cittadino[i].statoCivile.ToString());
                Console.WriteLine("Cittadinanza: " + cittadino[i].cittadinanza);
                Console.WriteLine("Codice Fiscale: " + cittadino[i].codiceFiscale);
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Metodo visualizza secondario per visualizzare solo Nome, Cognome e Stato civile
        /// </summary>
        /// <param name="cittadini"></param>
        static void VisualizzaModifica(Persona[] cittadini)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < cittadini.Length; i++)
            {
                Console.WriteLine("Cittadino numero: " + (i + 1));
                Console.WriteLine("Nome: " + cittadini[i].nome);
                Console.WriteLine("Cognome: " + cittadini[i].cognome);
                Console.WriteLine("Stato civile: " + cittadini[i].statoCivile.ToString());
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Metodo che modifica una persona
        /// </summary>
        /// <param name="cittadini"></param>
        /// <param name="cittadino"></param>
        static void Modifica(Persona[] cittadini, Persona cittadino)
        {
            int posizione;
            int scelta;
            bool controllo;
            Console.Clear();
            Console.WriteLine("Selezionare quale cittadino modificare");
            Console.WriteLine("\n");
            VisualizzaModifica(cittadini);
            Console.WriteLine("--------------------------------------");

            Console.Write("Inserire il numero del cittadino da modificare: ");
            controllo = int.TryParse(Console.ReadLine(), out posizione);

            try
            {
                if (cittadini[posizione - 1].stato == Stato.Occupato)
                {
                    if (controllo)
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Inserire lo stato civile:");
                            Console.WriteLine("1) Celibe");
                            Console.WriteLine("2) Nubile");
                            Console.WriteLine("3) Coniugato");
                            Console.WriteLine("4) Divorziato");
                            Console.WriteLine("5) Separato");
                            Console.Write("Scelta: ");
                            bool ok = int.TryParse(Console.ReadLine(), out scelta);

                            if (ok)
                            {
                                switch (scelta)
                                {

                                    case 1: cittadino.statoCivile = StatoCivile.Celibe; break;
                                    case 2: cittadino.statoCivile = StatoCivile.Nubile; break;
                                    case 3: cittadino.statoCivile = StatoCivile.Coniugato; break;
                                    case 4: cittadino.statoCivile = StatoCivile.Divorziato; break;
                                    case 5: cittadino.statoCivile = StatoCivile.Separato; break;
                                }
                            }

                        } while (scelta != 1 && scelta != 2 & scelta != 3 && scelta != 4 && scelta != 5);
                        cittadini[posizione - 1].statoCivile = cittadino.statoCivile;
                        Console.WriteLine("Persona modificata, premere invio per continuare");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Non puoi modificare, persona inesistente");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossibile modificare, premere invio per riprovare");
                Console.WriteLine("Errore: " + ex.Message);
                Console.ReadLine();
                Console.Clear();
                Modifica(cittadini, cittadino);
            }
        }

        /// <summary>
        /// Metodo che elimina le persone dall'anagrafe
        /// </summary>
        /// <param name="cittadini"></param>
        static bool Elimina(Persona[] cittadini)
        {
            Console.Clear();
            string codiceFiscale;

            Console.WriteLine("Inserire il codice fiscale della persona da rimuovere: ");
            codiceFiscale = Console.ReadLine();

            for (int i = 0; i < cittadini.Length; i++)
            {


                if (cittadini[i].codiceFiscale == codiceFiscale)
                {
                    cittadini[i] = new Persona();
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Metodo per il calcolo dell'età utilizzando il Date Time
        /// </summary>
        /// <param name="cittadini"></param>
        static void Eta(Persona[] cittadini)   //calcolo età tramite date time
        {
            DateTime oggi = DateTime.Today;
            for (int i = 0; i < cittadini.Length; i++)
            {
                cittadini[i].eta = oggi.Year - cittadini[i].dataNascita.Year;
                // Verifica se il compleanno è già avvenuto quest'anno
                if (oggi < cittadini[i].dataNascita.AddYears(cittadini[i].eta))
                {
                    cittadini[i].eta--;
                }
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < cittadini.Length; i++)
            {
                Console.WriteLine("Cittadino numero: " + (i + 1));
                Console.WriteLine("Nome: " + cittadini[i].nome);
                Console.WriteLine("Cognome: " + cittadini[i].cognome);
                Console.WriteLine("Stato civile: " + cittadini[i].statoCivile.ToString());
                Console.WriteLine("Età: " + cittadini[i].eta.ToString());
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Metodo per il calcolo dell'età senza l'utilizzo del date time
        /// </summary>
        /// <param name="cittadini"></param>
        static void Eta2(Persona[] cittadini)    //calcolo età senza date time
        {
            int anno;
            for (int i = 0; i < cittadini.Length; i++)
            {
                anno = Convert.ToInt32(cittadini[i].dataNascita.Year);
                cittadini[i].etaNoDT = 2023 - anno;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < cittadini.Length; i++)
            {
                Console.WriteLine("Cittadino numero: " + (i + 1));
                Console.WriteLine("Nome: " + cittadini[i].nome);
                Console.WriteLine("Cognome: " + cittadini[i].cognome);
                Console.WriteLine("Stato civile: " + cittadini[i].statoCivile.ToString());
                Console.WriteLine("Età: " + cittadini[i].etaNoDT.ToString());
                Console.WriteLine("\n");
            }
            Console.ReadLine();

        }

        /// <summary>
        /// Metodo per il calcolo codice fiscale
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="codiceCatastale"></param>
        /// <returns></returns>
        static string CalcoloCodiceFiscale(Persona persona, string codiceCatastale)
        {
            string CF = "";
            string vocali, consonanti;
            char[] nascita = { 'A', 'B', 'C', 'D', 'E', 'H', 'L', 'M', 'P', 'R', 'S', 'T' };
            // Aggiungo il cognome
            VocaliConsonanti(persona.cognome, out vocali, out consonanti);
            CF += (consonanti + vocali + "XX").Substring(0, 3);
            // Aggiungo il nome
            VocaliConsonanti(persona.nome, out vocali, out consonanti);
            if (consonanti.Length > 3)
            {
                CF += consonanti[0];
                CF += consonanti[2];
                CF += consonanti[3];
            }
            else
            {
                CF += (consonanti + vocali + "XX").Substring(0, 3);
            }
            // Aggiungo l'anno di nascita
            CF += persona.dataNascita.Year.ToString().Substring(2);
            // Aggiungo il mese di nascita
            CF += nascita[persona.dataNascita.Month - 1];
            // Aggiungo il giorno ed il sesso
            if (persona.sesso == Sesso.Femmina)
            {
                CF += (persona.dataNascita.Day + 40);
            }
            else
            {
                CF += persona.dataNascita.Day;
            }
            // Aggiungo il luogo di nascita
            CF += codiceCatastale;
            // Calcolo il carattere di controllo
            CF = CF.ToUpper();
            CF += Checksum(CF);
            return CF;
        }

        static void VocaliConsonanti(string str, out string vocali, out string consonanti)
        {
            vocali = "";
            consonanti = "";
            foreach (char c in str.ToLower())
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                {
                    vocali += c;
                }
                else if (c != ' ')
                {
                    consonanti += c;
                }
            }
        }

        static char Checksum(string CF)
        {
            short[] dispari = { 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 1, 0, 5, 7, 9, 13, 15, 17, 19, 21, 2, 4, 18, 20, 11, 3, 6, 8, 12, 14, 16, 10, 22, 25, 24, 23 };
            int checksum = 0;
            for (int i = 0; i < CF.Length; i++)
            {
                if (i % 2 == 0)
                {
                    checksum += dispari[ChecksumIndex(CF[i], false)];
                }
                else
                {
                    checksum += ChecksumIndex(CF[i], true);
                }
            }
            checksum %= 26;
            return (char)(checksum + 'A');
        }

        static int ChecksumIndex(char c, bool dispari)
        {
            int i;
            if (char.IsLetter(c))
            {
                i = c - 'A' + 10;
                if (dispari)
                {
                    i -= 10;
                }
            }
            else
            {
                i = c - '0';
            }
            return i;
        }

        /// <summary>
        /// Metodo per l'uscita dal programma
        /// </summary>
        static void Esci()
        {
            Environment.Exit(0);
        }
    }
}