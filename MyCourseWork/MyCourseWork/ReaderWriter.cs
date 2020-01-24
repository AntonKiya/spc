using MyCourseWork.Entyties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourseWork
{
    public static class ReaderWriter
    {
        public static void WriteWorker(Worker worker)
        {
            using (StreamWriter sw = new StreamWriter(@"workers.txt", true))
            {
                sw.WriteLine($"{worker.FIO}, {worker.TabNumber}, {worker.Position}, {worker.PhoneNumber}, {worker.Address}, {worker.StartWorkDate}, {worker.Experience}, {worker.Education}");
            };
        }

        private static List<string> GetTabNumbers()
        {
            List<string> workers = new List<string>();
            using (StreamReader sr = new StreamReader("workers.txt"))
            {
                while (!sr.EndOfStream)
                {
                    workers.Add(sr.ReadLine().Split(',')[1].Trim());
                }
            };
            return workers;
        }

        public static bool IsExistNumber(string number)
        {
            var numbers = GetTabNumbers();
            var result = numbers.FirstOrDefault(n => n == number);
            if (result != null)
                return true;
            return false;
        }

        public static void ReadSalary()
        {
            List<string> ws = new List<string>();

            List<string> positions = new List<string>();

            //Заполняем список работников и должностей исходя из записанных данных в txt
            using (StreamReader sr = new StreamReader("workers.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var worker = sr.ReadLine().Split(',');
                    ws.Add($"{worker[0]}, {worker[1]}, зарплата - ");
                    positions.Add(worker[2]);
                }
            };

            //заполняем список поручений 
            List<string> insWork = new List<string>();
            using (StreamReader sr = new StreamReader("ins.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var intructions = sr.ReadLine().Split(',');
                    insWork.Add(intructions[4]);
                }
            };

            //Считаем множитель, затем зп
            for (int i = 0; i < ws.Count; i++)
            {
                double mul = 1;

                switch(positions[i].Trim())
                {
                    case "Директор":
                        mul += 0.6;
                        break;
                    case "Управляющий":
                        mul += 0.55;
                        break;
                    case "Менеджер":
                        mul += 0.5;
                        break;
                    case "Представитель":
                        mul += 0.45;
                        break;
                    case "Секретарь":
                        mul += 0.40;
                        break;
                    case "Работник 1 класса":
                        mul += 0.20;
                        break;
                    case "Работник 2 класса":
                        mul += 0.25;
                        break;
                    case "Начальник отдела":
                        mul += 0.30;
                        break;
                    case "Руководитель персонала":
                        mul += 0.35;
                        break;
                }

                foreach(var ins in insWork)
                {
                    if(ins.Trim() == ws[i].Split(',')[0])
                    {
                        mul += 0.2;
                    }
                }
                ws[i] += $" {mul * 10000}";
            }

            if(ws.Count>0)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Информации не существует");
                return;
            }

            foreach(var workerSalary in ws)
            {
                var oneWS = workerSalary.Split(',');
                string result = oneWS[0] + oneWS[2];
                Console.WriteLine(result);
            }
            Console.WriteLine();

        }

        public static void ReadWorkers()
        {
            Console.WriteLine();
            using (StreamReader sr = new StreamReader("workers.txt"))
            {
                bool isRead = false;
                while (!sr.EndOfStream)
                {
                    isRead = true;
                    Console.WriteLine(sr.ReadLine());
                }
                if (!isRead)
                    Console.WriteLine("Ни один работник не существует!");
                Console.WriteLine();
            };
        }

        public static int ReadWorkersWithNumbers()
        {
            int i = 1;
            using (StreamReader sr = new StreamReader("workers.txt"))
            {
                while (!sr.EndOfStream)
                {
                    Console.Write($"{i} - ");
                    Console.WriteLine(sr.ReadLine());
                    i++;
                }
            };

            return i - 1;
        }

        public static string GetWorkerByNumber(int number)
        {
            using (StreamReader sr = new StreamReader("workers.txt"))
            {
                int counter = 0;
                while (!sr.EndOfStream)
                {
                    counter++;
                    if (counter == number)
                    {
                        var result = sr.ReadLine().Split(',');
                        return result[0];
                    }
                }
            };
            return null;
        }

        public static void WriteJob(Job job)
        {
            using (StreamWriter sw = new StreamWriter(@"jobs.txt", true))
            {
                sw.WriteLine($"{job.Name}, {job.Labour}, {job.StartDate}, {job.EndDate},");
            };
        }

        public static void ReadJobs()
        {
            Console.WriteLine();
            using (StreamReader sr = new StreamReader("jobs.txt"))
            {
                bool isRead = false;
                while (!sr.EndOfStream)
                {
                    isRead = true;
                    Console.WriteLine(sr.ReadLine());
                }
                if (!isRead)
                    Console.WriteLine("Ни одна работа не существует!");
                Console.WriteLine();
            };
        }

        public static void WritePosition(Position position)
        {
            using (StreamWriter sw = new StreamWriter(@"pos.txt", true))
            {
                sw.WriteLine($"{position.Name}");
            };
        }

        public static void ReadPosition()
        {
            Console.WriteLine();
            using (StreamReader sr = new StreamReader("pos.txt"))
            {
                bool isRead = false;
                while (!sr.EndOfStream)
                {
                    isRead = true;
                    Console.WriteLine(sr.ReadLine());
                }
                if (!isRead)
                    Console.WriteLine("Ни одна должность не существует!");
                Console.WriteLine();
            };
        }

        public static void WriteInstruction(Instruction instruction)
        {
            using (StreamWriter sw = new StreamWriter(@"ins.txt", true))
            {
                sw.WriteLine($"{instruction.Name}, {instruction.IssueDate}, {instruction.Labour}, {instruction.PlanEndDate}, {instruction.RealEndDate}, {instruction.Worker}");
            };
        }

        public static void ReadInstruction()
        {
            Console.WriteLine();
            using (StreamReader sr = new StreamReader("ins.txt"))
            {
                bool isRead = false;
                while (!sr.EndOfStream)
                {
                    isRead = true;
                    Console.WriteLine(sr.ReadLine());
                }
                if (!isRead)
                    Console.WriteLine("Ни одно поручение не существует!");
                Console.WriteLine();
            };
        }

        public static void InitTextFiles()
        {
            using (StreamWriter sw = new StreamWriter("workers.txt", true))
            {
            }
            using (StreamWriter sw = new StreamWriter("jobs.txt", true))
            {
            }
            using (StreamWriter sw = new StreamWriter("pos.txt"))
            {
                List<String> positions = new List<string>()
                {
                    "Управляющий",
                    "Директор",
                    "Менеджер",
                    "Представитель",
                    "Секретарь",
                    "Работник 1 класса",
                    "Работник 2 класса",
                    "Начальник отдела",
                    "Руководитель персонала 4000"
                };
                foreach (var pos in positions)
                    sw.WriteLine(pos);
            }
            using (StreamWriter sw = new StreamWriter("ins.txt", true))
            {
            }
        }
    }
}
