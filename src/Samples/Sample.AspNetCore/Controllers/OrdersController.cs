using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.AspNetCore.Data;
using Sample.AspNetCore.Models;
using Sample.AspNetCore.Models.ViewModels;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentInstruments;

namespace Sample.AspNetCore.Controllers;

public class OrdersController : Controller
{
    private readonly StoreDbContext context;
    private readonly ISwedbankPayClient swedbankPayClient;
   
    public OrdersController(StoreDbContext storeDbContext,
                            ISwedbankPayClient payClient)
    {
        this.context = storeDbContext;
        this.swedbankPayClient = payClient;
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ClearSingle(string paymentId)
    {
        var orders = await this.context.Orders.ToListAsync();

        var order = orders.FirstOrDefault(x => x.PaymentLink?.OriginalString == paymentId || x.PaymentOrderLink?.OriginalString == paymentId);

        if (order != null)
        {
            this.context.Orders.Remove(order);
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
    public async Task<IActionResult> Details(int? _)
    {
        var orders = await this.context.Orders.ToListAsync();
        if (orders == null || !orders.Any())
        {
            return NotFound();
        }

        
        var completedPayments = new List<OrderViewModel>();

        foreach (var order in orders)
        {
            List<HttpOperation> operations = new List<HttpOperation>();
            if (order.PaymentOrderLink != null)
            {
                var paymentOrder = await this.swedbankPayClient.PaymentOrders.Get(order.PaymentOrderLink);
                var paymentOrderOperations = paymentOrder.Operations.Where(r => r.Key.Value.Contains("paymentorder")).Select(x => x.Value);
                operations = paymentOrderOperations.ToList();
            }
            else
            {
                switch (order.Instrument)
                {
                    case PaymentInstrument.Swish:
                        var swishPayment = await this.swedbankPayClient.Payments.SwishPayments.Get(order.PaymentLink, PaymentExpand.All);
                        var swishOperations = swishPayment.Operations;
                        operations = swishOperations.Values.ToList();
                        break;
                    case PaymentInstrument.CreditCard:
                        var cardPayment = await this.swedbankPayClient.Payments.CardPayments.Get(order.PaymentLink, PaymentExpand.All);
                        var cardOperations = cardPayment.Operations;
                        operations = cardOperations.Values.ToList();

                        if (!string.IsNullOrWhiteSpace(cardPayment.Payment.RecurrenceToken)
                            && cardPayment.Payment.Operation.Equals(Operation.Verify))
                        {
                            operations.Add(new HttpOperation(new Uri("https://localhost:5001"), new LinkRelation("create-recurring", "create-recurring"), "GET", "text/html"));
                        }

                        break;
                    case PaymentInstrument.Trustly:
                        var trustlyPayment = await this.swedbankPayClient.Payments.TrustlyPayments.Get(order.PaymentLink, PaymentExpand.All);
                        var trustlyOperations = trustlyPayment.Operations;
                        operations = trustlyOperations.Values.ToList();
                        break;
                }
            }
            completedPayments.Add(new OrderViewModel
            {
                Order = order,
                OperationList = operations.ToList()
            });
        }
       

        return View(completedPayments);
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