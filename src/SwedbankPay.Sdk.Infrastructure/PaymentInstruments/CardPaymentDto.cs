using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class CardPaymentDto
    {
        public int Amount { get; }

        public int RemainingCaptureAmount { get; }

        public int RemainingCancellationAmount { get; }

        public int RemainingReversalAmount { get; }

        public AuthorizationTransactionDto Authorizations { get; }

        public CancellationTransactionDto Cancellations { get; }

        public CaptureTransactionDto Captures { get; }

        public DateTime Created { get; }

        public DateTime Updated { get; }

        public string Currency { get; }

        public string Description { get; }

        public string Id { get; }

        public string Instrument { get; }

        public string Intent { get; }

        public string Language { get; }

        public string Number { get; }

        public string Operation { get; }

        public PayeeInfoDto PayeeInfo { get; }

        public string PayerReference { get; }

        public string InitiatingSystemUserAgent { get; }

        public PricesDto Prices { get; }

        public ReversalsListResponseDto Reversals { get; }

        public string State { get; }

        public TransactionListResponseDto Transactions { get; }

        public UrlsDto Urls { get; }

        public string UserAgent { get; }

        public Dictionary<string, object> Metadata { get; }
    }
}