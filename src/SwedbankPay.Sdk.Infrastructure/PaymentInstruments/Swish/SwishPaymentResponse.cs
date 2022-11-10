using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

internal class SwishPaymentResponse : ISwishPaymentResponse
{
    public SwishPaymentResponse(SwishPaymentResponseDto payment,
                           HttpClient httpClient)
    {
        Payment = new SwishPayment(payment.Payment);
        Operations = new SwishPaymentOperations(payment.Operations.Map(), httpClient);
    }

    public ISwishPayment Payment { get; set; }
    public ISwishPaymentOperations Operations { get; set; }
}