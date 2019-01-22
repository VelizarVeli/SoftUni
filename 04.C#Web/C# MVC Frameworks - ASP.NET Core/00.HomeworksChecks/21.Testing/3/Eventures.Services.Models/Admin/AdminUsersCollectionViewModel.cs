using Eventures.Mapping;
using Eventures.Models;
using System;

namespace Eventures.ServicesViewModels
{
    public class AdminUsersCollectionViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
