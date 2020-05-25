using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApplication.Models;

namespace WebStoreApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int productID)
        {
            var selectedProduct = _productRepository.GetAllProducts.FirstOrDefault(c => c.ProductID == productID);

            if(selectedProduct != null)
            {
                _shoppingCart.AddToShoppingCart(selectedProduct, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productID)
        {
            var selectedProduct = _productRepository.GetAllProducts.FirstOrDefault(c => c.ProductID == productID);

            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromShoppingCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }
    }
}
