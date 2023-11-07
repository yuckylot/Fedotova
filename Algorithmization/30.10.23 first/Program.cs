using System;
using System.Collections.Generic;

//
//
//

namespace cat_n_mice 
{ 
    class Programm
    {
        public static void Main()
        {
            Console.WriteLine("Введите кол-во серых:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите кол-во белых:");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите Укус:");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("n1:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("m1:");
            int m1 = Convert.ToInt32(Console.ReadLine());
            
            if (n > 0 & n1 < n & m1 < m)
            {
                List<int> mice = new List<int>();
                for (int i = 0; i <n; i++)
                {
                    mice.Add(1);
                }
                for (int i = 0; i < m; i++)
                {
                    mice.Add(2);
                }

                Console.Write("[ ");
                foreach (int i in mice)
                {
                    Console.Write(i + " ");
                }
                Console.Write("]");


            }
            else
            {
                Console.WriteLine("syntax error");
            }
        }
    }
}
