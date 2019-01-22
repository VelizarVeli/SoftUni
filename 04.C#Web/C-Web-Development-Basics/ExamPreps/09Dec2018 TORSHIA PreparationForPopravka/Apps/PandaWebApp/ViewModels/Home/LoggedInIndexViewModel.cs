using System.Collections.Generic;
using TorshiaWebApp.ViewModels.Tasks;

namespace TorshiaWebApp.ViewModels.Home
{
   public class LoggedInIndexViewModel
    {
        public ICollection<BaseTaskViewModel> Tasks { get; set; }
    }
}
