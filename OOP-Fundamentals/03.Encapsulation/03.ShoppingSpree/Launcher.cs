using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    static void Main(string[] args)
    {
        var customerList = new List<Person>();
        var productList = new List<Product>();

        try
        {
            customerList = GetCustomersFromInput();
            productList = GetProductsFromInput();

            customerList = BuyProducts(customerList, productList);
            PrintBuyers(customerList);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static List<Person> BuyProducts(List<Person> customerList, List<Product> productList)
    {
        var command = Console.ReadLine();
        while (!command.Equals("END"))
        {
            var tokens = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var customerName = tokens[0];
            var productName = tokens[1];

            var person = customerList.FirstOrDefault(c => c.Name.Equals(customerName));
            var product = productList.FirstOrDefault(p => p.Name.Equals(productName));

            if (person.Money >= product.Cost)
            {
                Console.WriteLine($"{customerName} bought {productName}");
                person.Products.Add(product);
                person.Money -= product.Cost;
            }
            else
            {
                Console.WriteLine($"{customerName} can't afford {productName}");
            }
            command = Console.ReadLine();
        }
        return customerList;
    }

    private static void PrintBuyers(List<Person> customerList)
    {
        foreach (var customer in customerList)
        {
            if (customer.Products.Any())
                Console.WriteLine($"{customer.Name} - {string.Join(", ",customer.Products.Select(p => p.Name).ToList())}");
            else
                Console.WriteLine($"{customer.Name} - Nothing bought");
        }
    }

    private static List<Product> GetProductsFromInput()
    {
        var productList = new List<Product>();
        var inputProducts = Console.ReadLine()
            .Split(new char[] { ' ', ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputProducts.Length; i += 2)
        {
            var name = inputProducts[i];
            var cost = decimal.Parse(inputProducts[i + 1]);
            var product = new Product(name, cost);
            productList.Add(product);
        }
        return productList;
    }

    private static List<Person> GetCustomersFromInput()
    {
        var personList = new List<Person>();

        var inputCustomers = Console.ReadLine()
            .Split(new char[] { ' ', ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputCustomers.Length; i += 2)
        {
            var name = inputCustomers[i];
            var money = decimal.Parse(inputCustomers[i + 1]);
            var customer = new Person(name, money);
            personList.Add(customer);
        }

        return personList;
    }
}

