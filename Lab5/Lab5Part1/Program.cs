using System;
using System.Text;
using static System.Math;

namespace Lab5Part1
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WindowWidth = 125;
            Console.WindowHeight = 40;

            double
                y = 0,
                rowStep = 1,
                k = 0;
            int colls = 10,
                rows = 25;

            double collStep = rowStep / colls;

            printHeader();

            for (int row = 0; row < rows; row++)
            {
                decorationFont(true);
                Console.Write("──────────");
                decorationFont(false);
                Console.WriteLine(buildBorder("middle", colls));
                decorationFont(true);
                Console.Write($"{row * rowStep,10:F}");
                decorationFont(false);
                for (int col = 0; col < colls; col++)
                {
                    k = row * rowStep + col * collStep;

                    double numerator = Math.Log(6.0 * k, 3.0) - Math.Exp(k);
                    double denominator = k * k - 0.8;
                    y = (numerator / denominator) + Math.Pow(k, 9.0);
                    y = Math.Sign(y) * Math.Pow(Math.Abs(y), 1.0 / 3.0);

                    if (Math.Abs(k) > 999.00)
                    {
                        //Console.Write($"│{k,10:E2}");
                        Console.Write($"│{y,10:E2}");
                    }
                    else
                    {
                        //Console.Write($"│{k,10:F}");
                        Console.Write($"│{y,10:F}");
                    }
                }
                Console.WriteLine("│");
                if (row % 10 == 0 && row != 0)
                {
                    Console.WriteLine("Натисніть Enter для продовження...");
                    Console.ReadLine();
                    Console.Clear();
                    printHeader();
                }
            }

            Console.WriteLine("          " + buildBorder("bottom", colls));

            void printHeader()
            {
                decorationFont(true);
                Console.WriteLine("          " + buildBorder("top", colls));

                Console.Write("          ");
                for (int col = 0; col < colls; col++)
                {
                    Console.Write($"│{col * collStep,10:F}");
                }
                Console.WriteLine("│");
            }

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

            String buildBorder(String borderType, int cellQuantity, int cellSize = 10)
            {

                String[,] ch = {
                    { "┌", "┬", "┐" },
                    { "├", "┼", "┤" },
                    { "└", "┴", "┘" }
                };

                byte borderTypeIndex = 0;

                if (borderType == "top") borderTypeIndex = 0;
                else if (borderType == "middle") borderTypeIndex = 1;
                else if (borderType == "bottom") borderTypeIndex = 2;

                StringBuilder str = new StringBuilder("");
                str.Append("");
                for (int cell = 0; cell < cellQuantity; cell++)
                {
                    for (int i = 0; i < cellSize; i++)
                    {
                        str.Append("─");
                    }
                    str.Append(ch[borderTypeIndex, 1]);
                }
                str.Insert(0, ch[borderTypeIndex, 0]);
                str.Remove(str.Length - 1, 1);
                str.Insert(str.Length, ch[borderTypeIndex, 2]);
                return str.ToString();
            }
        }
    }
}

