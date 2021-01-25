using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class AuthorizationTransaction : Identifiable, IAuthorizationTransaction
    {
        public AuthorizationTransaction(MobilePayPaymentAuthorizationTransactionDto dto)
            :base(dto.Id)
        {
            Created = dto.Created;
            Updated = dto.Updated;
            Type = dto.Type;
            State = dto.State;
            Number = dto.Number;
            Amount = dto.Amount;
            VatAmount = dto.VatAmount;
            Description = dto.Description;
            PayeeReference = dto.PayeeReference;
            FailedReason = dto.FailedReason;
            FailedActivityName = dto.FailedActivityName;
            FailedErrorCode = dto.FailedErrorCode;
            FailedErrorDescription = dto.FailedErrorDescription;
            IsOperational = dto.IsOperational;
            Operations = dto.Operations?.Map();
        }

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

        public Amount Amount { get; }

        public DateTime Created { get; }

        
        public string Description { get; }

        
        public string FailedActivityName { get; }

        public string FailedErrorCode { get; }

        public string FailedErrorDescription { get; }

        public string FailedReason { get; }

        public bool IsOperational { get; }

        public long Number { get; }

        public IOperationList Operations { get; }

        public string PayeeReference { get; }

        public State State { get; }

        public string Type { get; }

        public DateTime Updated { get; }

        
        public Amount VatAmount { get; }
    }
}