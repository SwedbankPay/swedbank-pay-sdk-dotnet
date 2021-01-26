using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Details needed to create a Vipps payment.
    /// </summary>
    public class VippsPaymentRequestDetails
    {
        /// <summary>
        /// Instantiates a <see cref="VippsPaymentRequestDetails"/> with the provided parameters.
        /// </summary>
        /// <param name="operation">The initial operation of this payment.</param>
        /// <param name="intent">The intent of this payment.</param>
        /// <param name="currency">The wanted currency of the payment.</param>
        /// <param name="prices">List of payment instrument prices.</param>
        /// <param name="description">Textual description of the payment.</param>
        /// <param name="payerReference">Merchant reference to the payer.</param>
        /// <param name="userAgent">The payers UserAgent string.</param>
        /// <param name="language">The payers prefered language.</param>
        /// <param name="urls">Object with relevant URLs for the payment.</param>
        /// <param name="payeeInfo">Object with information about the merchant.</param>
        protected internal VippsPaymentRequestDetails(Operation operation,
                                                PaymentIntent intent,
                                                Currency currency,
                                                IEnumerable<IPrice> prices,
                                                string description,
                                                string payerReference,
                                                string userAgent,
                                                Language language,
                                                IUrls urls,
                                                IPayeeInfo payeeInfo)
        {
            Operation = operation ?? throw new ArgumentNullException(nameof(operation));
            Intent = intent;
            Currency = currency;
            Description = description;
            PayerReference = payerReference;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;

            foreach (var price in prices)
            {
                Prices.Add(price);
            }
        }

        /// <summary>
        /// The currency to be paid with.
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// A textual description of the payment.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Set this to true if you want to create a paymentToken for future use as One Click.
        /// </summary>
        public bool GeneratePaymentToken { get; set; }

        /// <summary>
        /// Set this to true if you want to create a recurrenceToken for future use Recurring purchases (subscription payments).
        /// </summary>
        public bool GenerateRecurrenceToken { get; set; }

        /// <summary>
        /// <seealso cref="PaymentIntent.Authorization"/> reserves the amount, and is followed by a cancellation or capture of funds.
        /// <seealso cref="PaymentIntent.AutoCapture"/> is a one phase option that enable capture of funds automatically after authorization.
        /// </summary>
        public PaymentIntent Intent { get; set; }

        /// <summary>
        /// Payers prefered language.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// Metadata can be used to store data associated to a payment that can be retrieved later by performing a GET on the payment.
        /// Swedbank Pay does not use or process metadata, it is only stored on the payment so it can be retrieved later alongside the payment.
        /// An example where metadata might be useful is when several internal systems are involved in the payment process
        /// and the payment creation is done in one system and post-purchases take place in another.
        /// In order to transmit data between these two internal systems,
        /// the data can be stored in metadata on the payment so the internal systems do not need to communicate with each other directly.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Initial operation of the payment.
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
        /// Previously generated payment token, allows for performing a payment without payer involvement.
        /// </summary>
        public string PaymentToken { get; set; }

        /// <summary>
        /// The prices resource lists the prices related to this payment.
        /// </summary>
        public IList<IPrice> Prices { get; set; } = new List<IPrice>();

        /// <summary>
        /// The Urls resource lists the urls related to this payment.
        /// </summary>
        public IUrls Urls { get; }

        /// <summary>
        /// The user agent string of the payer’s browser.
        /// </summary>
        public string UserAgent { get; set; }
    }
}