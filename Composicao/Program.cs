using Composicao.Entities;
using Composicao.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Composicao
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter Deparment's name: ");
            string dept = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            Department department = new Department(dept);

            Worker worker = new Worker(name, level, baseSalary, department);
            Console.Write("How many contracts to this worker?  ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime dt = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valueph = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration(hours): ");
                int duration = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(dt, valueph, duration);
                worker.AddContract(contract);
                //worker.AddContract(new HourContract { Date = dt, Hours = duration, ValuePerHour = valueph });
            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string data = Console.ReadLine();
            int mes = int.Parse(data.Substring(0, 2));
            int ano = int.Parse(data.Substring(3));
           
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + data + ": " + worker.Income(ano, mes).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
