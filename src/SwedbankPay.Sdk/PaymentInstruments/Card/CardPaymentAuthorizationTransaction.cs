using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Holds transactional details about authorization a card payment.
    /// </summary>
    public class CardPaymentAuthorizationTransaction : Identifiable
    {
        /// <summary>
        /// Constructs a new card payment authorization request.
        /// </summary>
        /// <param name="id">The unique ID of this transaction.</param>
        /// <param name="created">The <see cref="DateTime"/> the payment is created.</param>
        /// <param name="updated">The <see cref="DateTime"/> the payment was last updated.</param>
        /// <param name="type">The type of the transaction.</param>
        /// <param name="state">The current <see cref="Sdk.State"/> of the transaction.</param>
        /// <param name="number">The number reference for the transaction.</param>
        /// <param name="amount">The <seealso cref="Sdk.Amount"/> used for the payment.</param>
        /// <param name="vatAmount">The Vat<seealso cref="Sdk.Amount"/> used for the payment.</param>
        /// <param name="description">The textual description of the payment.</param>
        /// <param name="payeeReference">The unique payer reference.</param>
        /// <param name="failedReason">The reason this transaction failed.</param>
        /// <param name="failedActivityName">The activity that caused the failure.</param>
        /// <param name="failedErrorCode">The error code of the failure.</param>
        /// <param name="failedErrorDescription">A description of the failure.</param>
        /// <param name="isOperational">Is this transaction operational?</param>
        /// <param name="problem">Any problems that may have occured.</param>
        /// <param name="operations">Available operations.</param>
        public CardPaymentAuthorizationTransaction(Uri id,
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
                                        IProblemResponse problem,
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
            Problem = problem;
            Operations = operations;
        }

        /// <summary>
        /// Amount is entered in the lowest momentary units of the selected currency.
        /// </summary>
        public Amount Amount { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this authorization was created.
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// A 40 character length textual description of the purchase.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The name of the failed activity.
        /// </summary>
        public string FailedActivityName { get; }

        /// <summary>
        /// The error code of the failure.
        /// </summary>
        public string FailedErrorCode { get; }

        /// <summary>
        /// A textual description of the failure.
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
        /// Not usable for programmatic identification of the transaction, where <see cref="Identifiable.Id"/> should be used instead.
        /// </summary>
        public long Number { get; }

        /// <summary>
        /// Operations that are possible to perform on the transaction in its current state.
        /// </summary>
        public IOperationList Operations { get; }

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// </summary>
        public string PayeeReference { get; }

        /// <summary>
        /// Any problems will be listed here.
        /// </summary>
        public IProblemResponse Problem { get; }

        /// <summary>
        /// Indicates the state of the payment, not the state of any transactions performed on the payment.
        /// </summary>
        public State State { get; }

        /// <summary>
        /// Indicates the transaction type.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// The <seealso cref="DateTime"/> this resource was last updated.
        /// </summary>
        public DateTime Updated { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        public Amount VatAmount { get; }
    }
}