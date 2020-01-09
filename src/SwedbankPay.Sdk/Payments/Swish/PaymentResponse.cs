using System;

using SwedbankPay.Sdk.Transactions;

namespace SwedbankPay.Sdk.Payments.Swish
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
                               Amount amount,
                               string description,
                               string payerReference,
                               string initiatingSystemUserAgent,
                               string userAgent,
                               Language language,
                               Urls urls,
                               PayeeInfo payeeInfo)
        {
            Id = id;
            Number = number;
            Created = created;
            Instrument = instrument;
            Operation = operation;
            Intent = intent;
            State = state;
            Currency = currency;
            Amount = amount;
            Description = description;
            PayerReference = payerReference;
            InitiatingSystemUserAgent = initiatingSystemUserAgent;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
        }


       public Amount Amount { get; }

        public AuthorizationListResponse Authorizations { get; }

        public CancellationsListResponse Cancellations { get; }

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

        public PricesListResponse Prices { get; }

        public ReversalsListResponse Reversals { get; }

        public SaleListContainer Sales { get; }

        public State State { get; }

        public TransactionListResponse Transactions { get; }

        public Urls Urls { get; }

        public string UserAgent { get; }

        public string InitiatingSystemUserAgent { get; }
    }
}