namespace SwedbankPay.Client.Models.Common
{
    using System.Collections.Generic;

    public class Urls : IdLink
    {
        /// <summary>
        /// The list of URIs valid for embedding of PayEx Hosted Views.
        /// </summary>
        public List<string> HostUrls { get; set; }

        /// <summary>
        /// The URI to redirect the payer to once the payment is completed.
        /// </summary>
        public string CompleteUrl { get; set; }

        /// <summary>
        /// The URI to redirect the payer to if the payment is canceled.
        /// </summary>
        public string CancelUrl { get; set; }

        /// <summary>
        /// The URI to the API endpoint receiving  POST requests on transaction activity related to the payment order.
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// The URI to the terms of service document the payer must accept in order to complete the payment.
        /// </summary>
        public string TermsOfServiceUrl { get; set; }

        /// <summary>
        /// The URI to the logo that will be displayed on redirect pages.
        /// </summary>
        public string LogoUrl { get; set; }
    }
}
