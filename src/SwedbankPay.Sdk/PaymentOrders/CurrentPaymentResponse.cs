using System;

using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Transactions;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CurrentPaymentResponse : IdLink
    {
        public CurrentPaymentResponse(string number, string instrument, DateTime created, DateTime updated, Amount amount, AuthorizationListContainer authorizations, CancellationsListContainer cancellations, CapturesListContainer captures, CurrencyCode currency, string description, string intent, Language language, Operation operation, PayeeInfo payeeInfo, string payerReference, string paymentToken, PricesContainer prices, ReversalsListContainer reversals, State state, TransactionListContainer transactions, IdLink urls, string userAgent, SaleListContainer sales)
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
        public string Instrument { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public Amount Amount { get; }
        public AuthorizationListContainer Authorizations { get; }
        public CancellationsListContainer Cancellations { get; }
        public CapturesListContainer Captures { get; }
        public CurrencyCode Currency { get; }
        public string Description { get; }
        public string Intent { get; }
        public Language Language { get; }
        public Operation Operation { get; }
        public PayeeInfo PayeeInfo { get; }
        public string PayerReference { get; }
        public string PaymentToken { get; }
        public PricesContainer Prices { get; }
        public ReversalsListContainer Reversals { get; }
        public State State { get; }
        public TransactionListContainer Transactions { get; }
        public IdLink Urls { get; }
        public string UserAgent { get; }
        public SaleListContainer Sales { get; }

    }
}