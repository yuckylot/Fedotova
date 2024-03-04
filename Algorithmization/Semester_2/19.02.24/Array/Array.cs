using System;
using System.Linq;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Buffers.Binary;
using System.Collections.Immutable;
using System.Drawing;

namespace Task
{
    class Program
    {
        public static int ReadNum() // метод валидирующий ввод вместо -> Convert.ToInt32(Console.ReadLine())
        {
            string num = "";
            bool flag = false;
            while (!flag)
            {
                num = Console.ReadLine() ?? "";
                if (int.TryParse(num, out int n))
                {

                    flag = true;
                }
            }
            return Convert.ToInt32(num);
        }
        static void Main(string[] args)
        {

            Console.WriteLine("1. Array");
            Console.WriteLine("Enter Length of Array");
            int len = ReadNum();
            int[] arr = new int[len];
            Console.WriteLine("Enter NUmbers");
            for (int i = 0; i < len; i++)
            {
                arr[i] = ReadNum();
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
                    int num = ReadNum();
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
                    int num = ReadNum();
                    Console.WriteLine(Array.Find(arr, elem => elem == num));
                    Console.ReadKey();
                }
                else if (a == "5")
                {
                    Console.WriteLine("Enter needed number");
                    int num = ReadNum();
                    Console.WriteLine(Array.FindLast(arr, elem => elem == num));
                    Console.ReadKey();
                }
                else if (a == "6")
                {
                    Console.WriteLine("Enter needed number");
                    int num = ReadNum();
                    Console.WriteLine(Array.IndexOf(arr, num));
                    Console.ReadKey();
                }
                else if (a == "7")
                {
                    int[] new_arr = new int[arr.Length];
                    Array.Copy(arr, new_arr, arr.Length);
                    Array.Reverse(new_arr);
                    foreach ( int i in new_arr) { Console.WriteLine(i); }
                    Console.ReadKey();
                }
                else if (a == "8")
                {
                    Console.WriteLine("Enter needed Lenght of array");
                    int size = ReadNum();
                    int[] new_arr = arr;
                    Array.Resize(ref new_arr, size);
                    foreach ( int i in new_arr) { Console.WriteLine(i); }
                    Console.ReadKey();
                }
                else if (a == "9")
                {
                    Array.Sort(arr);
                    foreach (int i in arr) { Console.WriteLine(i); }
                    Console.ReadKey();
                }
            }
        }
    }
}