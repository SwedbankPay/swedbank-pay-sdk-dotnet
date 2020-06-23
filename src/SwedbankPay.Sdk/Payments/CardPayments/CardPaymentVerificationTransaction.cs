using System;
using System.Collections.Generic;
using System.Text;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentVerificationTransaction : IdLink
    {
        public CardPaymentVerificationTransaction(DateTime created,
                                        DateTime updated,
                                        string type,
                                        State state,
                                        string number,
                                        Amount amount,
                                        Amount vatAmount,
                                        string description,
                                        string payeeReference,
                                        string failedReason,
                                        string failedActivityName,
                                        string failedErrorCode,
                                        string failedErrorDescription,
                                        bool isOperational,
                                        OperationList operations)
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

        public DateTime Created { get; }
        public DateTime Updated { get; }
        public string Type { get; }
        public State State { get; }
        public string Number { get; }
        public Amount Amount { get; }
        public Amount VatAmount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
        public string FailedActivityName { get; }
        public string FailedErrorCode { get; }
        public string FailedErrorDescription { get; }
        public string FailedReason { get; }
        public bool IsOperational { get; }
        public OperationList Operations { get; }
    }
}



