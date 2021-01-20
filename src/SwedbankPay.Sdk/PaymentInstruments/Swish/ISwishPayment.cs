using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    /// <summary>
    /// Describes how a Swish payment returned from the api look like.
    /// </summary>
    public interface ISwishPayment : IIdentifiable
    {
        /// <summary>
        /// The payment number , useful when there’s need to reference the payment in human communication.
        /// Not usable for programmatic identification of the payment, for that id should be used instead.
        /// </summary>
        long Number { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this payment was created.
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this payment was last updated.
        /// </summary>
        DateTime Updated { get; }

        /// <summary>
        /// The payment instrument used for this payment.
        /// </summary>
        PaymentInstrument Instrument { get; }

        /// <summary>
        /// The same as the Operation that was used to initiate the payment.
        /// </summary>
        Operation Operation { get; }

        /// <summary>
        /// The payment intent of the current payment.
        /// </summary>
        PaymentIntent Intent { get; }

        /// <summary>
        /// The current <seealso cref="Sdk.State"/> of the payment.
        /// </summary>
        State State { get; }

        /// <summary>
        /// The currency code this payment is to be paid in.
        /// </summary>
        Currency Currency { get; }

        /// <summary>
        /// Contains information of the prices resource.
        /// </summary>
        IPricesListResponse Prices { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> to be paid in this payment.
        /// </summary>
        Amount Amount { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> available for reversal on this payment.
        /// </summary>
        Amount RemainingReversalAmount { get; set; }

        /// <summary>
        /// A textual description for this payment.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The reference to the payer from the merchant system, like e-mail address, mobile number, customer number etc.
        /// </summary>
        string PayerReference { get; }

        /// <summary>
        /// User agent string identifying the initiator.
        /// </summary>
        string InitiatingSystemUserAgent { get; }

        /// <summary>
        /// The user agent string of the payer’s browser.
        /// </summary>
        string UserAgent { get; }

        /// <summary>
        /// The prefered language of the payer.
        /// </summary>
        Language Language { get; }

        /// <summary>
        /// Gives access to available transactions on this payment.
        /// </summary>
        ITransactionListResponse Transactions { get; }

        /// <summary>
        /// Gives access to available sales transactions on this payment.
        /// </summary>
        ISwishSaleListResponse Sales { get; }

        /// <summary>
        /// Gives access to available reversal transactions on this payment.
        /// </summary>
        IReversalsListResponse Reversals { get; }

        /// <summary>
        /// The <seealso cref="IUrls"/> sent in the initial request for this payment.
        /// </summary>
        IUrls Urls { get; }

        /// <summary>
        /// Identifies the merchant that initiated the payment.
        /// </summary>
        PayeeInfo PayeeInfo { get; }

        /// <summary>
        /// Metadata can be used to store data associated to a payment that can be retrieved later by performing a GET on the payment.
        /// Swedbank Pay does not use or process metadata, it is only stored on the payment so it can be retrieved later alongside the payment.
        /// An example where metadata might be useful is when several internal systems are involved in the payment process and the payment
        /// creation is done in one system and post-purchases take place in another.
        /// In order to transmit data between these two internal systems,
        /// the data can be stored in metadata on the payment so the internal systems do not need to communicate with each other directly.
        /// </summary>
        Metadata Metadata { get; }
    }
}