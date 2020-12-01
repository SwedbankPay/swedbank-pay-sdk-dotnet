using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// Object describing details needed for performaing a Mobile Pay payment.
    /// </summary>
    public class MobilePayPaymentDetails : IMobilePayPaymentDetails
    {
        /// <summary>
        /// Instantiates a new <see cref="MobilePayPaymentDetails"/> with the provided parameters.
        /// </summary>
        /// <param name="operation">API operation to perform for this request.</param>
        /// <param name="intent">The initial payment intent for this payment.</param>
        /// <param name="currency">The wanted <seealso cref="Sdk.Currency"/> for this payment to be paid in.</param>
        /// <param name="prices">List of objects describing payment instrument prices.</param>
        /// <param name="description">A textual description of the payment.</param>
        /// <param name="payerReference">Reference to the payer in the merchant system.</param>
        /// <param name="userAgent">The payers user agent string.</param>
        /// <param name="language">The payers prefered <see cref="Sdk.Language"/>.</param>
        /// <param name="urls">Object with relevant URLs for this payment.</param>
        /// <param name="payeeInfo">Object containing information about the merchant.</param>
        /// <param name="metadata">Additional metadata about the payment.</param>
        /// <param name="prefillInfo">Known information about the payer that can be pre-filled in the payment window.</param>
        public MobilePayPaymentDetails(Operation operation,
                                                PaymentIntent intent,
                                                Currency currency,
                                                List<IPrice> prices,
                                                string description,
                                                string payerReference,
                                                string userAgent,
                                                Language language,
                                                IUrls urls,
                                                PayeeInfo payeeInfo,
                                                MetadataResponse metadata = null,
                                                PrefillInfo prefillInfo = null)
        {
            Operation = operation ?? throw new ArgumentNullException(nameof(operation));
            Intent = intent;
            Currency = currency;
            Prices = prices;
            Description = description;
            PayerReference = payerReference;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
            Metadata = metadata;
            PrefillInfo = prefillInfo;
        }


        public Currency Currency { get; set; }
        public string Description { get; set; }
        public PaymentIntent Intent { get; set; }
        public Language Language { get; set; }
        public Operation Operation { get; set; }
        public PayeeInfo PayeeInfo { get; set; }
        public string PayerReference { get; set; }
        public List<IPrice> Prices { get; set; }
        public IUrls Urls { get; }
        public string UserAgent { get; set; }
        public PrefillInfo PrefillInfo { get; set; }
        public MetadataResponse Metadata { get; }
    }
}
