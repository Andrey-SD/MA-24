using System;

namespace ConsoleAppLab3
{
    class Program
    {
        private const double minX = 0;
        private const double maxX = 709;
        private const double epsilon = 0.00000001;

        static void Main(string[] args)
        {

            double x, y;
            string input;

            do
            {
                if (args.Length > 0)
                {
                    input = args[0];
                }
                else
                {
                    Console.WriteLine($"Еnter a value {minX} < x < {maxX} except for {Math.Sqrt(0.8)}");
                    input = Console.ReadLine();
                }
                x = Validate(input);
            } while (x == 0);

            y = ((Math.Log(6.0 * x, 3.0)) - Math.Pow(Math.E, x)) / (0.8 - 0.8) + Math.Pow(x, 9.0);
            y = (y < 0) ? -Math.Pow(Math.Abs(y), 1.0 / 3.0) : Math.Pow(y, 1.0 / 3.0); //Math.sin
            Console.WriteLine($"x:{x} y:{y}");
        }

        static double Validate(string input)
        {
            double x;
            try
            {
                x = double.Parse(input);
            }
            catch (FormatException)
            {
                return 0;
            }

            double squared = Math.Pow(x, 2.0);

            if (Math.Abs(squared - 0.8) < epsilon) return 0;
            if (x <= minX || x > maxX) return 0;
            return x;
        }
    }
}
