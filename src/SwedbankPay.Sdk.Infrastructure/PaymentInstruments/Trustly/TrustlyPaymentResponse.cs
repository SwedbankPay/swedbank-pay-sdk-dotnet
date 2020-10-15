using SwedbankPay.Sdk.PaymentInstruments.Trustly;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments
{
    public class TrustlyPaymentResponse : ITrustlyPaymentResponse
    {
        public TrustlyPaymentResponse(TrustlyPaymentResponseDto trustlyPaymentResponseDto, HttpClient httpClient)
        {
            Payment = new TrustlyPayment(trustlyPaymentResponseDto.Payment);
            Operations = new TrustlyPaymentOperations(trustlyPaymentResponseDto.Operations.Map(), httpClient);
        }

        public ITrustlyPayment Payment { get; set; }
        public ITrustlyPaymentOperations Operations { get; set; }
    }
}