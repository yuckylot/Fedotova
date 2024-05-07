using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication23
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"./../../../subString.txt");
            int min_count = int.MaxValue;
            string min_line = "";
            bool check = false;
            while (true)
            {
                string line = sr.ReadLine();
                if (line != null)
                {
                    int count = 0;
                    foreach (char symb in line)
                    {
                        if (symb == 'a')
                        {
                            count += 1;
                        }
                        else if (count != 0 && count < min_count)
                        {
                            min_count = Math.Min(min_count, count);
                            min_line = line;
                            count = 0;
                            check = true;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            if (check)
            {
                Console.WriteLine(min_line);
            }
            else
            {
                Console.WriteLine("no a");
            }
            Console.ReadKey();
        }
    }
}