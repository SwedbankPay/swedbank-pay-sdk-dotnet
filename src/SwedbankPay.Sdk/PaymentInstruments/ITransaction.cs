using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    /// <summary>
    /// Object holding details about a transaction.
    /// </summary>
    public interface ITransaction : IIdentifiable
    {
        /// <summary>
        /// The <seealso cref="DateTime"/> this transaction was created.
        /// </summary>
        DateTime Created { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this transaction was last updated.
        /// </summary>
        DateTime Updated { get; }

        /// <summary>
        /// The latest activity on this transaction.
        /// </summary>
        string Activity { get; }

        /// <summary>
        /// The amount (including VAT, if any) to charge the payer, entered in the lowest monetary unit of the selected currency.
        /// </summary>
        Amount Amount { get; }

        /// <summary>
        /// A 40 character length textual description of the purchase.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Indicated wether this transaction is operational.
        /// </summary>
        bool IsOperational { get; }

        /// <summary>
        /// The transaction number, useful when there’s need to reference the transaction in human communication.
        /// Not usable for programmatic identification of the transaction, where id should be used instead.
        /// </summary>
        long Number { get; }

        /// <summary>
        /// List of available operations on this transaction.
        /// </summary>
        IOperationList Operations { get; }

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// In Invoice Payments payeeReference is used as an invoice/receipt number, if the receiptReference is not defined.
        /// </summary>
        string PayeeReference { get; }

        /// <summary>
        /// Indicates the state of the transaction, usually <seealso cref="State.Initialized"/>,
        /// <seealso cref="State.Completed"/> or <seealso cref="State.Failed"/>.
        /// If a partial reversal has been done and further transactionsare possible,
        /// the state will be <seealso cref="State.AwaitingActivity"/>.
        /// </summary>
        State State { get; }

        /// <summary>
        /// Indicates what type of transaction this is.
        /// </summary>
        TransactionType Type { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page,
        /// which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        Amount VatAmount { get; }

        /// <summary>
        /// Indicates any problems with the transaction.
        /// </summary>
        IProblem Problem { get; }
    }
}