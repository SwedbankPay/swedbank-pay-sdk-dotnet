namespace Sample.AspNetCore3.Components
{
    using Microsoft.AspNetCore.Mvc;
    using Sample.AspNetCore3.Models;

    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}