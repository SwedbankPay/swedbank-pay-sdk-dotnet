using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class CurrentPayment : Identifiable, ICurrentPayment
    {
        public CurrentPayment(PaymentOrderPaymentDto payment)
            : base(payment.Id)
        {
            Number = payment.Number;
            Instrument = EnumExtensions.Parse<PaymentInstrument>(payment.Instrument);
            Created = payment.Created;
            Updated = payment.Updated;
            Amount = payment.Amount;
            Currency = new Currency(payment.Currency);
            Description = payment.Description;
            Intent = EnumExtensions.Parse<PaymentIntent>(payment.Intent);
            Language = new Language(payment.Language);
            Operation = payment.Operation;
            PayeeInfo = payment.PayeeInfo.Map();
            PayerReference = payment.PayerReference;
            PaymentToken = payment.PaymentToken;
            State = payment.State;
            Urls = payment.Urls.Map();
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
        public ICancellationListResponse Cancellations { get; }
        public ICaptureListResponse Captures { get; }
        public Currency Currency { get; }
        public string Description { get; }
        public PaymentIntent Intent { get; }
        public Language Language { get; }
        public Operation Operation { get; }
        public IPaymentOrderPayeeInfo PayeeInfo { get; }
        public string PayerReference { get; }
        public string PaymentToken { get; }
        public IPriceListResponse Prices { get; }
        public IReversalListResponse Reversals { get; }
        public State State { get; }
        public ITransactionListResponse Transactions { get; }
        public IUrls Urls { get; }
        public string UserAgent { get; }
        public ISaleListResponse Sales { get; }
    }
}