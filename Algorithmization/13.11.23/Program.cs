// на вход подаётся строка определить нибольшую длину подстроки полиндрома
using System;

namespace Srting
{
    class program
    {
        public static void Main()
        {
            string l = Convert.ToString(Console.ReadLine());
            List<int> lent = new List<int>();
            string temp;
            string rev;
            for (int i = 0; i < l.Length; i++) 
            {
                for (int j = i+1; j < l.Length ; j++)
                {

                    temp = l.Substring(i, j-i+1);
                    Console.WriteLine(temp);
                    char[] arr = temp.ToCharArray();
                    Array.Reverse(arr);
                    rev = new string(arr);
                    Console.WriteLine(rev + " " + temp);
                    if (rev == temp)
                    {
                        lent.Add(rev.Length);
                        Console.WriteLine(rev.Length);
                    }
                   

                }
            }
            Console.WriteLine(lent.Max() + "ansv");



        }
    }
}