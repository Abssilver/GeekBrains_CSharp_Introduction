using System;

namespace Lesson_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(OrderTemplate());
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }
        private static string OrderTemplate()
        {
            // - допущения
            string organizationName = "ООО КОНФЕТНАЯ";
            uint postIndex = 100000;
            string city = "г.Шоколадинск";
            string street = "Мармеладная улица";
            //домов на улице меньше 255
            byte building = 1;
            string organizationAddress = $"{postIndex}, {city}, {street}, {building}";
            
            //не больше 65,535 за день
            ushort orderNumber = 50;
            ushort shiftNumber = 0500;
            //количество касс меньше 255
            byte cashboxNumber = 3;
            DateTime sellDate = new DateTime(2020,6,6,12,48,0);
            string cashData = $"Чек: {orderNumber} СМЕНА: {shiftNumber:d4} КАССА: {cashboxNumber} {sellDate}";
            
            uint prodictId = 05553535;
            string productName = "Трава в горшочке Овес";
            string sellPositionName = $"{prodictId:d8} {productName}";

            decimal productPrice = 125m;
            decimal productPriceWithDiscount = 112.49m;
            ushort productQuantity = 1;
            decimal discountValue = 12.51m;
            decimal totalPrice = 112.49m;
            uint vatValue = 20;
            string sellPositionPrice = string.Format("{0} {1} *{2} {3} {4} {5}%",
                productPrice.ToString("F"),
                productPriceWithDiscount.ToString("F"),
                productQuantity,
                discountValue.ToString("F"),
                totalPrice.ToString("F"),
                vatValue);
            
            decimal totalValue = 112.49m;
            decimal cashlessPayments = 112.49m;
            decimal vatTotal = 22.5m;
            
            decimal totalDIscount = 12.51m;
            
            ushort storeNumber = 111;
            string placeOfPayments = $"Магазин {storeNumber}";
            
            string cashierName = "Иван";
            string cashierSurname = "Иванов";
            string cashierPatronymic = "Иванович";
            
            //Данные выдуманы
            string FTSWebsite = "nalog.ru";
            ulong taxpayerIdentificationNumber = 7_000_111_222;
            ulong registrationNumberOfCashRegisterEquipment = 0_001_112_223_334_442;
            ulong cashRegisterEquipmentSerialNumber = 0_123_456_789;
            ulong fiscalStorageDevice = 9_345_111_000_000_111;
            uint fiscalDocumentNumber = 44_095;
            ulong fiscalSign = 3_123_498_015;
            string taxSystem = "ОСН";
            
            string tab = new string('-', 50);

            return string.Concat(
                organizationName, Environment.NewLine,
                organizationAddress, Environment.NewLine,
                tab, Environment.NewLine,
                "КАССОВЫЙ ЧЕК ПРИХОД", Environment.NewLine,
                cashData, Environment.NewLine,
                tab, Environment.NewLine,
                "Цена Цена со скидкой Кол-во Скидка Итого НДС%", Environment.NewLine,
                tab, Environment.NewLine,
                sellPositionName, Environment.NewLine,
                sellPositionPrice, Environment.NewLine,
                tab, Environment.NewLine,
                $"ИТОГ ={totalValue.ToString("F")}", Environment.NewLine,
                $"БЕЗНАЛИЧНЫМИ ={cashlessPayments.ToString("F")}", Environment.NewLine,
                $"СУММА НДС {vatValue}% ={vatTotal.ToString("F")}", Environment.NewLine,
                tab, Environment.NewLine,
                $"Общая скидка составила, руб ={totalDIscount.ToString("F")}", Environment.NewLine,
                tab, Environment.NewLine,
                "СПАСИБО ЗА ПОКУПКУ!", Environment.NewLine,
                new string('-', 10), new string('|', 30), new string('-', 10), Environment.NewLine,
                $"МЕСТО РАСЧЕТОВ: {placeOfPayments}", Environment.NewLine,
                $"КАССИР: {cashierSurname} {cashierName} {cashierPatronymic}", Environment.NewLine,
                $"Сайт ФНС: {FTSWebsite} ИНН: {taxpayerIdentificationNumber:d10}", Environment.NewLine,
                $"РН ККТ:{registrationNumberOfCashRegisterEquipment:d16} СНО: {taxSystem}", Environment.NewLine,
                $"ЗН ККТ:{cashRegisterEquipmentSerialNumber:d10} ФН:{fiscalStorageDevice}", Environment.NewLine,
                $"ФД {fiscalDocumentNumber} ФП {3_123_498_015}", Environment.NewLine);
        }
    }
}