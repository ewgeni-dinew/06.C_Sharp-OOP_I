using System;

public class StartUp
{
    static void Main(string[] args)
    {
        var author = Console.ReadLine();
        var title = Console.ReadLine();
        var price = decimal.Parse(Console.ReadLine());

        try
        {
            var book = new Book(title,author,price);
            var goldenBook = new GoldenEditionBook(title,author,price);
            Console.WriteLine(book.ToString());
            Console.WriteLine(goldenBook.ToString());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}

