using swedbankpay.Sdk.Payments;
using SwedbankPay.Sdk.PaymentInstruments.Vipps;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments
{
    internal class VippsPaymentResponse : IVippsPaymentReponse
    {
        public VippsPaymentResponse(VippsPaymentResponseDto paymentResponse, HttpClient httpClient)
        {
            Operations = new VippsPaymentOperations(paymentResponse.Operations.Map(), httpClient);
            Payment = new VippsPayment(paymentResponse.Payment);
        }

        public IVippsPaymentOperations Operations { get; set; }
        public IVippsPayment Payment { get; set; }
    }
}