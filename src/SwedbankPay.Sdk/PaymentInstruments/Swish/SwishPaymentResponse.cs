using System;
using System.Globalization;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SwishPaymentResponse
    {
        public SwishPaymentResponse(SwishPaymentResponseObject payment,
                               IOperationList operations)
        {
            Payment = payment;
            Operations = operations;
        }

        public SwishPaymentResponseObject Payment { get; }
        public IOperationList Operations { get; }
    }

    public class SwishPaymentResponseObject
    {
        public SwishPaymentResponseObject(Uri id,
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
                               Amount remainingReversalAmount,
                               string description,
                               string payerReference,
                               string initiatingSystemUserAgent,
                               string userAgent,
                               CultureInfo language,
                               ITransactionListResponse transactions,
                               SaleListResponse sales,
                               IReversalsListResponse reversals,
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
            Metadata = metadata;
        }


        public string Number { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public PaymentInstrument Instrument { get; }
        public Operation Operation { get; }
        public Intent Intent { get; }
        public State State { get; }
        public CurrencyCode Currency { get; }
        public IPricesListResponse Prices { get; }
        public Amount Amount { get; }
        public Amount RemainingReversalAmount { get; set; }
        public string Description { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public string UserAgent { get; }
        public CultureInfo Language { get; }
        public ITransactionListResponse Transactions { get; }
        public SaleListResponse Sales { get; }
        public IReversalsListResponse Reversals { get; }
        public IUrls Urls { get; }
        public PayeeInfo PayeeInfo { get; }
        public Uri Id { get; }
        public MetadataResponse Metadata { get; }
    }
}