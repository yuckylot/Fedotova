using System;
using Sgn_change;
using Left_Min_Right;
using Max_count_same;
using Max_Count_Neg;


namespace General
{
    class Programm
    {
        static void Main()
        {
            Console.WriteLine("1: Кол-во смен знаков");
            Console.WriteLine("2: Кол-во чисел меньших чем числа слева и справа");
            Console.WriteLine("3: Кол-во одинаковых чисел в ряд");
            Console.WriteLine("4: Самый длинный ряд отрицательных чисел");

            Console.WriteLine("\n Введите номер программы:");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n == 1)
            {
                Sgn_change.First.sc();
                Console.ReadLine();
            }

            if (n == 2)
            {
                Left_Min_Right.Second.lmr();
                Console.ReadLine();
            }

            if (n == 3)
            {
                Max_count_same.Third.mcs();
                Console.ReadLine();
            }
            
            if (n == 4)
            {
                Max_Count_Neg.Fourth.mcn();
                Console.ReadLine();
            }
        }
    }
}