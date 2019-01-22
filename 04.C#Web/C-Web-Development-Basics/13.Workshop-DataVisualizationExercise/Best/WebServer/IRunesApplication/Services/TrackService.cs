namespace WebServer.IRunesApplication.Services
{
    using Data;
    using Data.Models;
    using System.Linq;
    using Services.Contracts;
    using ViewModels.Product;

    public class TrackService : ITrackService
    {
        public void Create(string name, string link, decimal price, int albumId)
        {
            using (var db = new IRunesDbContext())
            {
                var album = db.Albums.Where(a => a.Id == albumId).FirstOrDefault();

                var track = new Track()
                {
                    Name = name,
                    VideoUrl = link,
                    Price = price,                  
                };

                album.Tracks.Add(track);
                db.SaveChanges();              
            }
        }

        public TrackDetailViewModel Find(int trackId, int albumId)
        {
            using (var db = new IRunesDbContext())
            {
                var model = db.Tracks
                    .Where(t => t.Id == trackId && t.AlbumId == albumId)
                    .Select(t => new TrackDetailViewModel()
                    {
                        Id = trackId,
                        AlbumId = albumId,
                        Name = t.Name,
                        videoLink = t.VideoUrl,
                        Price = t.Price
                    })
                    .FirstOrDefault();

                return model;
            }
        }
    }
}
