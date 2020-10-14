using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Globalization;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPaymentResponse : IMobilePayPaymentResponse
    {

        public MobilePayPaymentResponse(MobilePayPaymentResponseDto mobilePayPaymentResponseDto, HttpClient httpClient)
        {
            //ToDO: Fill out
        }

        public Amount Amount { get; }
        public IMobilePayPaymentAuthorizationListResponse Authorizations { get; }
        public ICancellationsListResponse Cancellations { get; }
        public ICapturesListResponse Captures { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public CurrencyCode Currency { get; }
        public string Description { get; }
        public Uri Id { get; }
        public PaymentInstrument Instrument { get; }
        public PaymentIntent Intent { get; }
        public CultureInfo Language { get; }
        public string Number { get; }
        public Operation Operation { get; }
        public PayeeInfo PayeeInfo { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public IPricesListResponse Prices { get; }
        public IReversalsListResponse Reversals { get; }
        public State State { get; }
        public ITransactionListResponse Transactions { get; }
        public IUrls Urls { get; }
        public string UserAgent { get; }
        public MetadataResponse Metadata { get; }
    }
}