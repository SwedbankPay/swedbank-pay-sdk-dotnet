using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Object containing detailed information about a invoice payment.
    /// </summary>
    public class InvoicePaymentRequestDetails : IPaymentRequestDetails
    {
        /// <summary>
        /// Instantiates a <see cref="InvoicePaymentRequestDetails"/> with the provided parameters.
        /// </summary>
        /// <param name="operation">The initial API operation for this invoice request.</param>
        /// <param name="intent">The initial payment intent for this invoice.</param>
        /// <param name="currency">The <seealso cref="Currency"/> this payment will be paid in.</param>
        /// <param name="prices">A list of objects detailing price differences between different payment instruments.</param>
        /// <param name="description">A textual description of what is being paid.</param>
        /// <param name="userAgent">The payers UserAgent string.</param>
        /// <param name="language">The payers prefered <seealso cref="Sdk.Language"/>.</param>
        /// <param name="urls">Object containing relevant URLs for this payment.</param>
        /// <param name="payeeInfo">Object with merchant information.</param>
        /// <param name="generatePaymentToken">Set if you want to generate a payment token for later use for this payment.</param>
        /// <param name="generateRecurrenceToken">Set if you want this to be a recurring payment.</param>
        /// <param name="payerReference">A transactionally unique payer reference from the merchant system.</param>
        /// <param name="metadata">Used to store meta data on the payment.</param>
        /// <param name="paymentToken">A previously generated payment token for this payment.</param>
        /// <param name="prefillInfo">Pre-fills the payment window with known information about the payer.</param>
        public InvoicePaymentRequestDetails(Operation operation,
                                                    PaymentIntent intent,
                                                    Currency currency,
                                                    List<IPrice> prices,
                                                    string description,
                                                    string payerReference,
                                                    bool generatePaymentToken,
                                                    bool generateRecurrenceToken,
                                                    string userAgent,
                                                    Language language,
                                                    IUrls urls,
                                                    PayeeInfo payeeInfo,
                                                    Dictionary<string, object> metadata = null,
                                                    string paymentToken = null,
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
            GeneratePaymentToken = generatePaymentToken;
            GenerateRecurrenceToken = generateRecurrenceToken;
            PaymentToken = paymentToken;
            PrefillInfo = prefillInfo;
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
        public bool GeneratePaymentToken { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool GenerateRecurrenceToken { get; set; }

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
        public Dictionary<string, object> Metadata { get; }

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
        public string PaymentToken { get; set; }

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
    }

}