using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPaper1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double x;
            while (true)
            {
                x = double.Parse(Console.ReadLine());
                
                double tolerance = 0.01; // Допустимая погрешность

                if (Math.Abs(x - (-5.4)) <= tolerance && x != 0)
                {
                    Console.WriteLine("(x >= -5.4) та (x != 0)");
                }
                else
                {
                    Console.WriteLine("Условие не выполнено.");
                }
            }

        }
    }
}
