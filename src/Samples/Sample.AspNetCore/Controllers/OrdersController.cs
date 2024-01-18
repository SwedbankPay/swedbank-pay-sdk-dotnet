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
using SwedbankPay.Sdk.PaymentOrder;

namespace Sample.AspNetCore.Controllers;

public class OrdersController : Controller
{
    private readonly StoreDbContext _storeDbContext;
    private readonly ISwedbankPayClient _swedbankPayClient;

    public OrdersController(StoreDbContext storeDbStoreDbContext,
        ISwedbankPayClient swedbankPayClient)
    {
        _storeDbContext = storeDbStoreDbContext;
        _swedbankPayClient = swedbankPayClient;
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Clear()
    {
        var orders = await _storeDbContext.Orders.ToListAsync();
        if (orders != null)
        {
            _storeDbContext.Orders.RemoveRange(orders);
            await _storeDbContext.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ClearSingle(string paymentId)
    {
        var orders = await _storeDbContext.Orders.ToListAsync();

        var order = orders.FirstOrDefault(x => x.PaymentLink?.OriginalString == paymentId || x.PaymentOrderLink?.OriginalString == paymentId);

        if (order != null)
        {
            _storeDbContext.Orders.Remove(order);
            await _storeDbContext.SaveChangesAsync();
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
            _storeDbContext.Add(order);
            await _storeDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(order);
    }


    // GET: Orders/Details/5
    public async Task<IActionResult> Details(int? _)
    {
        var orders = await _storeDbContext.Orders.ToListAsync();
        if (orders == null || !orders.Any())
        {
            return NotFound();
        }


        var completedPayments = new List<OrderViewModel>();

        foreach (var order in orders)
        {
            List<HttpOperation> operations = new List<HttpOperation>();
            string recurringToken = null;
            if (order.PaymentOrderLink != null)
            {
                var paymentOrder = await _swedbankPayClient.PaymentOrders.Get(order.PaymentOrderLink, PaymentOrderExpand.All);
                var paymentOrderOperations = paymentOrder?.Operations.Select(x => x.Value);
                operations = paymentOrderOperations?.ToList();

                var recurringTokenItem = paymentOrder?.PaymentOrder.Paid?.Tokens?.FirstOrDefault(x => x.Type == "recur");
                if (recurringTokenItem != null)
                {
                    var uri = new Uri("https://api.externalintegration.payex.com" + paymentOrder.PaymentOrder.Id);
                    operations.Add(new HttpOperation(uri, new LinkRelation("recur", "recur"), "POST", "text/html"));
                    recurringToken = recurringTokenItem.Token;
                }
                
                var unscheduledTokenItem = paymentOrder?.PaymentOrder.Paid?.Tokens?.FirstOrDefault(x => x.Type == "unscheduled");
                if (unscheduledTokenItem != null)
                {
                    var uri = new Uri("https://api.externalintegration.payex.com" + paymentOrder.PaymentOrder.Id);
                    operations.Add(new HttpOperation(uri, new LinkRelation("unscheduled", "unscheduled"), "POST", "text/html"));
                    recurringToken = unscheduledTokenItem.Token;
                }
            }

            completedPayments.Add(new OrderViewModel
            {
                Order = order,
                RecurringToken = recurringToken,
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

        var order = await _storeDbContext.Orders.FindAsync(id);
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
                _storeDbContext.Update(order);
                await _storeDbContext.SaveChangesAsync();
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
        return _storeDbContext.Orders.Any(e => e.OrderId == id);
    }
}