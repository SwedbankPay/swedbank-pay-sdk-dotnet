using System;
using System.Globalization;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPayment : ICardPayment
    {
        public CardPayment(CardPaymentDto payment)
        {
            // ToDo: Fill all properties
        }

        public Amount Amount { get; }

        public Amount RemainingCaptureAmount { get; }

        public Amount RemainingCancellationAmount { get; }

        public Amount RemainingReversalAmount { get; }

        public CardPaymentAuthorizationListResponse Authorizations { get; }

        public CancellationsListResponse Cancellations { get; }

        public CapturesListResponse Captures { get; }

        public DateTime Created { get; }

        public DateTime Updated { get; }

        public CurrencyCode Currency { get; }

        public string Description { get; }

        public Uri Id { get; }

        public PaymentInstrument Instrument { get; }

        public Intent Intent { get; }

        public CultureInfo Language { get; }

        public string Number { get; }

        public Operation Operation { get; }

        public PayeeInfo PayeeInfo { get; }

        public string PayerReference { get; }

        public string InitiatingSystemUserAgent { get; }

        public PricesListResponse Prices { get; }

        public ReversalsListResponse Reversals { get; }

        public State State { get; }

        public TransactionListResponse Transactions { get; }

        public Urls Urls { get; }

        public string UserAgent { get; }

        public MetadataResponse Metadata { get; }
    }
}