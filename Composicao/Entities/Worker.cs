using Composicao.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Composicao.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department{ get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract hourContract)
        {
            Contracts.Add(hourContract);
        }

        public void RemoveContract(HourContract hourContract)
        {
            Contracts.Remove(hourContract);
        }

        public double Income(int year, int month)
        {
            double income = BaseSalary;
            foreach (HourContract hc in Contracts)
            {
                if (hc.Date.Year == year && hc.Date.Month == month)
                {
                    income += hc.TotalValue();
                }
            }

            return income;
        }

    }
}
