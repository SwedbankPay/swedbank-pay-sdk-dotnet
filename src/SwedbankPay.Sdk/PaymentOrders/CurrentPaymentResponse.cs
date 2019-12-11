using System;

using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Transactions;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CurrentPaymentResponse : IdLink
    {
        public long Amount { get; set; }

        public AuthorizationListContainer Authorizations { get; set; }

        public CancellationsListContainer Cancellations { get; set; }

        public CapturesListContainer Captures { get; set; }

        public DateTime Created { get; set; }

        public CurrencyCode Currency { get; set; }
        public string Description { get; set; }

        public string Instrument { get; set; }

        public string Intent { get; set; }

        public Language Language { get; set; }
        public string Number { get; set; }
        public string Operation { get; set; }
        public PayeeInfo PayeeInfo { get; set; }

        public string PayerReference { get; set; }

        public string PaymentToken { get; set; }
        public PricesContainer Prices { get; set; }

        public ReversalsListContainer Reversals { get; set; }
        public State State { get; set; }

        public TransactionListContainer Transactions { get; set; }
        public IdLink Urls { get; set; }

        public string UserAgent { get; set; }
    }
}