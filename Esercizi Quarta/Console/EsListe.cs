using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES2510
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList myList = new ArrayList();
            myList.Add(1);
            myList.Add("ciao");
            myList.Add("Matteo");
            myList.Add(true);

            Console.WriteLine("CAPACITA' DELLA LISTA: ");         
            Console.WriteLine(myList.Capacity); ;                 //stampa la capacità della lista

            Console.WriteLine("\nELEMENTI NELLA LISTA:"); 
            Console.WriteLine(myList.Count);                     //stampa il numero di elementi nella lista

            Console.WriteLine("\nCONTENUTO DELLA LISTA:");       //stampo il contenuto della lista
            foreach (var i in myList)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();

            myList.ToArray();                 //Crea e ritorna un vettore contenente una copia di tutti gli elementi della lista

            myList.Sort();                    //riordina i valori nella lista

            myList.RemoveAt(3);             //Rimuove dalla lista il valore che si trova all’indice specificato

            myList.Remove("ciao");          //rimuove il valore specificato

            myList.Insert(4, "Valore");      //inserisce il valore dato alla posizione data

            myList.IndexOf(1);          //ritorna la posizione del valore specificato

            myList.BinarySearch(1);       //esegue una ricerca di tipo binario nella lista  

            myList.Clear();              //cancella tutti gli elementi della lista

        }
    }
}