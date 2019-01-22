using Eventures.Data;
using Eventures.Mapping;
using Eventures.Services.Contracts;
using Eventures.ServicesViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventures.Services
{
    public class AdminUserService : IAdminService
    {
        private readonly EventuresDbContext _dbContext;

        public AdminUserService(EventuresDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<AdminUsersCollectionViewModel>> AllAsync()
           =>
            await this._dbContext
                .Users
                .To<AdminUsersCollectionViewModel>()
                .ToListAsync();
        
    }
}
