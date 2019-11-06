using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.AspNetCore3.Constants;
using Sample.AspNetCore3.Extensions;
using Sample.AspNetCore3.Models;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentOrders;

namespace Sample.AspNetCore3.Controllers
{
    public class PaymentController : Controller
    {
        private readonly SwedbankPayOptions _swedbankPayOptions;

        public const string CartSessionKey = "_Cart";

        public PaymentController(IOptionsMonitor<SwedbankPayOptions> optionsAccessor)
        {
            _swedbankPayOptions = optionsAccessor.CurrentValue;
        }


        // GET: Payment
        public async Task<ActionResult> Index(Cart cart)
        {

            
            
            return View();
        }

        // GET: Payment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Payment/Create
        public ActionResult Create(Cart cart)
        {
            

            //var swedbankPayClient.PaymentOrders.CreatePaymentOrder();
            return View();
        }

        // POST: Payment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Payment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Abort(string LinkId)
        {
            try
            {
                var swedbankPayClient = new SwedbankPayClient(_swedbankPayOptions);

                var response = await swedbankPayClient.PaymentOrders.AbortPaymentOrder(LinkId);
                TempData["AbortMessage"] = $"Payment Order: {response.PaymentOrder.Id} has been {response.PaymentOrder.State}";

                return RedirectToAction(nameof(Index), "Products");
            }
            catch(Exception e)
            {
                return View();
            }
            
        }

        


    }
}