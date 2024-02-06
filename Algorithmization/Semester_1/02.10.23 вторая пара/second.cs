using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class  Programm
    {
        public static void sec()
        {
            Console.WriteLine("enter count of nums");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter nums");
            int min_num = int.MaxValue;
            for (int i = 0; i<n; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                if (Math.Abs(num%2) == 1)
                {
                    min_num = Math.Min(min_num, num);
                }
            }
            Console.WriteLine(min_num);
        }
    }
}

