using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

 abstract class Employee
    {
        public string Id;
        public string Name;
        public double HoursWorked;

        protected Employee(string id, string name, double hoursWorked)
        {
            Id = id;
            Name = name;
            HoursWorked = hoursWorked;
        }
        public abstract int CalculateDailyWage();
    }
    class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(string id, string name, double hoursWorked) : base(id, name, hoursWorked)
        {
        }
        public override int CalculateDailyWage()
        {
        int wage = (int)(1250 * 8);
        if (HoursWorked > 8) 
        {
            wage += (int)(1250 * 1.25 * (HoursWorked - 8));
        }
        return wage;
        }
    }
    class ContractEmployee : Employee
{
        public ContractEmployee(string id, string name, double hoursWorked)
            : base(id,name,hoursWorked)
        {
        }
        public override int CalculateDailyWage()
        {
        int wage = (int)(1000 * HoursWorked);
        return wage;
        }
    }
    class Program
    {
        static void Main()
        {
            List<Employee> list = new List<Employee>
        {
        new FullTimeEmployee("E001","山田太郎",8.5),
        new ContractEmployee("C001","佐藤花子",8.0),
        new FullTimeEmployee("E002","鈴木一郎",8.0),
        };


            foreach (var item in list)
            {
                double wage = item.CalculateDailyWage();
                Console.WriteLine($"社員ID: {item.Id}, 名前: {item.Name}, 給料: {wage}");
            }

        }
    }


