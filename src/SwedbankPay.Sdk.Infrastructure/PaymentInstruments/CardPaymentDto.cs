using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class CardPaymentDto
    {
        public int Amount { get; }

        public int RemainingCaptureAmount { get; }

        public int RemainingCancellationAmount { get; }

        public int RemainingReversalAmount { get; }

        public List<TransactionDto> Authorizations { get; }

        public List<TransactionDto> Cancellations { get; }

        public List<TransactionDto> Captures { get; }

        public DateTime Created { get; }

        public DateTime Updated { get; }

        public string Currency { get; }

        public string Description { get; }

        public string Id { get; }

        public string Instrument { get; }

        public string Intent { get; }

        public string Language { get; }

        public string Number { get; }

        public Operation Operation { get; }

        public PayeeInfo PayeeInfo { get; }

        public string PayerReference { get; }

        public string InitiatingSystemUserAgent { get; }

        public List<Price> Prices { get; }

        public ReversalsListResponse Reversals { get; }

        public string State { get; }

        public TransactionListResponse Transactions { get; }

        public ICollection<Uri> Urls { get; }

        public string UserAgent { get; }

        public MetadataResponse Metadata { get; }
    }
}