using System;
using System.Text;

namespace Lesson_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа выводящая введенную пользователем строку в обратном порядке приветсвует вас");
            string userInput = GetUserInput();
            Console.WriteLine($"Введенное пользователем \"{userInput}\" было трансформировано в \"{ReverseInput(userInput)}\"");
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }

        static string ReverseInput(string input)
        {
            StringBuilder builder = new StringBuilder(input.Length);
            for (int i = input.Length - 1; i >= 0; i--)
            {
                builder.Append(input[i]);
            }
            return builder.ToString();
        }

        static string GetUserInput()
        {
            string userInput = null;
            do
            {
                Console.WriteLine(
                    string.Concat("Введите строковое значение.", Environment.NewLine, 
                        "Пример : при вводе Hello будет выведено olleH"));
                userInput = Console.ReadLine();
            } while (userInput.Trim().Length == 0);
            return userInput;
        }
    }
}