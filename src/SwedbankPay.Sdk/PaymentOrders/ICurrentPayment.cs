﻿using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface ICurrentPayment
    {
        Amount Amount { get; }
        IPaymentAuthorizationResponse Authorizations { get; }
        ICancellationsListResponse Cancellations { get; }
        ICapturesListResponse Captures { get; }
        DateTime Created { get; }
        CurrencyCode Currency { get; }
        string Description { get; }
        PaymentInstrument Instrument { get; }
        PaymentIntent Intent { get; }
        Language Language { get; }
        long Number { get; }
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