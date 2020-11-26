using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentRecurResponseDetailsDto
    {
        public Uri Id { get; }

        public string RecurrenceToken { get; }

        public long Number { get; }

        public DateTime Created { get; }

        public DateTime Updated { get; }

        public string Instrument { get; }

        public string Operation { get; }

        public string Intent { get; }

        public string State { get; }

        public string Currency { get; }

        public PricesDto Prices { get; }

        public int Amount { get; }

        public int VatAmount { get; }

        public int ReminaingCaptureAmount { get; }

        public int RemainingCancellationAmount { get; }

        public string Description { get; }

        public string InitiatingSystemUserAgent { get; }

        public string UserAgent { get; }

        public TransactionListResponseDto Transactions { get; }

        public PaymentAuthorizationDto Authorizations { get; }

        public UrlsDto Urls { get; }

        public PayeeInfoDto PayeeInfo { get; }

        public MetadataResponse MetaData { get; }
    }
}