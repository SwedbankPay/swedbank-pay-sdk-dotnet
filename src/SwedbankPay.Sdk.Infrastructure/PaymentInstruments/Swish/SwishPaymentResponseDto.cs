using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

internal class SwishPaymentResponseDto
{
    public OperationListDto Operations { get; set; }
    public SwishPaymentDto Payment { get; set; }

    public ISwishPaymentResponse Map(HttpClient httpClient)
    {
        return new SwishPaymentResponse(this, httpClient);
    }
}