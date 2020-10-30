using SwedbankPay.Sdk.Common;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface ITransaction
    {
        string Activity { get; }
        Amount Amount { get; }
        DateTime Created { get; }
        string Description { get; }
        Uri Id { get; }
        bool IsOperational { get; }
        long Number { get; }
        IOperationList Operations { get; }
        string PayeeReference { get; }
        State State { get; }
        TransactionType Type { get; }
        DateTime Updated { get; }
        Amount VatAmount { get; }
    }
}