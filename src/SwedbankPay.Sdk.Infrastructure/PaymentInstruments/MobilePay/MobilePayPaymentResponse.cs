using System.Net.Http;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPaymentResponse : IMobilePayPaymentResponse
    {

        public MobilePayPaymentResponse(MobilePayPaymentResponseDto mobilePayPaymentResponseDto, HttpClient httpClient)
        {
            //ToDO: Fill out
        }

        public IMobilePayPaymentResponse Payment { get; }
        public IOperationList Operations { get; }
    }
}