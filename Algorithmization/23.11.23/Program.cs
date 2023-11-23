//Описать класс "Студент" (ФИО, год рождения, наименование группы)
//Сделать конструкторы, свойства, в головной программе создать
//массив экземпляров класса, в классе написать два метода,
//которые выводят на экран поля экземляра класса, по году или группе(поиск)

using System;
using System.Globalization;
using System.Runtime.ExceptionServices;

namespace stud
{
    public class Student
    {
        private string FIO { set; get; }
        private string Group { set; get; }
        private int Year { set; get; }
        public Student(string name, string group, int year)
        {
            this.FIO = name;
            this.Group = group;
            this.Year = year;
        }
        public string GetFIO()
        {
            return FIO;
        }
        public int SetFIO(string name)
        {
            this.FIO = name;
            return 1;
        }
        public string GetGroup() { 
            return Group;
        }
        public int SetGroup(string group)
        {
            this.Group = group;
            return 1;
        }
        public int GetYear()
        {
            return Year;
        }
        public int SetYear(int year)
        {
            this.Year = year;
            return 1;
        }
        public void SearchByGroup(string group)
        {
            if (this.Group == group)
            {
                Console.WriteLine($"{this.FIO}, {this.Group}, {this.Year}");
            }
        }
        public void SearchByYear(int year)
        {
            if (this.Year == year)
            {
                Console.WriteLine($"{this.FIO}, {this.Group}, {this.Year}");
            }
        }
        class program
        {
            public static void Main()
            {
                Student[] students = new Student[3] { new Student("kir", "fit-222", 2004), new Student("nik", "fit-322", 2005), new Student("sasha", "fit-232", 2005) };
                Console.Write("Year: ");
                int SearchingYear = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < students.Length; i++) { students[i].SearchByYear(SearchingYear); }
                Console.Write("Group: ");
                string SearchingGroup = Convert.ToString(Console.ReadLine());
                for (int i = 0;i < students.Length; i++) { students[i].SearchByGroup(SearchingGroup); }
                Console.ReadKey();
            }
        }
    }
}