using System;
using System.Globalization;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentResponse
    {
        public CardPaymentResponse(PaymentResponseObject payment,
                               OperationList operations)
        {
            Payment = payment;
            Operations = operations;
        }

        public PaymentResponseObject Payment { get; }
        public OperationList Operations { get; }
    }

    public class PaymentResponseObject
    {
        public PaymentResponseObject(Uri id,
                               string number,
                               PaymentInstrument instrument,
                               DateTime created,
                               DateTime updated,
                               State state,
                               Operation operation,
                               Intent intent,
                               CurrencyCode currency,
                               Amount amount,
                               Amount remainingCaptureAmount,
                               Amount remainingCancellationAmount,
                               Amount remainingReversalAmount,
                               string description,
                               string payerReference,
                               string initiatingSystemUserAgent,
                               string userAgent,
                               CultureInfo language,
                               PricesListResponse prices,
                               Guid? recurrenceToken,
                               TransactionListResponse transactions,
                               CardPaymentAuthorizationListResponse authorizations,
                               CapturesListResponse captures,
                               ReversalsListResponse reversals,
                               CancellationsListResponse cancellations,
                               Urls urls,
                               PayeeInfo payeeInfo,
                               MetadataResponse metadata)
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
            RecurrenceToken = recurrenceToken;
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
            Metadata = metadata;
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
        public Guid? RecurrenceToken { get; }
        public ReversalsListResponse Reversals { get; }
        public State State { get; }
        public TransactionListResponse Transactions { get; }
        public Urls Urls { get; }
        public string UserAgent { get; }
        public MetadataResponse Metadata { get; }
    }
}