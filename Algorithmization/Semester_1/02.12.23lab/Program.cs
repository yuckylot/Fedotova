using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Car_class
{
    public class Car
    {
        private int Year { get; set; }
        private string Color { get; set; }
        private int EngineNum { get; set; }
        private string Mark { get; set; }
        private string[] Owners = new string[6];
        private int[] YearTS = new int[6];


        public Car(string mark, int year, string[] owner , int[] years, string color, int ennum)
        {
            Mark = mark;
            Year = year;
            Owners = owner;
            YearTS = years;
            Color = color;
            EngineNum = ennum;
        }
        public void getAll()
        {
            Console.WriteLine("------------------");
            Console.WriteLine($"{Mark}");
            Console.WriteLine("Year of prod: " + Year);
            Console.WriteLine("Owners:");
            for (int i = 0; i < Owners.Length; i++)
            {
                Console.WriteLine("   "+ (i+1) +": " + Owners[i]);
            }
            Console.WriteLine("Years of ts");
            for (int i = 0;i < YearTS.Length; i++)
            {
                Console.WriteLine("   " + (i+1) + ": " + YearTS[i]);
            }
            Console.WriteLine("Color: " + Color);
            Console.WriteLine("Engine Num: " + EngineNum);
            Console.WriteLine("-------------------"); 
        }
        public void SearchbyEngine(int numb)
        {
            if (numb == EngineNum) getAll();
        }
        public void SearchbyYearts(int yts)
        {
            if (YearTS.Contains(yts)) getAll();
        }
        public void OneOwner()
        {
            if (Owners.Length == 1) getAll() ;
        }
    }
    class Prog
    {
        public static void Main()
        {
            Car[] cars = new Car[3] {new Car("volvo", 2015, new string[1] {"oldman"}, new int[3] {2016, 2019,2022}, "red", 307), new Car("Lada", 1990, new string[1] {"estriper"},new int[5] {1998, 2003, 2009, 2012, 2017},"gray",17), new Car("Toyota", 2005, new string[2] {"marig", "kago" } , new int[4] {2006, 2012, 2017, 2021}, "black", 11)};
            Console.WriteLine("Enter engine num: ");
            int seen = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i<cars.Length; i++) 
            {
                cars[i].SearchbyEngine(seen);
            }
            Console.WriteLine("Enter year of ts:");
            int sets = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].SearchbyYearts(sets);
            }
            Console.WriteLine("Cars with one owner:");
            Console.ReadKey();
            for (int i = 0; i < cars.Length; i++)
            {
                
                cars[i].OneOwner();
            }

        }
    }
}
