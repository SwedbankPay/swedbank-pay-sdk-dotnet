using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CurrentPaymentResponseObject : IdLink, ICurrentPaymentResponseObject
    {
        public CurrentPaymentResponseObject(PaymentOrderPaymentDto payment)
        {
            Number = payment.Number;
            Instrument = Enum.Parse<PaymentInstrument>(payment.Instrument);
            Created = payment.Created;
            Updated = payment.Updated;
            Amount = payment.Amount;
            Currency = new CurrencyCode(payment.Currency);
            Description = payment.Description;
            Intent = Enum.Parse<PaymentIntent>(payment.Intent);
            Language = new Language(payment.Language);
            Operation = payment.Operation;
            PayeeInfo = payment.PayeeInfo.Map();
            PayerReference = payment.PayerReference;
            PaymentToken = payment.PaymentToken;
            State = payment.State;
            Urls = new IdLink { Id = payment.Urls.Id };
            UserAgent = payment.UserAgent;

            Authorizations = payment.Authorizations?.Map();
            Cancellations = payment.Cancellations?.Map();
            Captures = payment.Captures?.Map();
            Reversals = payment.Reversals?.Map();
            Transactions = payment.Transactions?.Map();
            Prices = payment.Prices.Map();
            Sales = payment.Sales?.Map();
        }

        public long Number { get; }
        public PaymentInstrument Instrument { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public Amount Amount { get; }
        public IPaymentAuthorizationResponse Authorizations { get; }
        public ICancellationsListResponse Cancellations { get; }
        public ICapturesListResponse Captures { get; }
        public CurrencyCode Currency { get; }
        public string Description { get; }
        public PaymentIntent Intent { get; }
        public Language Language { get; }
        public Operation Operation { get; }
        public PayeeInfo PayeeInfo { get; }
        public string PayerReference { get; }
        public string PaymentToken { get; }
        public IPricesListResponse Prices { get; }
        public IReversalsListResponse Reversals { get; }
        public State State { get; }
        public ITransactionListResponse Transactions { get; }
        public IdLink Urls { get; }
        public string UserAgent { get; }
        public ISaleListResponse Sales { get; }
    }
}