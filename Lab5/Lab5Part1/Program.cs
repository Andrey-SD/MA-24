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
            int colls = 5,
                rows = 5;

            double collStep = rowStep / colls;

            String[,] ch = {
                { "┌", "┬", "┐" },
                { "├", "┼", "┤" },
                { "└", "┴", "┘" }
            };
            Console.WriteLine(collStep);
            Console.WriteLine(buildBorder("top", 3));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            decorationFont(true);
            
            //Console.WriteLine("       ┌───────┬───────┬───────┬───────┬───────┬───────┬───────┬───────┬───────┬───────┐");
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
                Console.WriteLine("├───────┼───────┼───────┼───────┼───────┼───────┼───────┼───────┼───────┼───────┤");
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
            Console.WriteLine("       └───────┴───────┴───────┴───────┴───────┴───────┴───────┴───────┴───────┘");

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

            String buildBorder(String position, int cellQuantity)
            {
                int cellSize = 7;
                StringBuilder str = new StringBuilder("");
                str.Append("");
                for (int cell = 0; cell < cellQuantity; cell++)
                {
                    for (int i = 0; i < cellSize; i++)
                    {
                        str.Append("─");
                    }
                    str.Append("┬");
                }
                str.Insert(0, "┌");
                str.Remove(str.Length-1, 1);
                str.Insert(str.Length, "┐");
                return str.ToString();
            }
            //Console.OutputEncoding = System.Text.Encoding.GetEncoding("CP437");
            ///28591
            /*Console.WriteLine(s1);
            Console.WriteLine("┌────────┬────────┬────────┬────────┬────────┬────────┬────────┬────────┐");


            byte i = 0, k = 0;
            for (double x = 0; x < 100.0 + t; x += 0.06)
            {
                y = Sin(x) * Exp(0.05 * x);
                //double y = 0.0;
                if (y < -t) Console.Write($"│{y:000.000}");
                else
                    Console.Write($"│{y:0000.000}");
                i++;
                if (i > 7)
                {
                    Console.Write("│");
                    Console.WriteLine();
                    Console.WriteLine("├────────┼────────┼────────┼────────┼────────┼────────┼────────┼────────┤");


                    i = 0; k++;
                }
                if (k == 21)
                {
                    Console.WriteLine("Pause...");
                    Console.ReadLine();
                    Console.Clear();
                    k = 0;
                }
            }
            //Console.WriteLine();
            while (i <= 7)
            {
                Console.Write("│        ");
                i++;
            }
            Console.Write("│");
            Console.WriteLine();
            Console.WriteLine("└────────┴────────┴────────┴────────┴────────┴────────┴────────┴────────┘");
            Console.ReadLine();*/
        }
    }
}

