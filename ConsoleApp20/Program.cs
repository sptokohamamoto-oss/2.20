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


            foreach(var item in employees)
{
                double wage = item.CalculateDailyWage(item.HoursWorked);
                int wageInt = (int)wage;
                Console.WriteLine($"社員ID: {item.Id}, 名前: {item.Name}, 給料: {wageInt}");
            }
            
        }
    }
    abstract class Employee
    {
        public string Id { get; }
        public string Name { get; }
        public double HoursWorked { get; }

        protected Employee(string id, string name, double hoursWorked)
        {
            Id = id;
            Name = name;
            HoursWorked = hoursWorked;
        }
        public abstract double CalculateDailyWage(double hoursWorked);
    }
    class FullTimeEmployee : Employee
    {
        private const double HourlyWage = 1250;
        private const double OvertimeRate = 1.25;
        private const double RegularHours = 8.0;

        public FullTimeEmployee(string id, string name, double hoursWorked) : base(id, name, hoursWorked)
        {
        }
        public override double CalculateDailyWage(double hoursWorked)
        {
         double regularHours = Math.Min(8.0, HoursWorked);
         double overtimeHours = Math.Max(0.0, HoursWorked - 8.0);

            return regularHours * 1250 + overtimeHours * 1250 * 1.25;

        }
    }
    class ContractEmployee : Employee
    {
        public const double HourlyWage = 1000;
        public ContractEmployee(string id, string name, double hoursWorked)
            : base(id,name,hoursWorked)
        {
        }
        public override double CalculateDailyWage(double hoursWorked)
        {
            return HoursWorked * 1000;
        }
    }
   
}

