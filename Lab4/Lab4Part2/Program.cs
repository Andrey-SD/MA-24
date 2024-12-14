using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab4Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double startX, endX, step, x, y;
            string input;
            bool valide;
            while (true)
            {
                do
                {
                    Console.Write("Вкажiть початкове значення аргумента функцiї: ");
                    input = Console.ReadLine();

                    valide = true;

                    if (!double.TryParse(input, out startX))
                    {
                        Console.WriteLine("Початкове значення має бути числом");
                        valide = false;
                    }
                } while (!valide);

                do
                {
                    Console.Write("Вкажiть кiнцевого значення аргумента функцiї: ");
                    input = Console.ReadLine();

                    valide = true;

                    if (!double.TryParse(input, out endX))
                    {
                        Console.WriteLine("Кiнцеве значення має бути числом");
                        valide = false;
                    }
                } while (!valide);

                do
                {
                    Console.Write("Вкажiть крок аргумента функцiї: ");
                    input = Console.ReadLine();

                    valide = true;

                    if (!double.TryParse(input, out step))
                    {
                        Console.WriteLine("Значення кроку має бути числом");
                        valide = false;
                    }
                    else if (step == 0)
                    {
                        Console.WriteLine("Значення кроку не може бути нулем");
                        valide = false;
                    }
                    else if (startX < endX && step < 0)
                    {
                        Console.WriteLine("При початковому меншим ніж кінцеве значення кроку має бути додатнім");
                        valide = false;
                    }
                    else if (startX > endX && step > 0)
                    {
                        Console.WriteLine("При початковому більшем ніж кінцеве значення кроку має бути від'ємним");
                        valide = false;
                    }
                }
                while (!valide);

                if (startX > endX)
                {
                    double t = startX;
                    startX = endX;
                    endX = t;
                }

                for (double count = startX; count <= endX; count += Math.Abs(step))
                {
                    x = count;
                    x = Math.Sign(step) * x;
                    if (x < -1)
                    {
                        y = Math.Pow(x, 3) * Math.Sin(x);
                        Console.WriteLine("При {0,9}\t x={1,8:F} \t y={2,10:F4}", "x<-1", x, y);
                    }
                    else if (x >= -1 && x <= 1)
                    {
                        y = 1 - Math.Pow(Math.E, x);
                        y = Math.Sign(y) * Math.Pow(Math.Abs(y), 1.0 / 3.0);
                        if (x == 0)
                        {
                            Console.WriteLine("При {0,9}\t {1,28}", "x=1", "ділення на 0 неможливе");
                        }
                        else
                        {
                            Console.WriteLine("При {0,9}\t x={1,8:F} \t y={2,10:F4}", "-1<x<=1", x, y);
                        }
                    }
                    else if (1 < x && x < 3)
                    {
                        y = (Math.Atan(x) + 2) / Math.Pow(Math.E, -x);
                        Console.WriteLine("При {0,9}\t x={1,8:F} \t y={2,10:F4}", "1<x<3", x, y);
                    }
                    else if (x > 3.1)
                    {
                        y = Math.Pow(Math.Cos(x), 2) / x - 1;
                        Console.WriteLine("При {0,9}\t x={1,8:F} \t y={2,10:F4}", "x>3.1", x, y);
                    }
                    else
                    {
                        Console.WriteLine("При {0,9}\t {1,28}", "x=" + x, "значення выдсутнє у діапазоні");
                    }
                }
            }
        }
    }
}
