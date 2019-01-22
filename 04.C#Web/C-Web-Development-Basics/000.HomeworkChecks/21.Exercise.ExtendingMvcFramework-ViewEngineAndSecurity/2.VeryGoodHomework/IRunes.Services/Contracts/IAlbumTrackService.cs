using System;

namespace IRunes.Services.Contracts
{
    public interface IAlbumTrackService
    {
	void AddAlbumTrack(Guid albumId, Guid trackId);
    }
}
