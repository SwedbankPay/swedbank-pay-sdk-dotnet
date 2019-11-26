namespace SwedbankPay.Sdk.Payments
{
    using SwedbankPay.Sdk.PaymentOrders;
    using SwedbankPay.Sdk.Transactions;

    using System;

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
                               long amount,
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


        public Uri Id { get; }

        public string Number { get; }

        public DateTime Created { get; }

        public string Instrument { get; }

        public string Operation { get; }

        public string Intent { get; }

        public State State { get; }

        public CurrencyCode Currency { get; }

        public PricesContainer Prices { get; }

        public long Amount { get; }

        public string Description { get; }

        public string PayerReference { get; }

        public string UserAgent { get; }

        public Language Language { get; }

        public Urls Urls { get; }

        public PayeeInfo PayeeInfo { get; }

        public TransactionListContainer Transactions { get; }

        public AuthorizationListContainer Authorizations { get; }

        public CapturesListContainer Captures { get; }

        public ReversalsListContainer Reversals { get; }

        public CancellationsListContainer Cancellations { get; }

        public string PaymentToken { get; }

        public SaleListContainer Sales { get; }
    }
}