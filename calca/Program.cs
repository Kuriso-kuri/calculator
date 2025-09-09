using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

class Calculat
{
    private static double memory = 0;
    static void Main()
    {
        Console.WriteLine("КАЛЬКУЛЯТОР");
        Console.WriteLine("Доступные операции: +, -, *, /, %, 1/x, x^2, √, M+, M-, MR");
        Console.WriteLine("Для выхода введите 'exit'");
        while (true)
        {
            try
            {
                Console.WriteLine("\nВведите операцию:");
                string input = Console.ReadLine().Trim();
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("bb");
                    break;
                }
                ProcessInput(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
    static void ProcessInput(string input)
    {
        switch (input)
        {
            case "M+":
                memory += GetValidNumber("Введите число для добавления в память:");
                Console.WriteLine($"Текущее значение памяти: {memory}");
                break;
            case "M-":
                memory -= GetValidNumber("Введите число для вычитания из памяти:");
                Console.WriteLine($"Текущее значение памяти: {memory}");
                break;
            case "MR":
                Console.WriteLine($"Значение из памяти: {memory}");
                break;
            case "1/x":
                double reciprocalNum = GetValidNumber("Введите число для вычисления 1/x:");
                if (reciprocalNum == 0)
                {
                    Console.WriteLine("делить на 0 запрещено законом!");
                    return;
                }
                double result = 1 / reciprocalNum;
                ValidateDecimalPlaces(result);
                Console.WriteLine($"Ответ: {result}");
                break;
            case "x^2":
                double squareNum = GetValidNumber("Введите число для возведения в квадрат:");
                result = squareNum * squareNum;
                ValidateDecimalPlaces(result);
                Console.WriteLine($"Ответ: {result}");
                break;
            case "sqrt":
                double sqrtNum = GetValidNumber("Введите число для извлечения корня:");
                if (sqrtNum < 0)
                {
                    Console.WriteLine("Фиг вам, а не извлечение корня из неположительного числа");
                    return;
                }
                result = Math.Sqrt(sqrtNum);
                ValidateDecimalPlaces(result);
                Console.WriteLine($"Ответ: {result}");
                break;
            case "+":
            case "-":
            case "*":
            case "/":
            case "%":
                PerformBinaryOperation(input);
                break;
            default:
                Console.WriteLine("Операция не определена! Доступные операции: +, -, *, /, %, 1/x, x^2, sqrt, M+, M-, MR");
                break;
        }
    }
    
    static void PerformBinaryOperation(string operation)
    {
        double num1 = GetValidNumber("Введите первое число:");
        double num2 = GetValidNumber("Введите второе число:");
        double result = 0;
        switch (operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 == 0)
                {
                    Console.WriteLine("делить на 0 запрещено законом!");
                    return;
                }
                result = num1 / num2;
                break;
            case "%":
                if (num2 == 0)
                {
                    Console.WriteLine("делить на 0 запрещено законом!");
                    return;
                }
                result = num1 % num2;
                break;
        }
        ValidateDecimalPlaces(result);
        Console.WriteLine($"Ответ: {result}");
    }
    static double GetValidNumber(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine().Trim();
            if (double.TryParse(input, out double number))
            {
                if (ValidateDecimalPlaces(number, out string errorMessage))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
            else
            {
                Console.WriteLine("Это не число! Пожалуйста, введите число заново:");
            }
        }
    }
    static bool ValidateDecimalPlaces(double number, out string errorMessage)
    {
        errorMessage = string.Empty;
        if (double.IsNaN(number) || double.IsInfinity(number))
        {
            errorMessage = "Недопустимое значение числа";
            return false;
        }
        string numberString = number.ToString(CultureInfo.InvariantCulture);
        if (!numberString.Contains('.'))
        {
            return true;
        }
        string[] parts = numberString.Split('.');
        int decimalPlaces = parts[1].Length;
        if (decimalPlaces > 15)
        {
            errorMessage = "Слишком много знаков после запятой (max: 15), ведите число заново";
            return false;
        }
        return true;
    }
    static void ValidateDecimalPlaces(double number)
    {
        if (!ValidateDecimalPlaces(number, out string errorMessage))
        {
            throw new Exception(errorMessage);
        }
    }
}