namespace IRunesApp.Models
{
    public abstract class BaseModel<T>
    {
        public T Id { get; set; }
    }
}