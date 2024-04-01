using System;
using System.Linq;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Buffers.Binary;
using System.Collections.Immutable;
using System.Drawing;
using System.Xml;

//ArrayList:   Count, BinSearch, Copy, IndexOf, Insert, Reverse, Sort, Add

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

            Console.WriteLine("2. ArrayList");
            Console.WriteLine("Enter Length of Array");
            int len = ReadNum();
            ArrayList arr = new ArrayList();
            Console.WriteLine("Enter NUmbers");
            for (int i = 0; i < len; i++)
            {
                arr.Add(ReadNum());
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Count");
                Console.WriteLine("2. BinSearch");
                Console.WriteLine("3. Copy");
                Console.WriteLine("4. IndexOf");
                Console.WriteLine("5. Insert");
                Console.WriteLine("6. Reverse");
                Console.WriteLine("7. Sort");
                Console.WriteLine("8. Add");

                string a = Console.ReadLine() ?? "";

                Console.Clear();
                if (a == "1")
                {
                    Console.Write(arr.Count);
                    Console.ReadKey();
                }
                else if (a == "2")
                {
                    Console.WriteLine("Enter needed number");
                    int num = ReadNum();
                    arr.Sort();
                    Console.Write(arr.BinarySearch(num));
                    Console.ReadKey();
                }
                else if (a == "3")
                {
                    ArrayList new_arr = new ArrayList();
                    new_arr.AddRange(arr);
                    foreach (object i in new_arr) {  Console.WriteLine((int)i); }
                    Console.ReadKey();
                }
                else if (a == "4")
                {

                    Console.WriteLine("Enter needed number");
                    int num = ReadNum();
                    Console.WriteLine(arr.IndexOf(num));
                    Console.ReadKey();
                }
                else if (a == "5")
                {
                    Console.WriteLine("Enter number");
                    int num = ReadNum();
                    Console.WriteLine("Enter Index");
                    int ind = ReadNum();
                    arr.Insert(ind, num);
                    foreach (object i in arr) { Console.WriteLine((int)i); }
                    Console.ReadKey();
                }
                else if (a == "6")
                {
                    ArrayList new_arr = new ArrayList();
                    new_arr.AddRange(arr);
                    new_arr.Reverse();
                    foreach (object i in new_arr) { Console.WriteLine((int)i); }
                    Console.ReadKey(); ;
                }
                else if (a == "7")
                {
                    ArrayList new_arr = new ArrayList();
                    new_arr.AddRange(arr);
                    new_arr.Sort();
                    foreach (object i in new_arr) { Console.WriteLine((int)i); }
                    Console.ReadKey(); 
                }
                else if (a == "8")
                {
                    int num = ReadNum();
                    arr.Add(num);
                    foreach (object i in arr) { Console.WriteLine((int)i); }
                    Console.ReadKey(); 
                }
            }
        }
    }
}