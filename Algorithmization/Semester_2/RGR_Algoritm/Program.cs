using System;

namespace Yuckylot
{
    class Program
    {
        static void IsBracketCorrect()
        {
            while (true)
            {
                Console.WriteLine("Введите выражение( чтобы перейти в меню напишите 'exit'):");
                string expression = Console.ReadLine() ?? "";
                if (expression == "exit")
                {
                    return;
                }
                else if (expression.Length > 0)
                {
                    char[] openBracket = { '(', '[', '{' };
                    char[] closeBracket = { ')', ']', '}' };
                    Stack<char> stack = new Stack<char>();
                    bool flag = true;
                    foreach (char c in expression)
                    {
                        if (openBracket.Contains(c))
                        {
                            stack.Push(c);
                        }
                        if (closeBracket.Contains(c))
                        {
                            if (stack.Count > 0)
                            {
                                char bracket = stack.Pop();
                                if (!(Array.IndexOf(closeBracket, c) == Array.IndexOf(openBracket, bracket)))
                                {
                                    flag = false;
                                }
                            }
                            else 
                            {
                                flag = false;
                            }
                        }
                    }
                    if (flag && stack.Count == 0)
                    {
                        Console.WriteLine("Скобки расставленны правильно");
                    }
                    else
                    {
                        Console.WriteLine("!Скобки расставленны некорректно!");
                    }
                    

                }
                else 
                {
                    Console.WriteLine("Выражение не может быть пустым!\nПопробуйте снова");
                    Console.WriteLine("Нажмите любую клавишу для перехода к записи выражения");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }

        static void RPN()
        {
            string expression = Console.ReadLine() ?? "";
            if (expression.Length > 0)
            {
                Stack<string> stack = new Stack<string>();
                string[] oper = { "+", "-", "*", "/" }; 
                string[] exp = expression.Split(' ');
                bool succses = true;

                foreach (string c in exp) 
                {

                    if (oper.Contains(c) && (c == exp[0] || c == exp[1]))
                    {
                        Console.WriteLine("Неверная запись");
                    }
                    else if (oper.Contains(c))
                    {
                        int a = Convert.ToInt32(stack.Pop());
                        int b = Convert.ToInt32(stack.Pop());
                        if (c == oper[0])
                        {
                            stack.Push((a+b).ToString());

                        }
                        else if (c == oper[1])
                        {
                            stack.Push((b - a).ToString());
                        }
                        else if (c == oper[2])
                        {
                            stack.Push((a * b).ToString());
                        }
                        else if (c == oper[3])
                        {
                            if (a != 0)
                            {
                                stack.Push((b / a).ToString());
                            }
                            else
                            {
                                Console.WriteLine("Деление на ноль");
                                succses = false;
                                break;
                            }
                        }
                    }
                    else 
                    {
                        stack.Push(c);
                    }
                }
                if (succses && stack.Count == 1)
                {
                    Console.WriteLine($"Решение: {stack.Pop()}");
                    Console.ReadKey();
                }
                else 
                {
                    Console.WriteLine("Неверная запись");
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("Выражение не может быть пустым\nПопробуйте снова");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AboutAuthor()
        {
            Console.WriteLine("Выполнил\nСтудент группы ФИТ-232\nХарлов Никита Станиславович");
            Console.ReadKey();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Об Авторе");
                Console.WriteLine("2. Проверка правильности скобок");
                Console.WriteLine("3. Вычисление польской записи");
                Console.WriteLine("4. Выход");

                int check = ReadNum();

                if (check == 1)
                {
                    Console.Clear();
                    AboutAuthor();
                }
                else if (check == 2)
                {
                    Console.Clear();
                    IsBracketCorrect();
                }
                else if (check == 3)
                {
                    Console.Clear();
                    RPN();
                }
                else if (check == 4)
                {
                    Console.Clear();
                    return;
                }
            }
        }
        static int ReadNum() // метод валидирующий ввод вместо -> Convert.ToInt32(Console.ReadLine())
        {
            string num = "";
            bool flag = false;
            while (!flag)
            {
                num = Console.ReadLine() ?? "";
                if (int.TryParse(num, out int n))
                {
                    flag = true;
                }
            }
            return Convert.ToInt32(num);
        }

        static void Main() 
        {
            Menu();
        }
    }

    
}