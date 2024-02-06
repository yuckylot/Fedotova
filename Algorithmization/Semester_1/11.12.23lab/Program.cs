using System;

namespace sfas
{
    class Tov
    {
        private string[,] Info = new string[4, 100];
        private string[,] Prod = new string[2, 10];
        private string Name;
        private int Godnost;

        public Tov(string[,] info, string[,] prod, string name, int god)
        {
            Info = info;
            Prod = prod;
            Name = name;
            Godnost = god;
        }

        public void getAll()
        {
           Console.Write(Name); Console.WriteLine(Godnost);
        }

    }
    class program
    {
        public static void Main()
        {
            string[,] date_apple = {{ "10.02", "16.02", "19.03" },
                                  { "9.02", "16.02", "18.03" },
                                  { "14", "17", "22" },
                                  { "30", "32", "36" } };
            string[,] prod_apple = { { "14.02", "26.02" },
                                    { "10", "17" } };
            Tov apple = new Tov(date_apple,prod_apple, "apple", 11);
            apple.getAll();
        }
    }
}