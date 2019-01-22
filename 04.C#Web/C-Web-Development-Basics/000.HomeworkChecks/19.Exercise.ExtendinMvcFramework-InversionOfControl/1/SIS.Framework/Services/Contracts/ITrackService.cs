namespace SIS.Framework.Services.Contracts
{
    using Models;
    using System.Collections.Generic;

    public interface ITrackService
    {
        void CreateAndSaveTrack(string name, string link, decimal price, string albumId);

        Track ById(string id);

        IEnumerable<Track> AllTracks(string albumId);
    }
}