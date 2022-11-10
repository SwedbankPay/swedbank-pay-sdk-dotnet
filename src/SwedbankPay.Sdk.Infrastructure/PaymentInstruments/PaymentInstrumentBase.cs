using System;

namespace SwedbankPay.Sdk.PaymentInstruments;

internal abstract class PaymentInstrumentBase : IPaymentInstrument
{
    protected PaymentInstrumentBase(IPaymentInstrument payment)
    {
        Amount = payment.Amount;
        VatAmount = payment.VatAmount;
        RemainingCaptureAmount = payment.RemainingCaptureAmount;
        RemainingCancellationAmount = payment.RemainingCancellationAmount;
        RemainingReversalAmount = payment.RemainingReversalAmount;
        Created = payment.Created;
        Updated = payment.Updated;
        Currency = payment.Currency;
        Description = payment.Description;
        Id = payment.Id;
        Instrument = payment.Instrument;
        Language = payment.Language;
        Number = payment.Number;
        Operation = payment.Operation;
        PayeeInfo = payment.PayeeInfo;
        PayerReference = payment.PayerReference;
        InitiatingSystemUserAgent = payment.InitiatingSystemUserAgent;
        Prices = payment.Prices;
        State = payment.State;
        Urls = payment.Urls;
        UserAgent = payment.UserAgent;
        Metadata = payment.Metadata;
        Cancellations = payment.Cancellations;
        Captures = payment.Captures;
        Reversals = payment.Reversals;
        Transactions = payment.Transactions;
        Intent = payment.Intent;
    }

    public Amount Amount { get; }

    public Amount RemainingCaptureAmount { get; }

    public Amount RemainingCancellationAmount { get; }

    public Amount RemainingReversalAmount { get; }

    public ICancellationListResponse Cancellations { get; }

    public ICaptureListResponse Captures { get; }

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

    public string PayerReference { get; }

    public string InitiatingSystemUserAgent { get; }

    public IPriceListResponse Prices { get; }

    public IReversalListResponse Reversals { get; }

    public State State { get; }

    public ITransactionListResponse Transactions { get; }

    public IUrls Urls { get; }

    public string UserAgent { get; }

    public Metadata Metadata { get; }

    public Amount VatAmount { get; }
}