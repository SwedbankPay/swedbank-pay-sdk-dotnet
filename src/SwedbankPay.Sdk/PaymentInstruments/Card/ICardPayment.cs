using System;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPayment
    {
        /// <summary>
        /// The amount (including VAT, if any) to charge the payer,
        /// entered in the lowest monetary unit of the selected currency.
        /// </summary>
        Amount Amount { get; }

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
        PaymentIntent Intent { get; }
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
    }
}