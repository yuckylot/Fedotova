using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace sgn_change
{
    internal class sgn_cha
    {
        public static void sc()
        {
            Console.WriteLine("Enter count of nums:");
            int n = Convert.ToInt32(Console.ReadLine());
            bool is_prev_pos = false;
            bool is_prev_def = false;
            int count = 0;

            Console.WriteLine("Enter {0} numbers:", n);

            for (int i = 0;  i < n; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                if (!is_prev_def)
                {
                    is_prev_def = true;
                }
                else
                {
                    if (is_prev_pos ^ num >=0)
                    {
                        ++count;
                    }
                }
                is_prev_pos = num >= 0;
            }
            Console.WriteLine("Count of sgn changes: {0}", count);
        }
    }
}
