using SwedbankPay.Sdk.Payments.MobilePayPayments;
using System;
using System.Globalization;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments
{
    public class MobilePayPaymentResponseDto
    {
        public MobilePayPaymentOperationsDto Operations { get; set; }

        public MobilePayPaymentDto Payment { get; set; }
        public int Amount { get; set; }
        public MobilePayPaymentAuthorizationListResponseDto Authorizations { get; set; }
        public CancellationsListResponseDto Cancellations { get; set; }
        public CapturesListResponseDto Captures { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public CurrencyCode Currency { get; set; }
        public string Description { get; set; }
        public Uri Id { get; set; }
        public string Instrument { get; set; }
        public string Intent { get; set; }
        public CultureInfo Language { get; set; }
        public string Number { get; set; }
        public string Operation { get; set; }
        public PayeeInfoDto PayeeInfo { get; set; }
        public string PayerReference { get; set; }
        public string InitiatingSystemUserAgent { get; set; }
        public PricesListResponseDto Prices { get; set; }
        public ReversalsListResponseDto Reversals { get; set; }
        public State State { get; set; }
        public TransactionListResponseDto Transactions { get; set; }
        public UrlsDto Urls { get; set; }
        public string UserAgent { get; set; }
        public MetadataResponse Metadata { get; set; }

        public IMobilePayPaymentResponse Map(HttpClient httpClient)
        {
            return new MobilePayPaymentResponse(this, httpClient);
        }
    }
}