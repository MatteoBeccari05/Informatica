using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackConsole
{
    class Stack
    {
        int[] array;
        int stack_pointer;

        public Stack(int dimensione)
        {
            array = new int[dimensione];
            stack_pointer = -1;
        }
        public Stack()
        {
            array = new int[10];                //inizializzo lo stack a 10
            stack_pointer = -1;
        }

        public void Reset()         //resetto lo stack assegnando tutti gli elementi dell'array a 0
        {
            Array.Clear(array, 0, GetElementi);         //pulisco l'array in modo che tutti gli elementi vadano a 0 
        }

        public int GetElementi
        {
            get
            {
                int i;
                for (i = 1; i < array.Length && array[i] != 0; i++) ; ;             
                return i;
            }
        }

        public void Push(int push)          //metodo per eseguire il push 
        {
            if (!Pieno())
            {
                array[++stack_pointer] = push;
            }
            else
            {
                throw new Exception("Stack vuoto");
            }
        }

        public int ElementoCima       //trovo il primo elemento dell'array
        {
            get
            {
                if (GetElementi > 0)
                {
                    return array[0];
                }
                else
                {
                    return -1;
                }
            }
        }

        public int Pop()           
        {
            if (!Vuoto())
            {
                int pop = array[stack_pointer];
                stack_pointer--;
                return pop;
            }
            else
            {
                throw new Exception("Stack vuoto");             //se lo stack è vuoto mi ritorna un eccezzione
            }
        }

        public bool Pieno()
        {
            return stack_pointer == array.Length -1;            //controllo che lo stack sia pieno 
        }

        public bool Vuoto()
        {
            return stack_pointer == -1;                 //controllo ci siano elelementi nello stack
        }

        public void Visualizza()                //metodo per visualizzare gli elementi nell'array
        {
            
            if (GetElementi > 0)
            {
                Console.WriteLine("ELEMENTI: ");
                for (int i = 0; i < GetElementi ; i++)
                {
                    Console.Write(array[i] + " - ");
                }
                Console.WriteLine("\nPremere invio per tornare al menu'");
                Console.ReadLine();    
            }
            
            
        }
        
    }
}
