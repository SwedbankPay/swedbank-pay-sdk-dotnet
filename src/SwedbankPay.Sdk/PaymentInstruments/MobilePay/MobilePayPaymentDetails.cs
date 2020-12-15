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
        /// <param name="userAgent">The payers user agent string.</param>
        /// <param name="language">The payers prefered <see cref="Sdk.Language"/>.</param>
        /// <param name="urls">Object with relevant URLs for this payment.</param>
        /// <param name="payeeInfo">Object containing information about the merchant.</param>
        public MobilePayPaymentDetails(Operation operation,
                                                PaymentIntent intent,
                                                Currency currency,
                                                List<IPrice> prices,
                                                string description,
                                                string userAgent,
                                                Language language,
                                                IUrls urls,
                                                PayeeInfo payeeInfo)
        {
            Operation = operation ?? throw new ArgumentNullException(nameof(operation));
            Intent = intent;
            Currency = currency;
            Prices = prices;
            Description = description;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public PaymentIntent Intent { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Operation Operation { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public PayeeInfo PayeeInfo { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string PayerReference { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public List<IPrice> Prices { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IUrls Urls { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public PrefillInfo PrefillInfo { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public MetadataResponse Metadata { get; set; }
    }
}
