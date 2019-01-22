namespace SIS.Framework.Services
{
    using Contracts;
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;

    public class AlbumService : IAlbumService
    {
        private readonly RunesDbContext dB;

        public AlbumService(RunesDbContext dB)
        {
            this.dB = dB;
        }

        public void CreateAndSaveAlbum(string name, string cover)
        {
            var album = new Album()
            {
                Name = name,
                Cover = cover
            };

            try
            {
                this.dB.Albums.Add(album);
                this.dB.SaveChanges();
            }
            catch (Exception exception)
            {
                // TODO: server exception
                return;
            }
        }

        public Album ById(string id)
        {
            return this.dB.Albums.Find(id);
        }

        public IEnumerable<Album> AllAlbums()
        {
            return this.dB.Albums;
        }
    }
}