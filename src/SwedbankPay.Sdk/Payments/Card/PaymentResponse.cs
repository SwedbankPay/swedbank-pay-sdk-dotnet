using SwedbankPay.Sdk.Transactions;

using System;

namespace SwedbankPay.Sdk.Payments.Card
{
    public class PaymentResponse
    {
        public PaymentResponse(Uri id,
                               string number,
                               string instrument,
                               DateTime created,
                               DateTime updated,
                               State state,
                               Operation operation,
                               string intent,
                               CurrencyCode currency,
                               Amount amount,
                               Amount remainingCaptureAmount,
                               Amount remainingCancellationAmount,
                               Amount remainingReversalAmount,
                               string description,
                               string payerReference,
                               string initiatingSystemUserAgent,
                               string userAgent,
                               Language language,
                               PricesContainer prices,
                               TransactionListContainer transactions,
                               AuthorizationListContainer authorizations,
                               CapturesListContainer captures,
                               ReversalsListContainer reversals,
                               CancellationsListContainer cancellations,
                               Urls urls,
                               PayeeInfo payeeInfo)
        {
            Id = id;
            Number = number;
            Created = created;
            Updated = updated;
            Instrument = instrument;
            Operation = operation;
            Intent = intent;
            State = state;
            Currency = currency;
            Prices = prices;
            Amount = amount;
            RemainingCaptureAmount = remainingCaptureAmount;
            RemainingCancellationAmount = remainingCancellationAmount;
            RemainingReversalAmount = remainingReversalAmount;
            Description = description;
            PayerReference = payerReference;
            InitiatingSystemUserAgent = initiatingSystemUserAgent;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
            Transactions = transactions;
            Authorizations = authorizations;
            Captures = captures;
            Reversals = reversals;
            Cancellations = cancellations;
        }


        public Amount Amount { get; }
        public Amount RemainingCaptureAmount { get; }
        public Amount RemainingCancellationAmount { get; }
        public Amount RemainingReversalAmount { get; }
        public AuthorizationListContainer Authorizations { get; }
        public CancellationsListContainer Cancellations { get; }
        public CapturesListContainer Captures { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public CurrencyCode Currency { get; }
        public string Description { get; }
        public Uri Id { get; }
        public string Instrument { get; }
        public string Intent { get; }
        public Language Language { get; }
        public string Number { get; }
        public Operation Operation { get; }
        public PayeeInfo PayeeInfo { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public PricesContainer Prices { get; }
        public ReversalsListContainer Reversals { get; }
        public State State { get; }
        public TransactionListContainer Transactions { get; }
        public Urls Urls { get; }
        public string UserAgent { get; }
    }
}