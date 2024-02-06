using System;

namespace Lab1
{
    class Programm
    {
        public static void Main()
        {
            double a = 0.5;
            double b = 2;


            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Введите х{0}:",i+1);
                double x = Convert.ToDouble(Console.ReadLine());

                double y;

                y = (b * Math.Pow(x, 2) * Math.Pow(Math.Exp(1), a * Math.Pow(x, 2))) + (a * Math.Pow(x + 1.5, 0.5));

                Console.WriteLine(y);

            }
        }
    }
}