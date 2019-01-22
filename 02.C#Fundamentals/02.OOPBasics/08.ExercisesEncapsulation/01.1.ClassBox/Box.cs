public class Box
{
    private double length;
    private double width;
    private double height;

    double Length
    {
        get { return length; }
        set { length = value; }
    }

    private double Width
    {
        get { return width; }
        set { width = value; }
    }

    private double Height
    {
        get { return height; }
         set { height = value; }
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