namespace IRunes.App.Common
{
    public static class Constants
    {
	public const string AlbumCoverArtTooltip = "{0} (Cover Art)";
	public const decimal AlbumPriceDiscountMultiplier = 0.87M;
	public const string AlbumsViewRoute = "/Albums/All";
	public const string DefaultAlbumCoverArt = "/No_Cover_Available.jpg";
	public const string DefaultUsername = "Guest";
	public const string EntityExistsError = "{0} '{1}' already exists!";
	public const string EntityPropertyMissingError = "{0} {1} is missing!";
	public const string ErrorKey = "Error";
	public const string HomeViewRoute = "/Home/Index";
	public const string InvalidCredentialsError = "Invalid credentials!";
	public const string LoginViewRoute = "/Users/Login";
	public const string MusicGenresListOption = "<option value='{0}'>{0}</option>\r\n";
	public const string ResourceNotAvailableMessage = "Not Available ;(";
	public const string TrackDetailsViewRoute = "/Tracks/Details?AlbumId={0}&TrackId={1}";
	public const string UsernameKey = "Username";
	public const string UsernameTakenError = "Username '{0}' is already taken!";
    }
}
