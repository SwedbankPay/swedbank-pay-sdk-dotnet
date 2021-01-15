using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal interface IPaymentInstrument
    {
        Amount Amount { get; }
        ICancellationsListResponse Cancellations { get; }
        ICapturesListResponse Captures { get; }
        DateTime Created { get; }
        Currency Currency { get; }
        string Description { get; }
        Uri Id { get; }
        string InitiatingSystemUserAgent { get; }
        Sdk.PaymentInstrument Instrument { get; }
        PaymentIntent Intent { get; }
        Language Language { get; }
        Metadata Metadata { get; }
        long Number { get; }
        Operation Operation { get; }
        PayeeInfo PayeeInfo { get; }
        string PayerReference { get; }
        IPricesListResponse Prices { get; }
        Amount RemainingCancellationAmount { get; }
        Amount RemainingCaptureAmount { get; }
        Amount RemainingReversalAmount { get; }
        IReversalsListResponse Reversals { get; }
        State State { get; }
        ITransactionListResponse Transactions { get; }
        DateTime Updated { get; }
        IUrls Urls { get; }
        string UserAgent { get; }
        Amount VatAmount { get; }
    }
}