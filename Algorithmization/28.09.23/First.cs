using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgn_change
{
    internal class First
    {
        public static void sc()
        {
            Console.WriteLine("Кол-во смен знаков");
            Console.WriteLine("\nВведите число N :");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите числа:");
            bool is_def = false;
            bool is_pos = false;
            int count = 0;

             
            for (int i = 0; i < n; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                if (!is_def)
                {
                    is_def = true;
                }
                else
                {
                    if (is_pos ^ num >= 0)
                    {
                        ++count;
                    }
                }
                is_pos = num >= 0;
            }
            Console.Write("Кол-во смен знаков: " + count);   
        }
    }
}
