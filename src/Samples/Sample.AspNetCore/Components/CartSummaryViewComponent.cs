using Microsoft.AspNetCore.Mvc;

using Sample.AspNetCore.Models;

namespace Sample.AspNetCore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly Cart cart;


        public CartSummaryViewComponent(Cart cartService)
        {
            this.cart = cartService;
        }


        public IViewComponentResult Invoke()
        {
            return View(this.cart);
        }
    }
}