using eTutorials.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Data.ViewComponents
{
    public class ShoppingCartSumBar : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSumBar(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
