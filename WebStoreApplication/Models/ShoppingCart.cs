using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApplication.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        public string ShoppingCartID { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {   
            // Accesses active session or returns null if there is no active session
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartID = session.GetString("CartID") ?? Guid.NewGuid().ToString();
            session.SetString("CartID", cartID);

            return new ShoppingCart(context) { ShoppingCartID = cartID };
        }

        public void AddToShoppingCart(ProductModel product, int noOfProducts)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
                sc => sc.ProductModel.productID == product.productID
                && sc.ShoppingCartID == ShoppingCartID);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartID = ShoppingCartID,
                    Product = product,
                    NoOfProducts = noOfProducts
                };

                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.NoOfProducts++;
            }
            _appDbContext.SaveChanges();
        }
        public int RemoveFromShoppingCart(ProductModel product)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
                sci => sci.ProductModel.productID == product.productID
                && sci.ShoppingCartID == ShoppingCartID);

            var currentNoOfProducts = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.NoOfProducts > 1)
                {
                    shoppingCartItem.NoOfProducts--;
                    currentNoOfProducts = shoppingCartItem.NoOfProducts;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _appDbContext.SaveChanges();
            return currentNoOfProducts;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return GetShoppingCartItems ?? (ShoppingCartItems = _appDbContext.ShoppingCartItems.Where(
               scID => scID.ShoppingCartID == ShoppingCartID).Include(s => s.Product).ToList());
        }
        public void ClearShoppingCart()
        {
            var shoppingCartItems = _appDbContext.Shopping_CartItems.Where(c => c.ShoppingCartID == ShoppingCartID);

            _appDbContext.Shopping_CartItems.RemoveRange(shoppingCartItems);
            _appDbContext.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            var totalPrice = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartID == ShoppingCartID).Select(c => c.Product.Price * c.NoOfProducts).Sum();
            return totalPrice;
        }
    }
}
