using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Sample.AspNetCore.Data;
using Sample.AspNetCore.Models;

namespace Sample.AspNetCore.Controllers;

public class ProductsController : Controller
{
    private readonly StoreDbContext _storeDbContext;


    public ProductsController(StoreDbContext storeDbStoreDbContext)
    {
        _storeDbContext = storeDbStoreDbContext;
    }


    // GET: Products/Create
    public IActionResult Create()
    {
        return View();
    }


    // POST: Products/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Reference,ImageUrl,ItemUrl,Type,Class,Price")]
        Product product)
    {
        if (ModelState.IsValid)
        {
            _storeDbContext.Add(product);
            await _storeDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }


    // POST: Products/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _storeDbContext.Products.FindAsync(id);
        _storeDbContext.Products.Remove(product);
        await _storeDbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


    // GET: Products/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _storeDbContext.Products.FirstOrDefaultAsync(m => m.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }


    // GET: Products/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _storeDbContext.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }


    // POST: Products/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("Id,Name,Reference,ImageUrl,ItemUrl,Type,Class,Price")]
        Product product)
    {
        if (id != product.ProductId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _storeDbContext.Update(product);
                await _storeDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductId))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }


    // GET: Products
    public async Task<IActionResult> Index()
    {
        return View(await _storeDbContext.Products.ToListAsync());
    }


    private bool ProductExists(int id)
    {
        return _storeDbContext.Products.Any(e => e.ProductId == id);
    }
}