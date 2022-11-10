using System;

namespace SwedbankPay.Sdk.PaymentInstruments;

/// <summary>
/// Object describing a authorization transaction.
/// </summary>
public interface IAuthorizationTransaction
{
    /// <summary>
    /// The <seealso cref="Sdk.Amount"/> to charge the payer in the selected currency.
    /// </summary>
    Amount Amount { get; }

    /// <summary>
    /// The <seealso cref="DateTime"/> the payment was created.
    /// </summary>
    DateTime Created { get; }

    /// <summary>
    /// A textual description of the payment.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// If the authorization failed this gives the name of the failure code.
    /// </summary>
    string FailedActivityName { get; }

    /// <summary>
    /// If the authorization failed this gives the failure code.
    /// </summary>
    string FailedErrorCode { get; }

    /// <summary>
    /// If the authorization failed this gives the description of the failure code.
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
    /// Not usable for programmatic identification of the transaction, where the ID should be used instead.
    /// </summary>
    long Number { get; }

    /// <summary>
    /// Available operations on this payment.
    /// </summary>
    IOperationList Operations { get; }

    /// <summary>
    /// A unique reference from the merchant system.
    /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
    /// </summary>
    string PayeeReference { get; }

    /// <summary>
    /// Indicates the state of the transaction, usually initialized, completed orfailed.
    /// If a partial transaction has been done and further transactionsare possible,
    /// the state will be awaitingActivity.
    /// </summary>
    State State { get; }

    /// <summary>
    /// Indicates the transaction type.
    /// </summary>
    string Type { get; }

    /// <summary>
    /// The <seealso cref="DateTime"/> the payment was last updated.
    /// </summary>
    DateTime Updated { get; }

    /// <summary>
    /// The payment’s VAT (Value Added Tax) <seealso cref="Sdk.Amount"/>, entered in the selected currency.
    /// The vatAmount entered will not affect the amount shown on the payment page,
    /// which only shows the total amount.
    /// This field is used to specify how much of the total amount the VAT will be.
    /// Set to 0 (zero) if there is no VAT amount charged.
    /// </summary>
    Amount VatAmount { get; }
}