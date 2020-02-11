using System;
using System.Globalization;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class PaymentResponse
    {
        public PaymentResponse(PaymentResponseObject payment,
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
                               DateTime created,
                               DateTime updated,
                               Instrument instrument,
                               Operation operation,
                               Intent intent,
                               State state,
                               CurrencyCode currency,
                               PricesListResponse prices,
                               Amount amount,
                               Amount remainingReversalAmount,
                               string description,
                               string payerReference,
                               string initiatingSystemUserAgent,
                               string userAgent,
                               CultureInfo language,
                               TransactionListResponse transactions,
                               SaleListResponse sales,
                               ReversalsListResponse reversals,
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
            RemainingReversalAmount = remainingReversalAmount;
            Description = description;
            PayerReference = payerReference;
            InitiatingSystemUserAgent = initiatingSystemUserAgent;
            UserAgent = userAgent;
            Language = language;
            Transactions = transactions;
            Sales = sales;
            Reversals = reversals;
            Urls = urls;
            PayeeInfo = payeeInfo;
            MetaData = metaData;
        }


        public string Number { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public Instrument Instrument { get; }
        public Operation Operation { get; }
        public Intent Intent { get; }
        public State State { get; }
        public CurrencyCode Currency { get; }
        public PricesListResponse Prices { get; }
        public Amount Amount { get; }
        public Amount RemainingReversalAmount { get; set; }
        public string Description { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public string UserAgent { get; }
        public CultureInfo Language { get; }
        public TransactionListResponse Transactions { get; }
        public SaleListResponse Sales { get; }
        public ReversalsListResponse Reversals { get; }
        public Urls Urls { get; }
        public PayeeInfo PayeeInfo { get; }
        public Uri Id { get; }
        public MetaDataResponse MetaData { get; }
    }
}