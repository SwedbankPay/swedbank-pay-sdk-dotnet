using Swedbankpay.Sdk.Payments;
using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPaymentResponse : IMobilePayPaymentResponse
    {

        public MobilePayPaymentResponse(MobilePayPaymentResponseDto mobilePayPaymentResponseDto, HttpClient httpClient)
        {
            Operations = new MobilePayPaymentOperations(mobilePayPaymentResponseDto.Operations.Map(), httpClient);
            Payment = new MobilePayPayment(mobilePayPaymentResponseDto.Payment);
        }

        public IMobilePayPaymentOperations Operations { get; set; }
        public IMobilePayPayment Payment { get; set; }
    }
}