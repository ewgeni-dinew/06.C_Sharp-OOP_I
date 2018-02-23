using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var num = int.Parse(Console.ReadLine());
        var departmentList = new Dictionary<string, double>();
        var departmentCount = new Dictionary<string, int>();
        var employeeList = new List<Employee>();

        for (int i = 0; i <num; i++)
        {
            var line = Console.ReadLine().Split();

            var currentName = line[0];
            var currentSalary = double.Parse(line[1]);
            var currentPos = line[2];
            var currentDep = line[3];

            var currentEmployee = new Employee(currentName, currentSalary, currentPos, currentDep);

            if (!departmentList.ContainsKey(currentDep))
            {
                departmentList[currentDep] = 0;
                departmentCount[currentDep] = 0;
            }

            departmentCount[currentDep]++;
            departmentList[currentDep] += currentSalary;

            if (line.Length == 5)
            {
                var isAge = int.TryParse(line[4], out int age);
                if (isAge)
                {
                    currentEmployee.Age = age;
                }
                else
                {
                    currentEmployee.Email = line[4];
                }
            }
            else if(line.Length==6)
            {
                currentEmployee.Email = line[4];
                currentEmployee.Age = int.Parse(line[5]);
            }
            employeeList.Add(currentEmployee);
        }

        var maxAvrgPay = 0.0;
        var maxPaidDep = string.Empty;

        foreach (var key in departmentList.Keys)
        {
            var count = departmentCount[key];
            var currentPaid = departmentList[key] / (double)count;
            if (currentPaid>maxAvrgPay)
            {
                maxAvrgPay = currentPaid;
                maxPaidDep = key;
            }
        }

        Console.WriteLine($"Highest Average Salary: {maxPaidDep}");
        foreach (var value in employeeList
            .Where(e=>e.Department==maxPaidDep)
            .OrderByDescending(e=>e.Salary))
        {
            Console.WriteLine($"{value.Name} {value.Salary:f2} {value.Email} {value.Age}");
        }
    }
}

