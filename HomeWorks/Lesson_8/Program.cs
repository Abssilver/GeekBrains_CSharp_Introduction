using System;

namespace Lesson_8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string output = Properties.Settings.Default.Greeting_p1;
            if (string.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {
                GetDataForSettings();
            }
            else
            {
                output = string.Concat(
                    output,
                    Environment.NewLine,
                    FillTheFieldsOfOutput());
            }
            Console.WriteLine(output);
            Console.WriteLine("Press any key to finish an adventure");
            Console.ReadKey();
        }
        static string FillTheFieldsOfOutput()
        {
            string output = Properties.Settings.Default.Greeting_p2;
            output = output.Replace("{username}", Properties.Settings.Default.UserName)
                .Replace("{occupation}", Properties.Settings.Default.UserOccupation)
                .Replace("{age}", Properties.Settings.Default.UserAge.ToString());
            return output;
        }
        static void GetDataForSettings()
        {
            string username = GetUserInput(
                     "Hello my friend, how can I call you?",
                     "Ahh, for sure, lately I have noticed more and more problems with my memory...",
                     NameCheck);
            byte age = Byte.Parse(GetUserInput(
                "And how long have you been living under this sun?",
                "I have not seen you for a long time...",
                AgeCheck));
            string occupation = GetUserInput(
                $"And who are you now, {username}?",
                "It was always difficult for me to understand what they are doing, people of your profession...",
                OccupationCheck);
            Properties.Settings.Default.UserName = username;
            Properties.Settings.Default.UserAge = age;
            Properties.Settings.Default.UserOccupation = occupation;
            Properties.Settings.Default.Save();
        }
        static bool NameCheck(string username) => username != null && username.Trim().Length > 0;
        static bool AgeCheck(string age) => Byte.TryParse(age, out _);
        static bool OccupationCheck(string occupation) => NameCheck(occupation);
        private static string GetUserInput(string description, string reaction, Func<string, bool> check)
        {
            string userInput = null;
            if (check == null)
            {
                throw new ArgumentException("Check function can not be null!");
            }
            do
            {
                Console.WriteLine($"{description}");
                userInput = Console.ReadLine();
            } while (!check.Invoke(userInput));
            Console.WriteLine($"{reaction}");
            return userInput;
        }
    }
}