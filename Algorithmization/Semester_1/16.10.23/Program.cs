// к кол-во городов
// каждый характеризуется раст от 1 города
// где расположить заправку чтобы растояние от ближайсших городов было >= n 
// сумма растояний от городов до заправки было минимальным.




using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Security;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace Gas_station
{
    class Programm
    {
        public static void Main()
        {
            Console.WriteLine("Введите количество городов: ");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите мин растояние до города: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите растояния до городов: ");
            int[] cities = new int[k];
            cities[0] = 0;
            for (int i = 1; i < k; i++)
            { 
                cities[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(String.Join(",", cities));

            // проверить каждый километр.
            bool check = false;
            string res = "Nothing ";
            for (int i = 1; i < cities[^1]; ++i)
            {
                
                for (int h = 0; h < k; ++h) 
                {
                    
                    if (Math.Abs(cities[h] - i) >= n)
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    int sum = 0;
                    for (int j = 0; j < k; ++j)
                    {
                        sum += Math.Abs(cities[j] - i);
                    }
                    res += Convert.ToString(i) + " " + Convert.ToString(sum) + ", " ;
                    
                }
            }
            Console.WriteLine(res);
        }
    }
}
 