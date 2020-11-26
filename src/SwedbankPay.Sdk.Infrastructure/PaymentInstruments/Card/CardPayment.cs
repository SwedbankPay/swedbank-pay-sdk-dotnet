using System;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPayment : ICardPayment
    {
        public CardPayment(CardPaymentDto payment)
        {
            if (payment is null)
            {
                throw new ArgumentNullException(nameof(payment));
            }

            Amount = payment.Amount;
            RemainingCaptureAmount = payment.RemainingCaptureAmount;
            RemainingCancellationAmount = payment.RemainingCancellationAmount;
            RemainingReversalAmount = payment.RemainingReversalAmount;
            Created = payment.Created;
            Updated = payment.Updated;
            Currency = new Currency(payment.Currency);
            Description = payment.Description;
            Id = new Uri(payment.Id, UriKind.RelativeOrAbsolute);
            Instrument = Enum.Parse<PaymentInstrument>(payment.Instrument);
            Language = new Language(payment.Language);
            Number = payment.Number;
            Operation = payment.Operation;
            PayeeInfo = payment.PayeeInfo.Map();
            PayerReference = payment.PayerReference;
            InitiatingSystemUserAgent = payment.InitiatingSystemUserAgent;
            Prices = payment.Prices.Map();
            State = payment.State;
            Urls = new Urls(payment.Urls);
            UserAgent = payment.UserAgent;
            Metadata = new MetadataResponse(payment.Metadata);
            RecurrenceToken = payment.RecurrenceToken;

            Authorizations = payment.Authorizations?.Map();
            Cancellations = payment.Cancellations?.Map();
            Captures = payment.Captures?.Map();
            Reversals = payment.Reversals?.Map();
            Transactions = payment.Transactions?.Map();
            if (!string.IsNullOrEmpty(payment.Intent))
            {
                Intent = Enum.Parse<PaymentIntent>(payment.Intent);
            }
        }

        public Amount Amount { get; }

        public Amount RemainingCaptureAmount { get; }

        public Amount RemainingCancellationAmount { get; }

        public Amount RemainingReversalAmount { get; }

        public ICardPaymentAuthorizationListResponse Authorizations { get; }

        public ICancellationsListResponse Cancellations { get; }

        public ICapturesListResponse Captures { get; }

        public DateTime Created { get; }

        public DateTime Updated { get; }

        public Currency Currency { get; }

        public string Description { get; }

        public Uri Id { get; }

        public PaymentInstrument Instrument { get; }

        public PaymentIntent Intent { get; }

        public Language Language { get; }

        public long Number { get; }

        public Operation Operation { get; }

        public PayeeInfo PayeeInfo { get; }

        public string PayerReference { get; }

        public string InitiatingSystemUserAgent { get; }

        public IPricesListResponse Prices { get; }

        public IReversalsListResponse Reversals { get; }

        public State State { get; }

        public ITransactionListResponse Transactions { get; }

        public IUrls Urls { get; }

        public string UserAgent { get; }

        public MetadataResponse Metadata { get; }

        public string RecurrenceToken { get; }
    }
}