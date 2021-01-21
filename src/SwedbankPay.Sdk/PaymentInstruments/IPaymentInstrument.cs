using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Base interface for payment instruments
    /// </summary>
    public interface IPaymentInstrument: IIdentifiable
    {
        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> to be paid.
        /// </summary>
        Amount Amount { get; }

        /// <summary>
        /// Currently available list of cancellations.
        /// </summary>
        ICancellationsList Cancellations { get; }

        /// <summary>
        /// Currently available list of captures.
        /// </summary>
        ICapturesList Captures { get; }

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
        /// The <seealso cref="Sdk.Amount"/> available for cancelling on this payment.
        /// </summary>
        Amount RemainingCancellationAmount { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> available for capturing on this payment.
        /// </summary>
        Amount RemainingCaptureAmount { get; }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> available for reversing on this payment.
        /// </summary>
        Amount RemainingReversalAmount { get; }

        /// <summary>
        /// Currently available list of reversals.
        /// </summary>

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
        /// The payments VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
        /// This field is used to specify how much of the total amount the VAT will be. Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        Amount VatAmount { get; }

        /// <summary>
        /// The reversal resource contains information about the reversal transaction made
        /// </summary>
        IReversalsList Reversals { get; }

        /// <summary>
        /// Metadata can be used to store data associated to a payment that can be retrieved later by performing a GET on the payment. 
        /// Swedbank Pay does not use or process metadata, it is only stored on the payment so it can be retrieved later alongside the payment. 
        /// An example where metadata might be useful is when several internal systems are involved in the payment process 
        /// and the payment creation is done in one system and post-purchases take place in another. 
        /// In order to transmit data between these two internal systems, 
        /// the data can be stored in metadata on the payment so the internal systems do not need to communicate with each other directly.
        /// </summary>
        Metadata Metadata { get; }
    }
}