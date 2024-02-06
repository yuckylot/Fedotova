using System;
using System.Security.Cryptography.X509Certificates;

namespace First
{
    class Programm
    {
        public static void Fis()
        {
            Console.WriteLine("First programm  \n");
            Console.WriteLine("enter count of nums");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter nums");
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                int num = Math.Abs(Convert.ToInt32(Console.ReadLine()));
                while (num > 0)
                {
                    if (num % 10 == 3)
                    {
                        count++;
                        break;
                    }
                    else
                    {
                        num = num / 10;
                    }

                }
            }
            Console.WriteLine(count);
        }
    }
}