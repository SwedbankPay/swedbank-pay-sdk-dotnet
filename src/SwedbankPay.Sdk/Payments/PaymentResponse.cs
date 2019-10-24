namespace SwedbankPay.Sdk.Payments
{
    using System;
    using SwedbankPay.Sdk.PaymentOrders;
    using SwedbankPay.Sdk.Transactions;

    public class PaymentResponse
    {
        public string Id { get; protected set; }

        public string Number { get; protected set; }

        public DateTime Created { get; protected set; }

        public string Instrument { get; protected set; }
        public string Operation { get; protected set; }

        public string Intent { get; protected set; }
        public string State { get; protected set; }

        public string Currency { get; protected set; }

        public PricesContainer Prices { get; protected set; }
        public long Amount { get; protected set; }
        public string Description { get; protected set; }

        public string PayerReference { get; protected set; }

        public string UserAgent { get; protected set; }

        public string Language { get; protected set; }
        
        public Urls Urls { get; protected set; } 
        
        public PayeeInfo PayeeInfo { get; protected set; }

        public TransactionListContainer Transactions { get; protected set; }

        public AuthorizationListContainer Authorizations { get; protected set; }

        public CapturesListContainer Captures { get; protected set; }

        public ReversalsListContainer Reversals { get; protected set; }

        public CancellationsListContainer Cancellations { get; protected set; }
        
        public string PaymentToken { get; protected set; }

        public SaleListContainer Sales { get; protected set; }
    }
}