using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Friday
{
    class Program
    {
        static void Main(string[] args)
        {
            string prodotto;
            string blackFriday;
            string nuovoCliente;
            bool ripetiz;
            double prezzo;
            double prezzoFinale;
            double prezzoScontato;                                      
            double prezzoiva;
            double totSconto = 0;
            double iva = 0;
            double blackfriday = 0;
            int scontrini = 0;
            int totProdotti = 0;

            do
            {
                Console.WriteLine("BENVENUTO AL VIOLAZON");
                Console.WriteLine("Che prodotto vuoi acquistare?");                          
                prodotto = Console.ReadLine();
                Console.WriteLine("Inserire il prezzo del prodotto:");                          
                prezzo = Convert.ToDouble(Console.ReadLine());

                if (prezzo <= 0)
                {
                    Console.Write("Il prezzo non è corretto, inserirne un altro ");                
                    prezzo = Convert.ToDouble(Console.ReadLine());
                }

                iva = prezzo / 100 * 22;                                          
                prezzoiva = prezzo + iva;
                prezzoFinale = prezzoiva;                                             
                Console.Write("Oggi siamo nella settimana del blackfriday?");
                blackFriday = Console.ReadLine().ToUpper();                           

                if (blackFriday == "SI")
                {
                    blackfriday = prezzoiva / 100 * 10;
                    prezzoScontato = prezzoiva - blackfriday;                   
                    prezzoFinale = prezzoScontato;
                }

                scontrini = scontrini + 1;
                totProdotti = totProdotti + 1;                     

                Console.Clear();
                Console.WriteLine("(----------------VIOLAZON----------------)");
                Console.WriteLine("(------------CHIUSURA CASSA--------------)");
                Console.WriteLine($"Totale articoli            {totProdotti})");
                Console.WriteLine("(----------------------------------------)");
                Console.WriteLine($"(Totale parziale        {prezzoiva}$Euro)");                        
                Console.WriteLine($"(BlackFriday(-10%)    {blackfriday}$Euro)");
                Console.WriteLine("(----------------------------------------)");
                Console.WriteLine($"(Importo Totale      {prezzoFinale}$Euro)");
                Console.WriteLine($"(Scontrino n.                {scontrini})");
                Console.WriteLine("(---------------ARRIVEDERCI--------------)");

                Console.WriteLine("");
                Console.WriteLine("Vuoi acquistare un altro prodotto?");
                Console.WriteLine("SI per confermare");
                Console.WriteLine("NO per annullare e stampare lo scontrino finale");         
                nuovoCliente = Console.ReadLine().ToUpper();
                ripetiz = nuovoCliente == "SI";
                Console.Clear();

            } while (ripetiz);

            Console.WriteLine("(----------------VIOLAZON----------------)");
            Console.WriteLine("(------------CHIUSURA CASSA--------------)");
            Console.WriteLine($"Totale articoli            {totProdotti})");
            Console.WriteLine("(----------------------------------------)");
            Console.WriteLine($"(Totale parziale        {prezzoiva}$Euro)");                           
            Console.WriteLine($"(BlackFriday(-10%)    {blackfriday}$Euro)");
            Console.WriteLine("(----------------------------------------)");
            Console.WriteLine($"(Importo Totale      {prezzoFinale}$Euro)");
            Console.WriteLine($"(Scontrino n.                {scontrini})");
            Console.WriteLine("(---------------ARRIVEDERCI--------------)");
            Console.ReadLine();
            
            if (ripetiz = nuovoCliente == "NO")
            {

                Console.WriteLine("(----------------VIOLAZON----------------)");
                Console.WriteLine("(------------CHIUSURA CASSA--------------)");
                Console.WriteLine($"Totale n° articoli        { totProdotti})");
                Console.WriteLine("(----------------------------------------)");                  
                Console.WriteLine($"(totale sconto               {totSconto})");
                Console.WriteLine($"(Totale incasso          {prezzoiva}$Eur)");
                Console.WriteLine($"(Scontrino n.                {scontrini})");
                Console.WriteLine("(---------------ARRIVEDERCI--------------)");


            }
        }
    }
}