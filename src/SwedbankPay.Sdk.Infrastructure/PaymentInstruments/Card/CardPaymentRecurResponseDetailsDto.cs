using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentRecurResponseDetailsDto
    {
        public Uri Id { get; set; }

        public string RecurrenceToken { get; set; }

        public long Number { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public string Instrument { get; set; }

        public string Operation { get; set; }

        public string State { get; set; }

        public string Currency { get; set; }

        public PricesDto Prices { get; set; }

        public long Amount { get; set; }

        public long ReminaingCaptureAmount { get; set; }

        public long RemainingCancellationAmount { get; set; }

        public string Description { get; set; }

        public string InitiatingSystemUserAgent { get; set; }

        public string UserAgent { get; set; }

        public TransactionListResponseDto Transactions { get; set; }

        public PaymentAuthorizationDto Authorizations { get; set; }

        public UrlsDto Urls { get; set; }

        public PayeeInfoDto PayeeInfo { get; set; }

        public MetadataDto MetaData { get; set; }
    }
}