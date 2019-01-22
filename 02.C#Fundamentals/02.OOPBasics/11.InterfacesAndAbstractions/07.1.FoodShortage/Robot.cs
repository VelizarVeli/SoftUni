public class Robot : INational
{
    private string model;
    public string Id { get; set; }
    
    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

}