using SwedbankPay.Sdk.Payments.TrustlyPayments;
using System;
using System.Globalization;

namespace SwedbankPay.Sdk.Payments
{
    public class TrustlyPayment : ITrustlyPayment
    {
        public TrustlyPayment(TrustlyPaymentResponseDto payment)
        {
            Amount = payment.Amount;
            Created = payment.Created;
            Updated = payment.Updated;
            Currency = payment.Currency;
            Description = payment.Description;
            Id = payment.Id;
            Instrument = Enum.Parse<PaymentInstrument>(payment.Instrument);
            Intent = Enum.Parse<PaymentIntent>(payment.Intent);
            Language = payment.Language;
            Number = payment.Number;
            Operation = payment.Operation;
            PayeeInfo = payment.PayeeInfo.Map();
            Transactions = payment.Transactions;
            PayerReference = payment.PayerReference;
            InitiatingSystemUserAgent = payment.InitiatingSystemUserAgent;
            Prices = payment.Prices.Map();
            State = payment.State;
            Urls = payment.Urls.Map();
            UserAgent = payment.UserAgent;
            Metadata = payment.Metadata;
        }

        public Amount Amount { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public CurrencyCode Currency { get; }
        public string Description { get; }
        public Uri Id { get; }
        public PaymentInstrument Instrument { get; }
        public PaymentIntent Intent { get; }
        public CultureInfo Language { get; }
        public string Number { get; }
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
