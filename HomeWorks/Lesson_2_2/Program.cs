using System;

namespace Lesson_2_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа перевода числового значения в название месяца привествует вас");
            Console.WriteLine($"Введенное вами значение соответсвует месяцу: {GetMonthName().ToString()}");
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

        public static Month GetMonthName()
        {
            int monthNumber = default;
            GetUserInput(ref monthNumber);
            return (Month)(monthNumber % 12);
        }
    }
    [Flags]
    public enum Month
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