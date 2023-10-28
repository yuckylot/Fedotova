using System;

namespace Lab4
{
    class Programm {
        public static void Main(string[] args)
        {
            Console.WriteLine("Funktion:");

            double a = 1;

            double y;

            for (int i = 0; i < 2; i++)
            {

                for (double x = 0; x <= 4; x = x + a / 2)
                {
                    if (x <=3 )
                    {
                        y = -a * Math.Exp(x - 3 * a);
                        Console.WriteLine(y);
                    }
                    if (x>3 & x <=4) 
                    {
                        y = -a * (1 + Math.Log(x - 3 * a));
                        Console.WriteLine(y);                  
                    }
                    
                }
                a = 1.5;
            }
        }
    }
}