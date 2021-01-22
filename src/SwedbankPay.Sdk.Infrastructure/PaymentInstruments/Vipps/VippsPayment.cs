using System;


namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    internal class VippsPayment : IVippsPayment
    {
        public VippsPayment(VippsPaymentDto payment)
        {
            Amount = payment.Amount;
            VatAmount = payment.VatAmount;
            RemainingReversalAmount = payment.RemainingReversalAmount;
            RemainingCaptureAmount = payment.RemainingCaptureAmount;
            RemainingCancellationAmount = payment.RemainingCancellationAmount;
            Created = payment.Created;
            Updated = payment.Updated;
            Currency = new Currency(payment.Currency);
            Description = payment.Description;
            Id = payment.Id;
            Instrument = Enum.Parse<PaymentInstrument>(payment.Instrument);
            Intent = Enum.Parse<PaymentIntent>(payment.Intent);
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
            Authorizations = payment.Authorizations?.Map();
            Cancellations = payment.Cancellations?.Map();
            Captures = payment.Captures?.Map();
            Reversals = payment.Reversals?.Map();
            Transactions = payment.Transactions?.Map();
        }

        public Amount Amount { get; }
        public IVippsPaymentAuthorizationListResponse Authorizations { get; }
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
        public PayeeInfo PayeeInfo { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public IPricesListResponse Prices { get; }
        public IReversalsListResponse Reversals { get; }
        public State State { get; }
        public ITransactionListResponse Transactions { get; }
        public IUrls Urls { get; }
        public string UserAgent { get; }
        public Metadata Metadata { get; }
        public Amount RemainingCancellationAmount { get; }
        public Amount RemainingCaptureAmount { get; }
        public Amount RemainingReversalAmount { get; }
        public Amount VatAmount { get; }
    }
}