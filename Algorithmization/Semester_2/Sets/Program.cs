using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Sets
{
    public static void DisplaySet(SortedSet<double> set)
    {
        Console.Write("{");
        int count = 0;
        foreach (double n in set)
        {
            if (count == set.Count - 1)
            {
                Console.Write("{0}", n);
            }
            else
            {
                Console.Write("{0}, ", n);
            }
            count += 1;
        }
        Console.Write("}");
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        SortedSet<double> numbersA = new SortedSet<double>() { 1, 3, 5, 7, 9 };
        SortedSet<double> numbersB = new SortedSet<double>() { 0, 2, 4, 6, 8, 10 };
        SortedSet<double> numbersC = new SortedSet<double>() { 1, 2, 5, 6, 9, 10, 11, 12 };

        Console.WriteLine("Множество #A:");
        DisplaySet(numbersA);
        Console.WriteLine();

        Console.WriteLine("Множество #B:");
        DisplaySet(numbersB);
        Console.WriteLine();

        Console.WriteLine("Множество #C:");
        DisplaySet(numbersC);
        Console.WriteLine();

        Console.WriteLine("Пересечение всех множеств:");
        DisplaySet(new SortedSet<double>(from x in numbersA.Intersect(numbersB).Intersect(numbersC) select x));
        Console.WriteLine();

        Console.WriteLine("Объединение всех множеств:");
        SortedSet<double> union = new SortedSet<double>(from x in numbersA.Union(numbersB).Union(numbersC) select x);
        DisplaySet(union);
        Console.WriteLine();

        Console.WriteLine("Дополнение множества #A:");
        DisplaySet(new SortedSet<double>(from x in union.Except(numbersA) select x));
        Console.WriteLine();

        Console.WriteLine("Дополнение множества #B:");
        DisplaySet(new SortedSet<double>(from x in union.Except(numbersB) select x));
        Console.WriteLine();

        Console.WriteLine("Дополнение множества #C:");
        DisplaySet(new SortedSet<double>(from x in union.Except(numbersC) select x));
    }
}