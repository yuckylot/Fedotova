
using System;
using System.Security.AccessControl;
using System.Linq;

namespace gg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Obraz");
            string obr = Console.ReadLine();
            Console.WriteLine("Enter count of strings");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter string");
            int sums = 0;
            for (int i = 0; i < n; i++)
            {
                string srr = Console.ReadLine();
                string sel = srr.Replace(obr, "&");
                int dep = sel.Count(p => p == '&');
                sums += dep;
            }
            Console.WriteLine(sums);
        }
    }
}