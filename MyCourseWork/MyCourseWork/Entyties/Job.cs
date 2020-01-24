using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCourseWork.Entyties
{
    public class Job: IExecutor
    {
        public string Name { get; private set; }
        public string Labour { get; private set; }
        public string StartDate { get; private set; }
        public string EndDate { get; private set; }

        public void DeleteRecords()
        {
            System.IO.File.Delete("ins.txt");
            ReaderWriter.InitTextFiles();
        }

        public void AddRecord()
        {
            Console.WriteLine("Введите название работы\n");
            Job job = new Job();
            while (true)
            {
                string result = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(result))
                {
                    job.Name = result;
                    break;
                }
                else
                    Console.WriteLine("Данные введены не верно\n");
            }

            Console.WriteLine("Введите трудоемкость в часах");
            Regex labour = new Regex(@"^[0-9]+$");
            while (true)
            {
                string result = Console.ReadLine();
                if (labour.IsMatch(result))
                {
                    job.Labour = result;
                    break;
                }
                else
                    Console.WriteLine("Данные введены не верно\n");
            }

            Console.WriteLine("Введите дату начала в формате дд.мм.гггг");
            Regex date = new Regex(@"^[0-9]{1,2}.[0-9]{1,2}.[0-9]{4}$");
            while (true)
            {
                string result = Console.ReadLine();
                if (date.IsMatch(result))
                {
                    job.StartDate = result;
                    break;
                }
                else
                    Console.WriteLine("Данные введены не верно\n");
            }

            Console.WriteLine("Введите дату завершения в формате дд.мм.гггг" +
                "\nЕсли работа еще выполняется, введите 0");
            while (true)
            {
                string result = Console.ReadLine();
                if (result == "0")
                {
                    job.EndDate = "В процессе выполнения";
                    break;
                }
                if (date.IsMatch(result))
                {
                    DateTime res;
                    if (DateTime.TryParse(result, out res))
                    {
                        job.EndDate = result;
                        break; ;
                    }
                }
                else
                    Console.WriteLine("Данные введены не верно\n");
            }

            ReaderWriter.WriteJob(job);

            Console.WriteLine("Запись успешно добавлена!\n\n");
        }

        public void ShowRecords()
        {
            ReaderWriter.ReadJobs();
        }

        public void WhatToDo()
        {
            bool needBreak = false;
            while (true)
            {
                if (needBreak)
                    break;
                Console.WriteLine("\n\nВыбран пункт \"Работа\"\n" +
                    "Что вы хотите сделать?\n" +
                    "\n1 - Добавить работу" +
                    "\n2 - Показать все работы" +
                    "\n3 - Удалить все работы" +
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
