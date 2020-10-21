using SwedbankPay.Sdk.PaymentInstruments.Swish;
using System;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments.Card;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CurrentPaymentResponseObject : IdLink, ICurrentPaymentResponseObject
    {
        public CurrentPaymentResponseObject(string number,
                                            PaymentInstrument instrument,
                                            DateTime created,
                                            DateTime updated,
                                            Amount amount,
                                            IPaymentAuthorizationListResponse authorizations,
                                            ICancellationsListResponse cancellations,
                                            ICapturesListResponse captures,
                                            CurrencyCode currency,
                                            string description,
                                            PaymentIntent intent,
                                            Language language,
                                            Operation operation,
                                            PayeeInfo payeeInfo,
                                            string payerReference,
                                            string paymentToken,
                                            IPricesListResponse prices,
                                            IReversalsListResponse reversals,
                                            State state,
                                            ITransactionListResponse transactions,
                                            IdLink urls,
                                            string userAgent,
                                            ISwishSaleListResponse sales)
        {
            Number = number;
            Instrument = instrument;
            Created = created;
            Updated = updated;
            Amount = amount;
            Authorizations = authorizations;
            Cancellations = cancellations;
            Captures = captures;
            Currency = currency;
            Description = description;
            Intent = intent;
            Language = language;
            Operation = operation;
            PayeeInfo = payeeInfo;
            PayerReference = payerReference;
            PaymentToken = paymentToken;
            Prices = prices;
            Reversals = reversals;
            State = state;
            Transactions = transactions;
            Urls = urls;
            UserAgent = userAgent;
            Sales = sales;
        }


        public string Number { get; }
        public PaymentInstrument Instrument { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public Amount Amount { get; }
        public IPaymentAuthorizationListResponse Authorizations { get; }
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
        public ISwishSaleListResponse Sales { get; }
    }
}