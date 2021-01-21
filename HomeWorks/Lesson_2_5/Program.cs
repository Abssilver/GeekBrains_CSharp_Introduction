using System;
using Lesson_2_2;

namespace Lesson_2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа проверки дождливой погоды привествует вас");
            CheckConditionsForWarmWinter(Lesson_2_1.Program.GetAverageTemperature(),Lesson_2_2.Program.GetMonthName());
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }
        private static void CheckConditionsForWarmWinter(double averageTemperature, Month month)
        {
            Console.WriteLine(
                $"Среднесуточная температура составляет: {averageTemperature:f2}");
            Console.WriteLine($"Введенное вами значение соответсвует месяцу: {month.ToString()}");
            if (averageTemperature > 0 && month < Month.March)
            {
                Console.WriteLine("Дождливая зима");
            } 
        }
    }
}