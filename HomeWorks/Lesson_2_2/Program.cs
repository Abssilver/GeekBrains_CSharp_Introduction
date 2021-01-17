using System;

namespace Lesson_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа перевода числового значения в название месяца привествует вас");
            int monthNumber = default;
            GetUserInput(ref monthNumber);
            Console.WriteLine($"Введенное вами значение соответсвует месяцу: {GetMonthName(monthNumber)}");
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }
        private static void GetUserInput(ref int monthNumber)
        {
            do
            {
                Console.WriteLine($"Введите числовое значение месяца. Примеры : значению 1 будет соотвествовать January");
            } while (!Int32.TryParse(Console.ReadLine(), out monthNumber) || monthNumber <= 0);
        }

        private static string GetMonthName(int monthNumber)
        {
            return ((Month)(monthNumber % 12)).ToString();
        }
        
        [Flags]
        private enum Month
        {
            December,
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November
        }
    }
}