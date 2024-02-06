using System;

namespace Times
{
    class Programm
    {
        public static void Times()
        {
            int seconds, minutes, hours;
            Console.WriteLine("Enter the number of seconds:");
            seconds = Convert.ToInt32(Console.ReadLine());
            hours = seconds / 3600;
            seconds = seconds - 3600 * hours;
            minutes = seconds / 60;
            seconds = seconds - 60 * minutes;
            Console.WriteLine("Your time is:");
            Console.WriteLine(hours + ":" + minutes + ":" + seconds);
            Console.ReadLine();
        }
    }
}