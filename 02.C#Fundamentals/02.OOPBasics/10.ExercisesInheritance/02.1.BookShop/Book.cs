using System;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

   public string Author
    {
        get { return author; }
        private set
        {
            var indexOfSpace = value.IndexOf(' ');

            if (indexOfSpace > 0 && indexOfSpace < value.Length - 1 && char.IsDigit(value[indexOfSpace + 1]))
            {
                throw new ArgumentException("Author not valid!");
            }

            author = value;
        }
    }

    public virtual string Title
    {
        get { return title; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            title = value;
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            price = value;
        }
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: { this.GetType().Name}")
            .AppendLine($"Title: { this.Title}")
            .AppendLine($"Author: { this.Author}")
            .AppendLine($"Price: { this.Price:f2}");
        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}