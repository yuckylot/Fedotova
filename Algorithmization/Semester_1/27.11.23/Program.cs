using System;
using System.Linq;

namespace gggg
{
    class Prog
    {
        static void Main()
        {
            Console.WriteLine("n");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("t");
            int t = Convert.ToInt32(Console.ReadLine());
            int a,b,min_road;
            min_road = Int32.MaxValue;
            int a_road = 0;
            int b_road = 0 + t;

            for (int i = 0; i < n; i++)
            {
                string vars = Console.ReadLine();
                a = Convert.ToInt32(vars.Split()[0]);
                b = Convert.ToInt32(vars.Split()[1]);

                a_road += a;
                b_road = Math.Min(a_road + t, b_road + b);

            }
            
                
            Console.WriteLine(Math.Min(a_road+t , b_road));
            Console.ReadKey();
        }
    }
}