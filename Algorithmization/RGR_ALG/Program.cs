//  10.	Программа с помощью датчика случайных чисел выбирает число в диапазоне от 0 до N.
//      Угадать это число с ограничением числа попыток и без ограничения.
//      После каждой попытки сообщается, больше или меньше названное число задуманного.

// https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/statements/exception-handling-statements
// https://learn.microsoft.com/ru-ru/dotnet/api/system.random?view=net-8.0
// https://learn.microsoft.com/ru-ru/dotnet/api/system.math.log?view=net-8.0

using System;


namespace rgr
{
    class Play
    {
        static void Main()
        {
            Random r = new Random();
            bool suc = true;
            int n;
            int playersNumber;
            int numberToFind;
            int countOfTrurns; 
            bool GameModeTurns;
            Console.WriteLine("+------- Choose Game Mode:");
            Console.WriteLine("| * 1 - Game with limit of turns");
            Console.WriteLine("| * 2 - Game without limit of turns");
            Console.Write("| ");
            if (Console.ReadLine() == "1")
            {
                GameModeTurns = true;
                Console.WriteLine("| * Game with limits *");
            } 
            else
            {
                GameModeTurns = false;
                Console.WriteLine("| * Game without limits *");
            }
            Console.WriteLine("| Enter Limit of Numbers: (by default = 100)");
            Console.Write("| ");
            string s = Console.ReadLine();
            if (s.Length > 0)
            {
                n = int.Parse(s);
            }
            else
            {
                n = 100;
            }
            if (GameModeTurns)
            {
                countOfTrurns = Convert.ToInt16(Math.Ceiling(Math.Log2(n) * 1.1));
                Console.WriteLine("| Count of Turns set on " + countOfTrurns);
            } 
            else
            {
                countOfTrurns = 1000;
            }

            //Компютер задумывет число
            numberToFind = r.Next(n);

            //Игра Начинается
            Console.WriteLine("+---- Game Starts ");
            for (int i = 0; i < countOfTrurns; i++)
            {
                Console.Write("| Enter supposed number: ");
                playersNumber = int.Parse(Console.ReadLine());
                if (playersNumber != numberToFind) 
                {
                    if (playersNumber > numberToFind)
                    {
                        Console.WriteLine("| MISS number you need is less"); 
                    }
                    else
                    {
                        Console.WriteLine("| MISS number you need is bigger");
                    }
                }
                else if (playersNumber == numberToFind)
                {
                    Console.WriteLine("+---- Success number that you need " + numberToFind );
                    suc = false;
                    break;
                }
                if (GameModeTurns) { Console.WriteLine("| Turns left: " + (countOfTrurns-i-1)); }
            }
            if (suc) { Console.WriteLine("+--- You lost, sorry "); }

        }
    }
}