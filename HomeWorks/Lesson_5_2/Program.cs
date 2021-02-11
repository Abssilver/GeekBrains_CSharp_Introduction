using System;
using System.IO;
using Lesson_5_1;

namespace Lesson_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "startup.txt";
            Console.WriteLine("Программа дозаписи данных в текстовый файл приветствует вас");
            Lesson_5_1.Program.SaveData(fileName, "Какая-то информация");
            ReadData(fileName);
            Lesson_5_1.Program.SaveData("startup.txt", 
                DateTime.Now.ToLongDateString(), 
                null, 
                true);
            ReadData(fileName);
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }
        static void ReadData(string fileName, string filepath = null)
        {
            filepath ??= Path.Combine(Directory.GetCurrentDirectory(), fileName);
            if (File.Exists(filepath))
            {
                using (StreamReader reader = new StreamReader(filepath, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("{0}\n{1}",
                    "Файл по указанному пути не существует",
                    $"Путь файла: {filepath}");
            }
        }
    }
}