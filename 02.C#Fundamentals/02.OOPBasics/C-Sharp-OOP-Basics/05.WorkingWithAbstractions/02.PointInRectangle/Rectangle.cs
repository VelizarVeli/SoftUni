class Rectangle
{
    public Point TopLeft { get; set; }

    public Point BottomRight { get; set; }

    public Rectangle(int topX, int topY, int bottomX, int bottomY)
    {
        TopLeft = new Point(topX, topY);
        BottomRight = new Point(bottomX, bottomY);
    }

    public bool Contains(Point point)
    {
        var contains = point.X >= TopLeft.X && point.X <= BottomRight.X && point.Y >= TopLeft.Y && point.Y <= BottomRight.Y;
        return contains;
    }
}