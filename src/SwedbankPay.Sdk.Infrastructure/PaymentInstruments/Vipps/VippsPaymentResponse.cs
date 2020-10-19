using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    internal class VippsPaymentResponse : IVippsPaymentReponse
    {
        public VippsPaymentResponse(VippsPaymentResponseDto paymentResponse, HttpClient httpClient)
        {
            Operations = new VippsPaymentOperations(paymentResponse.Operations, httpClient);
            Payment = new VippsPayment(paymentResponse.Payment);
        }

        public IVippsPaymentOperations Operations { get; set; }
        public IVippsPayment Payment { get; set; }
    }
}