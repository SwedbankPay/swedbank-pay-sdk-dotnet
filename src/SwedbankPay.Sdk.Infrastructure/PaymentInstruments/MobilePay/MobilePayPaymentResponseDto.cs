using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentResponseDto
    {
        public OperationListDto Operations { get; set; }
        public MobilePayPaymentDto Payment { get; set; }

        public IMobilePayPaymentResponse Map(HttpClient httpClient)
        {
            return new MobilePayPaymentResponse(this, httpClient);
        }
    }
}