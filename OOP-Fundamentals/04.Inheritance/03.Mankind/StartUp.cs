using System;
using System.Text.RegularExpressions;

public class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            var student = ParseStudentFromInput();
            var worker = ParseWorkerFromInput();

            Console.WriteLine(student.ToString());
            Console.WriteLine(worker.ToString());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static Worker ParseWorkerFromInput()
    {
        var input = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (input.Length < 4)
            throw new ArgumentException("");

        var firstName = input[0];
        var lasstName = input[1];
        var salary = decimal.Parse(input[2]);
        var workHours = decimal.Parse(input[3]);

        var worker = new Worker(firstName, lasstName, salary,workHours);

        return worker;
    }

    private static Student ParseStudentFromInput()
    {
        var input = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (input.Length<3)
            throw new ArgumentException("");

        var firstName = input[0];
        var lasstName = input[1];
        var facultyNumber = input[2];

        var regex = new Regex("[a-zA-Z0-9]+$");

        if (!regex.IsMatch(facultyNumber))
            throw new ArgumentException("Invalid faculty number!");

        var student = new Student(firstName,lasstName,facultyNumber);

        return student;
    }
}

