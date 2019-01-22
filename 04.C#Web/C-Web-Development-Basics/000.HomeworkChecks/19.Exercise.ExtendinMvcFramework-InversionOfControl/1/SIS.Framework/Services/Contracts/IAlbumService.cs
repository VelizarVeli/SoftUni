namespace SIS.Framework.Services.Contracts
{
    using Models;
    using System.Collections.Generic;

    public interface IAlbumService
    {
        void CreateAndSaveAlbum(string name, string cover);

        Album ById(string id);

        IEnumerable<Album> AllAlbums();
    }
}