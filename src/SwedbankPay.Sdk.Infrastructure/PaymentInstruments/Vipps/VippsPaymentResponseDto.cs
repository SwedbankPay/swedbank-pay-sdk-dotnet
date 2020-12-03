using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    internal class VippsPaymentResponseDto
    {
        public OperationListDto Operations { get; set; }
        public VippsPaymentDto Payment { get; set; }

        public IVippsPaymentReponse Map(HttpClient httpClient)
        {
            return new VippsPaymentResponse(this, httpClient);
        }
    }
}