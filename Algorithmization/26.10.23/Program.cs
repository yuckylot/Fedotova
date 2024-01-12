using System;
using System.Linq;

// Задано множество из N элементов
// Необходимо сформировать одномерные массивы, которые хранят:
// 1. Пересечение всех множеств
// 2. Объединение всех множеств
// 3. Дополнение для каждого множества относительно объединения
class Sets
{
    public static int[] SelectionSort(int[] array)
    {
        int[] sorted = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            int min = Int32.MaxValue;
            for (int j = i; j < array.Length; j++)
            {
                if (array[j] < min)
                {
                    min = array[j];
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            sorted[i] = min;
        }

        return sorted;
    }

    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] arr = new int[n][];
        int length = 0;

        for (int i = 0; i < n; i++)
        {
            int m = Convert.ToInt32(Console.ReadLine());
            length += m;
            arr[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                arr[i][j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int[] union = new int[length];
        int countUnion = 0;

        Console.WriteLine("Массивы:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                Console.Write($"{arr[i][j].ToString().PadLeft(5, ' ')} ");
                if (!union.Contains(arr[i][j]))
                {
                    union[countUnion] = arr[i][j];
                    countUnion++;
                }
            }
            Console.WriteLine();
        }

        union = new int[countUnion];
        int pointer = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (!union.Contains(arr[i][j]))
                {
                    union[pointer] = arr[i][j];
                    pointer++;
                }
            }
        }

        union = SelectionSort(union);

        int[] intersections = new int[union.Length];
        int countIntersection = 0;
        for (int i = 0; i < intersections.Length; i++)
        {
            intersections[i] = 0;
        }

        for (int k = 0; k < union.Length; k++)
        {
            for (int i = 0; i < n; i++)
            {
                if (arr[i].Contains(union[k]))
                {
                    intersections[k]++;
                }
            }
        }

        for (int i = 0; i < intersections.Length; i++)
        {
            if (intersections[i] == n)
            {
                countIntersection++;
            }
        }

        int[] intersection = new int[countIntersection];
        pointer = 0;
        for (int i = 0; i < intersections.Length; i++)
        {
            if (intersections[i] == n)
            {
                intersection[pointer] = union[i];
                pointer++;
            }
        }

        Console.WriteLine("Пересечение всех множеств:");
        if (countIntersection > 0)
        {
            foreach (int item in intersection)
            {
                Console.Write($"{item} ");
            }
        }
        else
        {
            Console.Write("Пусто!");
        }
        Console.WriteLine();

        Console.WriteLine("Объединение всех множеств:");
        if (countUnion > 0)
        {
            foreach (int item in union)
            {
                Console.Write($"{item} ");
            }
        }
        else
        {
            Console.Write("Пусто!");
        }
        Console.WriteLine();

        Console.WriteLine("Дополнение для каждого множества относительно объединения:");
        for (int i = 0; i < n; i++)
        {
            int flag = 0;
            Console.Write($"{i}:\t");
            for (int k = 0; k < union.Length; k++)
            {
                if (!arr[i].Contains(union[k]))
                {
                    Console.Write("{0} ", union[k]);
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                Console.Write("Пусто!");
            }
            Console.WriteLine();
        }
    }
}