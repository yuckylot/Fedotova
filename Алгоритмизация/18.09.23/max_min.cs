using System;

namespace Min_Max
{
    class Programm
    {
        public static void MM()
        {
            int num1, num2, modul, minn, maxx;
            Console.WriteLine("������� ������ �����:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("������� ������ �����:");
            num2 = Convert.ToInt32(Console.ReadLine());
            modul = Math.Abs(num1 - num2);
            minn = (num1 - modul + num2) / 2;
            maxx = (num1 + modul + num2) / 2;
            Console.WriteLine("Min:" + minn);
            Console.WriteLine("Max:" + maxx);
            Console.ReadLine();
        }
    }
}