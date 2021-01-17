using System;

namespace Lesson_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа определения четности числа приветсвует вас");
            //Считаем, что 0 является четным числом
            int userInput = default;
            GetUserInput(ref userInput);
            Console.WriteLine("Введенное вами число {0}", userInput % 2 == 0? "четное" : "нечетное");
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }
        private static void GetUserInput(ref int convertedInput)
        {
            do
            {
                Console.WriteLine("{0}\n{1}",
                    "Введите числовое значение, чтобы дать возможность программе определить его четность.",
                    "Пример ввода: 112");
            } while (!Int32.TryParse(Console.ReadLine(), out convertedInput));
        }
    }
}