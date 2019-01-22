using IRunes.Models.ViewModels.Albums;
using IRunes.Models.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services.Contracts
{
    public interface IAlbumService
    {
        ICollection<AlbumViewModel> GetAllAlbums();

        void CreateAlbum(AlbumViewModel model);

        AlbumViewModel GetAlbumById(string albumId);

        ICollection<TrackViewModel> GetAlbumTracks(string albumId);

        bool AlbumExists(string albumId);

        decimal GetPrice(string albumId);
    }
}
