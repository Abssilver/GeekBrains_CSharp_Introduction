using System;

namespace Lesson_3_2
{
    class Program
    {
        private static string[] _names =
        {
            "Николай",
            "Виктория",
            "Валентин",
            "Светлана",
            "Петр",
            "Зоя",
            "Алексей",
            "Екатерина",
            "Илья",
            "Александра"
        };
        //В целях избежания конфликтов с существующими номерами - номера будут на 1 цифру длинее
        private static string[] _phones =
        {
            "+7(123)111-222-33",
            "+7(124)658-132-25",
            "+7(125)989-222-25",
            "+7(225)089-222-48",
            "+7(325)089-562-50",
            "+7(425)999-562-12",
            "+7(435)947-882-12",
            "+7(445)897-856-03",
            "+7(455)797-125-03",
            "+7(456)477-045-03"
        };
        private static string[] _mails =
        {
            "random_1@random.com",
            "random_2@random.com",
            "random_3@random.com",
            "random_4@random.com",
            "random_5@random.com",
            "random_6@random.com",
            "random_7@random.com",
            "random_8@random.com",
            "random_9@random.com",
            "random_0@random.com"
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Программа телефонный справочник приветсвует вас");
            string[,] phonebook = new string [5, 2];
            FillPhonebook(phonebook);
            Console.WriteLine("Сгенерированный телефонный справочник:");
            PrintPhonebook(phonebook);
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }

        private static void PrintPhonebook(string[,] phonebook)
        {
            ValidatePhonebook(phonebook, phonebook.GetLength(1));
            for (int i = 0; i < phonebook.GetLength(0); i++)
            {
                Console.WriteLine($"{phonebook[i,0], 15} || {phonebook[i,1], -30}");
            }
        }

        private static void ValidatePhonebook(string[,] phonebook, int minSize)
        {
            if (phonebook.GetLength(1) < minSize)
            {
                throw new ArgumentException("Invalid phonebook!");
            }
        }

        private static void FillPhonebook(string[,] phonebook)
        {
            ValidatePhonebook(phonebook, phonebook.GetLength(1));
            Random rnd = new Random();
            for (int i = 0; i < phonebook.GetLength(0); i++)
            {
                phonebook[i, 0] = _names[rnd.Next(0, _names.Length)];
                phonebook[i, 1] = rnd.Next(0, 2) > 0
                    ? _phones[rnd.Next(0, _phones.Length)]
                    : _mails[rnd.Next(0, _mails.Length)];
            }
        }
    }
}