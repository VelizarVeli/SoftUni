namespace IRunes.Models
{
    public abstract class BaseModel<TIdentifier>
    {
	public TIdentifier Id { get; set; }
    }
}
