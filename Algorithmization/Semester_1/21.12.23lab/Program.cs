/*
 * Класс Животные:
 *  Наименование 
 *  Год рождения
 * Наследники:
 *  Собачки:
 *      Порода
 *      Окрас
 *      Выборки:
 *          По-Породе
 *  Кошечки:
 *      Порода
 *      Окрас
 *      Выборка:
 *          По-Окрасу
 *      Возможность смены породы()
 *      
 *  26.10
 *  30.10
 *  13.11
 *  2.12
 *  tables word
 *  kratnost 3
 *  proverit mouse1 2,3,5
 *  turists
 *  mouse2
*/

using System;
using System.Xml.Schema;

namespace Cats_Dogs
{
    class Animals
    {
        public string Name
        { get; set; }
        public int Birth
        { get; set; }

        public Animals(string name, int birth)
        {
            Name = name;
            Birth = birth;
        }
    }
    class Cats : Animals
    {
        private string Kind { get; set; }
        private string Pattern { get; set; }
        public Cats(string name, int birth, string kind, string pattern)
            : base(name, birth)
        {
            Kind = kind;
            Pattern = pattern;
        }
        public void PrintAll()
        {
            Console.WriteLine($" ---------------\n" +
                              $"Name: {Name}\n" +
                              $"Birth: {Birth}\n" +
                              $"Kind: {Kind}\n" +
                              $"Pattern: {Pattern}\n" +
                              $" ---------------");
        }
        public void SearchByPattern(string pattern)
        {
            if (Pattern == pattern) 
            {
                PrintAll();
            }
        }
        public void ChangeKind(string kind)
        {
            Kind = kind;
        }
    }
    class Dogs : Animals
    {
        private string Kind { get; set; }  
        private string Pattern { get; set; }

        public Dogs(string name, int birth, string kind, string pattern)
            :base(name, birth)
        {
            Kind=kind;
            Pattern = pattern;
        }
        public void PrintAll()
        {
            Console.WriteLine($"---------------\n" +
                              $"Name: {Name}\n" +
                              $"Birth: {Birth}\n" +
                              $"Kind: {Kind}\n" +
                              $"Pattern: {Pattern}\n" +
                              $"---------------");
        }
        public void SearchByKind(string kind)
        {
            if (Kind == kind) 
            { 
                PrintAll(); 
            }
        }

    }

    class Program
    {
        static void Main()
        {
            Cats[] arrCat = new Cats[3] { new Cats("barsic", 2013, "lisiy", "none"), new Cats("murzic", 2020, "vislouh", "gray"), new Cats("vasya", 2022, "dvor", "black") };
            Dogs[] arrDog = new Dogs[3] { new Dogs("rex", 2000, "ovcharka", "brown"), new Dogs("max", 2018,"hasky", "gray-blue"), new Dogs("starKiller", 2021, "pitbull", "black") };
            Console.WriteLine("Enter Pattern of Cat: ");
            string pattern = Console.ReadLine();
            foreach (var cat in arrCat) { cat.SearchByPattern(pattern); }
            Console.WriteLine("Enter Kind of Dog: ");
            string kind = Console.ReadLine();
            foreach (var cat in arrDog) {  cat.SearchByKind(kind); }
            Console.WriteLine("Enter wished cat to change kind: ");
            string name = Console.ReadLine();
            foreach (var cat in arrCat) { if (cat.Name == name) { Console.WriteLine($"Enter wished kind to {name}: "); string new_kind = Console.ReadLine(); cat.ChangeKind(new_kind); cat.PrintAll();  } }

        }
    }
}
