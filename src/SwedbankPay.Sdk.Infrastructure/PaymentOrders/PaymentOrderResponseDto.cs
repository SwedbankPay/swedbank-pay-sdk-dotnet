using SwedbankPay.Sdk.PaymentInstruments;
using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderResponseDto
    {
        public PaymentOperationsDto Operations { get; set; }
        public PaymentOrderDto PaymentOrder { get; set; }

        public IPaymentOrderResponse Map(HttpClient httpClient)
        {
            return new PaymentOrderResponse(this, httpClient);
        }
    }
}