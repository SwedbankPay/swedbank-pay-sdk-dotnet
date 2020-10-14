using SwedbankPay.Sdk.Payments.MobilePayPayments;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments
{
    public class MobilePayPaymentResponseDto
    {
        public MobilePayPaymentOperationsDto Operations { get; set; }

        public MobilePayPaymentDto Payment { get; set; }

        public IMobilePayPaymentResponse Map(HttpClient httpClient)
        {
            return new MobilePayPaymentResponse(this, httpClient);
        }
    }
}