using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CurrentPaymentResponse
    {
        public CurrentPaymentResponse(Uri paymentOrder, string menuElementName, CurrentPaymentResponseObject payment)
        {
            PaymentOrder = paymentOrder;
            MenuElementName = menuElementName;
            Payment = payment;
        }

        public Uri PaymentOrder { get; }
        public string  MenuElementName { get; }
        public CurrentPaymentResponseObject Payment { get; }

    }

    public class CurrentPaymentResponseObject : IdLink
    {
        public CurrentPaymentResponseObject(string number,
                                            PaymentInstrument instrument,
                                            DateTime created,
                                            DateTime updated,
                                            Amount amount,
                                            CardPaymentAuthorizationListResponse authorizations,
                                            CancellationsListResponse cancellations,
                                            CapturesListResponse captures,
                                            CurrencyCode currency,
                                            string description,
                                            Intent intent,
                                            Language language,
                                            Operation operation,
                                            PayeeInfo payeeInfo,
                                            string payerReference,
                                            string paymentToken,
                                            PricesListResponse prices,
                                            ReversalsListResponse reversals,
                                            State state,
                                            TransactionListResponse transactions,
                                            IdLink urls,
                                            string userAgent,
                                            SwishPaymentSaleListResponse sales)
        {
            Number = number;
            Instrument = instrument;
            Created = created;
            Updated = updated;
            Amount = amount;
            Authorizations = authorizations;
            Cancellations = cancellations;
            Captures = captures;
            Currency = currency;
            Description = description;
            Intent = intent;
            Language = language;
            Operation = operation;
            PayeeInfo = payeeInfo;
            PayerReference = payerReference;
            PaymentToken = paymentToken;
            Prices = prices;
            Reversals = reversals;
            State = state;
            Transactions = transactions;
            Urls = urls;
            UserAgent = userAgent;
            Sales = sales;
        }


        public string Number { get; }
        public PaymentInstrument Instrument { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public Amount Amount { get; }
        public CardPaymentAuthorizationListResponse Authorizations { get; }
        public CancellationsListResponse Cancellations { get; }
        public CapturesListResponse Captures { get; }
        public CurrencyCode Currency { get; }
        public string Description { get; }
        public Intent Intent { get; }
        public Language Language { get; }
        public Operation Operation { get; }
        public PayeeInfo PayeeInfo { get; }
        public string PayerReference { get; }
        public string PaymentToken { get; }
        public PricesListResponse Prices { get; }
        public ReversalsListResponse Reversals { get; }
        public State State { get; }
        public TransactionListResponse Transactions { get; }
        public IdLink Urls { get; }
        public string UserAgent { get; }
        public SwishPaymentSaleListResponse Sales { get; }
    }
}