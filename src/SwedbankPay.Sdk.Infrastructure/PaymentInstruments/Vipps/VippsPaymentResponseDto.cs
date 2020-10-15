using SwedbankPay.Sdk.PaymentInstruments.Vipps;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments
{
    public class VippsPaymentResponseDto
    {
        public PaymentOperationsDto Operations { get; set; }
        public VippsPaymentDto Payment { get; set; }

        public IVippsPaymentReponse Map(HttpClient httpClient)
        {
            return new VippsPaymentResponse(this, httpClient);
        }
    }
}