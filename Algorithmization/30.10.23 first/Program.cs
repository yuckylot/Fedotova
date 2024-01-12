using System;
using System.Linq;

// Дается n серых мышек и m белых,
// k - мышка, которую съедает кот,
// n1 - остаток серых,
// m1 - остаток белых.
// Вывод: выход с серой мышки.
class MiceAndCat
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        int k = Convert.ToInt32(Console.ReadLine());
        int n1 = Convert.ToInt32(Console.ReadLine());
        int m1 = Convert.ToInt32(Console.ReadLine());

        int remainder = n1 + m1;

        int[] mice = new int[n + m];
        for (int i = 0; i < mice.Length; i++)
        {
            mice[i] = 1;
        }

        int pointer = 0;

        while (mice.Count(c => c == 1) > remainder)
        {
            int moved = 0;

            while (moved != k)
            {
                ++pointer;

                if (pointer > mice.Length - 1)
                {
                    pointer = 0;
                }

                if (mice[pointer] == 1)
                {
                    ++moved;
                }
            }

            mice[pointer] = 0;
        }

        int placed_n = 0;
        int placed_m = 0;
        int placed_alive_n = 0;
        int placed_alive_m = 0;

        if (n - n1 == 0 || m - m1 == 0)
        {
            Console.WriteLine("Мышек так расположить не получится");
        }
        else
        {
            for (int i = 0; i < mice.Length; i++)
            {
                if (mice[i] == 0)
                {
                    if (placed_n < n - n1)
                    {
                        Console.WriteLine("Серая");
                        placed_n++;
                    }
                    else if (placed_m < m - m1)
                    {
                        Console.WriteLine("Белая");
                        placed_m++;
                    }
                }
                else if (mice[i] == 1)
                {
                    if (placed_alive_n < n1)
                    {
                        Console.WriteLine("Серая");
                        placed_alive_n++;
                    }
                    else if (placed_alive_m < m1)
                    {
                        Console.WriteLine("Белая");
                        placed_alive_m++;
                    }
                }
            }
        }
    }
}