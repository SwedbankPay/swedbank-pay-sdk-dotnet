using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAuthorizationTransaction : IdLink
    {
        public CardPaymentAuthorizationTransaction(DateTime created,
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
        /// Operations that are possible to perform on the transaction in its current state.
        /// </summary>
        public IOperationList Operations { get; }

        /// <summary>
        /// A unique reference from the merchant system.
        /// It is set per operation to ensure an exactly-once delivery of a transactional operation.
        /// </summary>
        public string PayeeReference { get; }
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