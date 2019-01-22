using IRunes.Models.ViewModels.Tracks;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services.Contracts
{
    public interface ITrackService
    {
        void CreateTrack(TrackViewModel model, decimal price);

        TrackViewModel GetTrackById(string trackId);
    }
}
