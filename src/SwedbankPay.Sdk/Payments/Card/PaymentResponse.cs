using System;

using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Transactions;
    
namespace SwedbankPay.Sdk.Payments.Card
{
    public class PaymentResponse
    {
        public PaymentResponse(Uri id,
                               string number,
                               DateTime created,
                               string instrument,
                               string operation,
                               string intent,
                               State state,
                               CurrencyCode currency,
                               PricesContainer prices,
                               Amount amount,
                               string description,
                               string payerReference,
                               string userAgent,
                               Language language,
                               Urls urls,
                               PayeeInfo payeeInfo,
                               TransactionListContainer transactions,
                               AuthorizationListContainer authorizations,
                               CapturesListContainer captures,
                               ReversalsListContainer reversals,
                               CancellationsListContainer cancellations,
                               string paymentToken,
                               SaleListContainer sales)
        {
            Id = id;
            Number = number;
            Created = created;
            Instrument = instrument;
            Operation = operation;
            Intent = intent;
            State = state;
            Currency = currency;
            Prices = prices;
            Amount = amount;
            Description = description;
            PayerReference = payerReference;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
            Transactions = transactions;
            Authorizations = authorizations;
            Captures = captures;
            Reversals = reversals;
            Cancellations = cancellations;
            PaymentToken = paymentToken;
            Sales = sales;
        }


        public Amount Amount { get; }

        public AuthorizationListContainer Authorizations { get; }

        public CancellationsListContainer Cancellations { get; }

        public CapturesListContainer Captures { get; }

        public DateTime Created { get; }

        public CurrencyCode Currency { get; }

        public string Description { get; }

        public Uri Id { get; }

        public string Instrument { get; }

        public string Intent { get; }

        public Language Language { get; }

        public string Number { get; }

        public string Operation { get; }

        public PayeeInfo PayeeInfo { get; }

        public string PayerReference { get; }

        public string PaymentToken { get; }

        public PricesContainer Prices { get; }

        public ReversalsListContainer Reversals { get; }

        public SaleListContainer Sales { get; }

        public State State { get; }

        public TransactionListContainer Transactions { get; }

        public Urls Urls { get; }

        public string UserAgent { get; }
    }
}