using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private const int MIN_LENGTH = 1;
    private const int MAX_LENGTH = 15;
    private const int MIN_TOPINGS = 0;
    private const int MAX_TOPINGS = 10;

    private string name;

    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }


    public Pizza(string name)
        : this()
    {
        this.Name = name;
    }

    private double ToppingsCalories
    {
        get
        {
            if (this.Toppings.Count == 0)
            {
                return 0;
            }

            return this.Toppings.Select(t => t.Calories).Sum();
        }
    }

    private double Calories => this.Dough.Calories + this.ToppingsCalories;

    private string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > MAX_LENGTH)
            {
                throw new ArgumentException($"Pizza name should be between {MIN_LENGTH} and {MAX_LENGTH} symbols.");
            }
            name = value;
        }
    }
    private Dough Dough { get; set; }
    private List<Topping> Toppings { get; set; }

    public void SetDough(Dough dough)
    {
        if (this.Dough != null)
        {
            throw new InvalidOperationException("Dough already set!");
        }
            this.Dough = dough;
    }

    public void AddToping(Topping topping)
    {
        this.Toppings.Add(topping);
        if (this.Toppings.Count > MAX_TOPINGS)
        {
            throw new ArgumentException($"Number of toppings should be in range [{MIN_TOPINGS}..{MAX_TOPINGS}].");
        }
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Calories:f2} Calories.";
    }
}