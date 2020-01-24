using MyCourseWork.Entyties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyCourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            ReaderWriter.InitTextFiles();
            Worker worker = new Worker();
            Job job = new Job();
            Position position = new Position();
            Instruction instruction = new Instruction();
            string result = String.Empty;
            Console.WriteLine("Добро пожаловать!");            
            while(true)
            {
                bool needExit = false;
                Console.WriteLine("Выберите подраздел:" +
                    "\n1 - Работники" +
                    "\n2 - Должность" +
                    "\n3 - Работа" +
                    "\n4 - Поручение" +
                    "\n5 - Посмотреть зарплаты" +
                    "\n0 - Выход из программы" +
                    "\n9 - Очистить консоль");
                result = Console.ReadKey(true).KeyChar.ToString();

                switch (result)
                {
                    case "1":
                        worker.WhatToDo();
                        break;
                    case "2":
                        position.WhatToDo();
                        break;
                    case "3":
                        job.WhatToDo();
                        break;
                    case "4":
                        instruction.WhatToDo();
                        break;
                    case "5":
                        ReaderWriter.ReadSalary();
                        break;
                    case "9":
                        Console.Clear();
                        break;
                    case "0":
                        needExit = true;
                        break;
                    default:
                        Console.WriteLine("Данного варианта не существует");
                        break;
                }
                if (needExit)
                    break;
            }
            Console.WriteLine("До свидания!");
            Thread.Sleep(1500);
        }

    }
}
