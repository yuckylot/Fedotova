using System;

namespace Lab2
{
    class Programm
    {
        public static void Main()
        {
            double a = 1.5;
            
            Console.WriteLine("Введите х [0.9,5]:");
            
            double x = Convert.ToDouble(Console.ReadLine());

            double y = 0;

            if (x >= 0.9 | x <= 5)
            {
                if (x < 1.3)
                {
                    y = (Math.PI * Math.Pow(x, 2)) - (7 / Math.Pow(x,2));
                }

                if (x >= 1.3 & x < 3)
                {
                    y = (a * Math.Pow(x, 3)) + (7*Math.Pow(x,0.5));
                }
                
                if (x >= 3)
                {
                    y = Math.Log(x + 7*Math.Pow(x,0.5), 10);
                }

                Console.WriteLine($"Answer :{y}");
            }

            else
            {
                Console.WriteLine("x not in range [0.9,5]");
            }
        }
    }
}