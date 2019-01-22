namespace EventuresWebApp.Web.ViewModels.Accounts
{
    using System.Collections.Generic;

    public class AdministrationViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
