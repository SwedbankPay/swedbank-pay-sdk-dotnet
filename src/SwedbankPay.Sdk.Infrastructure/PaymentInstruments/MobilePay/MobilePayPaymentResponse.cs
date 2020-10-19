using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentResponse : IMobilePayPaymentResponse
    {

        public MobilePayPaymentResponse(MobilePayPaymentResponseDto mobilePayPaymentResponseDto, HttpClient httpClient)
        {
            Operations = new MobilePayPaymentOperations(mobilePayPaymentResponseDto.Operations, httpClient);
            Payment = new MobilePayPayment(mobilePayPaymentResponseDto.Payment);
        }

        public IMobilePayPaymentOperations Operations { get; set; }
        public IMobilePayPayment Payment { get; set; }
    }
}