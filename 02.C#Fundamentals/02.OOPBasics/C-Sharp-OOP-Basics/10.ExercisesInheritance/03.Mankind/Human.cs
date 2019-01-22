using System;
using System.Linq;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get { return firstName; }
        set
        {
            char firstLetter = value[0];
            if (!Char.IsUpper(firstLetter))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        set
        {
            char firstLetter = value[0];
            if (!Char.IsUpper(firstLetter))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            lastName = value;
        }
    }
}