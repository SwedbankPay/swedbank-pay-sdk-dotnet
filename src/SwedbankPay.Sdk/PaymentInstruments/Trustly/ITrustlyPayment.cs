using System;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public interface ITrustlyPayment
    {
        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this payment.
        /// </summary>
        public Uri Id { get; }
        
        /// <summary>
        /// The amount (including VAT, if any) to charge the payer, entered in the selected currency.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> the payment was created.
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> the payment was last updated.
        /// </summary>
        public DateTime Updated { get; }

        /// <summary>
        /// THe currency of the provided amount.
        /// SEK or EUR.
        /// </summary>
        public CurrencyCode Currency { get; }

        /// <summary>
        /// A 40 character length textual description of the purchase.
        /// </summary>
        public string Description { get; }
        public PaymentInstrument Instrument { get; }

        /// <summary>
        /// <seealso cref="PaymentIntent.Sale"/> is the only intent option for Trustly payments.
        /// Performs the payment when the end-user gets redirected and completes the payment.
        /// </summary>
        public PaymentIntent Intent { get; }
        public Language Language { get; }
        public long Number { get; }

        /// <summary>
        /// The operation that the payment is supposed to perform. 
        /// For Trustly payments, this will always be Purchase as it is currently the only available operation.
        /// </summary>
        public Operation Operation { get; }

        /// <summary>
        /// Identifies the merchant that initiated the payment.
        /// </summary>
        public PayeeInfo PayeeInfo { get; }

        /// <summary>
        /// A resource to get a list of all available transactions.
        /// </summary>
        public ITransactionListResponse Transactions { get; }

        /// <summary>
        /// The reference to the payer from the merchant system,
        /// like e-mail address, mobile number, customer number etc.
        /// </summary>
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }

        /// <summary>
        /// The prices resource lists the prices related to a specific payment.
        /// </summary>
        public IPricesListResponse Prices { get; }

        /// <summary>
        ///  Indicates the state of the payment, not the state of any transactions performed on the payment.
        ///  To find the state of the payment’s transactions (such as a successful authorization),
        ///  see the transactions resource or the different specialized type-specific resources
        /// </summary>
        public State State { get; }

        /// <summary>
        /// The URI to the urls resource where all URIs related to the payment can be retrieved.
        /// </summary>
        public IUrls Urls { get; }

        /// <summary>
        /// The User-Agent string of the payer’s web browser.
        /// </summary>
        public string UserAgent { get; }

        /// <summary>
        /// Metadata can be used to store data associated to a payment that can be retrieved later by performing a GET on the payment.
        /// Swedbank Pay does not use or process metadata, it is only stored on the payment so it can be retrieved later alongside the payment.
        /// An example where metadata might be useful is when several internal systems are involved in the payment process
        /// and the payment creation is done in one system and post-purchases take place in another.
        /// In order to transmit data between these two internal systems, the data can be stored in metadata on the payment so the
        /// internal systems do not need to communicate with each other directly.
        /// </summary>
        public MetadataResponse Metadata { get; }
    }
}