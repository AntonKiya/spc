using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCourseWork.Entyties
{
    public class Instruction : IExecutor
    {
        public string Name { get; private set; }
        public string IssueDate { get; private set; }
        public string Labour { get; private set; }
        public string PlanEndDate { get; private set; }
        public string RealEndDate { get; private set; }
        public string Worker { get; private set; }

        public void AddRecord()
        {
            Instruction instruction = new Instruction();
            Console.WriteLine("Введите название поручения");
            while (true)
            {
                string result = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(result))
                {
                    instruction.Name = result;
                    break;
                }
                else
                    Console.WriteLine("Введена пустая строка!");
            }


            Console.WriteLine("Введите трудоемкость поручения (часы) ");
            Regex name = new Regex(@"^[0-9]+$");
            while (true)
            {
                string result = Console.ReadLine();
                if (name.IsMatch(result))
                {
                    instruction.Labour = result;
                    break;
                }
                else
                    Console.WriteLine("Данные введены не верно\n");
            }

            Console.WriteLine("Введите дату выдачи поручения в формате дд.мм.гггг");
            Regex date = new Regex(@"^[0-9]{1,2}.[0-9]{1,2}.[0-9]{4}$");
            while (true)
            {
                string result = Console.ReadLine();
                if (date.IsMatch(result))
                {
                    DateTime res;
                    if (DateTime.TryParse(result, out res))
                    {
                        instruction.IssueDate = result;
                        break;
                    }

                }
                Console.WriteLine("Данные введены не верно\n");
            }

            Console.WriteLine("Введите дату плановую дату окончания в формате дд.мм.гггг");
            while (true)
            {
                string result = Console.ReadLine();
                if (date.IsMatch(result))
                {
                    DateTime res;
                    if (DateTime.TryParse(result, out res))
                    {
                        instruction.PlanEndDate = result;
                        break;
                    }
                }
                Console.WriteLine("Данные введены не верно\n");
            }

            Console.WriteLine("Введите дату реальную дату окончания в формате дд.мм.гггг. Если работа еще выполняется, введите 0");
            while (true)
            {
                string result = Console.ReadLine();
                if (result == "0")
                {
                    instruction.RealEndDate = "В процессе выполнения";
                    break;
                }
                if (date.IsMatch(result))
                {
                    DateTime res;
                    if (DateTime.TryParse(result, out res))
                    {
                        instruction.RealEndDate = result;
                        break;
                    }
                }
                Console.WriteLine("Данные введены не верно\n");
            }

            Console.WriteLine("К какому сотруднику будет привязано поручение? Введите его номер из списка ниже");
            int count = ReaderWriter.ReadWorkersWithNumbers();
            if (count == 0)
            {
                Console.WriteLine("Ни одного работника не существует!");
                return;
            }
            while (true)
            {
                string result = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                Regex numWorker = new Regex(@"[0-9]+");
                if (numWorker.IsMatch(result))
                {
                    int res = int.Parse(result);
                    if (res > 0 && res <= count)
                    {
                        string worker = ReaderWriter.GetWorkerByNumber(res);
                        if (worker != null)
                        {
                            instruction.Worker = worker;
                            break;
                        }
                    }
                    Console.WriteLine("Введен некорректный номер!");
                }
            }

            ReaderWriter.WriteInstruction(instruction);

            Console.WriteLine("Запись успешно добавлена!\n\n");
        }

        public void DeleteRecords()
        {
            System.IO.File.Delete("ins.txt");
            ReaderWriter.InitTextFiles();
        }

        public void ShowRecords()
        {
            ReaderWriter.ReadInstruction();
        }

        public void WhatToDo()
        {
            bool needBreak = false;
            while (true)
            {
                if (needBreak)
                    break;
                Console.WriteLine("\n\nВыбран пункт \"Поручение\"\n" +
                    "Что вы хотите сделать?\n" +
                    "\n1 - Добавить поручение" +
                    "\n2 - Показать поручения" +
                    "\n3 - Удалить все поручения" +
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
