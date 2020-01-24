using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCourseWork.Entyties
{
    public class Worker : IExecutor
    {
        public string TabNumber { get; private set; }
        public string FIO { get; private set; }
        public string Position { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public string StartWorkDate { get; private set; }
        public string Experience { get; private set; }
        public string Education { get; private set; }


        public void DeleteRecords()
        {
            System.IO.File.Delete("ins.txt");
            ReaderWriter.InitTextFiles();
        }

        public void AddRecord()
        {
            Console.WriteLine("Введите ФИО работника\n");
            Worker worker = new Worker();
            Regex fio = new Regex(@"^\w+\s\w+\s\w+$");
            while (true)
            {
                string result = Console.ReadLine();
                if (fio.IsMatch(result))
                {
                    worker.FIO = result;
                    break;
                }
                else
                    Console.WriteLine("Данные введены не верно\n");
            }
            Console.WriteLine("Введите табельный номер сотрудника (10 цифр)");
            Regex num = new Regex(@"^[0-9]{10}$");
            while (true)
            {
                string result = Console.ReadLine();
                if (num.IsMatch(result))
                {
                    if (!ReaderWriter.IsExistNumber(result))
                    {
                        worker.TabNumber = result;
                        break;
                    }
                    Console.WriteLine("Данный табельный номер существует!");
                }
                else
                    Console.WriteLine("Данные введены не верно\n");
            }
            Console.WriteLine("Выберите должность из списка:" +
                "\n1 - Управляющий" +
                "\n2 - Директор" +
                "\n3 - Менеджер" +
                "\n4 - Представитель" +
                "\n5 - Секретарь" +
                "\n6 - Работник 1 класса" +
                "\n7 - Работник 2 класса" +
                "\n8 - Начальник отдела" +
                "\n9 - Руководитель персонала");
            while (true)
            {
                bool needBreak = false;
                string result = Console.ReadKey(true).KeyChar.ToString();
                switch (result)
                {
                    case "1":
                        worker.Position = "Управляющий";
                        needBreak = true;
                        break;
                    case "2":
                        worker.Position = "Директор";
                        needBreak = true;
                        break;
                    case "3":
                        worker.Position = "Менеджер";
                        needBreak = true;
                        break;
                    case "4":
                        worker.Position = "Представитель";
                        needBreak = true;
                        break;
                    case "5":
                        worker.Position = "Секретарь";
                        needBreak = true;
                        break;
                    case "6":
                        worker.Position = "Работник 1 класса";
                        needBreak = true;
                        break;
                    case "7":
                        worker.Position = "Работник 2 класса";
                        needBreak = true;
                        break;
                    case "8":
                        worker.Position = "Начальник отдела";
                        needBreak = true;
                        break;
                    case "9":
                        worker.Position = "Руководитель персонала";
                        needBreak = true;
                        break;
                    default:
                        Console.WriteLine("Нет такого варианта!");
                        break;
                }
                if (needBreak)
                    break;
            }

            Console.WriteLine("Введите номер телефона сотрудника без 8");
            Regex phone = new Regex(@"^[0-9]{10}$");
            while (true)
            {
                string result = Console.ReadLine();
                if (phone.IsMatch(result))
                {
                    worker.PhoneNumber = result;
                    break;
                }
                else
                    Console.WriteLine("Данные введены не верно\n");
            }

            Console.WriteLine("Введите адрес проживания сотрудника" +
                "\nАдрес вводить в формате Город, улица, дом, квартира");
            while (true)
            {
                string result = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(result))
                {
                    worker.Address = result;
                    break;
                }
                else
                    Console.WriteLine("Данные введены не верно\n");
            }

            Console.WriteLine("Введите дату начала работы сотрудника в формате дд.мм.гггг");
            Regex date = new Regex(@"^[0-9]{1,2}.[0-9]{1,2}.[0-9]{4}$");
            while (true)
            {
                string result = Console.ReadLine();
                if (date.IsMatch(result))
                {
                    DateTime res;
                    if (DateTime.TryParse(result, out res))
                    {
                        worker.StartWorkDate = result;
                        break;
                    }
                }
                else
                    Console.WriteLine("Данные введены не верно\n");
            }

            Console.WriteLine("Введите стаж  (полных лет)");
            Regex exp = new Regex(@"^[0-9]{1,2}");
            while (true)
            {
                string result = Console.ReadLine();
                if (exp.IsMatch(result))
                {
                    worker.Experience = result;
                    break;
                }
                else
                    Console.WriteLine("Данные введены не верно\n");
            }

            Console.WriteLine("Введите образование" +
                "\n1 - Cреднее" +
                "\n2 - Cреднее - профессиональное" +
                "\n3 - Высшее");
            while (true)
            {
                bool needBreak = false;
                string result = Console.ReadKey(true).KeyChar.ToString();
                switch(result)
                {
                    case "1":
                        needBreak = true;
                        worker.Education = "Cреднее";
                        break;
                    case "2":
                        needBreak = true;
                        worker.Education = "Cреднее - профессиональное";
                        break;
                    case "3":
                        needBreak = true;
                        worker.Education = "Высшее";
                        break;
                    default:
                        Console.WriteLine("Данные введены не верно!");
                        break;
                }
                if (needBreak)
                    break;
            }

            ReaderWriter.WriteWorker(worker);

            Console.WriteLine("\nЗапись успешно добавлена!\n\n");

        }

        public void ShowRecords()
        {
            ReaderWriter.ReadWorkers();
        }

        public void WhatToDo()
        {
            bool needBreak = false;
            while (true)
            {
                if (needBreak)
                    break;
                Console.WriteLine("\n\nВыбран пункт \"Работники\"\n" +
                    "Что вы хотите сделать?\n" +
                    "\n1 - Добавить работника" +
                    "\n2 - Показать всех работников" +
                    "\n3 - Удалить все должности" +
                    "\n0 - Назад");
                string result = Console.ReadKey(true).KeyChar.ToString();
                switch (result)
                {
                    case "0":
                        needBreak = true;
                        Console.Clear();
                        break;
                    case "1":
                        needBreak = true;
                        AddRecord();
                        break;
                    case "2":
                        ShowRecords();
                        break;
                    case "3":
                        DeleteRecords();
                        needBreak = true;
                        break;
                    default:
                        Console.WriteLine("Данного варианта не существует");
                        break;
                }
            }
        }
    }
}
