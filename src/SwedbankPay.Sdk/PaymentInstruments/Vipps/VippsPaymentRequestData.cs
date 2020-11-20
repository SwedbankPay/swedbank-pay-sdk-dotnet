using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentRequestData
    {
        protected internal VippsPaymentRequestData(Operation operation,
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
                                                string paymentToken = null)
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
        public Language Language { get; set; }

        /// <summary>
        /// Metadata can be used to store data associated to a payment that can be retrieved later by performing a GET on the payment.
        /// Swedbank Pay does not use or process metadata, it is only stored on the payment so it can be retrieved later alongside the payment.
        /// An example where metadata might be useful is when several internal systems are involved in the payment process
        /// and the payment creation is done in one system and post-purchases take place in another.
        /// In order to transmit data between these two internal systems,
        /// the data can be stored in metadata on the payment so the internal systems do not need to communicate with each other directly.
        /// </summary>
        public Dictionary<string, object> Metadata { get; }
        public Operation Operation { get; set; }

        /// <summary>
        /// Identifies the merchant that initiated the payment.
        /// </summary>
        public PayeeInfo PayeeInfo { get; set; }

        /// <summary>
        /// The reference to the payer from the merchant system, like e-mail address, mobile number, customer number etc.
        /// </summary>
        public string PayerReference { get; set; }
        public string PaymentToken { get; set; }

        /// <summary>
        /// The prices resource lists the prices related to this payment.
        /// </summary>
        public List<IPrice> Prices { get; set; }

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