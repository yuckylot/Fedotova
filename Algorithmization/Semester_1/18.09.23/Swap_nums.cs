using System;

namespace Swap_Nums
{
    class Programm
    {
        public static void Sn()
        {
            int num1, num2;
            Console.WriteLine("Enter first number:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            num2 = Convert.ToInt32(Console.ReadLine());
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
            Console.WriteLine(num1 + " " + num2);
            Console.ReadLine();
        }
    }
}