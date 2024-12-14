using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Math;

namespace Lab5Part1
{
    internal class Program
    {
        static void Main()
        {

            double
                y,
                rowStep = 1,
                k = 0;
            int colls = 10,
                rows = 10;

            double collStep = rowStep / colls;

            decorationFont(true);
            Console.WriteLine("       " + buildBorder("top", colls));

            Console.Write("       ");
            for (double col = 0; col < colls; col++)
            {
                Console.Write($"│{col * collStep,7:F}");
            }
            Console.WriteLine("│");

            for (double row = 0; row < rows; row++)
            {
                decorationFont(true);
                Console.Write("───────");
                decorationFont(false);
                Console.WriteLine(buildBorder("middle", colls));
                decorationFont(true);
                Console.Write($"{row * rowStep,7:F}");
                decorationFont(false);
                for (double col = 0; col < colls; col++)
                {
                    k = row * rowStep + col * collStep;
                    Console.Write($"│{k,7:F}");
                }
                Console.WriteLine("│");
            }

            Console.WriteLine("       " + buildBorder("bottom", colls));
            void decorationFont(bool value)
            {
                if (value)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

            String buildBorder(String position, int cellQuantity, int cellSize = 7)
            {

                String[,] ch = {
                    { "┌", "┬", "┐" },
                    { "├", "┼", "┤" },
                    { "└", "┴", "┘" }
                };

                byte indexPosition = 0;

                if (position == "top")
                {
                    indexPosition = 0;
                }
                else if (position == "middle")
                {
                    indexPosition = 1;
                }
                else if (position == "bottom")
                {
                    indexPosition = 2;
                }

                StringBuilder str = new StringBuilder("");
                str.Append("");
                for (int cell = 0; cell < cellQuantity; cell++)
                {
                    for (int i = 0; i < cellSize; i++)
                    {
                        str.Append("─");
                    }
                    str.Append(ch[indexPosition, 1]);
                }
                str.Insert(0, ch[indexPosition, 0]);
                str.Remove(str.Length - 1, 1);
                str.Insert(str.Length, ch[indexPosition, 2]);
                return str.ToString();
            }
        }
    }
}

