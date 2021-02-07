using System;

namespace Lesson_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа расчета факториала числа приветствует вас");
            int userInput = default;
            GetUserInput(ref userInput);
            Console.WriteLine($"Факториал введенного числа составляет: {CalculateFactorial(userInput)}");
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }
        private static void GetUserInput(ref int convertedInput)
        {
            do
            {
                Console.WriteLine("{0}\n{1}",
                    "Введите положительное число, для рассчета его факториала.",
                    "Пример ввода: 3");
            } while (!Int32.TryParse(Console.ReadLine(), out convertedInput) || convertedInput < 0);
        }

        private static int CalculateFactorial(int number) => number == 0
            ? 1
            :number * CalculateFactorial(--number);
        
    }
}