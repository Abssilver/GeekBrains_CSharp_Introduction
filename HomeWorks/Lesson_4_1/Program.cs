using System;
using System.Text.RegularExpressions;

namespace Lesson_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа вывода ФИО приветствует вас");
            int namesNumber = default;
            GetUserInput(ref namesNumber);
            string [][] names = new string[namesNumber][];
            for (int i = 0; i < names.GetLength(0); i++)
            {
                names[i] = GetUserNameInput();
            }
            DisplayNames(names);
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }

        private static void DisplayNames(string[][] names)
        {
            Console.WriteLine("Введенные имена:");
            for (int i = 0; i < names.GetLength(0); i++)
            {
                if (names[i].GetLength(0) < 3)
                {
                    throw new ArgumentException("Data in array is not valid for programm. Please, check name");
                }
                Console.WriteLine(GetFullName(names[i][0], names[i][1], names[i][2]));
            }
        }

        private static void GetUserInput(ref int convertedInput)
        {
            do
            {
                Console.WriteLine("{0}\n{1}",
                    "Введите числовое значение, которое будет соответствовать введенным вами ФИО.",
                    "Пример ввода: 3");
            } while (!Int32.TryParse(Console.ReadLine(), out convertedInput));
        }
        
        private static string [] GetUserNameInput()
        {
            string [] fullname = new string[3];
            string userInput = string.Empty;
            bool success = false;
            string pattern = @"^\w+\s+\w+\s+\w+$";
            Regex spacePattern = new Regex(@"\s+");
            do
            {
                Console.WriteLine("{0}\n{1}",
                    "Введите ФИО. В качестве разделителя используйте пробел",
                    "Пример ввода: Иванов Иван Иванович");
                userInput = Console.ReadLine()?.Trim();
                if (userInput != null)
                {
                    userInput = spacePattern.Replace(userInput, @" ");
                    Match match = Regex.Match(userInput, pattern, RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        fullname = userInput.Split(' ');
                        success = true;
                    } 
                }
            } while (!success);
            Console.WriteLine("Имя введено успешно.");
            return fullname;
        }
        
        private static string GetFullName(string firstName, string lastName, string patronymic)
            => $"{lastName} {firstName} {patronymic}";

    }
}