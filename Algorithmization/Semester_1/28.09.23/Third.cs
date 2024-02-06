using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_count_same
{
    internal class Third
    {
        public static void mcs()
        {
            Console.WriteLine("Кол-во одинаковых чисел подряд: \n");
            Console.WriteLine("Введите число N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите N чисел: ");
            int prev_num = 0;
            bool prev_is_def = false;
            int count = 1;
            int max_range = 0;

            for (int i = 0; i < n; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                if (!prev_is_def)
                {
                    prev_is_def = true;
                    max_range = 1;
                }
                else
                {
                    if (prev_num == num)
                    {
                        count++;
                    }
                    else
                    {
                        max_range = Math.Max(count, max_range);
                        count = 1;
                    }
                }
                prev_num = num;
            }
            Console.WriteLine("максимальный ряд: " + max_range);
        }
    }
}
