// работаем с двумерным массивом дан массив размером Н*М необходимо определить :
// 1. кол во столюцов в которых суммма элементов отрицательна а произведение положмительно
// 2. опред во всех ли строках минимальный элемент четный
// 3. посчитать кол во не нулевых элементов массива 
// 4. определить наибольший четный элемент 
// 5. опред кол-во пар строк сост из одинаковых элементов 


using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;
using System.Linq;
using System.Runtime.InteropServices;

namespace Work_with_Matrix
{
    class Programm
    {
        public static void Main()
        {
            Console.WriteLine("Введите N and M:");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите Числа массива:");
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    matrix[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    
                    
                    Console.Write("{0,3}", matrix[i, j]);
                }
                Console.WriteLine();
            }


            // 1.
            int counter = 0;
            int sum = 0;
            int miltiply = 1;
            for (int i = 0;i < n; i++)
            {
                sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += matrix[j, i];
                    miltiply *= matrix[j, i];
                }
                if (sum < 0 && miltiply > 0)
                {
                    counter++;
                } 

            }
            Console.WriteLine("1. -  |{0}|", counter);

            // 2.
            counter = 0;
            int[] resours = new int[m];
            bool lit = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        resours[k] = matrix[i, j];
                    }
                    
                }

                if (resours.Min() % 2 == 0)
                {
                    lit = true;
                
                }
                if (!lit)
                {
                    Console.WriteLine("2. No");
                }

            }
            if (lit)
            {
                Console.WriteLine("2. Yes");
            }


            // 3.
            counter = 0;
            for (int i= 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        counter += 1;
                    }
                }
            }
            Console.WriteLine("3. {0}",counter);


            // 4.
            string max_els = "";
            int max_el = -100000000;
            int[] maxis = new int[n];
            for (int i = 0; i <m  ; i++)
            {
                for (int j = 0; j <n; j ++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        maxis[k] = matrix[j, i];

                    }
                }
                
                for (int l = 0; l < n; l++)
                {
                    if (maxis[l] % 2 == 0)
                    {
                        max_el = Math.Max(max_el, maxis[l]);
                        Console.WriteLine(max_el);
                    }
                }
                max_els += Convert.ToString(max_el) + " ";
                max_el = -1111111111;
            }
            Console.WriteLine("4. {0}",max_els);

            // 5.


        }

    }
} 