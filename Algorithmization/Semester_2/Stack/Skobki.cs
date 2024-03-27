using System;
using System.Collections;
using System.Collections.Generic;

class Skobki
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter String");
        string str = Console.ReadLine() ?? "";
        char[] parens = ['(', ')', '[', ']', '{', '}'];

        Stack<char> stack = new Stack<char>();

        foreach (char c in str)
        {
            int index = Array.IndexOf(parens, c);
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (index != -1)
            {
                if (stack.Count > 0 && stack.Peek() == parens[index - 1])
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }
        }

        Console.WriteLine();

        if (stack.Count > 0)
        {
            Console.WriteLine("Error!");
        }
        else
        {
            Console.WriteLine("Good!");
        }
    }
}