using System;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя пользователя");
            string userInput = Console.ReadLine();
            DateTime currentDate = DateTime.Now;
            //Поставить точку останова здесь
            Console.WriteLine($"Привет, {userInput}, сегодня {currentDate.ToLongDateString()}");
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }
    }
}