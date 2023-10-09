using System;
using System.Linq;
using System.Reflection;

// дано К мышек одна белая все остальные серые мыши сидят по кругу кот начинает сьедать каждую М мышку
// оперделить с какой мышки кот должен сьедать каждую М мышь чтобы в конце осталась одна белая мышка
// Ограничения: полный перебор нельзя
// позицию превой мыши в самом начале

// подсказка смещаться от стокового значения на число

namespace Cat_Mouse
{
    class programm
    {
        static void Main()
        {
            Console.WriteLine("Enter count of mice:");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter bite:");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter position");
            int pos = Convert.ToInt32(Console.ReadLine());

            int cat_pos = 0;

            int[] mice = new int[k];
            for  (int i = 0; i < k; i++)
            {
                mice[i] = 1;
                Console.WriteLine("[{0}]", string.Join(",", mice));
            }
            Console.WriteLine(mice.Count(j => j == 1));

            cat_pos = cat_pos + m;
            mice[cat_pos] = 0;
            int delta = 0;
            Console.WriteLine("[{0}]", string.Join(",", mice));
            while (mice.Count(j => j == 1) > 1 )
            {
                if (cat_pos + 1 + m > k)
                {
                    delta = k - (cat_pos + 1);
                    cat_pos = m - delta - 1;

                }
                else 
                { 
                    cat_pos += m; 
                }
                mice[cat_pos] = 0;
                Console.WriteLine("[{0}]", string.Join(",", mice));
            }
        }
    }
}