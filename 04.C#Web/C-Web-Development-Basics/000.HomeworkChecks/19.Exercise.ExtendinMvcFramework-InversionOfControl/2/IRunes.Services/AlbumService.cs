using IRunes.Data;
using IRunes.Models.Models;
using IRunes.Models.ViewModels.Albums;
using IRunes.Models.ViewModels.Tracks;
using IRunes.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.Services
{
    public class AlbumService : IAlbumService
    {
        public ICollection<AlbumViewModel> GetAllAlbums()
        {
            using (var db = new IRunesDbContext())
            {
                var albums = db.Albums.Include(a => a.Tracks).ToArray();
                var albumModels = new List<AlbumViewModel>();

                foreach (var album in albums)
                {
                    var albumModel = new AlbumViewModel { Id = album.Id.ToString(), Name = album.Name };
                    albumModels.Add(albumModel);
                }

                return albumModels;
            }
        }

        public void CreateAlbum(AlbumViewModel model)
        {
            var album = new Album { Name = model.Name, Cover = model.Cover };
            using (var db = new IRunesDbContext())
            {
                db.Albums.Add(album);
                db.SaveChanges();
            }
        }

        public AlbumViewModel GetAlbumById(string albumId)
        {
            using (var db = new IRunesDbContext())
            {
                var album = db.Albums.FirstOrDefault(a => a.Id.ToString() == albumId);
                var albumModel =
                    new AlbumViewModel { Id = album.Id.ToString(), Cover = album.Cover, Name = album.Name };

                return albumModel;
            }
        }

        public ICollection<TrackViewModel> GetAlbumTracks(string albumId)
        {
            using (var db = new IRunesDbContext())
            {
                var tracks = db.Tracks.Where(t => t.AlbumId.ToString() == albumId).ToArray();
                var trackModels = new List<TrackViewModel>();

                foreach (var track in tracks)
                {
                    var trackModel = new TrackViewModel { Id = track.Id.ToString(), Name = track.Name };
                    trackModels.Add(trackModel);
                }

                return trackModels;
            }
        }

        public bool AlbumExists(string albumId)
        {
            using (var db = new IRunesDbContext())
            {
                return db.Albums.Any(a => a.Id.ToString() == albumId);
            }
        }

        public decimal GetPrice(string albumId)
        {
            using (var db = new IRunesDbContext())
            {
                return db.Albums.FirstOrDefault(a => a.Id.ToString() == albumId).Tracks.Sum(t => t.Price) * 0.87M;
            }
        }
    }
}
