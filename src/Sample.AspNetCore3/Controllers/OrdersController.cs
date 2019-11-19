namespace Sample.AspNetCore3.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Sample.AspNetCore3.Data;
    using Sample.AspNetCore3.Models;
    using Sample.AspNetCore3.Models.ViewModels;
    using SwedbankPay.Sdk;
    using SwedbankPay.Sdk.Transactions;

    public class OrdersController : Controller
    {
        private readonly StoreDbContext context;
        private readonly SwedbankPayOptions swedbankPayOptions;

        public OrdersController(StoreDbContext context, IOptionsMonitor<SwedbankPayOptions> swedPayOptions)
        {
            this.context = context;
            this.swedbankPayOptions = swedPayOptions.CurrentValue;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await this.context.Orders.ToListAsync();
            return View();
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var order = await this.context.Orders
                .FirstOrDefaultAsync();
            if (order == null)
            {
                return NotFound();
            }

            var swedbankPayClient = new SwedbankPayClient(this.swedbankPayOptions);
           
            var response = await swedbankPayClient.PaymentOrders.GetPaymentOrder(order.PaymentOrderLink);

            return View(new OrderViewModel
            {
                Order = order,
                Operations = response.Operations.Where(r => r.Rel.Contains("paymentorder")).ToList()
            });
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PaymentOrderId")] Order order)
        {
            if (ModelState.IsValid)
            {
                this.context.Add(order);
                await this.context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await this.context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PaymentOrderId")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.context.Update(order);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Clear()
        {
            var orders = await this.context.Orders.ToListAsync();
            if (orders != null)
            {
                this.context.Orders.RemoveRange(orders);
                await this.context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }
        private bool OrderExists(int id)
        {
            return this.context.Orders.Any(e => e.OrderId == id);
        }
    }
}
