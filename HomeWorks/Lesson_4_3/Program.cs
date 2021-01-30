using System;

namespace Lesson_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа определения времени года приветствует вас");
            int userInput = GetUserInput();
            Console.WriteLine("Введенному месяцу: {0} соответствует время года: {1}",
                userInput, 
                GetSeasonName(GetSeasonByNumber(userInput)));
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }
        static SeasonsOfTheYear GetSeasonByNumber(int month)
        {
            month %= 12;
            return month < (int)SeasonsOfTheYear.Spring ? SeasonsOfTheYear.Winter : 
                month < (int)SeasonsOfTheYear.Summer ? SeasonsOfTheYear.Spring : 
                month < (int)SeasonsOfTheYear.Autumn ? SeasonsOfTheYear.Summer : 
                SeasonsOfTheYear.Autumn;
        }
        
        static string GetSeasonName(SeasonsOfTheYear season)
        {
            string output = String.Empty;
            switch (season)
            {
                case SeasonsOfTheYear.Winter:
                    output = "Зима";
                    break;
                case SeasonsOfTheYear.Spring:
                    output = "Весна";
                    break;
                case SeasonsOfTheYear.Summer:
                    output = "Лето";
                    break;
                case SeasonsOfTheYear.Autumn:
                    output = "Осень";
                    break;
                default:
                    output = "Ошибка. Время года не назначено";
                    break;
            }
            return output;
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
                    "Введите число, соответсвующее месяцу года.",
                    "Примеры ввода: 10");
                userInput = Console.ReadLine()?.Trim();
                if (userInput != null)
                {
                    success = Int32.TryParse(userInput, out output)
                        && output > 0 
                        && output < 13;
                    if (!success)
                    {
                        PrintMessageToConsole("Ошибка: введите число от 1 до 12");
                    }
                }
            } while (!success);
            Console.WriteLine("Число введено успешно.");
            return output;
        }
        static void PrintMessageToConsole(string message) => Console.WriteLine(message);
    }
    enum SeasonsOfTheYear
    {
        Winter = 0,
        Spring = 3,
        Summer = 6,
        Autumn = 9
    }
}