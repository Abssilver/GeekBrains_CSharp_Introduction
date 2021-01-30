using System;
using System.Text.RegularExpressions;

namespace Lesson_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа подсчета суммы введенных чисел приветствует вас");
            int [] userInput = GetUserInput();
            PrintUserInput(userInput);
            Console.WriteLine($"Сумма введенных чисел: {CalculateSum(userInput)}");
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }

        static int CalculateSum(int[] userInput)
        {
            int sum = default;
            for (int i = 0; i < userInput.Length; i++)
            {
                sum += userInput[i];
            }
            return sum;
        }

        static void PrintUserInput(int[] userInput)
        {
            Console.WriteLine("Введенные пользователем числа:");
            for (int i = 0; i < userInput.Length; i++)
            {
                Console.Write($"{userInput[i]} ");
            }
            Console.WriteLine();
        }

        static int[] GetUserInput()
        {
            string userInput = string.Empty;
            Regex matchPattern = new Regex(@"-{0,1}\d+");
            bool success = false;
            int[] output = null;
            do
            {
                Console.WriteLine("{0}\n{1}",
                    "Введите числа для подсчета их суммы. В качестве разделителя используйте пробел",
                    "Пример ввода: 1 45 7 3");
                userInput = Console.ReadLine()?.Trim();
                if (userInput != null)
                {
                    var matches = matchPattern.Matches(userInput);
                    if (matches.Count > 0)
                    {
                        output = new int [matches.Count];
                        for (int i = 0; i < matches.Count; i++)
                        {
                            output[i] = Int32.Parse(matches[i].Value);
                        }
                        success = true;
                    } 
                }
            } while (!success);
            Console.WriteLine("Набор чисел введен успешно.");
            return output;
        }
    }
}