using System;
using System.Collections;
using System.Collections.Generic;

namespace AppHistory
{
    class Program
    {
        public static Stack<string> history = new Stack<string>();
        public static Stack<string> forwardHistory = new Stack<string>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1) Go back");
                Console.WriteLine("2) Go forward");
                Console.WriteLine("3) Show history");
                string choise = Console.ReadLine();
                int.TryParse(choise, out int number);
                switch (number)
                {
                    case 1:
                        if (history.Count <= 0)
                        {
                            goto default;
                        }
                        else { Back(history); }
                        break;
                    case 2:
                        if (forwardHistory.Count == 0)
                        {
                            Console.Write("Enter site: ");
                            forwardHistory.Push(Console.ReadLine());
                            Forward(forwardHistory);
                        }
                        else { Forward(forwardHistory); }
                        break;
                    case 3:
                        DisplayHistory(history);
                        break;
                    default:
                        Console.WriteLine("Home page");
                        break;
                }
            }
        }
        public static void DisplayHistory(Stack<string> obj)
        {
            Console.Clear();
            int number = 1;
            foreach (var item in obj)
            {
                Console.WriteLine(number + ")" + item);
                number++;
            }
            Console.WriteLine();
        }
        public static void Back(Stack<string> obj)
        {
            Console.Clear();
            forwardHistory.Push(obj.Pop());
            if (obj.Count != 0)
            {
                Console.WriteLine("You on site: " + obj.Peek());
            }
            else { Console.WriteLine("Home page"); }
        }
        public static void Forward(Stack<string> obj)
        {
            Console.Clear();
            {
                Console.WriteLine("You on site: " + obj.Peek());
                history.Push(obj.Pop());
            }
        }
    }
}