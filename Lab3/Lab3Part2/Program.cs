using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Part2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Введiть значення x: ");
            double x = 0.1, y;
            string input = Console.ReadLine();

            try
            {
                x = double.Parse(input);
                if (x <= 1)
                {
                    y = Math.Sqrt(5 - x);
                    Console.WriteLine($"Значення y1: {y}");
                }
                else if (2 < x && x < 3)
                {
                    y = Math.Sin(x) * Math.Pow(Math.Cos(x * Math.Pow(Math.E, -0.5 * x)), 2.0);
                    Console.WriteLine($"Значення y2: {y}");
                }
                else if (3 < x && x <= 7)
                {
                    y = Math.Sqrt(2 * x - 3);
                    Console.WriteLine($"Значення y3: {y}");
                }
                else if (x > 7)
                {
                    y = (Math.Sqrt(Math.Pow(Math.E, x) + 1)) / Math.Pow(x, 3) + 3;
                    Console.WriteLine($"Значення y4: {y}");
                }
                else
                {
                    Console.WriteLine($"Значення {x} немає у діапазоні.");
                }
                
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка формату: рядок не є дійсним числом.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Помилка переповнення: число занадто велике або занадто мале.");
            }


        }
    }
}
