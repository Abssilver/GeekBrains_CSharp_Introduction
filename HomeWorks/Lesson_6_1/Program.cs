using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lesson_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Консольное приложение Task Manager приветствует вас");
            DisplayMenu();
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }
        static Process[] GetLaunchedProcesses() => Process.GetProcesses();

        static void DisplayProcesses(Process[] processes)
        {
            DisplayProcess(
                "Имя процесса", 
                "PID",
                "# сеанса");
             DisplayProcess(new string('=',25),
                 new string('=',8),
                 new string('=',11));
            for (int i = 0; i < processes.Length; i++)
            {
                DisplayProcess(processes[i].ProcessName,
                    processes[i].Id.ToString(),
                    processes[i].SessionId.ToString());
            }
        }

        static void DisplayProcesses()
        {
            Process[] activeProcesses = GetLaunchedProcesses();
            DisplayProcesses(activeProcesses);
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Загружаю список запущенных процессов...");
            DisplayProcesses();
            object userInput;
            do
            {
                userInput = GetUserInput().ToLower();
                var input = int.TryParse(userInput.ToString(), out int number) ? number : userInput;
                switch (input)
                {
                    case string exitCommand when exitCommand.Equals("exit"):
                        Console.WriteLine("Завершаю работу приложения...");
                        break;
                    case string processName:
                        ProcessCommand(
                            "Ошибка при вводе имени процесса", 
                            Process.GetProcessesByName(processName.ToLower()));
                        break;
                    case int num:
                        ProcessCommand(
                            "Ошибка при вводе PID", 
                            Process.GetProcessById(num));
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода данных");
                        break;
                }
            } while (userInput.ToString()!="exit");
        }
        
        static void ProcessCommand(string error, params Process[] processesToBeClosed)
        {
            if (processesToBeClosed.Length > 0)
            {
                for (int i = 0; i < processesToBeClosed.Length; i++)
                {
                    Console.WriteLine("Завершаю процесс...\nid:{0} name:{1}...",
                        processesToBeClosed[i].Id,
                        processesToBeClosed[i].ProcessName);
                    processesToBeClosed[i].Kill();
                }
                Console.WriteLine("Успешно завершено");
            }
            else
            {
                Console.WriteLine(error);
            }
            DisplayProcesses();
        }
        
        static string GetUserInput()
        {
            string userInput = string.Empty;
            bool success;
            do
            {
                success = false;
                Console.WriteLine("{0}\n{1}\n{2}",
                    "Для завершения какого-либо процесса введите его имя, либо его PID",
                    "Примеры ввода: dotnet , 11925",
                    "Для выхода из программы введите exit");
                userInput = Console.ReadLine()?.Trim();
                if (userInput!=null)
                {
                    success = userInput.Length > 0;
                }
            } while (!success);
            Console.WriteLine("Ввод принят.");
            return userInput;
        }
        static void DisplayProcess(
            string processName,
            string pid,
            string sessionNumber) =>
            Console.WriteLine("{0,-25} {1, -8} {2, 11}",
                processName.Length > 25 
                    ? string.Concat(processName.Substring(0, 22), "...") 
                    : processName,
                pid,
                sessionNumber);
    }
}