namespace SIS.Framework.Services
{
    using Contracts;
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TrackService : ITrackService
    {
        private readonly RunesDbContext dB;

        public TrackService(RunesDbContext dB)
        {
            this.dB = dB;
        }

        public void CreateAndSaveTrack(string name, string link, decimal price, string albumId)
        {
            var track = new Track()
            {
                Name = name,
                Link = link,
                Price = price
            };

            var trackAlbum = new TrackAlbum();
            trackAlbum.AlbumId = albumId;
            track.Albums.Add(trackAlbum);

            try
            {
                this.dB.Tracks.Add(track);
                this.dB.SaveChanges();
            }
            catch (Exception exception)
            {
                // TODO: server exception
                return;
            }
        }

        public Track ById(string id)
        {
            return this.dB.Tracks.Find(id);
        }

        public IEnumerable<Track> AllTracks(string albumId)
        {
            return this.dB.Albums.FirstOrDefault(a => a.Id == albumId).Tracks.Select(at => at.Track);
        }
    }
}