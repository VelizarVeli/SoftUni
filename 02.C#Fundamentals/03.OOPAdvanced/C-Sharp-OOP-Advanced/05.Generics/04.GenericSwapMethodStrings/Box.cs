public class Box<T>
{
    private T item;

    public Box(T item)
    {
        this.item = item;
    }

    public override string ToString()
    {
        var output = $"{this.item.GetType().FullName}: {this.item}";
        return output;
    }
}