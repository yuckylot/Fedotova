using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication15
{
    class Program
    {
        static void Main()
        {
            int d = 106732567;
            int x = 152673837;
            for (int i = d; i < x; i++)
            {
                bool flag = true;

                if (((int)Math.Sqrt(i) * (int)Math.Sqrt(i)) != i)
                {
                    continue;
                }

                int count_dels = 0;
                int max_del = 0;

                for (int j = 2; j < (int)(Math.Sqrt(i) - 1); j++)
                {
                    if (i % j == 0)
                    {
                        count_dels += 2;
                        max_del = i / j;
                    }
                    if (count_dels > 2)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag && count_dels == 2)
                {
                    Console.WriteLine(i + " " + max_del);
                }

            }

            Console.ReadKey();

        }

    }
}