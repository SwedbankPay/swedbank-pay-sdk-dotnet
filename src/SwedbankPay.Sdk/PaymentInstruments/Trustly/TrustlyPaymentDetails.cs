using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPaymentDetails
    {
        public TrustlyPaymentDetails(Currency currency,
                                                List<IPrice> prices,
                                                string description,
                                                string payerReference,
                                                string userAgent,
                                                Language language,
                                                IUrls urls,
                                                PayeeInfo payeeInfo,
                                                TrustlyPrefillInfo prefillInfo)
        {
            Operation = Operation.Purchase;
            Intent = PaymentIntent.Sale;
            Currency = currency;
            Prices = prices;
            Description = description;
            PayerReference = payerReference;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
            PrefillInfo = prefillInfo;
        }

        /// <summary>
        /// SEK, EUR. The currency of the provided <seealso cref="Sdk.Amount"/>.
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// A 40 character length textual description of the purchase.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Only <seealso cref="PaymentIntent.Sale"/> is available for Trustly payments.
        /// </summary>
        public PaymentIntent Intent { get; set; }
        public Language Language { get; set; }

        /// <summary>
        /// Only <seealso cref="Operation.Purchase"/> is available for Trustly payments.
        /// </summary>
        public Operation Operation { get; set; }

        /// <summary>
        /// Identifies the merchant that initiated the payment.
        /// </summary>
        public PayeeInfo PayeeInfo { get; set; }

        /// <summary>
        /// The reference to the payer from the merchant system, like e-mail address, mobile number, customer number etc.
        /// </summary>
        public string PayerReference { get; set; }

        /// <summary>
        /// The prices resource lists the prices related to a specific payment.
        /// </summary>
        public List<IPrice> Prices { get; set; }

        /// <summary>
        /// The urls resource lists urls that redirects users to relevant sites.
        /// </summary>
        public IUrls Urls { get; }

        /// <summary>
        /// The user agent string of the payer’s browser.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Object representing information of what the payment menu text fields should be populated with
        /// </summary>
        public TrustlyPrefillInfo PrefillInfo { get; set; }
    }
}