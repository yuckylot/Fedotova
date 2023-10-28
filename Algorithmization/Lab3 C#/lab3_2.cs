using System;


namespace Lab3_2
{
    class Programm
    {
        public static void Main()
        {
            double a = -Math.PI;

            double b = Math.PI;

            int n = 18;

            double y;

            int dot = 0;

            Console.WriteLine("First Funktion: \n");

            for (double x = a;  x <= b; x= x +(Math.Abs(a)+Math.Abs(b))/n) 
            {
                y = Math.Abs(Math.Sin(x)) + Math.Abs(Math.Cos(x));

                dot++;

                Console.WriteLine($"{dot}. y = {y} ");
            }
            dot = 0;

            Console.WriteLine("\n");

            Console.WriteLine("Second Function: \n");

            for (double x = a; x <= b; x = x + (Math.Abs(a) + Math.Abs(b)) / n)
            {
                y = Math.Abs(Math.Sin(x)) - Math.Abs(Math.Cos(x));

                dot++;

                Console.WriteLine($"{dot}. y = {y} ");
            }

        }
    }
}
