using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Sample.AspNetCore.Data;
using Sample.AspNetCore.Extensions;
using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Abort;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest.Update;
using SwedbankPay.Sdk.PaymentOrder.Payer;
using SwedbankPay.Sdk.PaymentOrder.RiskIndicator;
using SwedbankPay.Sdk.PaymentOrder.Urls;

namespace Sample.AspNetCore.Controllers;

public class CheckOutController : Controller
{
    private readonly Cart _cartService;
    private readonly ILogger<CheckOutController> _logger;
    private readonly StoreDbContext _context;
    private readonly PayeeInfoConfig _payeeInfoOptions;
    private readonly ISwedbankPayClient _swedbankPayClient;
    private readonly UrlsOptions _urls;


    public CheckOutController(IOptionsSnapshot<PayeeInfoConfig> payeeInfoOptionsAccessor,
        IOptionsSnapshot<UrlsOptions> urlsAccessor,
        Cart cart,
        ILogger<CheckOutController> logger,
        StoreDbContext storeDbContext,
        ISwedbankPayClient payClient)
    {
        _payeeInfoOptions = payeeInfoOptionsAccessor.Value;
        _urls = urlsAccessor.Value;
        _cartService = cart;
        _logger = logger;
        _context = storeDbContext;
        _swedbankPayClient = payClient;
    }

    public async Task Callback([FromBody]CallbackInfo callbackInfo)
    {
        _logger.LogInformation($"Callback received for id {callbackInfo.PaymentOrder.Id}", callbackInfo);
    }

    public async Task<IPaymentOrderResponse> CreateOrUpdatePaymentOrder(string consumerProfileRef = null, Uri paymentUrl = null)
    {
        Uri orderId = null;
        var paymentOrderLink = _cartService.PaymentOrderLink;
        if (!string.IsNullOrWhiteSpace(paymentOrderLink))
        {
            orderId = new Uri(paymentOrderLink, UriKind.Relative);
        }

        return orderId == null ? await CreatePaymentOrder(consumerProfileRef, paymentUrl) : await UpdatePaymentOrder(orderId, consumerProfileRef);
    }

    private async Task<IPaymentOrderResponse> UpdatePaymentOrder(Uri orderId, string consumerProfileRef, Uri paymentUrl = null)
    {
        var paymentOrder = await _swedbankPayClient.PaymentOrders.Get(orderId, PaymentOrderExpand.All);
        if (paymentOrder?.Operations.Update == null)
        {
            if (paymentOrder?.Operations.Abort != null)
            {
                await paymentOrder.Operations.Abort(new PaymentOrderAbortRequest("UpdateNotAvailable"));
                return await CreatePaymentOrder(consumerProfileRef, paymentUrl);
            }

            return paymentOrder;
        }

        var totalAmount = _cartService.CalculateTotal();
        var updateRequest = new PaymentOrderUpdateRequest(new Amount(totalAmount), new Amount(0));

        var orderItems = _cartService.CartLines.ToOrderItems();
        var paymentOrderItems = orderItems?.ToList();

        if (paymentOrderItems != null && paymentOrderItems.Any())
        {
            foreach (var orderItem in paymentOrderItems)
            {
                updateRequest.PaymentOrder.OrderItems.Add(orderItem);
            }

            var sameOrderItems = paymentOrderItems.Select(x => x.Reference)
                .All(paymentOrder.PaymentOrder.OrderItems.OrderItemList.Select(y => y.Reference).Contains);

            var amountChanged = totalAmount != paymentOrder.PaymentOrder.Amount;
            if (amountChanged || !sameOrderItems)
            {
                var paymentOrderStatus = paymentOrder.PaymentOrder.Status;
                if (!paymentOrderStatus.Equals(Status.Initialized))
                {
                    await paymentOrder.Operations.Abort(new PaymentOrderAbortRequest("UpdatedOrderItems"));
                    return await CreatePaymentOrder(consumerProfileRef, paymentUrl);
                }
                else
                {
                    await paymentOrder.Operations.Update(updateRequest);
                }
            }

            return paymentOrder;
        }

        return paymentOrder;
    }

    public async Task<IPaymentOrderResponse> CreatePaymentOrder(string consumerProfileRef = null, Uri paymentUrl = null)
    {
        var totalAmount = _cartService.CalculateTotal();

        var orderItems = _cartService.CartLines.ToOrderItems();
        var paymentOrderItems = orderItems?.ToList();
        try
        {
            
            
            
            var paymentOrderRequest = new PaymentOrderRequest(Operation.Purchase, new Currency("SEK"),
                new Amount(totalAmount),
                new Amount(0), "Test description", "useragent",
                new Language("sv-SE"),
                new Urls(_urls.HostUrls.ToList(), _urls.CompleteUrl, _urls.CancelUrl, _urls.CallbackUrl)
                {
                    PaymentUrl = paymentUrl ?? _urls.PaymentUrl,
                    LogoUrl = _urls.LogoUrl
                },
                new PayeeInfo(_payeeInfoOptions.PayeeId, _payeeInfoOptions.PayeeReference))
            {
                OrderItems = paymentOrderItems
            };

            paymentOrderRequest.Metadata = null;
        
            paymentOrderRequest.Payer = new Payer
            {
                FirstName = "Olivia",
                LastName = "Nyhuus",
                PayerReference = "AB1234",
                Email = new EmailAddress("olivia.nyhuus@payex.com"),
                Msisdn = new Msisdn("+46739000001"),
                WorkPhoneNumber = new Msisdn("+4787654321"),
                HomePhoneNumber = new Msisdn("+4776543210"),
                ShippingAddress = new Address
                {
                    StreetAddress = "Saltnestoppen 43",
                    CoAddress = "",
                    City = "Saltnes",
                    ZipCode = "1642",
                    CountryCode = new CountryCode("NO")
                },
                BillingAddress = new Address
                {
                    FirstName = "firstname/companyname",
                    LastName = "lastname",
                    Email = new EmailAddress("karl.anderssson@mail.se"),
                    StreetAddress = "Saltnestoppen 43",
                    CoAddress = "",
                    City = "Saltnes",
                    ZipCode = "1642",
                    CountryCode = new CountryCode("NO")
                },
                AccountInfo = new AccountInfo
                {
                    AccountAgeIndicator = AccountAgeIndicator.ThirtyToSixtyDays,
                    AccountChangeIndicator = AccountChangeIndicator.MoreThanSixtyDays,
                    AccountPwdChangeIndicator = AccountPwdChangeIndicator.NoChange,
                    ShippingAddressUsageIndicator = ShippingAddressUsageIndicator.ThisTransaction,
                    ShippingNameIndicator = ShippingNameIndicator.AccountNameIdenticalToShippingName,
                    SuspiciousAccountActivity = SuspiciousAccountActivity.NoSuspiciousActivityObserved
                }
            };
            
            paymentOrderRequest.RiskIndicator = new RiskIndicator
            {
                DeliveryEmailAddress = new EmailAddress("olivia.nyhuus@payex.com"),
                DeliveryTimeFrameIndicator = DeliveryTimeFrameIndicator.ElectronicDelivery,
                PreOrderDate = DateTime.Today,
                PreOrderPurchaseIndicator = PreOrderPurchaseIndicator.MerchandiseAvailable,
                ShipIndicator = ShipIndicator.ShipToCardholdersBillingAddress,
                GiftCardPurchase = false,
                ReOrderPurchaseIndicator = ReOrderPurchaseIndicator.MerchandiseAvailable,
                PickUpAddress = new Address
                {
                    Name = "Company Megashop Sarpsborg",
                    StreetAddress = "Hundskinnveien 92",
                    CoAddress = "",
                    City = "Sarpsborg",
                    ZipCode = "1711",
                    CountryCode = new CountryCode("NO")
                }
            };
            
            var paymentOrder = await _swedbankPayClient.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);
            
            _cartService.PaymentOrderLink = paymentOrder?.PaymentOrder.Id.OriginalString;
            _cartService.PaymentLink = null;
            _cartService.ConsumerProfileRef = consumerProfileRef;
            _cartService.Update();

            return paymentOrder;
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
            return null;
        }
    }

    [HttpPost]
    public async Task<JsonResult> GetViewPaymentOrderHref(string consumerProfileRef = null)
    {
        string paymentOrderLink = _cartService.PaymentOrderLink;
        if (!string.IsNullOrWhiteSpace(paymentOrderLink))
        {
            var uri = new Uri(paymentOrderLink, UriKind.Relative);
            var paymentOrderResponse = await _swedbankPayClient.PaymentOrders.Get(uri, PaymentOrderExpand.None);
            return Json(paymentOrderResponse.Operations.View.Href.OriginalString);
        }

        var paymentOrderResponseObject = await CreateOrUpdatePaymentOrder(consumerProfileRef, _urls.StandardCheckoutPaymentUrl);
        return Json(paymentOrderResponseObject.Operations.View.Href.OriginalString);
    }


    public async Task<IActionResult> LoadPaymentMenu()
    {
        var consumerProfileRef = _cartService.ConsumerProfileRef;
        var paymentOrder = await CreateOrUpdatePaymentOrder(consumerProfileRef, _urls.AnonymousCheckoutPaymentUrl);

        var jsSource = paymentOrder.Operations.View.Href;

        var swedbankPaySource = new SwedbankPayCheckoutSource
        {
            JavascriptSource = jsSource,
            Culture = CultureInfo.GetCultureInfo("sv-SE"),
            UseAnonymousCheckout = true,
            AbortOperationLink = paymentOrder.Operations[LinkRelation.UpdateAbort]?.Href,
            PaymentOrderLink = paymentOrder.PaymentOrder.Id
        };

        return View("Checkout", swedbankPaySource);
    }

    public IActionResult LoadCardPaymentMenu()
    {
        return View("Payment");
    }

    public ViewResult Aborted()
    {
        return View();
    }


    public ViewResult Thankyou()
    {
        if (_cartService.CartLines != null && _cartService.CartLines.Any())
        {
            var products = _cartService.CartLines.Select(p => p.Product);
            _context.Products.AttachRange(products);

            _context.Orders.Add(new Order
            {
                PaymentOrderLink = _cartService.PaymentOrderLink != null ? new Uri(_cartService.PaymentOrderLink, UriKind.RelativeOrAbsolute) : null,
                PaymentLink = _cartService.PaymentLink != null ? new Uri(_cartService.PaymentLink, UriKind.RelativeOrAbsolute) : null,
                // Instrument = this._cartService.Instrument,
                Lines = _cartService.CartLines.ToList()
            });
            _context.SaveChanges(true);
            _cartService.Clear();
        }

        var model = new CheckoutViewModel
        {
            PaymentOrderLink = _cartService.PaymentOrderLink
        };
        return View(model);
    }
}