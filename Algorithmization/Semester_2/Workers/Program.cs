using System;
using System.Linq;
using System.Collections.Generic;

class Worker
{
    public int id;
    public string name;
    public string position;
    public int salary;
    public string category;
    public int quantity;
    public int pricePerPiece;

    public Worker(int id, string name, string position, int salary, string category, int quantity, int pricePerPiece)
    {
        this.id = id;
        this.name = name;
        this.position = position;
        this.salary = salary;
        this.category = category;
        this.quantity = quantity;
        this.pricePerPiece = pricePerPiece;
    }
    public void Print()
    {
        Console.WriteLine($"id {id}");
        Console.WriteLine($"name {name}");
        Console.WriteLine($"position {position}");
        Console.WriteLine($"salary {salary}");
        Console.WriteLine($"category {category}");
        Console.WriteLine($"quatity {quantity}");
        Console.WriteLine($"ppp {pricePerPiece}");
        Console.WriteLine($"q*p = {quantity * pricePerPiece}");
        Console.WriteLine("");
    }
}

public static class Program
{
    public static void Main()
    {
        List<Worker> workers = new List<Worker>(){
            new Worker(1, "1", "1", 10000, "food", 23, 1000),
            new Worker(2, "2", "2", 12000, "tech", 13, 1500),
            new Worker(3, "3", "3", 15000, "food", 33, 200),
        };

        var q1 = from w in workers
                 where w.salary < w.quantity * w.pricePerPiece
                 select w;

        Console.WriteLine($"1) {q1.Count()}");

        Console.WriteLine($"2) ");
        var q2 = from w in workers
                 group w by w.category;

        foreach (var category in q2)
        {
            int totalUnits = 0;
            int totalMoney = 0;
            foreach (var w in category) { totalUnits += w.quantity; totalMoney += w.quantity * w.pricePerPiece; }
            Console.WriteLine($"{category.Key} - {totalUnits} un. / {totalMoney}$");
        }

        int q3 = workers.Select(x => x.quantity).Sum();
        Console.WriteLine($"3) {q3}");

        var q4 = workers.Where(w => w.salary > 0.5 * w.quantity * w.pricePerPiece).ToList().Count();
        Console.WriteLine($"4) {q4}");
    }
}