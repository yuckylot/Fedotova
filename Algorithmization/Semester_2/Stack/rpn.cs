using System;
using System.Collections;
using System.Collections.Generic;

class Rpn
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter Line:");
        string str = Console.ReadLine() ?? "";

        var notation = str.Split();
        string[] operations = new string[] { "+", "-", "*", "/" };

        Stack<double> stack = new Stack<double>();

        bool valid = true;

        foreach (string elem in notation)
        {
            bool isDouble = double.TryParse(elem, out double number);
            if (isDouble)
            {
                stack.Push(number);
            }
            else if (Array.IndexOf(operations, elem) != -1)
            {
                if (stack.Count < 2)
                {
                    valid = false;
                    break;
                }

                double n1 = stack.Pop();
                double n2 = stack.Pop();

                if (elem == "+")
                {
                    stack.Push(n2 + n1);
                }
                else if (elem == "-")
                {
                    stack.Push(n2 - n1);
                }
                else if (elem == "*")
                {
                    stack.Push(n2 * n1);
                }
                else if (elem == "/")
                {
                    if (n1 == 0)
                    {
                        throw new DivideByZeroException("Нельзя делить на ноль!");
                    }
                    else
                    {
                        stack.Push(n2 / n1);
                    }
                }
            }
        }

        if (stack.Count != 1)
        {
            valid = false;
        }

        if (valid)
        {
            Console.WriteLine("Запись верна!");
            Console.WriteLine($"Результат: {stack.Peek()}");
        }
        else
        {
            Console.WriteLine("Запись НЕВЕРНА!");
        }
    }
}