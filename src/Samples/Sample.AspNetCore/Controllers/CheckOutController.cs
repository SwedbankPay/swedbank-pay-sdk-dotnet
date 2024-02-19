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

    public void Callback([FromBody] CallbackInfo callbackInfo)
    {
        _logger.LogInformation($"Callback received for id {callbackInfo?.PaymentOrder?.Id}", callbackInfo);
    }

    public async Task<IPaymentOrderResponse> CreateOrUpdatePaymentOrder(bool generatePaymentToken, bool generateRecurrenceToken, bool generateUnscheduledToken)
    {
        return await CreateOrUpdatePaymentOrder(generatePaymentToken, generateRecurrenceToken, generateUnscheduledToken, null, null);
    }

    public async Task<IPaymentOrderResponse> CreateOrUpdatePaymentOrder(bool generatePaymentToken, bool generateRecurrenceToken, bool generateUnscheduledToken,
        Uri paymentUrl, string paymentToken)
    {
        Uri orderId = null;
        var paymentOrderLink = _cartService.PaymentOrderLink;
        if (!string.IsNullOrWhiteSpace(paymentOrderLink))
        {
            orderId = new Uri(paymentOrderLink, UriKind.Relative);
        }

        return orderId == null
            ? await CreatePaymentOrder(generatePaymentToken, generateRecurrenceToken, generateUnscheduledToken, paymentUrl, paymentToken)
            : await UpdatePaymentOrder(orderId, generatePaymentToken, generateRecurrenceToken, generateUnscheduledToken);
    }

    private async Task<IPaymentOrderResponse> UpdatePaymentOrder(Uri orderId, bool generatePaymentToken, bool generateRecurrenceToken, bool generateUnscheduledToken,
        Uri paymentUrl = null)
    {
        var paymentOrder = await _swedbankPayClient.PaymentOrders.Get(orderId, PaymentOrderExpand.All);
        if (paymentOrder?.Operations.Update == null)
        {
            if (paymentOrder?.Operations.Abort != null)
            {
                await paymentOrder.Operations.Abort(new PaymentOrderAbortRequest("UpdateNotAvailable"));
                return await CreatePaymentOrder(generatePaymentToken, generateRecurrenceToken, generateUnscheduledToken, paymentUrl, null);
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

            var sameOrderItems = paymentOrder.PaymentOrder.OrderItems?.OrderItemList != null && paymentOrderItems.Select(x => x.Reference)
                .All(paymentOrder.PaymentOrder.OrderItems.OrderItemList.Select(y => y.Reference).Contains);

            var amountChanged = totalAmount != paymentOrder.PaymentOrder.Amount;
            if (amountChanged || !sameOrderItems)
            {
                var paymentOrderStatus = paymentOrder.PaymentOrder.Status;
                if (!paymentOrderStatus.Equals(Status.Initialized))
                {
                    await paymentOrder.Operations.Abort(new PaymentOrderAbortRequest("UpdatedOrderItems"));
                    return await CreatePaymentOrder(generatePaymentToken, generateRecurrenceToken, generateUnscheduledToken, paymentUrl, null);
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

    public async Task<IPaymentOrderResponse> CreatePaymentOrder(bool generatePaymentToken, bool generateRecurrenceToken, bool generateUnscheduledToken)
    {
        return await CreatePaymentOrder(generatePaymentToken, generateRecurrenceToken, generateUnscheduledToken, null, null);
    }
    
    public async Task<IPaymentOrderResponse> CreatePaymentOrder(bool generatePaymentToken, bool generateRecurrenceToken, bool generateUnscheduledToken,
        Uri paymentUrl, string paymentToken)
    {
        var totalAmount = _cartService.CalculateTotal();

        var orderItems = _cartService.CartLines.ToOrderItems();
        var paymentOrderItems = orderItems?.ToList();
        try
        {
            var urls = new Urls(_urls.HostUrls.ToList(), _urls.CompleteUrl, _urls.CallbackUrl)
            {
                PaymentUrl = paymentUrl ?? _urls.PaymentUrl,
                LogoUrl = _urls.LogoUrl,
                CancelUrl = _urls.CancelUrl
            };
            
            var paymentOrderRequest = new PaymentOrderRequest(generateRecurrenceToken || generateUnscheduledToken ? Operation.Verify : Operation.Purchase,
                new Currency("SEK"),
                new Amount(totalAmount),
                new Amount(0), "Test description", "useragent",
                new Language("sv-SE"),
                urls,
                new PayeeInfo(_payeeInfoOptions.PayeeReference)
                {
                    PayeeId = _payeeInfoOptions.PayeeId,
                    OrderReference = $"PO-{DateTime.UtcNow.Ticks}"
                })
            {
                OrderItems = paymentOrderItems
            };

            if (generatePaymentToken)
            {
                paymentOrderRequest.GeneratePaymentToken = true;
                paymentOrderRequest.EnablePaymentDetailsConsentCheckbox = true;
                paymentOrderRequest.DisableStoredPaymentDetails = true;       
            }
            
            paymentOrderRequest.Metadata = null;
            paymentOrderRequest.GenerateRecurrenceToken = generateRecurrenceToken;
            paymentOrderRequest.GenerateUnscheduledToken = generateUnscheduledToken;
       ;
       
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

            if (!string.IsNullOrWhiteSpace(paymentToken))
            {
                paymentOrderRequest.GeneratePaymentToken = false;
                paymentOrderRequest.PaymentToken ??= paymentToken;          
            }

            var paymentOrder = await _swedbankPayClient.PaymentOrders.Create(paymentOrderRequest, PaymentOrderExpand.All);

            _cartService.PaymentOrderLink = paymentOrder?.PaymentOrder.Id.OriginalString;
            _cartService.PaymentLink = null;
            _cartService.Update();

            return paymentOrder;
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
            return null;
        }
    }

    
    public async Task<IActionResult> LoadPaymentMenu(bool isRedirect = false, bool generatePaymentToken = false, bool generateRecurrenceToken = false,
        bool generateUnscheduledToken = false, string paymentToken = null)
    {
        var paymentOrder =
            await CreateOrUpdatePaymentOrder(generatePaymentToken, generateRecurrenceToken, generateUnscheduledToken, _urls.AnonymousCheckoutPaymentUrl, paymentToken);
        if (isRedirect)
        {
            return Redirect(paymentOrder?.Operations.Redirect?.Href.ToString()!);
        }

        var swedbankPaySource = new SwedbankPayCheckoutSource
        {
            JavascriptSource = paymentOrder?.Operations.View?.Href,
            Culture = CultureInfo.GetCultureInfo("sv-SE"),
            UseAnonymousCheckout = true,
            AbortOperationLink = paymentOrder?.Operations[LinkRelation.UpdateAbort]?.Href,
            PaymentOrderLink = paymentOrder?.PaymentOrder.Id
        };

        return View("Checkout", swedbankPaySource);
    }

    public IActionResult LoadCardPaymentMenu()
    {
        return View("Payment");
    }

    public ViewResult Aborted()
    {
        _cartService.PaymentOrderLink = null;
        _cartService.Update();
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