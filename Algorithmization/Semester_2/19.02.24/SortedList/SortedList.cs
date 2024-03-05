using System;
using System.Linq;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Buffers.Binary;
using System.Collections.Immutable;
using System.Drawing;
using System.Diagnostics;

//SortedList: Add, IndexOf и по ключу и по значению, Вывод ключа по индексу, Вывод значения по индексу

namespace Task
{
    class Program
    {
        public static string ReadString(string s = "")
        {
            if (s.Length > 0) { Console.WriteLine(s); }

            string key = "";
            bool flag = false;
            while (!flag) {
                key = Console.ReadLine() ?? ""; 
                if (key.Length > 0) {
                    flag = true;
                }
            }
            return key;

        }
        public static int ReadNum(string s = "") // метод валидирующий ввод вместо -> Convert.ToInt32(Console.ReadLine())
        {
            if (s.Length > 0) { Console.WriteLine(s); }
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
        public static void ValueAndKeys(SortedList myList)
        {
            Console.WriteLine("\t-KEY-\t-VALUE-");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine("\t{0}:\t{1}", myList.GetKey(i), myList.GetByIndex(i));
            }
            Console.WriteLine();
        } 
        static void Main(string[] args)
        {

            Console.WriteLine("3. SortedList");
            int len = ReadNum("Enter Length of Array");
            SortedList arr = new SortedList();
            Console.WriteLine("Enter Numbers");
            for (int i = 0; i < len; i++)
            {
                arr.Add(ReadString("Enter key"),ReadNum("Enter value"));
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add");
                Console.WriteLine("2. IndexOf by key");
                Console.WriteLine("3. IndexOf by value");
                Console.WriteLine("4. Key by index");
                Console.WriteLine("5. Value by index");

                string a = Console.ReadLine() ?? "";

                Console.Clear();
                if (a == "1")
                {
                    arr.Add(ReadString("Enter key"), ReadNum("Enter value"));
                    ValueAndKeys(arr);
                    Console.ReadKey();
                }
                else if (a == "2")
                {
                    Console.WriteLine(arr.IndexOfKey(ReadString("Enter key")));
                    Console.ReadKey();
                }
                else if (a == "3")
                {
                    Console.WriteLine(arr.IndexOfValue(ReadNum("Enter value")));
                    Console.ReadKey();
                }
                else if (a == "4")
                {
                    Console.WriteLine(arr.GetKey(ReadNum("Enter index of key")));
                    Console.ReadKey();
                }
                else if (a == "5")
                {
                    Console.WriteLine(arr.GetByIndex(ReadNum("Enter index of value"))); 
                    Console.ReadKey();
                }
            }
        }
    }
}