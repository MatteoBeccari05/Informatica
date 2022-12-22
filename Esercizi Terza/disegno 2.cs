using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lezione180222
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tasto;
            char matita = '*';
            int x = 0, y = 0;
            bool scrivi = false;
            Console.WindowWidth = 120;
            Console.WindowHeight = 30;
            bool[,] autosalvataggio = new bool[Console.WindowWidth, Console.WindowHeight];
            bool[,] salvataggio = new bool[Console.WindowWidth, Console.WindowHeight];

            do
            {
                pannello(x, y, matita);
                tasto = Console.ReadKey(true);



                Console.SetCursorPosition(x, y);
                if (tasto.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Console.Write("Inserire il carattere da utilizzare per disegnare: ");
                    matita = Convert.ToChar(Console.ReadLine());
                    Console.Clear();
                }
                if (tasto.Key == ConsoleKey.F3)
                {
                    Salvataggio(salvataggio, autosalvataggio);
                    pannello(x, y, matita);
                }
                if (tasto.Key == ConsoleKey.F2)
                {
                    for (int i = 0; i < Console.WindowHeight - 1; i++)
                    {
                        for (int j = 0; j < Console.WindowWidth - 2; j++)
                        {
                            Console.SetCursorPosition(j, i);
                            if (salvataggio[i, j] == true)
                                Console.Write(matita);
                        }
                    }
                }
                if (tasto.Key == ConsoleKey.Insert && scrivi == false)
                {
                    scrivi = true;
                }
                else if (tasto.Key == ConsoleKey.Insert && scrivi == true)
                {
                    scrivi = false;
                }
                if (tasto.Key != ConsoleKey.Insert && scrivi == false)
                {
                    if (tasto.Key == ConsoleKey.RightArrow && x < Console.WindowWidth - 1)
                    {
                        Console.SetCursorPosition(x, y);
                        x++;
                    }
                    if (tasto.Key == ConsoleKey.LeftArrow && x > 0)
                    {
                        Console.SetCursorPosition(x, y);
                        x--;
                    }
                    if (tasto.Key == ConsoleKey.DownArrow && y < Console.WindowHeight - 2)
                    {
                        Console.SetCursorPosition(x, y);
                        y++;
                    }
                    if (tasto.Key == ConsoleKey.UpArrow && y > 1)
                    {
                        Console.SetCursorPosition(x, y);
                        y--;
                    }
                }
                if (tasto.Key != ConsoleKey.Insert && scrivi == true)
                {
                    if (tasto.Key == ConsoleKey.RightArrow && x < Console.WindowWidth - 1)
                    {
                        Console.SetCursorPosition(x, y);
                        x++;
                        Console.Write(matita);
                        autosalvataggio[x, y] = true;
                    }
                    if (tasto.Key == ConsoleKey.LeftArrow && x > 0)
                    {
                        Console.SetCursorPosition(x, y);
                        x--;
                        Console.Write(matita);
                        autosalvataggio[x, y] = true;
                    }
                    if (tasto.Key == ConsoleKey.DownArrow && y < Console.WindowHeight - 2)
                    {
                        Console.SetCursorPosition(x, y);
                        y++;
                        Console.Write(matita);
                        autosalvataggio[x, y] = true;
                    }
                    if (tasto.Key == ConsoleKey.UpArrow && y > 1)
                    {
                        Console.SetCursorPosition(x, y);
                        y--;
                        Console.Write(matita);
                        autosalvataggio[x, y] = true;
                    }
                }
            } while (tasto.Key != ConsoleKey.Escape);
        }
        static void pannello(int x, int y, char matita)
        {

            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(i, Console.WindowHeight - 2);
                Console.Write(" ");

            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nx:" + x + "   y:" + y + "      char:" + matita);
        }
        static void Salvataggio(bool[,] salvataggio, bool[,] autosalvataggio)
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    salvataggio[j, i] = autosalvataggio[j, i];
                }
            }
            Console.Clear();
        }
    }
}

