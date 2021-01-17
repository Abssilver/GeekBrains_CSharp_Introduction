using System;

namespace Lesson_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double minDayTemperature = default;
            double maxDayTemperature = minDayTemperature;
            Console.WriteLine("Программа подсчета среднесуточной температуры привествует вас");
            GetTemperature(ref minDayTemperature, "Введите значение минимальной температуры за сутки");
            GetTemperature(ref maxDayTemperature, "Введите значение максимальной температуры за сутки");
            Console.WriteLine(
                $"Среднесуточная температура составляет: {CalculateAverageTemperature(minDayTemperature, maxDayTemperature):f2}");
        }

        private static void GetTemperature(ref double temperature, string description)
        {
            do
            {
                Console.WriteLine($"{description}. Примеры ввода: 6 ; 3,2");
            } while (!Double.TryParse(Console.ReadLine(), out temperature));
        }

        private static double CalculateAverageTemperature(double min, double max) => (min + max) / 2;
    }
}