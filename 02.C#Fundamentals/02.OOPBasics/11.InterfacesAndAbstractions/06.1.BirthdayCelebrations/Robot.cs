public class Robot : INational
{
    private string model;
    
    public Robot(string model, string id)
    {
        this.Model = model;
        this.id = id;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string id { get; set; }
}