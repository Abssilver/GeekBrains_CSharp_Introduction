// Decompiled with JetBrains decompiler
// Type: Lesson_7_1.Program
// Assembly: lesson_7_1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7A638461-83B9-46A5-9D58-6753777B17FE
// Assembly location: C:\GeekBrains\Введение в С#\GeekBrains_CSharp_Introduction\HomeWorks\Lesson_7_1\bin\Debug\netcoreapp3.1\Lesson_7_1.dll

using System;

namespace Lesson_7_1
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine("Программа расчета факториала числа, умноженного на 2 приветствует вас");
      int convertedInput = 0;
      Program.GetUserInput(ref convertedInput);
      Console.WriteLine(string.Format("Факториал введенного числа, умноженного на 2 составляет: {0}", (object) Program.CalculateFactorial(convertedInput)));
      Console.WriteLine("Нажмите любую клавишу для завершения программы");
      Console.ReadKey();
    }

    private static void GetUserInput(ref int convertedInput)
    {
      do
      {
        Console.WriteLine("{0}\n{1}", (object) "Введите положительное число, для рассчета его факториала.", (object) "Пример ввода: 3");
      }
      while (!int.TryParse(Console.ReadLine(), out convertedInput) || convertedInput < 0);
    }

    private static int CalculateFactorial(int number) => number != 0 ? number * Program.CalculateFactorial(--number) : 2;
  }
}
