using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Describes a credt card payment.
    /// </summary>
    public interface ICardPayment
    {
        /// <summary>
        /// The amount (including VAT, if any) to charge the payer,
        /// entered in the lowest monetary unit of the selected currency.
        /// </summary>
        Amount Amount { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        Amount VatAmount { get; }

        /// <summary>
        /// The available amount to capture.
        /// </summary>
        Amount RemainingCaptureAmount { get; }

        /// <summary>
        /// The available amount to cancel.
        /// </summary>
        Amount RemainingCancellationAmount { get; }

        /// <summary>
        /// The available amount to reverse.
        /// </summary>
        Amount RemainingReversalAmount { get; }

        /// <summary>
        /// The available authorization transactions for this payment.
        /// </summary>
        ICardPaymentAuthorizationListResponse Authorizations { get; }

        /// <summary>
        /// The available cancellations for this payment.
        /// </summary>
        ICancellationsListResponse Cancellations { get; }

        /// <summary>
        /// The available captures for this payment.
        /// </summary>
        ICapturesListResponse Captures { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> of when the payment was created.
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> of when the payment was last updated.
        /// </summary>
        DateTime Updated { get; }

        /// <summary>
        /// The currency of this payment.
        /// </summary>
        Currency Currency { get; }

        /// <summary>
        /// Your description of this payment.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// A unique ID for this payment.
        /// </summary>
        Uri Id { get; }

        /// <summary>
        /// The payment instrument used for this payment.
        /// </summary>
        PaymentInstrument Instrument { get; }

        /// <summary>
        /// The initial intent of the payment.
        /// </summary>
        PaymentIntent Intent { get; }

        /// <summary>
        /// The prefered <see cref="Sdk.Language"/> of the payer.
        /// </summary>
        Language Language { get; }

        /// <summary>
        /// The payment number, useful when there’s need to reference the payment in human communication.
        /// Not usable for programmatic identification of the payment, for that <see cref="Id"/> should be used instead.
        /// </summary>
        long Number { get; }

        /// <summary>
        /// Determines the initial operation, that defines the type card payment created.
        /// </summary>
        Operation Operation { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        PayeeInfo PayeeInfo { get; }

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// </summary>
        string PayerReference { get; }

        /// <summary>
        /// The user agent of the initiating system.
        /// </summary>
        string InitiatingSystemUserAgent { get; }

        /// <summary>
        /// Lists the prices related to a specific payment.
        /// </summary>
        IPricesListResponse Prices { get; }

        /// <summary>
        /// The available reversals for this payment.
        /// </summary>
        IReversalsListResponse Reversals { get; }

        /// <summary>
        /// The current state of this payment.
        /// </summary>
        State State { get; }

        /// <summary>
        /// All available <seealso cref="ITransaction"/> of this payment.
        /// </summary>
        ITransactionListResponse Transactions { get; }

        /// <summary>
        /// The <seealso cref="IUrls"/> set for this payment.
        /// </summary>
        IUrls Urls { get; }

        /// <summary>
        /// The useragent string of the payee.
        /// </summary>
        string UserAgent { get; }

        /// <summary>
        /// Metadata set for this payment.
        /// </summary>
        MetadataResponse Metadata { get; }

        /// <summary>
        /// The created recurrenceToken, if <seealso cref="Operation.Verify"/>, <seealso cref="Operation.Recur"/> generateRecurrenceToken: true was used.
        /// </summary>
        string RecurrenceToken { get; }
    }
}