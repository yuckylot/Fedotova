using System;
using System.Linq;

class Tourists
{
    static void Main()
    {
        Console.WriteLine("Введите время восхода: (7:30)");
        string sunrise_time = Console.ReadLine();
        Console.WriteLine("Введите время заката: (22:30)");
        string sunset_time = Console.ReadLine();
        Console.WriteLine("Введите скорость: (км\\ч)");
        double speed = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите количество остановок:");
        int stop_amount = Convert.ToInt32(Console.ReadLine());
        double[] stops = new double[stop_amount];
        Console.WriteLine("Введите расстояния до остановок:");
        for (int i = 0; i < stop_amount; i += 1)
        {
            stops[i] = Convert.ToDouble(Console.ReadLine());
        }

        double sunrise_hours = Convert.ToDouble(sunrise_time.Split(':')[0]);
        double sunrise_minutes = Convert.ToDouble(sunrise_time.Split(':')[1]) / 60;
        double sunrise = sunrise_hours + sunrise_minutes;

        double sunset_hours = Convert.ToDouble(sunset_time.Split(':')[0]);
        double sunset_minutes = Convert.ToDouble(sunset_time.Split(':')[1]) / 60;
        double sunset = sunset_hours + sunset_minutes;

        double available_time = sunset - sunrise;
        double distance = speed * available_time;

        int day_count = 0;
        int pointer = 0;
        int step = 1;
        double position = 0;

        while (pointer + step < stop_amount)
        {
            if (stops[pointer + step] - position <= distance)
            {
                step += 1;
            }
            else
            {
                pointer += step;
                position = stops[pointer - 1];
                step = 1;
                day_count += 1;
                Console.Write("{0} ", pointer);
            }
        }

        Console.WriteLine();
        Console.WriteLine(day_count);
    }
}