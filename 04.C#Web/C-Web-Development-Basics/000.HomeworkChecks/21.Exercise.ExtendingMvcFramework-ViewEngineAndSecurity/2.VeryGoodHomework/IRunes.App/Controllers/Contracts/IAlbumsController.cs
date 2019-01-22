using IRunes.App.ViewModels;
using SIS.Framework.ActionResults.Contracts;

namespace IRunes.App.Controllers.Contracts
{
    public interface IAlbumsController
    {
	IActionResult All(AlbumsViewModel model);
	IActionResult Details(AlbumDetailsViewModel model);
	IActionResult Create(AlbumCreateGetViewModel model);
	IActionResult Create(AlbumCreatePostViewModel model);
    }
}
