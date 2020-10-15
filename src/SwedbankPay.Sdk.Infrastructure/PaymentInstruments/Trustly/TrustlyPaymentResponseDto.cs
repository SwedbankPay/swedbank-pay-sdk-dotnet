using SwedbankPay.Sdk.PaymentInstruments.Trustly;
using SwedbankPay.Sdk.Payments.TrustlyPayments;
using System;
using System.Globalization;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments
{
    public class TrustlyPaymentResponseDto
    {
        public TrustlyPaymentDto Payment { get; set; }
        public PaymentOperationsDto Operations { get; set; }

        public ITrustlyPaymentResponse Map(HttpClient httpClient)
        {
            return new TrustlyPaymentResponse(this, httpClient);
        }
    }
}