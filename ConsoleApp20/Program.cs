using System;
using System.Collections.Generic;

class Program
{
    
    static void Main()
    {
        var employee  = new List<(Employee emp,double hours)>
        {
           ( new FullTimeEmployee("E001", "山田太郎"),8.5),
           ( new ContractEmployee("C001", "佐藤花子"),8.0),
           (new FullTimeEmployee("E002", "鈴木一郎"),8.0),
        };


        foreach (var item in employee)
        {
            double wage = item.emp.CalculateDailyWage(item.hours);
            Console.WriteLine($"社員ID: {item.emp.Id}, 名前: {item.emp.Name}, 給料: {(int)wage}");
        }
    }
}


abstract class Employee
{
    public string Id;
    public string Name;

    protected Employee(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public abstract double CalculateDailyWage(double HoursWorked);
}
class FullTimeEmployee : Employee
{
    private const double HourlyWage = 1250;
    private const double OvertimeRate = 1.25;
    private const double RegularHours = 8.0;

    public FullTimeEmployee(string id, string name)
        : base(id, name)
    {
    }

    public override double CalculateDailyWage(double HoursWorked)
    {
        double regular = Math.Min(HoursWorked, RegularHours);
        double overtime = Math.Max(0.0, HoursWorked - RegularHours);
        return regular * HourlyWage + overtime * HourlyWage * OvertimeRate;
    }
}

class ContractEmployee : Employee
{
    private const double HourlyWage = 1000;

    public ContractEmployee(string id, string name)
        : base(id, name)
    {
    }

    public override double CalculateDailyWage(double HoursWorked)
    {
        return HoursWorked * HourlyWage;
    }
}
  
