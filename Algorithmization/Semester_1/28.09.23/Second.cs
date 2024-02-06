using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Left_Min_Right
{
    internal class Second
    {
        public static void lmr()
        {
            Console.WriteLine("Кол-во чисел, которые меньше своих соседей: \n");
            Console.WriteLine("Введите число N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите N чисел:");
            int count = 0;
            int left = Convert.ToInt32(Console.ReadLine());
            int num = Convert.ToInt32(Console.ReadLine());
            int right = Convert.ToInt32(Console.ReadLine());

            if ((left > num) && (right > num))
            {
                ++count;
            }

            for (int i = 0; i < n-3; i++) 
            {
                left = num;
                num = right;
                right = Convert.ToInt32(Console.ReadLine());

                if ((left > num) && (right > num))
                {
                    ++count;
                }

            }
            Console.WriteLine("Кол-во : " +count);
        }   
    }
}
