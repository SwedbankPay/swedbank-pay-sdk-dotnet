using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    public class UrlsResponse : Identifiable, IUrls
    {
        internal UrlsResponse(UrlsDto urls)
               : base(urls.Id)
        {
            if (urls.HostUrls != null)
            {
                HostUrls = urls.HostUrls;
            }

            if (urls.CompleteUrl != null)
            {
                CompleteUrl = urls.CompleteUrl;
            }

            if (urls.TermsOfServiceUrl != null)
            {
                TermsOfServiceUrl = urls.TermsOfServiceUrl;
            }

            if (urls.CancelUrl != null)
            {
                CancelUrl = urls.CancelUrl;
            }

            if (urls.PaymentUrl != null)
            {
                PaymentUrl = urls.PaymentUrl;
            }

            if (urls.CallbackUrl != null)
            {
                CallbackUrl = urls.CallbackUrl;
            }

            if (urls.LogoUrl != null)
            {
                LogoUrl = urls.LogoUrl;
            }
        }

        /// <summary>
        ///     The URI to the API endpoint receiving  POST requests on transaction activity related to the payment order.
        /// </summary>
        public Uri CallbackUrl { get; set; }

        /// <summary>
        ///     The URI to redirect the payer to if the payment is canceled.
        /// </summary>
        public Uri CancelUrl { get; set; }

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
        public Uri LogoUrl { get; set; }

        /// <summary>
        ///     The URI that SwedbankPay will redirect back to when the payment menu needs to be loaded, to inspect and act on the
        ///     current status of the payment. Only used in hosted views. Can not be used simultaneously with cancelUrl; only
        ///     cancelUrl or paymentUrl can be used, not both.
        /// </summary>
        public Uri PaymentUrl { get; set; }

        /// <summary>
        ///     The URI to the terms of service document the payer must accept in order to complete the payment.
        /// </summary>
        public Uri TermsOfServiceUrl { get; }
    }
}
