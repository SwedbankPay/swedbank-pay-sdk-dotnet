using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentData
    {
        Amount Amount { get; }
        Amount RemainingCaptureAmount { get; }
        Amount RemainingCancellationAmount { get; }
        Amount RemainingReversalAmount { get; }
        IInvoicePaymentAuthorizationListResponse Authorizations { get; }
        ICancellationsListResponse Cancellations { get; }
        ICapturesListResponse Captures { get; }
        DateTime Created { get; }
        DateTime Updated { get; }
        CurrencyCode Currency { get; }
        string Description { get; }
        Uri Id { get; }
        PaymentInstrument Instrument { get; }
        PaymentIntent Intent { get; }
        Language Language { get; }
        long Number { get; }
        Operation Operation { get; }
        PayeeInfo PayeeInfo { get; }
        string PayerReference { get; }
        string InitiatingSystemUserAgent { get; }
        IPricesListResponse Prices { get; }
        IReversalsListResponse Reversals { get; }
        State State { get; }
        ITransactionListResponse Transactions { get; }
        IUrls Urls { get; }
        string UserAgent { get; }
        Dictionary<string, object> Metadata { get; }
    }
}