using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.AspNetCore3.Data;
using Sample.AspNetCore3.Models;
using Sample.AspNetCore3.Models.ViewModels;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Transactions;

namespace Sample.AspNetCore3.Controllers
{
    public class PaymentController : Controller
    {
        private readonly SwedbankPayOptions _swedbankPayOptions;
        private Cart _cartService;
        private readonly StoreDBContext _context;

        public PaymentController(IOptionsMonitor<SwedbankPayOptions> optionsAccessor, Cart cartService, StoreDBContext context)
        {
            _swedbankPayOptions = optionsAccessor.CurrentValue;
            _cartService = cartService;
            _context = context;
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

        
        [HttpGet]
        
        public async Task<ActionResult> CancelPayment(string paymentOrderId)
        {
            try
            {
                var swedbankPayClient = new SwedbankPayClient(_swedbankPayOptions);
                var transactionRequestObject = new TransactionRequestContainer(new TransactionRequest
                {
                    PayeeReference = DateTime.Now.Ticks.ToString(),
                    Description = "Cancelling parts of the total amount"

                });
                var response = await swedbankPayClient.PaymentOrders.CancelPaymentOrder(paymentOrderId, transactionRequestObject);
                
                TempData["CancelMessage"] = $"Payment has been cancelled: {response.Id}";
                _cartService.PaymentOrderLink = null;
                
                return RedirectToAction(nameof(Details), "Orders");
            }
            catch (Exception e)  
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction(nameof(Details), "Orders");
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AbortPaymentOrder(string LinkId)
        {
            try
            {
                var swedbankPayClient = new SwedbankPayClient(_swedbankPayOptions);
                
                var response = await swedbankPayClient.PaymentOrders.AbortPaymentOrder(LinkId);
                
                TempData["AbortMessage"] = $"Payment Order: {response.PaymentOrder.Id} has been {response.PaymentOrder.State}";
                _cartService.PaymentOrderLink = null;

                return RedirectToAction(nameof(Index), "Products");
            }
            catch(Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction(nameof(Index), "Orders");
            }
            
        }

        public async Task<IActionResult> GetPaymentOrder(string LinkId)
        {
            try
            {
                var swedbankPayClient = new SwedbankPayClient(_swedbankPayOptions);

                var response = await swedbankPayClient.PaymentOrders.AbortPaymentOrder(LinkId);

                TempData["AbortMessage"] = $"Payment Order: {response.PaymentOrder.Id} has been {response.PaymentOrder.State}";
                _cartService.PaymentOrderLink = null;

                return RedirectToAction(nameof(Index), "Products");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction(nameof(Index), "Orders");
            }

        }

        public async Task<IActionResult> CapturePayment()
        {
            try
            {
                var swedbankPayClient = new SwedbankPayClient(_swedbankPayOptions);

                var transActionRequestObject = new TransactionRequestContainer(new TransactionRequest
                {

                });

                //var response = await swedbankPayClient.PaymentOrders.Capture();

                //TempData["AbortMessage"] = $"Payment Order: {response.PaymentOrder.Id} has been {response.PaymentOrder.State}";
                //_cartService.PaymentOrderLink = null;

                return RedirectToAction(nameof(Index), "Products");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"Something unexpected happened. {e.Message}";
                return RedirectToAction(nameof(Index), "Orders");
            }
        }


        [HttpPost]
        public void OnCompleted(string id)
        {
            
            _context.Orders.Add(new Order
            {
                PaymentOrderLink = _cartService.PaymentOrderLink,
                PaymentLink = id 

            });
            _context.SaveChanges();
        }
        




    }
}