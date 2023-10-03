using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Sample.AspNetCore.Data;
using Sample.AspNetCore.Models;

namespace Sample.AspNetCore.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cartService;
        private readonly StoreDbContext _storesContext;


        public CartController(StoreDbContext storeDb, Cart cart)
        {
            _storesContext = storeDb;
            _cartService = cart;
        }


        public async Task<IActionResult> AddToCart(int id)
        {
            var productList = await _storesContext.Products.ToListAsync();
            var product = productList.FirstOrDefault(p => p.ProductId == id);
            _cartService.AddItem(product, 1);

            return RedirectToAction("Index", "Products");
        }


        [HttpPost]
        public IActionResult Create(Cart cart)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Payment", cart);
            }

            return View(cart);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult RemoveFromCart(int id)
        {
            var line = this._cartService.CartLines.FirstOrDefault(i => i.Product.ProductId == id);
            if (line != null)
            {
                this._cartService.RemoveItem(line.Product, line.Quantity);
            }

            return RedirectToAction("Index", "Products");
        }


        [HttpPost]
        public IActionResult UpdateQuantity(int id, int quantity)
        {
            var line = this._cartService.CartLines.FirstOrDefault(i => i.Product.ProductId == id);
            if (line != null)
            {
                line.Quantity = quantity;
                this._cartService.Update();
            }

            return RedirectToAction("Index", "Products");
        }
    }
}