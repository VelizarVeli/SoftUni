using Microsoft.AspNetCore.Identity;
using Panda.Data;
using Panda.Model;

namespace Panda.Services
{
  public  abstract class BaseService
  {
      protected PandaDbContext Db { get; }
      protected UserManager<PandaUser> UserManager { get; }

        protected BaseService(PandaDbContext db, UserManager<PandaUser> userManager)
        {
            Db = db;
            UserManager = userManager;
        }
    }
}