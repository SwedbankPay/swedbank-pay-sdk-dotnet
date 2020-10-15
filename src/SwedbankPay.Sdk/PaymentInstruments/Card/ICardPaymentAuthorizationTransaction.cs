using SwedbankPay.Sdk.Common;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentAuthorizationTransaction
    {
        Amount Amount { get; }
        DateTime Created { get; }
        string Description { get; }
        string FailedActivityName { get; }
        string FailedErrorCode { get; }
        string FailedErrorDescription { get; }
        string FailedReason { get; }
        bool IsOperational { get; }
        string Number { get; }
        IOperationList Operations { get; }
        string PayeeReference { get; }
        ProblemResponse Problem { get; }
        State State { get; }
        string Type { get; }
        DateTime Updated { get; }
        Amount VatAmount { get; }
    }
}