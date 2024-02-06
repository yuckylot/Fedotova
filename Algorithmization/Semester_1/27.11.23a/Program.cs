using System;
using System.Runtime.InteropServices;

namespace sssd
{
    public class Car
    {
        private int Year { get; set; }
        private string Color { get; set; }
        private string Mark { get; set; }
        private string FIO { get; set; }
        private int YearTS { get; set; }

        public Car(int year, string color, string mark, string fio , int yts)
        {
            Year = year;
            Color = color;
            Mark = mark;
            FIO = fio;
            YearTS = yts;
        }
        public void SearchByYear(int year)
        {
            if (Year == year) 
            {
                Console.WriteLine($"{Year},{Color},{Mark},{FIO},{YearTS}");
            }
        }
        public void SearchByMark(string mark)
        {
            if (Mark == mark)
            {
                Console.WriteLine($"{Year},{Color},{Mark},{FIO},{YearTS}");
            }
        }
        public void SearchByFIO(string fio)
        {
            if (FIO == fio)
            {
                Console.WriteLine($"{Year},{Color},{Mark},{FIO},{YearTS}");
            }
        }
        public void SearchByYTS(int yts)
        {
            if (YearTS == yts)
            {
                Console.WriteLine($"{Year},{Color},{Mark},{FIO},{YearTS}");
            }
        }
    }
    class Prog
    {
        public static void Main()
        {
            Car[] cars = new Car[5] {new Car(2005,"black","toyota","nik",2007),new Car(2020, "blue", "lada", "egor", 2015), new Car(2023, "gray", "jaguar", "kola", 2023),new Car(1990, "green", "honda", "vadin", 2000), new Car(2004, "purple", "lada", "sanya", 2020)};

            Console.Write("year: ");
            int ser_year = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SearchByYear(ser_year);
            }
            Console.Write("mark: ");
            string ser_mar= Console.ReadLine();
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SearchByMark(ser_mar);
            }
            Console.Write("Fio: ");
            string ser_fio = Console.ReadLine();
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SearchByFIO(ser_fio);
            }
            Console.Write("Year of ts: ");
            int ser_yearts = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SearchByYTS(ser_yearts);
            }

        }
    }
}
