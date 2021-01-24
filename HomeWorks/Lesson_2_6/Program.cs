using System;

namespace Lesson_2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа работы с битовыми масками приветствует вас");
            //Работаем всю неделю, кроме выходных
            DaysOfWeek_Local scheduleOne = ~DaysOfWeek_Local.Saturday & ~DaysOfWeek_Local.Sunday;
            //Работаем всю неделю
            DaysOfWeek_Local scheduleTwo = ~DaysOfWeek_Local.Saturday | ~DaysOfWeek_Local.Sunday;
            //Работаем со вторника до пятницы
            DaysOfWeek_Local scheduleThree = scheduleOne & ~DaysOfWeek_Local.Monday;
            Console.WriteLine("Проверка офиса с графиком работы, предсталенного битовой маской работы по будням");
            CheckSchedule(scheduleOne);
            Console.WriteLine("Проверка офиса с графиком работы, предсталенного битовой маской работы в течение всей недели");
            CheckSchedule(scheduleTwo);
            Console.WriteLine("Проверка офиса с графиком работы, предсталенного битовой маской работы со вторника по пятницу");
            CheckSchedule(scheduleThree);
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }

        private static void CheckSchedule(DaysOfWeek_Local schedule)
        {
            DaysOfWeek_Local working = (DaysOfWeek_Local)0b_0011111; 
            DaysOfWeek_Local weekend = (DaysOfWeek_Local)0b_1100000;
            DaysOfWeek_Local tuesdayToFriday = (DaysOfWeek_Local)0b_0011110;
            if ((schedule & working) == working)
            {
                Console.WriteLine("Офис работает по будням");
            }
            else if ((schedule & tuesdayToFriday) == tuesdayToFriday)
            {
                Console.WriteLine("Офис работает со вторника по пятницу");
            }
            if ((schedule & weekend) == weekend)
            {
                Console.WriteLine("Офис работает по выходным");
            }
        }
        [Flags]
        enum DaysOfWeek_Local
        {
            Monday    = 0b_0000001,
            Tuesday   = 0b_0000010,
            Wednesday = 0b_0000100,
            Thursday  = 0b_0001000,
            Friday    = 0b_0010000,
            Saturday  = 0b_0100000,
            Sunday    = 0b_1000000
        }
    }
    
}