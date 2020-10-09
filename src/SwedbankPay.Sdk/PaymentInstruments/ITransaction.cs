using System;

namespace SwedbankPay.Sdk.Payments
{
    public interface ITransaction
    {
        string Activity { get; }
        Amount Amount { get; }
        DateTime Created { get; }
        string Description { get; }
        Uri Id { get; }
        bool IsOperational { get; }
        string Number { get; }
        OperationList Operations { get; }
        string PayeeReference { get; }
        State State { get; }
        TransactionType Type { get; }
        DateTime Updated { get; }
        Amount VatAmount { get; }
    }
}