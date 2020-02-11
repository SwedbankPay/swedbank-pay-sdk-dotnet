using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.AspNetCore.Data;
using Sample.AspNetCore.Models;
using Sample.AspNetCore.Models.ViewModels;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments;

namespace Sample.AspNetCore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly StoreDbContext context;
        private readonly SwedbankPayClient swedbankPayClient;
       
        public OrdersController(StoreDbContext context,
                                SwedbankPayClient swedbankPayClient)
        {
            this.context = context;
            this.swedbankPayClient = swedbankPayClient;
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


        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var order = await this.context.Orders
                .FirstOrDefaultAsync();
            if (order == null)
                return NotFound();

            OperationList operations = null;

            if (!string.IsNullOrWhiteSpace(order.PaymentOrderLink))
            {
                var paymentOrder = await this.swedbankPayClient.PaymentOrders.Get(new Uri(order.PaymentOrderLink, UriKind.RelativeOrAbsolute));
                var paymentOrderOperations = paymentOrder.Operations.Where(r => r.Key.Value.Contains("paymentorder")).Select(x => x.Value);
                operations = new OperationList(paymentOrderOperations);
            }
            else
            {
                switch (order.Instrument)
                {
                    case Instrument.Swish:
                        var swishPayment = await this.swedbankPayClient.Payments.SwishPayments.Get(order.PaymentLink, PaymentExpand.All);
                        var swishOperations = swishPayment.Operations;
                        operations = new OperationList(swishOperations.Values);
                        break;
                    case Instrument.CreditCard:
                        var cardPayment = await this.swedbankPayClient.Payments.SwishPayments.Get(order.PaymentLink, PaymentExpand.All);
                        var cardOperations = cardPayment.Operations;
                        operations = new OperationList(cardOperations.Values);
                        break;
                }
            }

            return View(new OrderViewModel
            {
                Order = order,
                OperationList = operations
            });
        }


        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var order = await this.context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();
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
                return NotFound();

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
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }


        // GET: Orders
        public IActionResult Index()
        {
            return View();
        }


        private bool OrderExists(int id)
        {
            return this.context.Orders.Any(e => e.OrderId == id);
        }
    }
}