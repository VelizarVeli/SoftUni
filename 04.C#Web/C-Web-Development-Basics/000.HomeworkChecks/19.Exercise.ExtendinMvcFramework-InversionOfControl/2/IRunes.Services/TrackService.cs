using IRunes.Data;
using IRunes.Models.Models;
using IRunes.Models.ViewModels.Tracks;
using IRunes.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.Services
{
    public class TrackService : ITrackService
    {
        public void CreateTrack(TrackViewModel model, decimal price)
        {
            var track = new Track { AlbumId = Guid.Parse(model.AlbumId), Name = model.Name, Link = model.Link, Price = price };
            using (var db = new IRunesDbContext())
            {
                db.Tracks.Add(track);
                db.SaveChanges();
            }
        }

        public TrackViewModel GetTrackById(string trackId)
        {
            using (var db = new IRunesDbContext())
            {
                var track = db.Tracks.FirstOrDefault(t => t.Id.ToString() == trackId);
                var trackModel = new TrackViewModel { AlbumId = track.AlbumId.ToString(), Link = track.Link, Name = track.Name, Price = track.Price.ToString("F2") };

                return trackModel;
            }
        }
    }
}
