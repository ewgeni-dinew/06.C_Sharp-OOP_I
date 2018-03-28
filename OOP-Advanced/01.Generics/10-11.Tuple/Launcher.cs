using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class Launcher
    {
        static void Main()
        {
            var nameAndAddress = Console.ReadLine().Split();
            var personInfo = new Tuple<string, string, string>($"{nameAndAddress[0]} {nameAndAddress[1]}",
                nameAndAddress[2], nameAndAddress[3]);

            var nameAndAmountBeer = Console.ReadLine().Split();
            bool drinkOrNot = nameAndAmountBeer[2] == "drunk" ? true : false;
            var personsBeerAmount = new Tuple<string, int, bool>(nameAndAmountBeer[0], int.Parse(nameAndAmountBeer[1]), drinkOrNot);

            var bankAccount = Console.ReadLine().Split();
            double balance = Math.Round(double.Parse(bankAccount[1]), 1);
            var differentTypeNumbers = new Tuple<string, double, string>(bankAccount[0], balance, bankAccount[2]);

            Console.WriteLine(personInfo);
            Console.WriteLine(personsBeerAmount);
            Console.WriteLine(differentTypeNumbers);
        }
    }
}
