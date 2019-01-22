namespace WebServer.IRunesApplication.Services.Contracts
{
    using ViewModels.Product;

    public interface ITrackService
    {
        void Create(string name, string link, decimal price, int albumId);

        TrackDetailViewModel Find(int trackId, int albumId);
    }
}