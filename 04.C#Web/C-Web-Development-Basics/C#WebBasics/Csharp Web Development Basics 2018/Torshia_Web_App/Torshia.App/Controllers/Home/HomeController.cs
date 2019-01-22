namespace Torshia.App.Controllers.Home
{
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP.Responses;
    using System.Linq;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var user = this.DbContext.Users.FirstOrDefault(u => u.Username == this.User.Username);
            var tasks = this.DbContext.Tasks.Include(t => t.AffectedSectors).ToArray();
            return this.View(tasks);
        }
        
        public IHttpResponse RootIndex()
        {
            return this.Redirect("/Home/Index");
        }
    }
}