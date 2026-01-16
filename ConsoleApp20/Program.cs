using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleAPP20
{
    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>
        {
        new FullTimeEmployee("E001","山田太郎",8.5),
        new ContractEmployee("C001","佐藤花子",8.0),
        new FullTimeEmployee("E002","鈴木一郎",8.0),
        };

            
            foreach (Employee emp in employees)
            {
                double wage = emp.CalculateDailyWage();
                Console.WriteLine($"社員ID: {emp.Id}, 名前: {emp.Name},給料: {(int)wage}");

            }
        }
    }
    abstract class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double HoursWorked { get; set; }

        protected Employee(string id, string name, double hoursWorked)
        {
            Id = id;
            Name = name;
            HoursWorked = hoursWorked;
        }
        public abstract double CalculateDailyWage();
    }
    class FullTimeEmployee : Employee
    {
        private const double HourlyWage = 1250;
        private const double OvertimeRate = 1.25;
        private const double RegularHours = 8.0;

        public FullTimeEmployee(string id, string name, double hoursWorked) : base(id, name, hoursWorked)
        {
        }
        public override double CalculateDailyWage()
        {
         double regularHours = Math.Min(8.0, HoursWorked);
         double overtimeHours = Math.Max(0.0, HoursWorked - 8.0);

            return regularHours * HourlyWage + overtimeHours * HourlyWage * 1.25;

        }
    }
    class ContractEmployee : Employee
    {
        public const double HourlyWage = 1000;
        public ContractEmployee(string id, string name, double hoursWorked)
            : base(id,name,hoursWorked)
        {
        }
        public override double CalculateDailyWage()
        {
            return HoursWorked * HourlyWage;
        }
    }
   
}

