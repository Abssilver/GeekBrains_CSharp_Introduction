using System;
using System.IO;

namespace Lesson_5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string savePathNoRecursion = "no_recursion.txt";
            string savePathRecursion = "recursion.txt";
            Console.WriteLine("Программа сохранения дерева каталогов в текстовый файл приветствует вас");
            string directoryName = null;
            CreateDirectory(3,3, out directoryName);
            SaveData(savePathNoRecursion, GetEntries(directoryName));
            SaveDataWithRecursion(savePathRecursion, directoryName);
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }

        static string[] GetEntries(string filepath=null)
        {
            filepath ??= Directory.GetCurrentDirectory();
            string[] entries = Directory.GetFileSystemEntries(filepath, "*", SearchOption.AllDirectories);
            string[] result = new string[entries.Length + 1];
            result[0] = filepath;
            for (int i = 0; i < entries.Length; i++)
            {
                result[i + 1] = entries[i];
            }
            return result;
        }

        static void SaveDataWithRecursion(string fileName, string directoryName)
        {
            Lesson_5_1.Program.SaveData(fileName, directoryName);
            SaveEntriesNamesWithRecursion(fileName, directoryName);
            Console.WriteLine("{0}\nРасположение файла: {1}",
                "Запись успешно завершена",
                Path.Combine(Directory.GetCurrentDirectory(), fileName));
        }

        static void SaveEntriesNamesWithRecursion(string fileName, string directoryName)
        {
            string[] directories = Directory.GetDirectories(directoryName);
            string[] files = Directory.GetFiles(directoryName);
            SaveData(fileName, directories,  null, true);
            SaveData(fileName, files, null, true);
            for (int i = 0; i < directories.Length; i++)
            {
                SaveEntriesNamesWithRecursion(fileName, directories[i]);
            }
        }
        public static void SaveData(string fileName, string[] data, string filepath = null, bool append = false)
        {
            filepath ??= Path.Combine(Directory.GetCurrentDirectory(), fileName);
            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, append, System.Text.Encoding.Default))
                {
                    foreach (var element in data)
                    {
                        writer.WriteLine(element);
                    }
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
        static void CreateDirectory(int levelOfDepth, int filesInDirectory, out string directoryName, string filepath = null, int index = 0)
        { 
            filepath ??= Directory.GetCurrentDirectory();
            string directoryPath = Path.Combine(filepath, $"directory_level_{levelOfDepth}_{index}");
            directoryName = directoryPath;
            Directory.CreateDirectory(directoryPath);
            Console.WriteLine($"Директория создана.\nРасположение директории: {directoryPath}");
            for (int i = 0; i < filesInDirectory; i++) 
            { 
                string data = $"Файл уровня: {levelOfDepth}. Номер файла: {i}";
                string filePath = Path.Combine(directoryPath, $"file_{levelOfDepth}_{i}.txt");
                File.WriteAllText(filePath, data);
                Console.WriteLine($"Файл {levelOfDepth}_{i} создан");
            }
            if (levelOfDepth > 0)
            {
                for (int i = levelOfDepth; i > 0; i--)
                {
                    CreateDirectory(levelOfDepth - 1, 
                        filesInDirectory, 
                        out _,
                        directoryPath, 
                        i);
                }
            }
        }
    }
}



