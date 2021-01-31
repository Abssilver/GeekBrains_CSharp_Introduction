using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lesson_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "SavedInput.bin";
            Console.WriteLine("Программа записи данных в бинарный файл приветствует вас");
            byte[] data = GetUserInput();
            SaveData(fileName, data);
            byte[] readData = ReadData(fileName);
            PrintData(readData);
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }
        static byte[] GetUserInput()
        {
            string userInput = string.Empty;
            Regex matchPattern = new Regex(@"-{0,1}\d+");
            bool success = false;
            byte[] output = null;
            do
            {
                Console.WriteLine("{0}\n{1}",
                    "Введите произвольный набор чисел (0...255). В качестве разделителя используйте пробел",
                    "Пример ввода: 5 25 69 240");
                userInput = Console.ReadLine()?.Trim();
                if (userInput != null)
                {
                    var matches = matchPattern.Matches(userInput);
                    if (matches.Count > 0)
                    {
                        output = new byte [matches.Count];
                        for (int i = 0; i < matches.Count; i++)
                        {
                            success = Byte.TryParse(matches[i].Value, out output[i]);
                            if (!success)
                            {
                                PrintWarningMessage($"Неверно введенное число: {matches[i].Value}.\nПопробуйте снова");
                                break;
                            }
                        }
                    } 
                }
            } while (!success);
            Console.WriteLine("Набор чисел введен успешно.");
            return output;
        }
        static void PrintWarningMessage(string warning) => Console.WriteLine(warning);

        static void SaveData(string fileName, byte[] data, string filepath = null)
        {
            filepath ??= Path.Combine(Directory.GetCurrentDirectory(), fileName); 
            try
            {
                using (BinaryWriter writer = 
                    new BinaryWriter(File.Open(filepath, FileMode.Create, FileAccess.Write)))
                { 
                    foreach (var element in data) 
                        writer.Write(element); 
                }
                Console.WriteLine($"Данные успешно записаны.\nРасположение файла: {filepath}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Ошибка записи:\n{exception.Message}");
            }
        }
        static byte[] ReadData(string fileName, string filepath = null)
        {
            filepath ??= Path.Combine(Directory.GetCurrentDirectory(), fileName);
            byte[] data = null;
            if (File.Exists(filepath))
            {
                using (BinaryReader reader =
                    new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read)))
                {
                    data = new byte[reader.BaseStream.Length/sizeof(byte)];
                    for (int i = 0; i < data.Length; i++)
                        data[i] = reader.ReadByte();
                }
                Console.WriteLine("Данные успешно считаны.");
            }
            else
            {
                Console.WriteLine("{0}\n{1}",
                    "Файл по указанному пути не существует",
                    $"Путь файла: {filepath}");
            }
            return data;
        }
        static void PrintData(byte[] data)
        {
            Console.WriteLine("Введенные данные:");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write($"{data[i]} ");
            }
            Console.WriteLine();
        }
    }
}