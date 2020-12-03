using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// Object describing a payment for the Mobile Pay payment instrument.
    /// </summary>
    public interface IMobilePayPayment
    {
        /// <summary>
        /// The relative URI and unique identifier of the capture resource this capture belongs to.
        /// </summary>
        Uri Id { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> to be paid.
        /// </summary>
        Amount Amount { get; }

        /// <summary>
        /// Currently available list of authorizations.
        /// </summary>
        IMobilePayPaymentAuthorizationListResponse Authorizations { get; }

        /// <summary>
        /// Currently available list of cancellations.
        /// </summary>
        ICancellationsListResponse Cancellations { get; }

        /// <summary>
        /// Currently available list of captures.
        /// </summary>
        ICapturesListResponse Captures { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> the payment was created.
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this payment was last updated.
        /// </summary>
        DateTime Updated { get; }

        /// <summary>
        /// The currency this payment is to be paid in.
        /// </summary>
        Currency Currency { get; }

        /// <summary>
        /// A textual description of what this payment is for.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The payment instrument used by the payer.
        /// </summary>
        PaymentInstrument Instrument { get; }

        /// <summary>
        /// The <seealso cref="PaymentIntent"/> of this payment.
        /// </summary>
        PaymentIntent Intent { get; }

        /// <summary>
        /// The prefered <seealso cref="Sdk.Language"/> for this payment.
        /// </summary>
        Language Language { get; }

        /// <summary>
        /// The payment number , useful when there’s need to reference the payment in human communication.
        /// Not usable for programmatic identification of the payment, for that id should be used instead.
        /// </summary>
        long Number { get; }

        /// <summary>
        /// The operation used to initiate this payment.
        /// </summary>
        Operation Operation { get; }

        /// <summary>
        /// Identifies the merchant that initiated the payment.
        /// </summary>
        PayeeInfo PayeeInfo { get; }

        /// <summary>
        /// The reference to the payer from the merchant system, like e-mail address, mobile number, customer number etc.
        /// </summary>
        string PayerReference { get; }

        /// <summary>
        /// The system user agent used
        /// </summary>
        string InitiatingSystemUserAgent { get; }

        /// <summary>
        /// Gives access to <seealso cref="IPrice"/> resource if available.
        /// </summary>
        IPricesListResponse Prices { get; }

        /// <summary>
        /// Currently available list of reversals.
        /// </summary>
        IReversalsListResponse Reversals { get; }

        /// <summary>
        /// The current <seealso cref="Sdk.State"/> of the payment.
        /// </summary>
        State State { get; }

        /// <summary>
        /// Currently available list of transactions.
        /// </summary>
        ITransactionListResponse Transactions { get; }

        /// <summary>
        /// The <seealso cref="IUrls"/> used to iniate this payment.
        /// </summary>
        IUrls Urls { get; }

        /// <summary>
        /// The user agent string of the payer’s browser.
        /// </summary>
        string UserAgent { get; }

        /// <summary>
        /// Metadata can be used to store data associated to a payment that can be retrieved later by performing a GET on the payment. 
        /// Swedbank Pay does not use or process metadata, it is only stored on the payment so it can be retrieved later alongside the payment. 
        /// An example where metadata might be useful is when several internal systems are involved in the payment process 
        /// and the payment creation is done in one system and post-purchases take place in another. 
        /// In order to transmit data between these two internal systems, 
        /// the data can be stored in metadata on the payment so the internal systems do not need to communicate with each other directly.
        /// </summary>
        MetadataResponse Metadata { get; }
    }
}