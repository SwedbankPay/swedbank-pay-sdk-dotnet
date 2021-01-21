using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Holds transactional details about authorization a card payment.
    /// </summary>
    public interface ICardPaymentAuthorizationTransaction
    {
        /// <summary>
        /// Amount is entered in the lowest momentary units of the selected currency.
        /// </summary>
        Amount Amount { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this authorization was created.
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// A 40 character length textual description of the purchase.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The name of the failed activity.
        /// </summary>
        string FailedActivityName { get; }

        /// <summary>
        /// The error code of the failure.
        /// </summary>
        string FailedErrorCode { get; }

        /// <summary>
        /// A textual description of the failure.
        /// </summary>
        string FailedErrorDescription { get; }

        /// <summary>
        /// The human readable explanation of why the payment failed.
        /// </summary>
        string FailedReason { get; }

        /// <summary>
        /// true if the transaction is operational; otherwise false.
        /// </summary>
        bool IsOperational { get; }

        /// <summary>
        /// The transaction number, useful when there’s need to reference the transaction in human communication.
        /// Not usable for programmatic identification of the transaction, where <see cref="Identifiable.Id"/> should be used instead.
        /// </summary>
        long Number { get; }

        /// <summary>
        /// Operations that are possible to perform on the transaction in its current state.
        /// </summary>
        IOperationList Operations { get; }

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// </summary>
        string PayeeReference { get; }

        /// <summary>
        /// Any problems will be listed here.
        /// </summary>
        IProblemResponse Problem { get; }

        /// <summary>
        /// Indicates the state of the payment, not the state of any transactions performed on the payment.
        /// </summary>
        State State { get; }

        /// <summary>
        /// Indicates the transaction type.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this resource was last updated.
        /// </summary>
        DateTime Updated { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        Amount VatAmount { get; }
    }
}