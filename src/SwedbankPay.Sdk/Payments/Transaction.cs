﻿using System;

namespace SwedbankPay.Sdk.Payments
{
    public class Transaction
    {
        public Transaction(Uri id,
                           DateTime created,
                           DateTime updated,
                           TransactionType type,
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
                           OperationList operations,
                           string activity)
        {
            Id = id;
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
            Activity = activity;
        }


        public Amount Amount { get; }
        public DateTime Created { get; }
        public string Description { get; }
        public string FailedActivityName { get; }
        public string FailedErrorCode { get; }
        public string FailedErrorDescription { get; }
        public string FailedReason { get; }
        public Uri Id { get; }
        public bool IsOperational { get; }
        public string Number { get; }
        public OperationList Operations { get; }
        public string PayeeReference { get; }
        public State State { get; }
        public TransactionType Type { get; }
        public DateTime Updated { get; }
        public Amount VatAmount { get; }
        public string Activity { get; }
    }
}