using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    /// <summary>
    /// Request details for creating a Trustly payment.
    /// </summary>
    public class TrustlyPaymentDetails
    {
        /// <summary>
        /// Instantiates a new <see cref="TrustlyPaymentDetails"/> with the provided parameters.
        /// </summary>
        /// <param name="currency">The wanted currency of the payment.</param>
        /// <param name="prices">Prices object describing the payment price with different payment methods.</param>
        /// <param name="description">Textual description of the payment.</param>
        /// <param name="payerReference">A reference to the payer in the merchant system.</param>
        /// <param name="userAgent">The payers UserAgent string.</param>
        /// <param name="language">The payers preferred <seealso cref="Sdk.Language"/>.</param>
        /// <param name="urls">Object holding relevant URLs for this payment.</param>
        /// <param name="payeeInfo">Object with merchant information.</param>
        public TrustlyPaymentDetails(Currency currency,
                                                IEnumerable<IPrice> prices,
                                                string description,
                                                string payerReference,
                                                string userAgent,
                                                Language language,
                                                IUrls urls,
                                                IPayeeInfo payeeInfo)
        {
            Operation = Operation.Purchase;
            Intent = PaymentIntent.Sale;
            Currency = currency;
            Description = description;
            PayerReference = payerReference;
            UserAgent = userAgent ?? SwedbankPay.Sdk.UserAgent.Default;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;

            foreach (var price in prices)
            {
                Prices.Add(price);
            }
        }

        /// <summary>
        /// SEK, EUR. The currency of the provided <seealso cref="Amount"/>.
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

        /// <summary>
        /// Payers prefered language.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// Only <seealso cref="Operation.Purchase"/> is available for Trustly payments.
        /// </summary>
        public Operation Operation { get; set; }

        /// <summary>
        /// Identifies the merchant that initiated the payment.
        /// </summary>
        public IPayeeInfo PayeeInfo { get; set; }

        /// <summary>
        /// The reference to the payer from the merchant system, like e-mail address, mobile number, customer number etc.
        /// </summary>
        public string PayerReference { get; set; }

        /// <summary>
        /// The prices resource lists the prices related to a specific payment.
        /// </summary>
        public IList<IPrice> Prices { get; set; } = new List<IPrice>();

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