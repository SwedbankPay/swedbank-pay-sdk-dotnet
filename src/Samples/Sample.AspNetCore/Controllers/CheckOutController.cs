using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Sample.AspNetCore.Data;
using Sample.AspNetCore.Extensions;
using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentInstruments.Invoice;
using SwedbankPay.Sdk.PaymentInstruments.Swish;
using SwedbankPay.Sdk.PaymentInstruments.Trustly;
using SwedbankPay.Sdk.PaymentOrders;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.AspNetCore.Controllers
{
	public class CheckOutController : Controller
	{
		private readonly Cart cartService;
		private readonly StoreDbContext context;
		private readonly PayeeInfoConfig payeeInfoOptions;
		private readonly ISwedbankPayClient swedbankPayClient;
		private readonly UrlsOptions urls;


		public CheckOutController(IOptionsSnapshot<PayeeInfoConfig> payeeInfoOptionsAccessor,
								  IOptionsSnapshot<UrlsOptions> urlsAccessor,
								  Cart cart,
								  StoreDbContext storeDbContext,
								  ISwedbankPayClient payClient)
		{
			this.payeeInfoOptions = payeeInfoOptionsAccessor.Value;
			this.urls = urlsAccessor.Value;
			this.cartService = cart;
			this.context = storeDbContext;
			this.swedbankPayClient = payClient;
		}



		public async Task<IPaymentOrderResponse> CreateOrUpdatePaymentOrder(string consumerProfileRef = null, Uri paymentUrl = null)
		{
			Uri orderId = null;
			var paymentOrderLink = this.cartService.PaymentOrderLink;
			if (!string.IsNullOrWhiteSpace(paymentOrderLink))
			{
				orderId = new Uri(paymentOrderLink, UriKind.Relative);
			}

			return orderId == null ? await CreatePaymentOrder(consumerProfileRef, paymentUrl) : await UpdatePaymentOrder(orderId, consumerProfileRef);
		}

		private async Task<IPaymentOrderResponse> UpdatePaymentOrder(Uri orderId, string consumerProfileRef, Uri paymentUrl = null)
		{
			var paymentOrder = await this.swedbankPayClient.PaymentOrders.Get(orderId, PaymentOrderExpand.OrderItems | PaymentOrderExpand.CurrentPayment);
			if (paymentOrder.Operations.Update == null)
			{
				if(paymentOrder.Operations.Abort != null)
				{
					await paymentOrder.Operations.Abort(new PaymentOrderAbortRequest("UpdateNotAvailable"));
					return await CreatePaymentOrder(consumerProfileRef, paymentUrl);
				}

				return paymentOrder;
			}

			var totalAmount = this.cartService.CalculateTotal();
			var updateRequest = new PaymentOrderUpdateRequest(new Amount(totalAmount), new Amount(0));

			var orderItems = this.cartService.CartLines.ToOrderItems();
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
					var currentPayment = paymentOrder.PaymentOrder.CurrentPayment.Payment;
					if (currentPayment != null && (currentPayment.State.Equals(State.Aborted) || currentPayment.State.Equals(State.Ready)))
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
			var paymentOrderItems = orderItems?.ToList();
			try
			{
				var paymentOrderRequest = new PaymentOrderRequest(Operation.Purchase, new Currency("SEK"),
																  new Amount(totalAmount),
																  new Amount(0), "Test description", "useragent",
																  new Language("sv-SE"),
																  false,
																  new Urls(this.urls.HostUrls.ToList(), this.urls.CompleteUrl,
																		   this.urls.TermsOfServiceUrl)
																  {
																	  CancelUrl = this.urls.CancelUrl,
																	  PaymentUrl = paymentUrl ?? this.urls.PaymentUrl,
																	  CallbackUrl = this.urls.CallbackUrl,
																	  LogoUrl = this.urls.LogoUrl
																  },
																  new PayeeInfo(this.payeeInfoOptions.PayeeId, this.payeeInfoOptions.PayeeReference));
				paymentOrderRequest.PaymentOrder.OrderItems = paymentOrderItems;
				paymentOrderRequest.PaymentOrder.Payer = payer;

				var paymentOrder = await this.swedbankPayClient.PaymentOrders.Create(paymentOrderRequest);

				this.cartService.PaymentOrderLink = paymentOrder.PaymentOrder.Id.OriginalString;
				this.cartService.PaymentLink = null;
				this.cartService.ConsumerProfileRef = consumerProfileRef;
				this.cartService.Update();

				return paymentOrder;
			}
			catch (Exception ex)
			{
				Debug.Write(ex.Message);
				return null;
			}
		}

		public async Task<ICardPaymentResponse> CreateCardPayment()
		{
			var totalAmount = this.cartService.CalculateTotal();
			var vatAmount = new Amount(0);
			try
			{
				var cardRequest = new CardPaymentRequest(Operation.Purchase,
														PaymentIntent.Authorization, new Currency("SEK"),
														"Test Purchase", "useragent",
														new Language("sv-SE"),
														new Urls(
																this.urls.HostUrls.ToList(),
																this.urls.CompleteUrl,
																this.urls.TermsOfServiceUrl)
														{
															CancelUrl = this.urls.CancelUrl,
															PaymentUrl = this.urls.PaymentUrl,
															CallbackUrl = this.urls.CallbackUrl,
															LogoUrl = this.urls.LogoUrl
														},
														new PayeeInfo(this.payeeInfoOptions.PayeeId,
																	  this.payeeInfoOptions.PayeeReference)
														);
				foreach (var url in urls.HostUrls)
				{
					cardRequest.Payment.Urls.HostUrls.Add(url);
				}

				cardRequest.Payment.GenerateRecurrenceToken = true;
				cardRequest.Payment.Prices.Add(new Price(new Amount(totalAmount), PriceType.CreditCard, vatAmount));

				var cardPayment = await this.swedbankPayClient.Payments.CardPayments.Create(cardRequest);
				this.cartService.PaymentLink = cardPayment.Payment.Id.OriginalString;
				this.cartService.Instrument = PaymentInstrument.CreditCard;
				this.cartService.PaymentOrderLink = null;
				this.cartService.Update();
				return cardPayment;
			}
			catch (Exception ex)
			{
				Debug.Write(ex.Message);
				return null;
			}
		}

		public async Task<ITrustlyPaymentResponse> CreateTrustlyPayment()
		{
			var totalAmount = this.cartService.CalculateTotal();
			var vatAmount = new Amount(0);
			try
			{
				var trustlyPaymentRequest = new TrustlyPaymentRequest(
																	new Currency("SEK"),
																	new List<IPrice>(),
																	"Test Purchase", this.payeeInfoOptions.PayeeReference, "useragent", new Language("sv-SE"),
																	new Urls(this.urls.HostUrls.ToList(),
																			 this.urls.CompleteUrl,
																			 this.urls.TermsOfServiceUrl)
																	{
																		CancelUrl = this.urls.CancelUrl,
																		PaymentUrl = this.urls.PaymentMenuPaymentUrl,
																		CallbackUrl = this.urls.CallbackUrl,
																		LogoUrl = this.urls.LogoUrl
																	},
																	new PayeeInfo(this.payeeInfoOptions.PayeeId,
																				  this.payeeInfoOptions.PayeeReference));

				trustlyPaymentRequest.Payment.Prices.Add(new Price(new Amount(totalAmount),
																				PriceType.Trustly,
																				vatAmount));
				foreach (var url in urls.HostUrls)
				{
					trustlyPaymentRequest.Payment.Urls.HostUrls.Add(url);
				}

				var trustlyPayment = await this.swedbankPayClient.Payments.TrustlyPayments.Create(trustlyPaymentRequest);

				this.cartService.PaymentLink = trustlyPayment.Payment.Id.OriginalString;
				this.cartService.Instrument = PaymentInstrument.Trustly;
				this.cartService.PaymentOrderLink = null;
				this.cartService.Update();

				return trustlyPayment;
			}
			catch (Exception ex)
			{
				Debug.Write(ex.Message);
				return null;
			}
		}

		public async Task<ISwishPaymentResponse> CreateSwishPayment()
		{
			var totalAmount = this.cartService.CalculateTotal();
			var vatAmount = new Amount(0);
			try
			{
				var swishRequest = new SwishPaymentRequest(new List<IPrice>(),
															"Test Purchase",
															this.payeeInfoOptions.PayeeReference, "useragent", new Language("sv-SE"), new Urls(this.urls.HostUrls.ToList(), this.urls.CompleteUrl, this.urls.TermsOfServiceUrl) { CancelUrl = this.urls.CancelUrl, PaymentUrl = this.urls.PaymentUrl, CallbackUrl = this.urls.CallbackUrl, LogoUrl = this.urls.LogoUrl },
															new PayeeInfo(this.payeeInfoOptions.PayeeId, this.payeeInfoOptions.PayeeReference),
															new PrefillInfo(new Msisdn("+46739000001")));
				swishRequest.Payment.Prices.Add(new Price(new Amount(totalAmount), PriceType.Swish, vatAmount));

				var swishPayment = await this.swedbankPayClient.Payments.SwishPayments.Create(swishRequest);
				this.cartService.PaymentLink = swishPayment.Payment.Id.OriginalString;
				this.cartService.Instrument = PaymentInstrument.Swish;
				this.cartService.PaymentOrderLink = null;
				this.cartService.Update();

				return swishPayment;
			}
			catch (Exception ex)
			{
				Debug.Write(ex.Message);
				return null;
			}
		}

		public async Task<IInvoicePaymentResponse> CreateInvoicePayment()
		{
			var totalAmount = this.cartService.CalculateTotal();
			var vatAmount = new Amount(0);
			try
			{
				var invoiceRequest = new InvoicePaymentRequest(Operation.FinancingConsumer,
															   PaymentIntent.Authorization,
															   new Currency("SEK"),
															   new List<IPrice>(),
															   "Test Purchase",
                                                               "useragent",
															   new Language("sv-SE"),
															   new Urls(this.urls.HostUrls.ToList(), this.urls.CompleteUrl, this.urls.TermsOfServiceUrl) { CancelUrl = this.urls.CancelUrl, PaymentUrl = this.urls.PaymentUrl, CallbackUrl = this.urls.CallbackUrl, LogoUrl = this.urls.LogoUrl },
															   new PayeeInfo(this.payeeInfoOptions.PayeeId, this.payeeInfoOptions.PayeeReference),
															   InvoiceType.PayExFinancingSe);
				invoiceRequest.Payment.Prices.Add(new Price(new Amount(totalAmount), PriceType.Invoice, vatAmount));

				var invoicePayment = await this.swedbankPayClient.Payments.InvoicePayments.Create(invoiceRequest);
				this.cartService.PaymentLink = invoicePayment.Payment.Id.OriginalString;
				this.cartService.Instrument = PaymentInstrument.Swish;
				this.cartService.PaymentOrderLink = null;
				this.cartService.Update();

				return invoicePayment;
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
			string paymentOrderLink = this.cartService.PaymentOrderLink;
			if (!string.IsNullOrWhiteSpace(paymentOrderLink))
			{
				var uri = new Uri(paymentOrderLink, UriKind.Relative);
				var paymentOrderResponse = await this.swedbankPayClient.PaymentOrders.Get(uri, PaymentOrderExpand.None);
				return Json(paymentOrderResponse.Operations.View.Href.OriginalString);
			}

			var paymentOrderResponseObject = await CreateOrUpdatePaymentOrder(consumerProfileRef, this.urls.StandardCheckoutPaymentUrl);
			return Json(paymentOrderResponseObject.Operations.View.Href.OriginalString);
		}


		public async Task<IActionResult> InitiateConsumerSession()
		{
			var consumerUiScriptSource = this.cartService.ConsumerUiScriptSource;
			var swedbankPaySource = new SwedbankPayCheckoutSource
			{
				Culture = CultureInfo.GetCultureInfo("sv-SE"),
				UseAnonymousCheckout = false,
			};

			if (!string.IsNullOrWhiteSpace(consumerUiScriptSource))
			{
				swedbankPaySource.ConsumerUiScriptSource = new Uri(consumerUiScriptSource, UriKind.Absolute);
				return View("Checkout", swedbankPaySource);
			}

			var initiateConsumerRequest = new ConsumerRequest(new Language("sv-SE"));
			initiateConsumerRequest.ShippingAddressRestrictedToCountryCodes.Add(new CountryCode("SE"));

			var response = await this.swedbankPayClient.Consumers.InitiateSession(initiateConsumerRequest);
			swedbankPaySource.ConsumerUiScriptSource = response.Operations.ViewConsumerIdentification?.Href;

			this.cartService.ConsumerUiScriptSource = response.Operations.ViewConsumerIdentification?.Href.ToString();
			this.cartService.Update();

			return View("Checkout", swedbankPaySource);
		}


		public async Task<IActionResult> LoadPaymentMenu()
		{
			var consumerProfileRef = this.cartService.ConsumerProfileRef;
			var paymentOrder = await CreateOrUpdatePaymentOrder(consumerProfileRef, this.urls.AnonymousCheckoutPaymentUrl);

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

		public async Task<IActionResult> LoadSwishPaymentMenu()
		{
			var response = await CreateSwishPayment();

			var jsSource = response.Operations.ViewSales.Href;

			var swedbankPaySource = new SwedbankPayCheckoutSource
			{
				JavascriptSource = jsSource,
				Culture = CultureInfo.GetCultureInfo("sv-SE"),
				UseAnonymousCheckout = true,
				AbortOperationLink = response.Operations[LinkRelation.UpdateAbort].Href
			};

			return View("Checkout", swedbankPaySource);
		}

		[HttpPost]
		public async Task<JsonResult> GetPaymentJsSource(PaymentInstrument instrument)
		{
			switch (instrument)
			{
				case PaymentInstrument.CreditCard:
					var cardPayment = await CreateCardPayment().ConfigureAwait(false);
					return new JsonResult(cardPayment.Operations.ViewAuthorization.Href);

				case PaymentInstrument.Swish:
					var swishPayment = await CreateSwishPayment().ConfigureAwait(false);
					return new JsonResult(swishPayment.Operations.ViewSales.Href);

				case PaymentInstrument.Trustly:
					var trustlyPayment = await CreateTrustlyPayment().ConfigureAwait(false);
					return new JsonResult(trustlyPayment.Operations.ViewSale.Href);
				case PaymentInstrument.Invoice:
					var invoicePayment = await CreateInvoicePayment().ConfigureAwait(false);
					return new JsonResult(invoicePayment.Operations.ViewAuthorization.Href);
				default:
					return null;
			}
		}


		public ViewResult Aborted()
		{
			return View();
		}


		public ViewResult Thankyou()
		{
			if (this.cartService.CartLines != null && this.cartService.CartLines.Any())
			{
				var products = this.cartService.CartLines.Select(p => p.Product);
				this.context.Products.AttachRange(products);

				this.context.Orders.Add(new Order
				{
					PaymentOrderLink = this.cartService.PaymentOrderLink != null ? new Uri(this.cartService.PaymentOrderLink, UriKind.RelativeOrAbsolute) : null,
					PaymentLink = this.cartService.PaymentLink != null ? new Uri(this.cartService.PaymentLink, UriKind.RelativeOrAbsolute) : null,
					Instrument = this.cartService.Instrument,
					Lines = this.cartService.CartLines.ToList()
				});
				this.context.SaveChanges(true);
				this.cartService.Clear();
			}
			return View();
		}
	}
}