using System;

namespace Lesson_2_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа подсчета среднесуточной температуры привествует вас");
            Console.WriteLine(
                $"Среднесуточная температура составляет: {GetAverageTemperature():f2}");
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }

        public static double GetAverageTemperature()
        {
            double minDayTemperature = default;
            double maxDayTemperature = minDayTemperature;
            GetTemperature(ref minDayTemperature, "Введите значение минимальной температуры за сутки");
            GetTemperature(ref maxDayTemperature, "Введите значение максимальной температуры за сутки");
            return CalculateAverageTemperature(minDayTemperature, maxDayTemperature);
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