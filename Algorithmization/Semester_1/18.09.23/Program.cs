using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swap_Nums;
using Times;
using Min_Max;
using System.Runtime.ConstrainedExecution;

namespace _18._09._23
{
    internal class Program
    {
        static void Main()
        {
            string a;
            Console.WriteLine("1. Swap_Nums");
            Console.WriteLine("2. Times");
            Console.WriteLine("3. Min-Max");

            Console.WriteLine(" ");
            Console.WriteLine("Please enter program number:");
            a = Console.ReadLine();
            if (a == "1") 
            {
                Console.WriteLine(" ");
                Swap_Nums.Programm.Sn();
            }
            if (a == "2")
            {
                Console.WriteLine(" ");
                Times.Programm.Times();
            }
            if (a == "3")
            {
                Console.WriteLine(" ");
                Min_Max.Programm.MM();

            }
            else
            {
                Console.WriteLine("ERROR");
                Console.ReadLine();
            }
                
        }
    }
}