using System;

public class Relative
{
    public string Name { get; set; }
    public string Birthday { get; set; }
    public string Type { get; set; }

    public Relative(string name, string birthday, string type)
    {
        this.Name = name;
        this.Birthday = birthday;
        this.Type = type;
    }
}