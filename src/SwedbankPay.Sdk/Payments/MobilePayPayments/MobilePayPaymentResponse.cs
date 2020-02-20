using System;
using System.Globalization;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPaymentResponse
    {
        public MobilePayPaymentResponse(PaymentResponseObject payment,
                               OperationList operations)
        {
            this.Payment = payment;
            this.Operations = operations;
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
                               string description,
                               string payerReference,
                               string initiatingSystemUserAgent,
                               string userAgent,
                               CultureInfo language,
                               PricesListResponse prices,
                               TransactionListResponse transactions,
                               MobilePayPaymentAuthorizationListResponse authorizations,
                               CapturesListResponse captures,
                               ReversalsListResponse reversals,
                               CancellationsListResponse cancellations,
                               Urls urls,
                               PayeeInfo payeeInfo,
                               MetaDataResponse metaData)
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
            MetaData = metaData;
        }


        public Amount Amount { get; }
        public MobilePayPaymentAuthorizationListResponse Authorizations { get; }
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
        public MetaDataResponse MetaData { get; }
    }
}