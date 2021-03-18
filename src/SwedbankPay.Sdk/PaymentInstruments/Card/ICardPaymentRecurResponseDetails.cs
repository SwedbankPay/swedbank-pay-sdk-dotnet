using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Transactional details about a recurring credit card payment.
    /// </summary>
    public interface ICardPaymentRecurResponseDetails: IIdentifiable
    {
        /// <summary>
        /// The created recurrenceToken.
        /// </summary>
        string RecurrenceToken { get; }

        /// <summary>
        /// The transaction number, useful when there’s need to reference the transaction in human communication.
        /// Not usable for programmatic identification of the transaction, where <see cref="IIdentifiable.Id"/> should be used instead.
        /// </summary>
        long Number { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this recur payment was created.
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this recur payment was last updated.
        /// </summary>
        DateTime Updated { get; }

        /// <summary>
        /// The <seealso cref="PaymentInstrument"/> used for this recur payment.
        /// </summary>
        PaymentInstrument Instrument { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Operation"/> used to create this payment.
        /// </summary>
        Operation Operation { get; }

        /// <summary>
        /// The current <seealso cref="Sdk.State"/> of the recur payment.
        /// </summary>
        State State { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Currency"/> used for this recur payment.
        /// </summary>
        Currency Currency { get; }

        /// <summary>
        /// A resource to get <seealso cref="IPrice"/> for this recur payment.
        /// </summary>
        IPriceListResponse Prices { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> (including VAT, if any) to charge the payer,
        /// entered in the lowest monetary unit of the selected currency. 
        /// </summary>
        Amount Amount { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> available for later capture.
        /// </summary>
        Amount RemainingCaptureAmount { get; }

        /// <summary>
        /// The remainder of authorized amount (<seealso cref="Amount"/>) not yet captured.
        /// </summary>
        Amount RemainingCancellationAmount { get; }

        /// <summary>
        /// A textual human readable description of the purchase.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The user agent of the initiating system.
        /// </summary>
        string InitiatingSystemUserAgent { get; }

        /// <summary>
        /// The User-Agent string of the payer’s web browser.
        /// </summary>
        string UserAgent { get; }

        /// <summary>
        /// The current transactions resource.
        /// </summary>
        ITransactionListResponse Transactions { get; }

        /// <summary>
        /// The current authorizations resource.
        /// </summary>
        ICardPaymentAuthorization Authorizations { get; }

        /// <summary>
        /// The <seealso cref="Uri"/> to the urls resource where all URIs related to the payment can be retrieved.
        /// </summary>
        IUrls Urls { get; }

        /// <summary>
        /// Identifies the merchant that initiated the payment.
        /// </summary>
        IPayeeInfo PayeeInfo { get; }

        /// <summary>
        /// Metadata can be used to store data associated to a payment that can be retrieved later by
        /// performing a GET on the payment. Swedbank Pay does not use or process metadata,
        /// it is only stored on the payment so it can be retrieved later alongside the payment.
        /// An example where metadata might be useful is when several internal systems are involved
        /// in the payment process and the payment creation is done in one system and post-purchases take place in another.
        /// In order to transmit data between these two internal systems,
        /// the data can be stored in metadata on the payment so the internal systems do not need to
        /// communicate with each other directly.
        /// </summary>
        Metadata MetaData { get; }
    }
}