using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Program
    {
        private static double memory = 0;

        static void Main()
        {
            double number1 = System.Convert.ToInt32(Console.ReadLine());
            string operation = Console.ReadLine();
            
            if (operation == "1/x" || operation == "^2" || operation == "sqrt" || 
                operation == "M+" || operation == "M-" || operation == "MR")
            {
                SoloNum(number1, operation);
                return;
            }
            double number2 = System.Convert.ToInt32(Console.ReadLine());
            if (operation == "+")
            {
                Console.WriteLine(number1 + number2);
            }
            else if (operation == "-")
            {
                Console.WriteLine(number1 - number2);
            }
            else if (operation == "*")
            {
                Console.WriteLine(number1 * number2);
            }
            else if (operation == "/")
            {
                if (number2 == 0)
                {
                    Console.WriteLine("на 0 не делится");
                }
                else
                {
                    Console.WriteLine(number1 / number2);
                }
            }
            else if (operation == "%")
            {
                if (number2 == 0)
                {
                    Console.WriteLine("на 0 не делится");
                }
                else
                {
                    Console.WriteLine(number1 % number2);
                }
            }
            else
            {
                Console.WriteLine("ошибка знака!, доступные операции: + - * / % sqrt ^2 1/x M+ M- MR");
            }
            static void SoloNum(double number, string operation)
            {
                if (operation == "sqrt")
                {
                    if (number < 0)
                    {
                        Console.WriteLine("нельзя извлечь корень из отрицательного числа");
                    }
                    else
                    {
                        Console.WriteLine(Math.Sqrt(number));
                    }
                }
                else if (operation == "^2")
                {
                    Console.WriteLine(Math.Pow(number, 2));
                }
                else if (operation == "1/x")
                {
                    if (number != 0)
                    {
                        Console.WriteLine(1 / number);
                    }
                    else
                    {
                        Console.WriteLine("на 0 не делится");
                    }
                }
                else if (operation == "M+")
                {
                    memory += number;
                    Console.WriteLine("добавлено в память, сейчас:" + memory);
                }
                else if (operation == "M-")
                {   
                    memory -= number;
                    Console.WriteLine("удалено из памяти, сейчас:" + memory);
                }
                else if (operation == "MR")
                { 
                    Console.WriteLine("значение памяти:" + memory);
                }
            }
        }
    }
};