using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface ICurrentPayment
    {
        /// <summary>
        /// The amount (including VAT, if any) to charge the payer, entered in the monetary unit of the selected currency.
        /// </summary>
        Amount Amount { get; }

        /// <summary>
        /// Resource to get available authorization transactions.
        /// </summary>
        IPaymentAuthorizationResponse Authorizations { get; }

        /// <summary>
        /// Resource to get available cancellation transactions.
        /// </summary>
        ICancellationsListResponse Cancellations { get; }

        /// <summary>
        /// Resource to get available capture transactions.
        /// </summary>
        ICapturesListResponse Captures { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> the current payment was created.
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// The currency of the payment.
        /// </summary>
        CurrencyCode Currency { get; }

        /// <summary>
        /// A 40 character length textual description of the purchase.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The payment instrument used for this payment order.
        /// </summary>
        PaymentInstrument Instrument { get; }

        /// <summary>
        /// The initial intent of this payment order.
        /// </summary>
        PaymentIntent Intent { get; }
        Language Language { get; }

        /// <summary>
        /// The transaction number, useful when there’s need to reference the transaction in human communication.
        /// Not usable for programmatic identification of the transaction, where id should be used instead.
        /// </summary>
        long Number { get; }

        /// <summary>
        /// The operation used to create this payment.
        /// </summary>
        Operation Operation { get; }

        /// <summary>
        /// Identifies the merchant that initiated the payment order.
        /// </summary>
        PayeeInfo PayeeInfo { get; }

        /// <summary>
        /// The reference to the payer from the merchant system, like e-mail address, mobile number, customer number etc.
        /// </summary>
        string PayerReference { get; }
        string PaymentToken { get; }

        /// <summary>
        /// The prices resource lists the prices related to a specific payment.
        /// </summary>
        IPricesListResponse Prices { get; }

        /// <summary>
        /// Resource to get available reversal transactions.
        /// </summary>
        IReversalsListResponse Reversals { get; }

        /// <summary>
        /// Resource to get available sales transactions.
        /// </summary>
        ISaleListResponse Sales { get; }

        /// <summary>
        /// The current state of the payment order.
        /// </summary>
        State State { get; }

        /// <summary>
        /// Resource to get available transactions.
        /// </summary>
        ITransactionListResponse Transactions { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this payment order was last updated.
        /// </summary>
        DateTime Updated { get; }

        /// <summary>
        /// Resource to get available URLs for this payment order.
        /// </summary>
        IUrls Urls { get; }

        /// <summary>
        /// The user agent string of the payer’s browser.
        /// </summary>
        string UserAgent { get; }
    }
}