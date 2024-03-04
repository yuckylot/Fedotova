// формируется база аудиторий университета
// * кол-во мест 
// * оснащенность проектором
// * оснащенность компютерами
// * номер этажа
//
// Необходимо:
// 1. Список аудиторий с кол-во посад мест больше или равному заданного
// 2. Список ауд с проектором и заданным кол-во мест
// 3. Списоок ауд и комп и заданным кол во мест
// 4. Спиисок ауд на заданннм этаже
// 5. Польный список
//
// Отдельный класс меню:
//
// Перечень след функций:
// 1. Заполнение фудиторий
// 2. Добавление 
// 3. Изменение данных по этажу и номеру
// 4. перечень всех запросов в меню
// 5. Выход

using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Linq;
using System.Drawing;

namespace Uni
{
    class Auditor
    {
        private string Number;
        private string Floor;
        private int Seats;
        private bool Projector;
        private int Comp;

        public Auditor(string number, string floor, int seats, bool projector, int comp)
        {
            Number = number;
            Floor = floor;
            Seats = seats;
            Projector = projector;
            Comp = comp;
        }

        public void WriteAll()
        {
            Console.WriteLine($"Number: {Floor + Number}\nSeats: {Seats}\nProjector: {Projector}\nComputers: {Comp}");
        }

        public void AudBySeats(int seats)
        {
            if (Seats >= seats)
            {
                WriteAll();
            }
        }
        public void AudByProj(bool d)
        {
            if (Projector == d)
            {
                WriteAll();
            }
        }
        public void AudByComp(int comps)
        {
            if (Comp >= comps && Seats >= comps)
            {
                WriteAll();
            }
        }
        public void AudByFloor(string floor)
        {
            if (Floor == floor)
            {
                WriteAll();
            }
        }
        public void AllAud()
        {
            WriteAll();
        }

        public string[] NumberFloor() 
        {
            return new string[2] { Number, Floor };
        }
        public void ChangeAtr(string par)
        {
            if (par == "1")
            {
                Console.WriteLine("How much seats in room now");
                int n = Convert.ToInt32(Console.ReadLine());
                Seats = n;
            }
                
            else if (par == "2")
            {
                Console.WriteLine("Projector");
                Console.WriteLine("1. true");
                Console.WriteLine("2. false");
                bool pr = false;
                string n = Console.ReadLine() ?? "";
                if (n == "1")
                {
                    pr = true;

                }
                else if (n == "2")
                {
                    pr = false;
                }
                Projector = pr;
            }
            else if (par == "3")
            {
                Console.WriteLine("How much computers in room now");
                int n = Convert.ToInt32(Console.ReadLine());
                Comp = n;
            }

        }
    }

    class Menu
    {
        public static Auditor AddAud()
        {
            bool flag = false;
            string floor = "0";
            string num = "0";
            string seats = "0";
            bool projector = false;
            string comp = "0";
            Auditor b = new Auditor(num, floor, Convert.ToInt32(seats), projector, Convert.ToInt32(comp));
            Console.WriteLine("Enter floor:");
            while (!flag)
            {
                floor = Console.ReadLine() ?? "";
                if (int.TryParse(floor, out int n)) {

                    flag = true;
                }
            } flag = false;
            Console.WriteLine("Enter number:");
            while (!flag)
            {
                num = Console.ReadLine() ?? "";
                if (int.TryParse(num, out int n))
                {

                    flag = true;
                }
            }
            flag = false;
            Console.WriteLine("Enter count of seats:");
            while (!flag)
            {
                seats = Console.ReadLine() ?? "";
                if (int.TryParse(seats, out int n))
                {

                    flag = true;
                }
            }
            flag = false;
            Console.WriteLine("Projector:");
            while (!flag)
            {
                Console.WriteLine("1. true");
                Console.WriteLine("2. false");
                string g = Console.ReadLine() ?? "";
                if (g == "1")
                {
                    projector = true;
                    flag = true;
                } else if (g == "2") {
                    projector = false;
                    flag = true;
                } else
                {
                    flag = false;
                }
            } flag = false;
            Console.WriteLine("Enter count of computers");
            while (!flag)
            {
                comp = Console.ReadLine() ?? "";
                if (int.TryParse(comp, out int n))
                {

                    flag = true;
                }
            }
            if (flag)
            {
                if (num is not null && floor is not null && seats is not null && comp is not null)
                {
                    Auditor a = new Auditor(num, floor, Convert.ToInt32(seats), projector, Convert.ToInt32(comp));
                    return a;

                }
            }
            return b;
        }
        public static void ChangeAud()
        {

        }
        public static void AudMet()
        {

        }
        public static void Mene()
        {
            List<Auditor> Auds = new List<Auditor>() {};
            while (true)
            {

                Console.WriteLine("1. Fill Aud list");
                Console.WriteLine("2. Add one Aud");
                Console.WriteLine("3. Change Aud info");
                Console.WriteLine("4. Auds by smth");
                Console.WriteLine("5. Exit");

                string s = Console.ReadLine() ?? "";
                Console.Clear();
                if (s == "1")
                {
                    Auds.Add(AddAud());
                    while (true)
                    {
                        Console.WriteLine("If you want to go to menu, print n/N");
                        string t = Console.ReadLine() ?? "";
                        if (t == "n" || t == "N")
                        {
                            break;
                        } 
                        else
                        {
                            Auds.Add(AddAud());
                            Console.ReadKey();
                        }
                        
                    }
                }
                else if (s == "2")
                {
                    Auds.Add(AddAud());
                }
                else if (s == "3")
                {
                    if (Auds.Count == 0)
                    {
                        Console.WriteLine("database is empty");
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.WriteLine("Enter Number");
                        string number = Console.ReadLine() ?? "";
                        Console.WriteLine("Enter Floor");
                        string floor = Console.ReadLine() ?? "";

                        foreach (Auditor auditor in Auds)
                        {
                            string[] ad = auditor.NumberFloor();
                            if (ad[0] == number && ad[1] == floor )
                            {
                                Console.Clear();
                                Console.WriteLine("1. Change count of seats");
                                Console.WriteLine("2. Change Projector");
                                Console.WriteLine("3. Change count of computers");
                                bool flag = false;
                                string h = "";
                                while (!flag)
                                {
                                    h = Console.ReadLine() ?? "";
                                    if (int.TryParse(h, out int n))
                                    {

                                        flag = true;
                                    }

                                }
                                auditor.ChangeAtr(h);

                            }
                        }
                    }

                }
                else if (s == "4")
                {
                    Console.WriteLine("All Auds sorts");
                    if (Auds.Count == 0)
                    {
                        Console.WriteLine("database is empty");
                        Console.ReadKey();

                    }
                    else if (Auds.Count > 0)
                    {
                        
                        
                        string j = "";
                        bool flag = false;
                        while (!flag)
                        {
                            Console.WriteLine("1. Auds by Seats");
                            Console.WriteLine("2. Auds by Projector");
                            Console.WriteLine("3. Auds by Comps and Seats");
                            Console.WriteLine("4. Auds by Floor");
                            Console.WriteLine("5. Write all Auds");
                            j = Console.ReadLine() ?? "";
                            if (j == "1" || j == "2" || j == "3" || j == "4" || j == "5") 
                            {
                                flag = true;
                            }
                            Console.Clear();
                        }
                        if (j == "1")
                        {
                            Console.WriteLine("Enter Count of seats");
                            string seats = "";
                            bool flage = false;
                            while (!flage)
                            {
                                seats = Console.ReadLine() ?? "";
                                if (int.TryParse(seats, out int n))
                                {

                                    flage = true;
                                }

                            }
                            foreach (Auditor auditors in Auds)
                            {
                                auditors.AudBySeats(Convert.ToInt32(seats));
                                Console.ReadKey();
                            }

                        }
                        else if (j == "2")
                        {

                            Console.WriteLine("Projector");
                            Console.WriteLine("1. true");
                            Console.WriteLine("2. false");
                            Console.WriteLine("Enter Count of comp");
                            bool proj = false;
                            string u = Console.ReadLine() ?? "";
                            bool flage = false;
                            while (!flage)
                            {
                                if (u == "1" || u == "2")
                                {
                                    flage = true;
                                }
                            }
                            if (u == "1")
                            {
                                proj = true;
                            }
                            else
                            {
                                proj = false;
                            }
                            Console.Clear();
                            foreach (Auditor auditors in Auds)
                            {
                                auditors.AudByProj(proj);
                                Console.ReadKey();
                            }
                        }
                        else if (j == "3")
                        {
                            Console.WriteLine("Enter Count of comp");
                            string comp = "";
                            bool flage = false;
                            while (!flage)
                            {
                                comp = Console.ReadLine() ?? "";
                                if (int.TryParse(comp, out int n))
                                {

                                    flage = true;
                                }

                            }
                            foreach (Auditor auditors in Auds)
                            {
                                auditors.AudByComp(Convert.ToInt32(comp));
                                Console.ReadKey();
                            }
                        }
                        else if (j == "4")
                        {
                            Console.WriteLine("Enter Floor");
                            string floor = "";
                            bool flage = false;
                            while (!flage)
                            {
                                floor = Console.ReadLine() ?? "";
                                if (int.TryParse(floor, out int n))
                                {

                                    flage = true;
                                }

                            }
                            foreach (Auditor auditors in Auds)
                            {
                                auditors.AudByFloor(floor);
                                Console.ReadKey();
                            }
                        }
                        else if (j == "5")
                        {
                            foreach (Auditor auditors in Auds)
                            {
                                auditors.AllAud();
                                Console.ReadKey();
                            };
                        }

                            
                        
                    }

                }

                else if (s == "5")
                {
                    Environment.Exit(0);
                }
                Console.Clear();
            }

        }
    }
    class Programm { 
        static void Main()
        {
            Menu.Mene();
        }
    
    }
}