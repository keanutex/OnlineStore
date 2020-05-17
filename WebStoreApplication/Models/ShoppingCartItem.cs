using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApplication.Models
{
    public class ShoppingCartItem
    {
        public string ShoppingCartID { get; set; }
        public int ShoppingCartItemID { get; set; }
        public ProductModel Product {get; set;}
        public int Amount { get; set; }

    }
}
