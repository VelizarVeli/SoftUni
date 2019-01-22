using Eventures.ServicesViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.Areas.Administration.Models
{
    public class UserViewModel
    {
        public IEnumerable<SelectListItem> Roles { get; set; }

        public IEnumerable<AdminUsersCollectionViewModel> Users { get; set; }
    }
}
