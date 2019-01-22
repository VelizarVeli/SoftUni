using System.Collections.Generic;
using TORSHIAWebApp.ViewModels.Tasks;

namespace TORSHIAWebApp.ViewModels.Home
{
   public class LoggedInIndexViewModel
    {
        public ICollection<BaseTaskViewModel> Tasks { get; set; }
    }
}
