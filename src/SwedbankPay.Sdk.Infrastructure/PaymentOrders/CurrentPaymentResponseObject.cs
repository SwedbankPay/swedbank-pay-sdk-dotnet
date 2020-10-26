using System;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.Common;

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
            Authorizations = payment.Authorizations.Map();
            Cancellations = payment.Cancellations.Map();
            Captures = payment.Captures.Map();
            Currency = new CurrencyCode(payment.Currency);
            Description = payment.Description;
            Intent = Enum.Parse<PaymentIntent>(payment.Intent);
            Language = new Language(payment.Language);
            Operation = payment.Operation;
            PayeeInfo = payment.PayeeInfo.Map();
            PayerReference = payment.PayerReference;
            PaymentToken = payment.PaymentToken;
            Prices = payment.Prices.Map();
            Reversals = payment.Reversals.Map();
            State = payment.State;
            Transactions = payment.Transactions.Map();
            Urls = new IdLink { Id = new Uri(payment.Urls.Id, UriKind.RelativeOrAbsolute)};
            UserAgent = payment.UserAgent;
            Sales = payment.Sales.Map();
        }

        public string Number { get; }
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