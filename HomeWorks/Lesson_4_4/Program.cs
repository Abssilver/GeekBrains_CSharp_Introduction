using System;

namespace Lesson_4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа вычисления числа Фибоначчи приветствует вас");
            int userInput = GetUserInput();
            Console.WriteLine("Введенному порядковому числу Фибоначчи: {0} соответствует число: {1}",
                userInput, 
                GetFibonacciNumberExtended(userInput));
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }

        static int GetFibonacciNumber(int index)
        {
            if (index == 1)
            {
                return 1;
            }
            else if (index == 0)
            {
                return 0;
            }
            else
            {
                return GetFibonacciNumber(--index) + GetFibonacciNumber(--index);
            }
        }

        static int GetFibonacciNumberExtended(int index)
        {
            if (index >= 0)
            {
                return GetFibonacciNumber(index);
            }
            else if(index == -1)
            {
                return 1;
            }
            else
            {
                return -1 * GetFibonacciNumberExtended(++index) + GetFibonacciNumberExtended(++index);
            }
        }

        static int GetUserInput()
        {
            string userInput = string.Empty;
            int output = default;
            bool success;
            do
            {
                success = false;
                Console.WriteLine("{0}\n{1}",
                    "Введите порядковый номер числа Фибоначчи, которое необходимо вычислить.",
                    "Пример ввода: 5");
                userInput = Console.ReadLine()?.Trim();
                if (userInput != null)
                {
                    success = Int32.TryParse(userInput, out output);
                }
            } while (!success);
            Console.WriteLine("Число введено успешно.");
            return output;
        }
        static void PrintMessageToConsole(string message) => Console.WriteLine(message);
    }
}