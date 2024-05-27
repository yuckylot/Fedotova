//Даны данные о банковских счетах клиентов
//Структура данных: номер счёта, ФИО, доход, расход,
//налог(5 % с дохода, автоматически, исходя из дохода).
//  Необходимо с использованием запросов отобрать клиентов с отрицательным балансом,
//  Посчитать количество клиентов с положительным балансом,
//  Выдать клиентов с максимальным доходом,
//  Посчитать общую сумму налогов

using System;
using System.CodeDom.Compiler;
using System.Linq;

namespace Yuckylot
{
    class Bank
    {
        string Name;
        List<Account> Accounts;

        public Bank()
        {
            Name = "Yuckylot Bank";
            Accounts = new List<Account>();
        }
        public void FillBase()
        {
            for (int i = 1; i < 50; i ++)
            {
                Accounts.Add(GenerateAccount(i));
            }
        }
        public Account GenerateAccount(int id)
        {
            string[] names1 = { "Серхио", "Даниэль", "Каролина", "Дэвид", "Рейна", "Сол", "Бернард", "Дэнни", "Димас", "Юрий", "Иван", "Лаура" };
            string[] names2 = { "Тапиа", "Гутьеррес", "Руэда", "Гальвиз", "Юли", "Ривера", "Мамами", "Сауседо", "Домингес", "Эскобар", "Мартин", "Креспо" };
            string[] names3 = { "Джонсон", "Уильямс", "Джонс", "Браун", "Дэвид", "Миллер", "Уилсон", "Андерсон", "Томас", "Джексон", "Уайт", "Дэвид", "Миллер", "Уилсон", "Андерсон", "Томас", "Джексон", "Уайт", "Робинсон" };
            Random rnd = new Random();
            return new Account(id, $"{names1[rnd.Next(0, names1.Length)]} {names2[rnd.Next(0, names2.Length)]} {names3[rnd.Next(0, names3.Length)]}", Math.Round(rnd.NextDouble()*10000, 2), Math.Round(rnd.NextDouble() * 10000, 2)); 
        }
        public void Show()
        {
            foreach (Account account in Accounts)
            {
                account.ShowAcc();  
            }
        }
        public void NegativeBalanceAccounts()
        {
            Console.WriteLine("Чтобы увидеть аккаунты с Отрицательным балансом, нажмите любую калвишу");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Счета с отрицательным Балансом");
            Accounts
                .Where(acc => (acc.Income - acc.Outcome - acc.Tax) < 0)
                .ToList()
                .ForEach(acc => acc.ShowAcc());

        }
        public void CountPositivBalanceAccounts()
        {
            Console.WriteLine("Чтобы увидеть количество счетов с положительным балансом, нажмите любую калвишу");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Колличество счетов Балансом");
            Console.WriteLine(
                Accounts
                .Where(acc => (acc.Income - acc.Outcome - acc.Tax) > 0)
                .ToList()
                .Count()
                );
                
        }
        public void ClientsWithMaxIncome()
        {
            Console.WriteLine("Чтобы увидеть клиентов с максимальным доходом, нажмите любую калвишу");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Колличество счетов Балансом");
            double maxIncome =
                Accounts
                .OrderByDescending(acc => acc.Income)
                .First().Income;
            Accounts
                .Where(acc => acc.Income == maxIncome)
                .ToList()
                .ForEach(acc => Console.WriteLine($"На счеиту:{acc.Id}; Хозяин счета:{acc.Name}; Доходы: {acc.Income}"));
        }
        public void AllTaxSum()
        {
            Console.WriteLine("Чтобы увидеть сумму всех налогов, нажмите любую калвишу");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Сумма налогов: ");
            double sum =
                Accounts
                .Select(acc => acc.Tax)
                .ToList()
                .Sum();
            Console.Write(sum);
        }
    }
    class Account
    {
        public int Id;
        public string Name;
        public double Income;
        public double Outcome;
        public double Tax;

        public Account(int id, string name, double income, double outcome)
        {
            Id = id;
            Name = name;
            Income = income;
            Outcome = outcome;
            Tax = Math.Round(Income * 0.05, 2);
        }
        public void ShowAcc()
        {
            Console.WriteLine($"На счеиту:{Id}; Баланс: {Income - Outcome - Tax}; Хозяин счета:{Name}; Доходы: {Income}; Расходы: {Outcome}; Налог: {Tax}");
        }
    }

    class Program
    {
        public static void Main() 
        {
            Bank bank = new Bank();
            bank.FillBase();
            bank.NegativeBalanceAccounts();
            bank.CountPositivBalanceAccounts();
            bank.ClientsWithMaxIncome();
            bank.AllTaxSum();
        }
    }
}
