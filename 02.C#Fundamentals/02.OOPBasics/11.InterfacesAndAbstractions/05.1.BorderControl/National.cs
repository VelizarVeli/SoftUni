public abstract class National
{
    private string id;

    public National(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }
}