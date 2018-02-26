using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;
   
    public Book(string title,string author,decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }
    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length<3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value; }
    }

    public string Author
    {
        get { return author; }
        set
        {
            var input = value
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (input.Length>1&&char.IsDigit(input[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            author = value; }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value<=0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}");
        sb.AppendLine($"Title: {this.Title}");
        sb.AppendLine($"Author: {this.Author}");
        sb.AppendLine($"Price: {this.Price:f2}");

        return sb.ToString();
    }

}

