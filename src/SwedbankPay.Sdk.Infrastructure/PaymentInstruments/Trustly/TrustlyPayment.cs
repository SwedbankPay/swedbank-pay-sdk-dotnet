﻿using SwedbankPay.Sdk.Extensions;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly;

internal class TrustlyPayment : ITrustlyPayment
{
    public TrustlyPayment(TrustlyPaymentDto payment)
    {
        Amount = payment.Amount;
        VatAmount = payment.VatAmount;
        RemainingCancellationAmount = payment.RemainingCancellationAmount;
        RemainingCaptureAmount = payment.RemainingCaptureAmount;
        RemainingReversalAmount = payment.RemainingReversalAmount;
        Created = payment.Created;
        Updated = payment.Updated;
        Currency = new Currency(payment.Currency);
        Description = payment.Description;
        Id = new Uri(payment.Id, UriKind.RelativeOrAbsolute);
        Instrument = payment.Instrument.ParseTo<PaymentInstrument>();
        Intent = payment.Intent.ParseTo<PaymentIntent>();
        Language = new Language(payment.Language);
        Number = payment.Number;
        Operation = payment.Operation;
        PayeeInfo = payment.PayeeInfo.Map();
        PayerReference = payment.PayerReference;
        InitiatingSystemUserAgent = payment.InitiatingSystemUserAgent;
        Prices = payment.Prices.Map();
        State = payment.State;
        Urls = payment.Urls.Map();
        UserAgent = payment.UserAgent;
        Metadata = payment.Metadata?.Map();
        Transactions = payment.Transactions?.Map();
        Cancellations = payment.Cancellations?.Map();
        Captures = payment.Captures?.Map();
        Reversals = payment.Reversals?.Map();
    }

    public Amount Amount { get; }
    public DateTime Created { get; }
    public DateTime Updated { get; }
    public Currency Currency { get; }
    public string Description { get; }
    public Uri Id { get; }
    public PaymentInstrument Instrument { get; }
    public PaymentIntent Intent { get; }
    public Language Language { get; }
    public long Number { get; }
    public Operation Operation { get; }
    public IPayeeInfo PayeeInfo { get; }
    public ITransactionListResponse Transactions { get; }
    public string PayerReference { get; }
    public string InitiatingSystemUserAgent { get; }
    public IPriceListResponse Prices { get; }
    public State State { get; }
    public IUrls Urls { get; }
    public string UserAgent { get; }
    public Metadata Metadata { get; }

    public ICancellationListResponse Cancellations { get; }

    public ICaptureListResponse Captures { get; }

    public Amount RemainingCancellationAmount { get; }

    public Amount RemainingCaptureAmount { get; }

    public Amount RemainingReversalAmount { get; }

    public Amount VatAmount { get; }

    public IReversalListResponse Reversals { get; }
}
