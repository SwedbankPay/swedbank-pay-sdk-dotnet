using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public class Urls : IdLink, IUrls
    {
        public Urls(UrlsDto urls)
        {
            HostUrls = urls.HostUrls ?? throw new ArgumentNullException(nameof(urls.HostUrls), $"{nameof(urls.HostUrls)} is required.");
            CompleteUrl = urls.CompleteUrl ?? throw new ArgumentNullException(nameof(urls.CompleteUrl), $"{nameof(urls.CompleteUrl)} is required.");
            TermsOfServiceUrl = urls.TermsOfServiceUrl
                                ?? throw new ArgumentNullException(nameof(urls.TermsOfServiceUrl), $"{nameof(urls.TermsOfServiceUrl)} is required.");
            CancelUrl = urls.CancelUrl;
            PaymentUrl = urls.PaymentUrl;
            CallbackUrl = urls.CallbackUrl;
            LogoUrl = urls.LogoUrl;
        }

        public Urls(ICollection<Uri> hostUrls,
                    Uri completeUrl,
                    Uri termsOfServiceUrl,
                    Uri cancelUrl = null,
                    Uri paymentUrl = null,
                    Uri callbackUrl = null,
                    Uri logoUrl = null)
        {
            HostUrls = hostUrls ?? throw new ArgumentNullException(nameof(hostUrls), $"{nameof(hostUrls)} is required."); ;
            CompleteUrl = completeUrl ?? throw new ArgumentNullException(nameof(completeUrl), $"{nameof(completeUrl)} is required."); ;
            TermsOfServiceUrl = termsOfServiceUrl ?? throw new ArgumentNullException(nameof(termsOfServiceUrl), $"{nameof(termsOfServiceUrl)} is required."); ;
            CancelUrl = cancelUrl;
            PaymentUrl = paymentUrl;
            CallbackUrl = callbackUrl;
            LogoUrl = logoUrl;
        }


        /// <summary>
        ///     The URI to the API endpoint receiving  POST requests on transaction activity related to the payment order.
        /// </summary>
        public Uri CallbackUrl { get; }

        /// <summary>
        ///     The URI to redirect the payer to if the payment is canceled.
        /// </summary>
        public Uri CancelUrl { get; }

        /// <summary>
        ///     The URI to redirect the payer to once the payment is completed.
        /// </summary>
        public Uri CompleteUrl { get; }

        /// <summary>
        ///     The list of URIs valid for embedding of PayEx Hosted Views.
        /// </summary>
        public ICollection<Uri> HostUrls { get; }

        /// <summary>
        ///     The URI to the logo that will be displayed on redirect pages.
        /// </summary>
        public Uri LogoUrl { get; }

        /// <summary>
        ///     The URI that SwedbankPay will redirect back to when the payment menu needs to be loaded, to inspect and act on the
        ///     current status of the payment. Only used in hosted views. Can not be used simultaneously with cancelUrl; only
        ///     cancelUrl or paymentUrl can be used, not both.
        /// </summary>
        public Uri PaymentUrl { get; }

        /// <summary>
        ///     The URI to the terms of service document the payer must accept in order to complete the payment.
        /// </summary>
        public Uri TermsOfServiceUrl { get; }
    }
}