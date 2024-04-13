using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Interface
{
    interface IMethods
    {
        double Add(double a, double b);
        double Subtract(double a, double b);
        double Multiply(double a, double b);
        double Divide(double a, double b);
        double Root(double a);
        double Sin(double phi);
        double Cos(double phi);
    }
    public class Methods : IMethods
    {
        public static int GetInt0()
        {
            bool flag = false;
            string a = "";
            while (!flag)
            {
                a = Console.ReadLine() ?? "";
                if (a.Length > 0 && Int32.TryParse(a, out int n) && a != "0")
                {
                    flag = true;
                }
            }
            return int.Parse(a);
        }
        static public void ShowMethods()
        { 
            string[] opers = { "Add", "Subtract", "Multiply", "Divide", "Root", "Sin", "Cos"};
            for (int i = 0; i < opers.Length; i++)
            {
                Console.WriteLine($"{i+1}: {opers[i]}");
            }
            Console.WriteLine("0: Exit");
        }
        public double Add(double a, double b)
        {
            return a + b;
        }
        public double Subtract(double a, double b)
        {
            return a - b;
        }
        public double Multiply(double a, double b)
        {
            return a * b;
        }
        public double Divide(double a, double b)
        {
            if (b == 0) 
            {
                Console.WriteLine("Second num mustn't be zero");
                b = GetInt0();
            }
            return a / b;
        }
        public double Root(double a)
        {
            if (a < 0) 
            {
                Console.WriteLine("Num mustn't be negative");
                a = GetInt0();
            }
            return Math.Pow(a, 0.5);
        }
        public double Sin(double phi)
        {
            return Math.Sin(phi);
        }
        public double Cos(double phi)
        {
            return Math.Cos(phi);
        }

    }
    public delegate double Unary(double a);
    public delegate double Binary(double a, double b);

    class Program
    {
        public static int GetInt() 
        {
            bool flag = false;
            string a = "";
            while (!flag)
            {
                a = Console.ReadLine() ?? "";
                if (a.Length > 0 && Int32.TryParse(a, out int n))
                {
                    flag = true;
                }
            }
            return int.Parse(a);
        }
        static void Prog()
        {
            Methods.ShowMethods();
            int input = GetInt();
            Console.Clear();
            Methods obj = new Methods();
            Binary bin = new Binary(obj.Add);
            Unary unar = new Unary(obj.Root);
            bool flag = false;
            do
            {
                flag = false;
                switch (input)
                {
                    case 1:
                        {
                            bin = new Binary(obj.Add);
                            break;
                        }
                    case 2:
                        {
                            bin = new Binary(obj.Subtract);
                            break;
                        }
                    case 3:
                        {
                            bin = new Binary(obj.Multiply);
                            break;
                        }
                    case 4:
                        {
                            bin = new Binary(obj.Divide);
                            break;
                        }
                    case 5:
                        {
                            unar = new Unary(obj.Root);
                            break;
                        }
                    case 6:
                        {
                            unar = new Unary(obj.Sin);
                            break;
                        }
                    case 7:
                        {
                            unar = new Unary(obj.Cos);
                            break;
                        }
                    case 0: 
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Try again");
                            flag = true;
                            break;
                        }
                }
            } while (flag);
            if (input <= 4)
            {
                Console.WriteLine("Enter first num");
                int num1 = GetInt();
                Console.WriteLine("Enter second num");
                int num2 = GetInt();

                Console.WriteLine($"Answer: {bin(num1, num2)}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Enter num");
                int num = GetInt();
                Console.WriteLine($"Answer: {unar(num)}");
                Console.ReadKey();
            }
            Console.Clear();
        }
        static void Main()
        {
            while (true)
            {
                Prog();
            }
        } 
    }
}
