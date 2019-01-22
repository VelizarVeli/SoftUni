public class Robot : National
{
    private string model;

    public Robot(string model, string id)
        :base(id)
    {
        this.Model = model;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
}