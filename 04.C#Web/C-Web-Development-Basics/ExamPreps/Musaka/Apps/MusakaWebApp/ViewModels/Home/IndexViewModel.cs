using System.Collections.Generic;

namespace MusakaWebApp.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public decimal Total { get; set; } = 0;
    }
}
