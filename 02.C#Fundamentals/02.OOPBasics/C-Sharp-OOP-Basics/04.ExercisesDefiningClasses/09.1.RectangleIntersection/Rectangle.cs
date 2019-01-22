using System.Collections.Generic;
using System.Linq;

public class Rectangle
{
    public string Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Horizontal { get; set; }
    public double Vertical { get; set; }

    public Rectangle(string id,double width, double height, double horizontal, double vertical)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.Horizontal = horizontal;
        this.Vertical = vertical;
    }
}