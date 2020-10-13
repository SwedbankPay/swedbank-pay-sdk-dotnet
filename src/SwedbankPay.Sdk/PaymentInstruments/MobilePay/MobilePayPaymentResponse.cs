using System;
using System.Globalization;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPaymentResponse
    {
        public MobilePayPaymentResponse(MobilePayPaymentResponseObject payment,
                               IOperationList operations)
        {
            this.Payment = payment;
            this.Operations = operations;
        }

        public MobilePayPaymentResponseObject Payment { get; }
        public IOperationList Operations { get; }
    }

    public class MobilePayPaymentResponseObject
    {
        public MobilePayPaymentResponseObject(Uri id,
                               string number,
                               PaymentInstrument instrument,
                               DateTime created,
                               DateTime updated,
                               State state,
                               Operation operation,
                               PaymentIntent intent,
                               CurrencyCode currency,
                               Amount amount,
                               string description,
                               string payerReference,
                               string initiatingSystemUserAgent,
                               string userAgent,
                               CultureInfo language,
                               IPricesListResponse prices,
                               ITransactionListResponse transactions,
                               MobilePayPaymentAuthorizationListResponse authorizations,
                               ICapturesListResponse captures,
                               IReversalsListResponse reversals,
                               ICancellationsListResponse cancellations,
                               IUrls urls,
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
            Metadata = metadata;
        }


        public Amount Amount { get; }
        public MobilePayPaymentAuthorizationListResponse Authorizations { get; }
        public ICancellationsListResponse Cancellations { get; }
        public ICapturesListResponse Captures { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public CurrencyCode Currency { get; }
        public string Description { get; }
        public Uri Id { get; }
        public PaymentInstrument Instrument { get; }
        public PaymentIntent Intent { get; }
        public CultureInfo Language { get; }
        public string Number { get; }
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
    }
}