using System;

namespace Swap_Nums
{
    class Programm
    {
        public static void Sn()
        {
            int num1, num2;
            Console.WriteLine("¬ведите первое число:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("¬ведите второе число:");
            num2 = Convert.ToInt32(Console.ReadLine());
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
            Console.WriteLine(num1 + " " + num2);
            Console.ReadLine();
        }
    }
}