using SwedbankPay.Sdk.PaymentOrders;

using System;
using System.Globalization;

namespace SwedbankPay.Sdk.Payments.TrustlyPayments
{
    public class TrustlyPaymentResponse
    {
        public TrustlyPaymentResponse(TrustlyPaymentResponseObject payment,
                                      IOperationList operations)
        {
            this.Payment = payment;
            this.Operations = operations;
        }

        public TrustlyPaymentResponseObject Payment { get; }
        public IOperationList Operations { get; }
    }

    public class TrustlyPaymentResponseObject
    {
        public TrustlyPaymentResponseObject(Uri id,
                               string number,
                               DateTime created,
                               DateTime updated,
                               PaymentInstrument instrument,
                               Operation operation,
                               Intent intent,
                               State state,
                               CurrencyCode currency,
                               IPricesListResponse prices,
                               Amount amount,
                               string description,
                               string payerReference,
                               string initiatingSystemUserAgent,
                               string userAgent,
                               CultureInfo language,
                               IUrls urls,
                               PayeeInfo payeeInfo,
                               ITransactionListResponse transactions,

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
            Metadata = metadata;
        }


        public Amount Amount { get; }
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
        public ITransactionListResponse Transactions { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public IPricesListResponse Prices { get; }
        public State State { get; }
        public IUrls Urls { get; }
        public string UserAgent { get; }
        public MetadataResponse Metadata { get; }
    }
}
