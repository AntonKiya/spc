using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCourseWork.Entyties
{
    public class Position: IExecutor
    {
        public string Name { get; private set; }

        public void DeleteRecords()
        {
            System.IO.File.Delete("ins.txt");
            ReaderWriter.InitTextFiles();
        }

        public void AddRecord()
        {
            Console.WriteLine("Добавление новых должностей заблокировано!");
            return;
            Position position = new Position();
            Console.WriteLine("Введите название должности\n");
            while (true)
            {
                string result = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(result))
                {
                    position.Name = result;
                    break;
                }
                else
                    Console.WriteLine("Данные введены не верно\n");
            }            

            ReaderWriter.WritePosition(position);

            Console.WriteLine("Запись успешно добавлена!\n\n");
        }

        public void ShowRecords()
        {
            //Console.WriteLine("Добавление новых должностей заблокировано!");
            ReaderWriter.ReadPosition();
        }

        public void WhatToDo()
        {
            bool needBreak = false;
            while (true)
            {
                if (needBreak)
                    break;
                Console.WriteLine("\n\nВыбран пункт \"Должность\"\n" +
                    "Что вы хотите сделать?\n" +
                    "\n1 - Добавить должность" +
                    "\n2 - Показать все должности" +
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
                    default:
                        Console.WriteLine("Данного варианта не существует");
                        break;
                }
            }
        }
    }
}
