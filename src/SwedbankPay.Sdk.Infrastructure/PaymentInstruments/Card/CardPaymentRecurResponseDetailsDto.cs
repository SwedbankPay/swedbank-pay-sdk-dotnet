using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentRecurResponseDetailsDto
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

        public int Amount { get; set; }

        public int ReminaingCaptureAmount { get; set; }

        public int RemainingCancellationAmount { get; set; }

        public string Description { get; set; }

        public string InitiatingSystemUserAgent { get; set; }

        public string UserAgent { get; set; }

        public TransactionListResponseDto Transactions { get; set; }

        public PaymentAuthorizationDto Authorizations { get; set; }

        public UrlsDto Urls { get; set; }

        public PayeeInfoDto PayeeInfo { get; set; }

        public MetadataResponse MetaData { get; set; }
    }
}