using WebStoreApplication.Models;

namespace WebStoreApplication.Controllers
{
    internal class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}