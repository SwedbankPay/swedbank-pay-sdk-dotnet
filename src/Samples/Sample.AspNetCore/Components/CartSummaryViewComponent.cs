using Microsoft.AspNetCore.Mvc;

using Sample.AspNetCore.Models;

namespace Sample.AspNetCore.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly Cart _cart;


    public CartSummaryViewComponent(Cart cartService)
    {
        _cart = cartService;
    }


    public IViewComponentResult Invoke()
    {
        return View(_cart);
    }
}