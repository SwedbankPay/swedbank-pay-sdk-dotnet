using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sample.AspNetCore3.Data;
using Sample.AspNetCore3.Models;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentOrders;

namespace Sample.AspNetCore3.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private ProductDBContext _productsContext;
        private Cart _cart;

        public CartController(ILogger<CartController> logger, ProductDBContext productsContext, Cart cart)
        {
            _logger = logger;
            _productsContext = productsContext;
            _cart = cart;
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            
            var productList = await _productsContext.Products.ToListAsync();
            var product = productList.FirstOrDefault(p => p.Id == id);
            _cart.AddItem(product, 1);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            
            var line = _cart.CartLines.FirstOrDefault(i => i.Product.Id == id);
            if (line != null)
            {
                _cart.RemoveItem(line.Product, line.Quantity);
            }
           
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangeQuantity(int id)
        {

            var line = _cart.CartLines.FirstOrDefault(i => i.Product.Id == id);
            if (line != null)
            {
                _cart.RemoveItem(line.Product, line.Quantity);
            }

            return RedirectToAction("Index");
        }




        public IActionResult Index()
        {
            return View(_cart);
        }

        [HttpPost]
        public IActionResult Create(Cart cart)
        {

            if (ModelState.IsValid)
            {
                //cart.Product = _context.Products.First();

                return RedirectToAction("Index", "Payment", cart);
            }

            return View(cart);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       

    }
}
