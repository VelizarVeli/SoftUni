namespace SIS.HTTP.Sessions.Contracts
{
    public interface IHttpSession
    {
        string Id { get; }

        void AddParameter(string name, object parameter);

        void ClearParameters();

        bool ContainsParameter(string name);

        object GetParameter(string name);
    }
}