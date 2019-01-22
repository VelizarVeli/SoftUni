namespace EventWebApp.Common
{
    using System.Collections.Generic;

    public static class GlobalConstants
    {
        public const string AdministratorRoleName = "Admin";

        public static readonly List<string> RolesName = new List<string>
        {
            "Admin",
            "User"
        };
    }
}
