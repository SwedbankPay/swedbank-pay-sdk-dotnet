using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    internal class TrustlyPayment : ITrustlyPayment
    {
        public TrustlyPayment(TrustlyPaymentDto payment)
        {
            Amount = payment.Amount;
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
            Metadata = payment.Metadata;
            Transactions = payment.Transactions?.Map();
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
        public PayeeInfo PayeeInfo { get; }
        public ITransactionListResponse Transactions { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public IPricesListResponse Prices { get; }
        public State State { get; }
        public IUrls Urls { get; }
        public string UserAgent { get; }
        public MetadataResponse Metadata { get; }
    }
}
