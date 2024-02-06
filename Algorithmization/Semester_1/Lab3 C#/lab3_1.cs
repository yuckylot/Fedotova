using System;

namespace Lab2_1
{
    class Programm
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите n:");

            int n = Convert.ToInt32(Console.ReadLine());

            int y = 1;

            for (int i = 0; i < n; i++)
            {
                y *= (i + 1);
            }

            Console.WriteLine(y);

        }
    }
}