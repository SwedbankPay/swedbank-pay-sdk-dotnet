using SwedbankPay.Sdk.Payments.SwishPayments;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments
{
    public class SwishPaymentResponseDto
    {
        public PaymentOperationsDto Operations{ get; set; }
        public SwishPaymentDto Payment { get; set; }
        
        public ISwishPaymentResponse Map(HttpClient httpClient)
        {
            return new SwishPaymentResponse(this, httpClient);
        }
    }
}