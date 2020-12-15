using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Object describing a authorization transaction for Vipps.
    /// </summary>
    public class AuthorizationTransaction : Identifiable
    {
        /// <summary>
        /// Instantiates a new <see cref="AuthorizationTransaction"/> with the provided parameters.
        /// </summary>
        /// <param name="id">A unique reference to this transaction.</param>
        /// <param name="created">The <seealso cref="DateTime"/> the transaction was created.</param>
        /// <param name="updated">The <seealso cref="DateTime"/> the transaction was last updated.</param>
        /// <param name="type">The transaction type.</param>
        /// <param name="state">The last known state of this transaction.</param>
        /// <param name="number">Unique number of this transaction.</param>
        /// <param name="amount">Amount to charge the payer.</param>
        /// <param name="vatAmount">Amount to charge the payer as value added taxes.</param>
        /// <param name="description">A textual description of the payment.</param>
        /// <param name="payeeReference">Unique reference to this transaction in the merchant system.</param>
        /// <param name="failedActivityName">If failed showes what activity failed.</param>
        /// <param name="failedErrorCode">If failed shows the error code.</param>
        /// <param name="failedReason">If failed gives the reason for the failure.</param>
        /// <param name="failedErrorDescription">If failed describes the failure.</param>
        /// <param name="isOperational">Indicates if this transaction was operational.</param>
        /// <param name="operations">Available operations for this transaction.</param>
        public AuthorizationTransaction(Uri id,
                                        DateTime created,
                                        DateTime updated,
                                        string type,
                                        State state,
                                        long number,
                                        Amount amount,
                                        Amount vatAmount,
                                        string description,
                                        string payeeReference,
                                        string failedReason,
                                        string failedActivityName,
                                        string failedErrorCode,
                                        string failedErrorDescription,
                                        bool isOperational,
                                        IOperationList operations)
            : base(id)
        {
            Created = created;
            Updated = updated;
            Type = type;
            State = state;
            Number = number;
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
            FailedReason = failedReason;
            FailedActivityName = failedActivityName;
            FailedErrorCode = failedErrorCode;
            FailedErrorDescription = failedErrorDescription;
            IsOperational = isOperational;
            Operations = operations;
        }

        /// <summary>
        /// The <seealso cref="Sdk.Amount"/> to charge the payer in the selected currency.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> the payment was created.
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// A textual description of the payment.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// If the authorization failed this gives the name of the failure code.
        /// </summary>
        public string FailedActivityName { get; }

        /// <summary>
        /// If the authorization failed this gives the failure code.
        /// </summary>
        public string FailedErrorCode { get; }

        /// <summary>
        /// If the authorization failed this gives the description of the failure code.
        /// </summary>
        public string FailedErrorDescription { get; }

        /// <summary>
        /// The human readable explanation of why the payment failed.
        /// </summary>
        public string FailedReason { get; }

        /// <summary>
        /// true if the transaction is operational; otherwise false.
        /// </summary>
        public bool IsOperational { get; }

        /// <summary>
        /// The transaction number, useful when there’s need to reference the transaction in human communication.
        /// Not usable for programmatic identification of the transaction, where the ID should be used instead.
        /// </summary>
        public long Number { get; }

        /// <summary>
        /// Available operations on this payment.
        /// </summary>
        public IOperationList Operations { get; }

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// </summary>
        public string PayeeReference { get; }

        /// <summary>
        /// Indicates the state of the transaction, usually initialized, completed orfailed.
        /// If a partial transaction has been done and further transactionsare possible,
        /// the state will be awaitingActivity.
        /// </summary>
        public State State { get; }

        /// <summary>
        /// Indicates the transaction type.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> the payment was last updated.
        /// </summary>
        public DateTime Updated { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) <seealso cref="Sdk.Amount"/>, entered in the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page,
        /// which only shows the total amount.
        /// This field is used to specify how much of the total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        public Amount VatAmount { get; }
    }
}