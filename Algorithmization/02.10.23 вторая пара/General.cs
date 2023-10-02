using System;
using First;
using Second;
using Thrid;



namespace General
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("num of progrram");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n ==1)
            {
                First.Programm.Fis();
                Console.ReadLine();
            }
            if (n == 2)
            {
                Second.Programm.sec();
                Console.ReadLine();
            }
            if(n == 3)
            {
                Thrid.Program.Th();
                Console.ReadLine();
            }
        }
    }
}