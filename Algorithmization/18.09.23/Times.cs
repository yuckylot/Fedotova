using System;

namespace Times
{
    class Programm
    {
        public static void Times()
        {
            int seconds, minutes, hours;
            seconds = Convert.ToInt32(Console.ReadLine());
            hours = seconds / 3600;
            seconds = seconds - 3600 * hours;
            minutes = seconds / 60;
            seconds = seconds - 60 * minutes;
            Console.WriteLine(hours + ":" + minutes + ":" + seconds);
            Console.ReadLine();
        }
    }
}