namespace Sample.AspNetCore.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Sample.AspNetCore.Models;
    using Sample.AspNetCore.Extensions;
    using SwedbankPay.Sdk;
    using SwedbankPay.Sdk.Consumers;
    using SwedbankPay.Sdk.PaymentOrders;

    public class CheckOutController : Controller
    {
        private readonly PayeeInfoConfig payeeInfoOptions;
        private readonly Cart cartService;
        private readonly SwedbankPayClient swedbankPayClient;

        public CheckOutController(IOptionsSnapshot<PayeeInfoConfig> payeeInfoOptionsAccessor,
            Cart cartService, SwedbankPayClient swedbankPayClient)
        {
            this.payeeInfoOptions = payeeInfoOptionsAccessor.Value;
            this.cartService = cartService;
            this.swedbankPayClient = swedbankPayClient;
        }
        
        public async Task<PaymentOrder> CreatePaymentOrder(string consumerProfileRef = null)
        {
            var totalAmount = this.cartService.CalculateTotal();
            Payer payer = null;

            if (!string.IsNullOrWhiteSpace(consumerProfileRef))
            {
                payer = new Payer
                {
                    ConsumerProfileRef = consumerProfileRef
                };
            }

            var orderItems = this.cartService.CartLines.ToOrderItems();
            var paymentOrderItems = orderItems.ToList();
            var paymentOrderRequest = new PaymentOrderRequest(Operation.Purchase, new CurrencyCode("SEK"), Amount.FromDecimal(totalAmount),
                                                               Amount.FromDecimal(0), "Test description", "useragent", new Language("sv-SE"), false, new Urls(),
                                                              new PayeeInfo(this.payeeInfoOptions.PayeeId, this.payeeInfoOptions.PayeeReference), payer, paymentOrderItems);
            var paymentOrder = await this.swedbankPayClient.PaymentOrder.Create(paymentOrderRequest);
            
            this.cartService.PaymentOrderLink = paymentOrder.PaymentOrderResponse.Id;
            this.cartService.Update();

            return paymentOrder;
        }

        [HttpPost]
        public async Task<JsonResult> GetViewPaymentOrderHref(string consumerProfileRef = null)
        {
            var paymentOrder = await CreatePaymentOrder(consumerProfileRef);

            return Json (paymentOrder.Operations.View.Href);
        }

        public async Task<IActionResult> LoadPaymentMenu()
        {
            var response = await CreatePaymentOrder();
            
            var jsSource = response.Operations.View.Href;

            var swedBankPaySource = new SwedbankPayCheckoutSource
            {
                JavascriptSource = jsSource,
                Culture = "sv-SE",
                UseAnonymousCheckout = true,
                AbortOperationLink = response.Operations[LinkRelation.UpdateAbort].Href
            };

            return View("Checkout", swedBankPaySource);
        }

        public async Task<IActionResult> InitiateConsumerSession()
        {
            var initiateConsumerRequest = new ConsumersRequest(CountryCode.SE, Operation.Initiate);
            var response = await this.swedbankPayClient.Consumers.InitiateSession(initiateConsumerRequest);
            var jsSource = response.Operations.ViewConsumerIdentification?.Href;
            
            var swedBankPaySource = new SwedbankPayCheckoutSource
            {
                JavascriptSource = jsSource,
                Culture = "sv-SE",
                UseAnonymousCheckout = false
            };
            return View("Checkout", swedBankPaySource);
        }

        public ViewResult Thankyou()
        {
            this.cartService.Clear();
            return View();
        }



    }
}