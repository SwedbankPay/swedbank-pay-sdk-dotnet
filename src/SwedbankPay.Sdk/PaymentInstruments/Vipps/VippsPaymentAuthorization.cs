using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentAuthorization : IdLink
    {
        public VippsPaymentAuthorization(
                             string vippsTransactionId,
                             string mobileNumber,
                             AuthorizationTransaction transaction)
        {
            VippsTransactionId = vippsTransactionId;
            MobileNumber = mobileNumber;
            Transaction = transaction;
        }


        public string VippsTransactionId { get; }
        public string MobileNumber { get; }
        public AuthorizationTransaction Transaction { get; }
    }

    public class AuthorizationTransaction : IdLink
    {
        public AuthorizationTransaction(DateTime created,
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


        public Amount Amount { get; }
        public DateTime Created { get; }
        public string Description { get; }
        public string FailedActivityName { get; }
        public string FailedErrorCode { get; }
        public string FailedErrorDescription { get; }
        public string FailedReason { get; }
        public bool IsOperational { get; }
        public string Number { get; }
        public IOperationList Operations { get; }
        public string PayeeReference { get; }
        public State State { get; }
        public string Type { get; }
        public DateTime Updated { get; }
        public Amount VatAmount { get; }
    }
}