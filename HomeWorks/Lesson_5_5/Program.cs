using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lesson_5_5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string filenameJson = Path.Combine(Directory.GetCurrentDirectory(), "tasks.json");
            //string filenameXml = Path.Combine(Directory.GetCurrentDirectory(), "tasks.xml");
            //string filenameBin = Path.Combine(Directory.GetCurrentDirectory(), "tasks.bin");
            
            Console.WriteLine("Приложение по работе со списком задач приветствует вас");
            await DisplayMenu(filenameJson, LoadToDoArrayJson, SaveToDoArrayJson);
            //await DisplayMenu(filenameXml, LoadToDoArrayXml, SaveToDoArrayXml);
            //await DisplayMenu(filenameBin, LoadToDoArrayBin, SaveToDoArrayBin);
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }

        #region JsonSerialization
        static async Task<ToDo[]> LoadToDoArrayJson(string filePath)
        {
            ToDo[] tasks = null;
            if (File.Exists(filePath))
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    tasks = await JsonSerializer.DeserializeAsync<ToDo[]>(stream);
                }
                Console.WriteLine("Задания успешно загружены");
            }
            else
            {
                Console.WriteLine("{0}\n{1}",
                    "Отсутствует файл по указанному пути",
                    $"Путь: {filePath}");
            }
            return tasks;
        }
        static async void SaveToDoArrayJson(string filePath, ToDo[] tasks)
        {
            try
            {
                using (FileStream stream = File.Create(filePath))
                {
                    await JsonSerializer.SerializeAsync(stream, tasks);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка записи. {e.Message}");
            }
        }

        #endregion

        #region XmlSerialization
        static async Task<ToDo[]> LoadToDoArrayXml(string filePath)
        {
            ToDo[] tasks = null;
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ToDo[]));
                using (FileStream stream = File.OpenRead(filePath))
                {
                    XmlReader reader = XmlReader.Create(stream);
                    tasks = (ToDo[])serializer.Deserialize(reader);
                }
                Console.WriteLine("Задания успешно загружены");
            }
            else
            {
                Console.WriteLine("{0}\n{1}",
                    "Отсутствует файл по указанному пути",
                    $"Путь: {filePath}");
            }
            return await Task.Run(() => tasks);
        }
        static void SaveToDoArrayXml(string filePath, ToDo[] tasks)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ToDo[]));
                    serializer.Serialize(writer, tasks);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка записи. {e.Message}");
            }
        }
        
        #endregion

        #region BinSerialization
        static async Task<ToDo[]> LoadToDoArrayBin(string filePath)
        {
            ToDo[] tasks = null;
            if (File.Exists(filePath))
            {
                IFormatter formatter = new BinaryFormatter();
                using (FileStream stream = File.OpenRead(filePath))
                {
                    tasks = (ToDo[])formatter.Deserialize(stream);
                }
                Console.WriteLine("Задания успешно загружены");
            }
            else
            {
                Console.WriteLine("{0}\n{1}",
                    "Отсутствует файл по указанному пути",
                    $"Путь: {filePath}");
            }
            return await Task.Run(() => tasks);
        }
        static void SaveToDoArrayBin(string filePath, ToDo[] tasks)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(stream, tasks);  
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка записи. {e.Message}");
            }
        }
        
        #endregion

        #region Core
        static async Task DisplayMenu(string filepath, Func<string,Task<ToDo[]>> loadAction, Action<string,ToDo[]> saveAction)
        {
            Console.WriteLine("Загружаю список задач...");
            ToDo[] tasks = await loadAction.Invoke(filepath);
            DisplayMenu(tasks);
            object userInput;
            do
            {
                userInput = GetUserInput("Введите команду", "Create");
                var input = int.TryParse(userInput.ToString(), out int number) ? number : userInput;
                switch (input)
                {
                    case string command:
                        tasks = ProcessCommand(command.ToLower(), filepath, tasks, saveAction) ?? tasks;
                        break;
                    case int num:
                        tasks = ProcessTaskCompletion(num, filepath, tasks, saveAction) ?? tasks;
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода данных");
                        break;
                }
            } while (userInput.ToString()!="exit");
        }
        static void DisplayMenu(ToDo[] tasks)
        {
            if (tasks!=null)
            {
                DisplayTasks(tasks);
                Console.WriteLine("{0, 10} - {1,-80}\n{2, 10} - {3,-80}",
                    "[index_number]",
                    "Для перевода задачи в состояние \"выполнено\". Пример: 1",
                    "[index_number]",
                    "Повторный ввод номера задачи в статусе \"выполнено\" приведет к ее удалению.");
            }
            Console.WriteLine("{0, 10} - {1,-80}\n{2, 10} - {3,-80}",
                "[Create]",
                "Для создания задачи",
                "[Exit]",
                "Для выхода из приложения");
        }
        static ToDo[] ProcessCommand(string command, string filepath, ToDo[] tasks, Action<string, ToDo[]> saveAction)
        {
            ToDo[] newData = null;
            if (command == "create")
            {
                ToDo newTask = CreateTask();
                //По заданию array
                if (tasks!=null)
                {
                    newData = new ToDo[tasks.Length + 1]; 
                    for (int i = 0; i < tasks.Length; i++)
                    {
                        newData[i] = tasks[i];
                    }
                    newData[tasks.Length] = newTask;
                }
                else
                {
                    newData = new []{ newTask };
                }
                saveAction?.Invoke(filepath, newData);
                Console.WriteLine("Загружаю обновленные данные...");
                DisplayMenu(newData);
            }
            else if (command != "exit")
            {
                Console.WriteLine("Неверно введенная команда. Попробуйте снова");
            }
            return newData;
        }
        static ToDo[] ProcessTaskCompletion(int index, string filepath, ToDo[] tasks, Action<string, ToDo[]> saveAction)
        {
            ToDo[] newData = null;
            int validatedIndex = index - 1;
            if (validatedIndex >= 0 && validatedIndex < tasks.Length)
            {
                if (tasks[validatedIndex].IsDone)
                {
                    //По заданию array
                    newData = new ToDo[tasks.Length-1];
                    int newDataIndex = 0;
                    for (int i = 0; i < tasks.Length; i++)
                    {
                        if (i==validatedIndex)
                        {
                            continue;
                        }
                        newData[newDataIndex++] = tasks[i];
                    }
                    saveAction?.Invoke(filepath, newData);
                    Console.WriteLine("Загружаю обновленные данные...");
                    DisplayMenu(newData);
                    return newData;
                }
                tasks[validatedIndex].IsDone = true;
                saveAction?.Invoke(filepath, tasks);
                Console.WriteLine("Загружаю обновленные данные..."); 
                DisplayMenu(tasks);
            }
            else
            {
                Console.WriteLine("Неверно введенный индекс. Попробуйте снова");
            }
            return newData;
        }
        static void DisplayTasks(ToDo[] todoArray)
        {
            Console.WriteLine(new string('*', 46));
            Console.WriteLine("{0,5} | {1,10} | {2, 25}", "#", "Выполнена", "Описание");
            for (int i = 0; i < todoArray.Length; i++)
            {
                string done = todoArray[i].IsDone ? "[x]" : "[ ]";
                string description = todoArray[i].Title.Length > 25
                    ? string.Concat(todoArray[i].Title.Substring(0, 22), "...")
                    : todoArray[i].Title;
                Console.WriteLine($"{i+1, 5} | {done,10} | {description, 25}");
            }
            Console.WriteLine(new string('*', 46));
        }
        static ToDo CreateTask()
        {
            return new ToDo
            {
                Title = GetUserInput("Введите описание задачи", "купить хлеб"),
                IsDone = false
            };
        }
        static string GetUserInput(string description, string example)
        {
            string userInput;
            bool success = false;
            do
            {
                Console.WriteLine("{0}\n{1}",
                    $"{description}",
                    $"Пример ввода: {example}");
                userInput = Console.ReadLine();
                if (userInput!=null && userInput.Trim().Length > 0)
                {
                    success = true;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода. Попробуйте снова");
                }
            } while (!success);
            Console.WriteLine("Данные введены успешно.");
            return userInput;
        }

        #endregion
    }
    
    [Serializable]
    public class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public ToDo() { }
    }
}