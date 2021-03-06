﻿using System;
using System.IO;

namespace Lesson_5_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа записи ввода пользователя в текстовый файл приветствует вас");
            string userInput = GetUserInput();
            SaveData("SavedInput.txt", userInput);
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }
        static string GetUserInput()
        {
            string userInput = null;
            do
            {
                Console.WriteLine(
                    string.Concat("Введите данные которые необходимо сохранить", Environment.NewLine,
                        "Пример : Нужно перевернуть картошку через 20 минут"));
                userInput = Console.ReadLine();
            } while (userInput.Trim().Length == 0);
            Console.WriteLine("Данные успешно введены");
            return userInput;
        }

        public static void SaveData(string fileName, string data, string filepath = null, bool append = false)
        {
            filepath ??= Path.Combine(Directory.GetCurrentDirectory(), fileName);
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, append, System.Text.Encoding.Default))
                {
                    writer.WriteLine(data);
                }
                string outputMessage = null;
                if (append)
                {
                    outputMessage = "Дозапись успешно произведена";
                }
                else
                {
                    outputMessage = $"Запись успешно завершена\nРасположение файла: {filepath}";
                }
                Console.WriteLine(outputMessage);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Ошибка записи:\n{exception.Message}");
            }
        }
    }
}