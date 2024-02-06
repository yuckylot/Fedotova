using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrid
{
    class Program 
    {
        public static void Th()
        {
           
            Console.WriteLine("enter count of nums");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter nums");
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                if (num % 3 == num %5 && num%5 == num%7 )
                {
                    count++;
                }
            }
            Console.WriteLine(count);

        }
    }
}
