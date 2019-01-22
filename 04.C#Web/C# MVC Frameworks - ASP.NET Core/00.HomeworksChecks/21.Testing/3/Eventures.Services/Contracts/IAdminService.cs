using Eventures.ServicesViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eventures.Services.Contracts
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminUsersCollectionViewModel>> AllAsync();
    }
}
