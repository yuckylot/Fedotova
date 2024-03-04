using System;
using System.Linq;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Buffers.Binary;
using System.Collections.Immutable;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("1. Array");
            Console.WriteLine("Enter Length of Array");
            int len = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[len];
            for (int i = 0; i < len; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Count");
                Console.WriteLine("2. BinSearch");
                Console.WriteLine("3. Copy");
                Console.WriteLine("4. Find");
                Console.WriteLine("5. FindLast");
                Console.WriteLine("6. IndexOf");
                Console.WriteLine("7. Reverse");
                Console.WriteLine("8. Resize");
                Console.WriteLine("9. Sort");
                    
                string a = Console.ReadLine() ?? "";

                Console.Clear();
                if (a == "1")
                {
                    Console.Write(arr.Count());
                    Console.ReadKey();
                }
                else if (a == "2")
                {
                    Console.WriteLine("Enter needed number");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Array.Sort(arr);
                    Console.Write(Array.BinarySearch(arr, num));
                    Console.ReadKey();
                }
                else if (a == "3")
                {
                    int[] new_arr = new int[arr.Length];
                    Array.Copy(arr, new_arr, arr.Length);
                    foreach (int i in new_arr) { Console.WriteLine(i); }
                    Console.ReadKey();
                }
                else if (a == "4")
                {

                    Console.WriteLine("Enter needed number");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(Array.Find(arr, elem => elem == num));
                    Console.ReadKey();
                }
                else if (a == "5")
                {
                    Console.WriteLine("Enter needed number");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(Array.FindLast(arr, elem => elem == num));
                    Console.ReadKey();
                }
                else if (a == "6")
                {
                    Console.WriteLine("Enter needed number");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(Array.IndexOf(arr, num));
                    Console.ReadKey();
                }
                else if (a == "7")
                {
                    int[] new_arr = new int[arr.Length];
                    Array.Copy(arr, new_arr, arr.Length);
                    Array.Reverse(arr);
                    foreach ( int i in new_arr) { Console.WriteLine(i); }
                }
                else if (a == "8")
                {

                }
            }
        }
    }
}