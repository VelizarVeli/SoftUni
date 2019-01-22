namespace WebServer.IRunesApplication.ViewModels
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        public const string SessionKey = "%^Current_Shopping_Cart^%";

        public List<int> ProductIds { get; set; } = new List<int>();
    }
}
