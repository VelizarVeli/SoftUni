using System;

public class Box
{
    private double length;
    private double width;
    private double height;

   public double Length
    {
        get { return this.length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }

            this.length = value;
        }
    }

    public double Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }

            this.width = value;
        }
    }

    public double Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }

            this.height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Height = height;
        this.Width = width;
    }

    public double CalculateSurfaceArea(double a, double b, double c)
    {
        double result = 2 * a * b + 2 * b * c + 2 * a * c;
        return result;
    }

    public double CalculateLAteralSurfaceArea(double a, double b, double c)
    {
        double result = CalculateSurfaceArea(a, b, c) - width * length * 2;

        return result;
    }

    public double CalculateVolume(double a, double b, double c)
    {
        double result = a * b * c;
        return result;
    }
}