using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Count_Neg
{   
    internal class Fourth
    { 
        public static void mcn()
        {
            Console.WriteLine("Минимальный размер последовательности, состоящей из отрицательных чисел \n");
            Console.WriteLine("Введите число N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите N чисел: ");
            int count = 0;
            int min_comb = 999;
            bool prev_is_def = false;
            bool prev_is_neg = false;
            bool firstly = true;
            for (int i = 0; i < n; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                if (!prev_is_def)
                {
                    prev_is_def = true;
                    if (num < 0)
                    {
                        count++;
                        firstly = false;
                    }
                }
                else
                {
                    if (prev_is_neg && num < 0)
                    {
                        if (firstly)
                        {
                            count = count +2;
                            firstly = false;
                        }
                        else
                        {
                            count++;
                        }
                    }
                    else
                    {
                        if (count == 0) { }
                            
                        else
                        {
                            min_comb = Math.Min(min_comb, count);
                            count = 0;
                            firstly = true;
                        }

                                
                    }
                }
                Console.WriteLine(count + "line");
                prev_is_neg = num < 0;
            }
            if (count !=0)
            {
                min_comb = Math.Min(min_comb, count);
            }

            if (min_comb == 0)
            {
                Console.WriteLine("Нет отрицательных чисел");
            }
            else
            {
                Console.WriteLine("Длинна минимальной последовательности отрицаельных чисел: " + (min_comb));
            }
        }
    }
}
