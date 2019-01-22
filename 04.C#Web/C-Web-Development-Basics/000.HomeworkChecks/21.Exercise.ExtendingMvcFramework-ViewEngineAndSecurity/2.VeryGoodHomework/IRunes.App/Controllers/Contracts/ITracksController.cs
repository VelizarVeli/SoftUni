using IRunes.App.ViewModels;
using SIS.Framework.ActionResults.Contracts;

namespace IRunes.App.Controllers.Contracts
{
    public interface ITracksController
    {
	IActionResult Create(TrackCreateGetViewModel model);
	IActionResult Create(TrackCreatePostViewModel model);
	IActionResult Details(TrackDetailsViewModel model);
    }
}
