using System;
using System.Globalization;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentVerifyResponse
    {
        public CardPaymentVerifyResponse(PaymentVerifyResponseObject payment,
                               OperationList operations)
        {
            Payment = payment;
            Operations = operations;
        }

        public PaymentVerifyResponseObject Payment { get; }
        public OperationList Operations { get; }
    }

    public class PaymentVerifyResponseObject
    {
        public PaymentVerifyResponseObject(Uri id,
                               string number,
                               DateTime created,
                               DateTime updated,
                               Operation operation,
                               State state,
                               CurrencyCode currency,
                               Amount amount,
                               string description,
                               string payerReference,
                               string initiatingSystemUserAgent,
                               string userAgent,
                               CultureInfo language,
                               TransactionListResponse transactions,
                               CardPaymentVerificationListResponse verifications,
                               Urls urls,
                               PayeeInfo payeeInfo)
        {
            Id = id;
            Number = number;
            Created = created;
            Updated = updated;
            Operation = operation;
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
            Transactions = transactions;
            Verifications = verifications;
        }


        public Amount Amount { get; }
        public CardPaymentVerificationListResponse Verifications { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public CurrencyCode Currency { get; }
        public string Description { get; }
        public Uri Id { get; }
        public CultureInfo Language { get; }
        public string Number { get; }
        public Operation Operation { get; }
        public PayeeInfo PayeeInfo { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public State State { get; }
        public TransactionListResponse Transactions { get; }
        public Urls Urls { get; }
        public string UserAgent { get; }
    }
}