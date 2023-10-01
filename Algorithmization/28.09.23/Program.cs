using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sgn_change
    
    ;
namespace Programm
{
    internal class Programm
    {
        static void Main()
        {
            Console.WriteLine("Выберите программу:");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 1)
            {
                sgn_change.sgn_cha.sc();
                Console.ReadLine();
            }
        }
    }
}
    
