using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double startX, endX, step, y;
            string input;
            bool valide;

            do
            {
                Console.Write("Вкажiть початкове значення аргумента функцiї: ");
                input = Console.ReadLine();

                if (double.TryParse(input, out startX))
                {
                    valide = true;
                }
                else
                {
                    Console.WriteLine("Початкове значення має бути числом");
                    valide = false;
                }
            } while (!valide);



            do
            {
                Console.Write("Вкажiть кiнцевого значення аргумента функцiї: ");
                input = Console.ReadLine();

                if (double.TryParse(input, out endX))
                {
                    valide = true;
                }
                else
                {
                    Console.WriteLine("Кiнцеве значення має бути числом");
                    valide = false;
                }
            }

            while (!valide);

            do
            {
                Console.Write("Вкажiть крок аргумента функцiї: ");
                input = Console.ReadLine();

                if (double.TryParse(input, out step))
                {
                    valide = true;
                    if (step == 0)
                    {
                        Console.WriteLine("Значення кроку не може бути нулем");
                        valide = false;
                    }

                    if (startX < endX && step < 0)
                    {
                        Console.WriteLine("Значення кроку не може бути від'ємним при початковому більшем ніж кінцеве ");
                        valide = false;
                    }

                    if (startX > endX && step > 0)
                    {
                        Console.WriteLine("Значення кроку не може бути додатнім при початковому меншим за кінцевого");
                        valide = false;
                    }
                }
                else
                {
                    Console.WriteLine("Значення кроку має бути числом");
                    valide = false;
                }
            }
            while (!valide);

            for (double x = startX; x < endX; x += step)
            {

                double denominator = 9.5 * Math.Sin(x) - Math.Pow(3.0, x);
                //denominator = Math.Sign(denominator) * Math.Pow(Math.Abs(denominator), 1.0 / 3.0);//більше аба 0 при 

                double numerator = 3 * Math.Pow(Math.Sin(x), 3.0) + 0.4 * Math.Pow(Math.Cos(x), 2.0);

                if (numerator == 0 || denominator < 0)
                {
                    Console.WriteLine($"При значенні x = {x} знаменник набуває значення 0, або основа степеня менше 0");
                }
                else
                {
                    try
                    {
                        double result = Math.Pow(denominator, 0.3) / numerator;
                        Console.WriteLine($"При x = {x,8:F} \t y = {(result),20:F}"); // максималку через экспоненту
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine($"При значенні x = {x} результат набуває надвеликого значення");
                    }
                    catch (DivideByZeroException)
                    {

                    }
                }
            }

        }
    }
}

