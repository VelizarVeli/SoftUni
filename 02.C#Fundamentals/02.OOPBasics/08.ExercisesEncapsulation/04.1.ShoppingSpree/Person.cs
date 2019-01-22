using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<string> bagOfProducts = new List<string>();

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value=="")
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }
    }

    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            money = value;
        }
    }

    public List<string> Products
    {
        get { return bagOfProducts; }
        set
        {
            bagOfProducts = value;
        }
    }

    public void AddProduct(string productName)
    {
        this.bagOfProducts.Add(productName);
    }

}