using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface ICurrentPaymentResponseObject
    {
        Amount Amount { get; }
        ICardPaymentAuthorizationListResponse Authorizations { get; }
        ICancellationsListResponse Cancellations { get; }
        ICapturesListResponse Captures { get; }
        DateTime Created { get; }
        CurrencyCode Currency { get; }
        string Description { get; }
        PaymentInstrument Instrument { get; }
        PaymentIntent Intent { get; }
        Language Language { get; }
        string Number { get; }
        Operation Operation { get; }
        PayeeInfo PayeeInfo { get; }
        string PayerReference { get; }
        string PaymentToken { get; }
        IPricesListResponse Prices { get; }
        IReversalsListResponse Reversals { get; }
        ISaleListResponse Sales { get; }
        State State { get; }
        ITransactionListResponse Transactions { get; }
        DateTime Updated { get; }
        IdLink Urls { get; }
        string UserAgent { get; }
    }
}