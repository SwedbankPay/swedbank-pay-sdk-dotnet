using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class AuthorizationTransaction : Identifiable
    {
        public AuthorizationTransaction(DateTime created,
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
        public string FailedActivityName { get; }
        public string FailedErrorCode { get; }
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
        /// Not usable for programmatic identification of the transaction, where <see cref="Id"/> should be used instead.
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