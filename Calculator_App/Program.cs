using System;
using System.Collections.Generic;
using System.Linq.Expressions;

internal class Program
{
    static void Main(string[] args)
    {
        
        List<string> symbols = new List<string>();
        symbols.Add("+");
        symbols.Add("-");
        symbols.Add("*");
        symbols.Add("/");

        List<Func<double, double, double>> operators = new List<Func<double, double, double>>();
        operators.Add(add);
        operators.Add(subtract);
        operators.Add(multiply);
        operators.Add(divide);
        void Calculator()
        {
            Console.Write("Enter the first number: ");
            double first_num = Convert.ToDouble(Console.ReadLine());
            foreach (string symbol in symbols)
            {
                Console.WriteLine(symbol);
            }
            bool endCalc = false;
            while (!endCalc)
            {
                Console.WriteLine("Choose an operation");
                string chosenSymbol = Console.ReadLine();
                Console.Write("Enter the next number: ");
                double next_num = Convert.ToDouble(Console.ReadLine());

                int symbolIndex = symbols.IndexOf(chosenSymbol);
                double answer = operators[symbolIndex](first_num, next_num);
                Console.WriteLine($"Answer is : {answer}");
                Console.WriteLine($"Press 'y' to continue with {answer} or 'n' to start a new calculation or 'q' to quit");
                char input = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if (input == 'y')
                {
                    first_num = answer;
                }
                else if (input == 'n')
                {
                    endCalc = true;
                    Console.Clear();
                    Calculator();
                }
                else if (input == 'q')
                {
                    endCalc = true;
                }

            }
        }
        Calculator();
    }
    static double add(double num1, double num2)
    {
        return num1 + num2;
    }
    static double subtract(double num1, double num2)
    {
        return num1 - num2;
    }

    static double multiply(double num1, double num2)
    {
        return num1 * num2;
    }

    static double divide(double num1, double num2)
    {
        return num1 / num2;
    }
}
