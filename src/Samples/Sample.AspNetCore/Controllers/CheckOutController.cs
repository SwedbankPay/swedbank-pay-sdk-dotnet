using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Sample.AspNetCore.Data;
using Sample.AspNetCore.Extensions;
using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest;

namespace Sample.AspNetCore.Controllers
{
	public class CheckOutController : Controller
	{
		private readonly Cart _cartService;
		private readonly StoreDbContext _context;
		private readonly PayeeInfoConfig _payeeInfoOptions;
		private readonly ISwedbankPayClient _swedbankPayClient;
		private readonly UrlsOptions _urls;


		public CheckOutController(IOptionsSnapshot<PayeeInfoConfig> payeeInfoOptionsAccessor,
								  IOptionsSnapshot<UrlsOptions> urlsAccessor,
								  Cart cart,
								  StoreDbContext storeDbContext,
								  ISwedbankPayClient payClient)
		{
			_payeeInfoOptions = payeeInfoOptionsAccessor.Value;
			_urls = urlsAccessor.Value;
			_cartService = cart;
			_context = storeDbContext;
			_swedbankPayClient = payClient;
		}



		public async Task<IPaymentOrderResponse> CreateOrUpdatePaymentOrder(string consumerProfileRef = null, Uri paymentUrl = null)
		{
			Uri orderId = null;
			var paymentOrderLink = this._cartService.PaymentOrderLink;
			if (!string.IsNullOrWhiteSpace(paymentOrderLink))
			{
				orderId = new Uri(paymentOrderLink, UriKind.Relative);
			}

			return orderId == null ? await CreatePaymentOrder(consumerProfileRef, paymentUrl) : await UpdatePaymentOrder(orderId, consumerProfileRef);
		}

		private async Task<IPaymentOrderResponse> UpdatePaymentOrder(Uri orderId, string consumerProfileRef, Uri paymentUrl = null)
		{
			var paymentOrder = await this._swedbankPayClient.PaymentOrders.Get(orderId, PaymentOrderExpand.All);
			if (paymentOrder.Operations.Update == null)
			{
				if(paymentOrder.Operations.Abort != null)
				{
					await paymentOrder.Operations.Abort(new PaymentOrderAbortRequest("UpdateNotAvailable"));
					return await CreatePaymentOrder(consumerProfileRef, paymentUrl);
				}

				return paymentOrder;
			}

			var totalAmount = this._cartService.CalculateTotal();
			var updateRequest = new PaymentOrderUpdateRequest(new Amount(totalAmount), new Amount(0));

			var orderItems = this._cartService.CartLines.ToOrderItems();
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
					if (paymentOrderStatus != null && (paymentOrderStatus.Equals(Status.Aborted) || paymentOrderStatus.Equals(Status.Ready)))
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
			var totalAmount = this._cartService.CalculateTotal();
			
			var orderItems = this._cartService.CartLines.ToOrderItems();
			var paymentOrderItems = orderItems?.ToList();
			try
			{
				var paymentOrderRequest = new PaymentOrderRequest(Operation.Purchase, new Currency("SEK"),
																  new Amount(totalAmount),
																  new Amount(0), "Test description", "useragent",
																  new Language("sv-SE"),
																  "Checkout3",
																  new Urls(this._urls.HostUrls.ToList(), this._urls.CompleteUrl, this._urls.CancelUrl, this._urls.CallbackUrl)
																  {
																	  PaymentUrl = paymentUrl ?? this._urls.PaymentUrl,
																	  LogoUrl = this._urls.LogoUrl
																  },
																  new PayeeInfo(this._payeeInfoOptions.PayeeId, this._payeeInfoOptions.PayeeReference));
				paymentOrderRequest.OrderItems = paymentOrderItems;
				var paymentOrder = await this._swedbankPayClient.PaymentOrders.Create(paymentOrderRequest);

				_cartService.PaymentOrderLink = paymentOrder.PaymentOrder.Id.OriginalString;
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

		// public async Task<ICardPaymentResponse> CreateCardPayment()
		// {
		// 	var totalAmount = this._cartService.CalculateTotal();
		// 	var vatAmount = new Amount(0);
		// 	try
		// 	{
		// 		var cardRequest = new CardPaymentRequest(Operation.Purchase,
		// 												PaymentIntent.Authorization, new Currency("SEK"),
		// 												"Test Purchase", "useragent",
		// 												new Language("sv-SE"),
		// 												new Urls(
		// 														this._urls.HostUrls.ToList(),
		// 														this._urls.CompleteUrl,
		// 														this._urls.TermsOfServiceUrl)
		// 												{
		// 													CancelUrl = this._urls.CancelUrl,
		// 													PaymentUrl = this._urls.PaymentUrl,
		// 													CallbackUrl = this._urls.CallbackUrl,
		// 													LogoUrl = this._urls.LogoUrl
		// 												},
		// 												new PayeeInfo(this._payeeInfoOptions.PayeeId,
		// 															  this._payeeInfoOptions.PayeeReference)
		// 												);
		// 		foreach (var url in _urls.HostUrls)
		// 		{
		// 			cardRequest.Payment.Urls.HostUrls.Add(url);
		// 		}
  //
		// 		cardRequest.Payment.GenerateRecurrenceToken = true;
		// 		cardRequest.Payment.Prices.Add(new Price(new Amount(totalAmount), PriceType.CreditCard, vatAmount));
  //
		// 		var cardPayment = await this._swedbankPayClient.Payments.CardPayments.Create(cardRequest);
		// 		this._cartService.PaymentLink = cardPayment.Payment.Id.OriginalString;
		// 		this._cartService.Instrument = PaymentInstrument.CreditCard;
		// 		this._cartService.PaymentOrderLink = null;
		// 		this._cartService.Update();
		// 		return cardPayment;
		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		Debug.Write(ex.Message);
		// 		return null;
		// 	}
		// }
  //
  //
		// public async Task<ICardPaymentResponse> CreateVerifyRecurringPayment()
		// {
		// 	try
		// 	{
		// 		var cardRequest = new CardPaymentVerifyRequest(PaymentIntent.Authorization, new Currency("SEK"),
		// 													  "Test Purchase", "useragent",
		// 													  new Language("sv-SE"),
		// 													  new Urls(
		// 														  this._urls.HostUrls.ToList(),
		// 														  this._urls.CompleteUrl,
		// 														  this._urls.TermsOfServiceUrl)
		// 													  {
		// 														  CancelUrl = this._urls.CancelUrl,
		// 														  PaymentUrl = this._urls.PaymentUrl,
		// 														  CallbackUrl = this._urls.CallbackUrl,
		// 														  LogoUrl = this._urls.LogoUrl
		// 													  },
		// 													  new PayeeInfo(this._payeeInfoOptions.PayeeId,
		// 																	this._payeeInfoOptions.PayeeReference)
		// 		);
		// 		foreach (var url in _urls.HostUrls)
		// 		{
		// 			cardRequest.Payment.Urls.HostUrls.Add(url);
		// 		}
  //
		// 		cardRequest.Payment.GenerateRecurrenceToken = true;
		// 		
		// 		var cardPayment = await this._swedbankPayClient.Payments.CardPayments.Create(cardRequest);
		// 		this._cartService.PaymentLink = cardPayment.Payment.Id.OriginalString;
		// 		this._cartService.Instrument = PaymentInstrument.CreditCard;
		// 		this._cartService.PaymentOrderLink = null;
		// 		this._cartService.Update();
		// 		return cardPayment;
		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		Debug.Write(ex.Message);
		// 		return null;
		// 	}
		// }
  //
  //
		// public async Task<ITrustlyPaymentResponse> CreateTrustlyPayment()
		// {
		// 	var totalAmount = this._cartService.CalculateTotal();
		// 	var vatAmount = new Amount(0);
		// 	try
		// 	{
		// 		var trustlyPaymentRequest = new TrustlyPaymentRequest(
		// 															new Currency("SEK"),
		// 															new List<IPrice>(),
		// 															"Test Purchase", this._payeeInfoOptions.PayeeReference, "useragent", new Language("sv-SE"),
		// 															new Urls(this._urls.HostUrls.ToList(),
		// 																	 this._urls.CompleteUrl,
		// 																	 this._urls.TermsOfServiceUrl)
		// 															{
		// 																CancelUrl = this._urls.CancelUrl,
		// 																PaymentUrl = this._urls.PaymentMenuPaymentUrl,
		// 																CallbackUrl = this._urls.CallbackUrl,
		// 																LogoUrl = this._urls.LogoUrl
		// 															},
		// 															new PayeeInfo(this._payeeInfoOptions.PayeeId,
		// 																		  this._payeeInfoOptions.PayeeReference));
  //
		// 		trustlyPaymentRequest.Payment.Prices.Add(new Price(new Amount(totalAmount),
		// 																		PriceType.Trustly,
		// 																		vatAmount));
		// 		foreach (var url in _urls.HostUrls)
		// 		{
		// 			trustlyPaymentRequest.Payment.Urls.HostUrls.Add(url);
		// 		}
  //
		// 		var trustlyPayment = await this._swedbankPayClient.Payments.TrustlyPayments.Create(trustlyPaymentRequest);
  //
		// 		this._cartService.PaymentLink = trustlyPayment.Payment.Id.OriginalString;
		// 		this._cartService.Instrument = PaymentInstrument.Trustly;
		// 		this._cartService.PaymentOrderLink = null;
		// 		this._cartService.Update();
  //
		// 		return trustlyPayment;
		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		Debug.Write(ex.Message);
		// 		return null;
		// 	}
		// }
  //
		// public async Task<ISwishPaymentResponse> CreateSwishPayment()
		// {
		// 	var totalAmount = this._cartService.CalculateTotal();
		// 	var vatAmount = new Amount(0);
		// 	try
		// 	{
		// 		var swishRequest = new SwishPaymentRequest(new List<IPrice>(),
		// 													"Test Purchase",
		// 													this._payeeInfoOptions.PayeeReference, "useragent", new Language("sv-SE"), new Urls(this._urls.HostUrls.ToList(), this._urls.CompleteUrl, this._urls.TermsOfServiceUrl) { CancelUrl = this._urls.CancelUrl, PaymentUrl = this._urls.PaymentUrl, CallbackUrl = this._urls.CallbackUrl, LogoUrl = this._urls.LogoUrl },
		// 													new PayeeInfo(this._payeeInfoOptions.PayeeId, this._payeeInfoOptions.PayeeReference),
		// 													new PrefillInfo(new Msisdn("+46739000001")));
		// 		swishRequest.Payment.Prices.Add(new Price(new Amount(totalAmount), PriceType.Swish, vatAmount));
  //
		// 		var swishPayment = await this._swedbankPayClient.Payments.SwishPayments.Create(swishRequest);
		// 		this._cartService.PaymentLink = swishPayment.Payment.Id.OriginalString;
		// 		this._cartService.Instrument = PaymentInstrument.Swish;
		// 		this._cartService.PaymentOrderLink = null;
		// 		this._cartService.Update();
  //
		// 		return swishPayment;
		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		Debug.Write(ex.Message);
		// 		return null;
		// 	}
		// }
  //
		// public async Task<IInvoicePaymentResponse> CreateInvoicePayment()
		// {
		// 	var totalAmount = this._cartService.CalculateTotal();
		// 	var vatAmount = new Amount(0);
		// 	try
		// 	{
		// 		var invoiceRequest = new InvoicePaymentRequest(Operation.FinancingConsumer,
		// 													   PaymentIntent.Authorization,
		// 													   new Currency("SEK"),
		// 													   new List<IPrice>(),
		// 													   "Test Purchase",
  //                                                              "useragent",
		// 													   new Language("sv-SE"),
		// 													   new Urls(this._urls.HostUrls.ToList(), this._urls.CompleteUrl, this._urls.TermsOfServiceUrl) { CancelUrl = this._urls.CancelUrl, PaymentUrl = this._urls.PaymentUrl, CallbackUrl = this._urls.CallbackUrl, LogoUrl = this._urls.LogoUrl },
		// 													   new PayeeInfo(this._payeeInfoOptions.PayeeId, this._payeeInfoOptions.PayeeReference),
		// 													   InvoiceType.PayExFinancingSe);
		// 		invoiceRequest.Payment.Prices.Add(new Price(new Amount(totalAmount), PriceType.Invoice, vatAmount));
  //
		// 		var invoicePayment = await this._swedbankPayClient.Payments.InvoicePayments.Create(invoiceRequest);
		// 		this._cartService.PaymentLink = invoicePayment.Payment.Id.OriginalString;
		// 		this._cartService.Instrument = PaymentInstrument.Swish;
		// 		this._cartService.PaymentOrderLink = null;
		// 		this._cartService.Update();
  //
		// 		return invoicePayment;
		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		Debug.Write(ex.Message);
		// 		return null;
		// 	}
		// }

		[HttpPost]
		public async Task<JsonResult> GetViewPaymentOrderHref(string consumerProfileRef = null)
		{
			string paymentOrderLink = this._cartService.PaymentOrderLink;
			if (!string.IsNullOrWhiteSpace(paymentOrderLink))
			{
				var uri = new Uri(paymentOrderLink, UriKind.Relative);
				var paymentOrderResponse = await this._swedbankPayClient.PaymentOrders.Get(uri, PaymentOrderExpand.None);
				return Json(paymentOrderResponse.Operations.View.Href.OriginalString);
			}

			var paymentOrderResponseObject = await CreateOrUpdatePaymentOrder(consumerProfileRef, this._urls.StandardCheckoutPaymentUrl);
			return Json(paymentOrderResponseObject.Operations.View.Href.OriginalString);
		}


		// public async Task<IActionResult> InitiateConsumerSession()
		// {
		// 	var consumerUiScriptSource = this._cartService.ConsumerUiScriptSource;
		// 	var swedbankPaySource = new SwedbankPayCheckoutSource
		// 	{
		// 		Culture = CultureInfo.GetCultureInfo("sv-SE"),
		// 		UseAnonymousCheckout = false,
		// 	};
		//
		// 	if (!string.IsNullOrWhiteSpace(consumerUiScriptSource))
		// 	{
		// 		swedbankPaySource.ConsumerUiScriptSource = new Uri(consumerUiScriptSource, UriKind.Absolute);
		// 		return View("Checkout", swedbankPaySource);
		// 	}
		//
		// 	var initiateConsumerRequest = new ConsumerRequest(new Language("sv-SE"));
		// 	initiateConsumerRequest.ShippingAddressRestrictedToCountryCodes.Add(new CountryCode("SE"));
		//
		// 	var response = await this._swedbankPayClient.Consumers.InitiateSession(initiateConsumerRequest);
		// 	swedbankPaySource.ConsumerUiScriptSource = response.Operations.ViewConsumerIdentification?.Href;
		//
		// 	this._cartService.ConsumerUiScriptSource = response.Operations.ViewConsumerIdentification?.Href.ToString();
		// 	this._cartService.Update();
		//
		// 	return View("Checkout", swedbankPaySource);
		// }


		public async Task<IActionResult> LoadPaymentMenu()
		{
			var consumerProfileRef = this._cartService.ConsumerProfileRef;
			var paymentOrder = await CreateOrUpdatePaymentOrder(consumerProfileRef, this._urls.AnonymousCheckoutPaymentUrl);

			var jsSource = paymentOrder.Operations.View.Href;

			var swedbankPaySource = new SwedbankPayCheckoutSource
			{
				JavascriptSource = jsSource,
				Culture = CultureInfo.GetCultureInfo("sv-SE"),
				UseAnonymousCheckout = true,
				AbortOperationLink = paymentOrder.Operations[LinkRelation.UpdateAbort]?.Href
			};

			return View("Checkout", swedbankPaySource);
		}

		public IActionResult LoadCardPaymentMenu()
		{
			return View("Payment");
		}

		// public async Task<IActionResult> LoadSwishPaymentMenu()
		// {
		// 	var response = await CreateSwishPayment();
		//
		// 	var jsSource = response.Operations.ViewSales.Href;
		//
		// 	var swedbankPaySource = new SwedbankPayCheckoutSource
		// 	{
		// 		JavascriptSource = jsSource,
		// 		Culture = CultureInfo.GetCultureInfo("sv-SE"),
		// 		UseAnonymousCheckout = true,
		// 		AbortOperationLink = response.Operations[LinkRelation.UpdateAbort].Href
		// 	};
		//
		// 	return View("Checkout", swedbankPaySource);
		// }

		// [HttpPost]
		// public async Task<JsonResult> GetPaymentJsSource(PaymentInstrument instrument, bool recurring = false)
		// {
		// 	switch (instrument)
		// 	{
		// 		case PaymentInstrument.CreditCard:
  //                   if (recurring)
  //                   {
  //                       var recurringPayment = await CreateVerifyRecurringPayment().ConfigureAwait(false);
  //                       return new JsonResult(recurringPayment.Operations.ViewVerification.Href);
  //                   }
  //                   else
  //                   {
  //                       var cardPayment = await CreateCardPayment().ConfigureAwait(false);
  //                       return new JsonResult(cardPayment.Operations.ViewAuthorization.Href);
  //                   }
  //               case PaymentInstrument.Swish:
		// 			var swishPayment = await CreateSwishPayment().ConfigureAwait(false);
		// 			return new JsonResult(swishPayment.Operations.ViewSales.Href);
  //
		// 		case PaymentInstrument.Trustly:
		// 			var trustlyPayment = await CreateTrustlyPayment().ConfigureAwait(false);
		// 			return new JsonResult(trustlyPayment.Operations.ViewSale.Href);
		// 		case PaymentInstrument.Invoice:
		// 			var invoicePayment = await CreateInvoicePayment().ConfigureAwait(false);
		// 			return new JsonResult(invoicePayment.Operations.ViewAuthorization.Href);
		// 		default:
		// 			return null;
		// 	}
		// }


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
			return View();
		}
	}
}