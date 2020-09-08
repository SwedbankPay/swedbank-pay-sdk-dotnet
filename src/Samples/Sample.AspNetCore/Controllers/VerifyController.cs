using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments;

using SwedbankPay.Sdk.Payments.CardPayments;
using System.Diagnostics;
using Sample.AspNetCore.Models;
using System.Globalization;
using Microsoft.Extensions.Options;
using System.Runtime.InteropServices.ComTypes;
using Sample.AspNetCore.Data;
using Microsoft.Extensions.Configuration;

namespace Sample.AspNetCore.Controllers
{
    public class VerifyController : Controller
    {

        private readonly ISwedbankPayClient swedbankPayClient;
        private readonly Cart cartService;
        private readonly PayeeInfoConfig payeeInfoOptions;
        private readonly UrlsOptions urls;
        private bool generatePaymentToken;
        private bool generateReccurenceToken;
        private string description;
        private string userAgent;
        private readonly StoreDbContext context;
        private readonly SwedbankPayConnectionSettings swedbankPayConnectionSettings;


        public VerifyController(IOptionsSnapshot<PayeeInfoConfig> payeeInfoOptionsAccessor,
                              IOptionsSnapshot<UrlsOptions> urlsAccessor,
                              Cart cartService,
                              ISwedbankPayClient swedbankPayClient, StoreDbContext context, SwedbankPayConnectionSettings swedbankPayConnectionSettings)
        {
            this.payeeInfoOptions = payeeInfoOptionsAccessor.Value;
            this.urls = urlsAccessor.Value;
            this.cartService = cartService;
            this.swedbankPayClient = swedbankPayClient;
            this.context = context;
            this.swedbankPayConnectionSettings = swedbankPayConnectionSettings;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
         
        public async Task<CardVerify> InitiateVerify()
        {
            try
            {
                var verifyRequest = new CardPaymentVerifyRequest(Operation.Verify, new CurrencyCode("SEK"),                                                                                 
                                                                                   description = "Test Verification", userAgent = "useragent",
                                                                                   CultureInfo.GetCultureInfo("sv-SE"),
                                                                                   new Urls(this.urls.HostUrls, this.urls.VerificationListUrl,
                                                                                            this.urls.TermsOfServiceUrl, this.urls.CancelUrl,
                                                                                            this.urls.PaymentUrl, this.urls.CallbackUrl, this.urls.LogoUrl),
                                                                                   new PayeeInfo(this.payeeInfoOptions.PayeeId,
                                                                                                 this.payeeInfoOptions.PayeeReference),
                                                                                   this.payeeInfoOptions.PayeeReference,
                                                                                   generatePaymentToken = true,
                                                                                   generateReccurenceToken = true)
                                                                                   ;


                var cardVerify = await this.swedbankPayClient.Payments.CardPayments.Verify(verifyRequest);
                this.cartService.VerificationLink = cardVerify.VerifyResponse.Id.OriginalString;
                this.cartService.Update();
                //this.context.SaveChanges(true);

                return cardVerify;
                //var completeUrl = verifyResponse.VerifyResponse.Urls.CompleteUrl;
                //var getCardVerify = await this.swedbankPayClient.Payments.CardPayments.Get(cardVerify.VerifyResponse.Id);

             
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return null;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRedirectVerificationHref(string consumerProfileRef = null)
        {
            var verify = await InitiateVerify();

            return new RedirectResult(verify.Operations.RedirectVerification.Href.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> ViewList()
        {
            Uri baseUrl = swedbankPayConnectionSettings.ApiBaseUrl;
            var verificationLink = new Uri(baseUrl, this.cartService.VerificationLink);
            var response = await this.swedbankPayClient.Payments.CardPayments.Get(verificationLink);

            return View(response);
 
            ///return View(response.Operations.ViewVerification.Href);
        }
    }
}