using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = System.Text.Encoding.UTF8;


      int N = 2; // Варіант
      int rows = 2 * (N + 6);
      int cols = 2 * (N + 6);

      double minValue = -2 * (N + 6);
      double maxValue = 4 * (N + 6);
      double x, y;

      //double[,] X = new double[rows, cols];
      double[] X = new double[cols];
      double[] Y = new double[0];

      Random random = new Random();

      Console.WriteLine("Массив X\tМассив Y");

      for (int i = 0; i < rows; i++)
      {
        X[i] = random.NextDouble() * (maxValue - minValue) + minValue;
        Console.Write($"{X[i],8:F2}\t");

        x = X[i];
        try
        {
          // Обчислення чисельника і знаменника
          double numerator = Math.Log(6.0 * x, 3.0) - Math.Exp(x);
          double denominator = x * x - 0.8;

          // Основна формула
          y = (numerator / denominator) + Math.Pow(x, 9.0);

          // Кубічний корінь зі збереженням знаку
          y = Math.Sign(y) * Math.Pow(Math.Abs(y), 1.0 / 3.0);
          //Console.WriteLine($"{y,7:F2}");
          Y = Y.Append(y).ToArray();
          Console.Write($"{y,8:F2}");
        }
        catch { }

        Console.WriteLine();
      }

      Console.WriteLine();
      Console.WriteLine("У массиві Y...");
      if (Y.Length != 0)
      {
        double min = Y[0];
        double max = Y[0];
        double
            sum = 0.0,
            sumNegative = 0.0,
            product = 1;
        bool flag = false;
        foreach (double value in Y)
        {
          if (value > max) max = value;
          if (value < min) min = value;
          if (value < 0) sumNegative += value;
          if (value >= 1.5 && value <= 1.5)
          {
            product *= value;
            flag = true;
          }
          sum += value;
        }

        Console.WriteLine($"Мінімальне значення: {min:F2}");
        Console.WriteLine($"Максимальне значення: {max:F2}");
        Console.WriteLine($"Середнє значення: {(sum / Y.Length):F2}");
        Console.WriteLine($"Сума негативних: {sumNegative:F2}");
        if (flag)
        {
          Console.WriteLine($"Значення яких знаходиться в інтервалі [-1.5 ... 1.5]: {product:F2}");
        }
        else
        {
          Console.WriteLine($"Значення які знаходяться в інтервалі [-1.5 ... 1.5] відсутні.");
        }

        // Створення двовимірного масиву A
        Console.WriteLine("Массив A:");
        int colsA = 0;
        do
        {
          Console.Write("Введіть кількість стовпців від 1 до 10: ");
          colsA = int.Parse(Console.ReadLine());
        }
        while (colsA <= 0 || colsA > 10);

        int rowsA = Y.Length / colsA;
        double[,] A = new double[rowsA, colsA];

        int index = 0;
        for (int i = 0; i < rowsA; i++)
        {
          for (int j = 0; j < colsA; j++)
          {
            A[i, j] = Y[index];
            index++;
            Console.Write($"{A[i, j],10:F2}");
          }
          Console.WriteLine("");
        }

        // Створення  масиву Z
        Console.WriteLine("\n");
        Console.WriteLine("Массив Z:");

        double[] Z = new double[rowsA];
        index = 0;
        for (int i = 0; i < rowsA; i++)
        {
          double sumRow = 0;
          for (int j = 0; j < colsA; j++)
          {
            sumRow += A[i, j];
          }
          Z[index] = sumRow;
          Console.WriteLine($"{Z[index],10:F2}");
          index++;

        }
      }
    }
  }
}
