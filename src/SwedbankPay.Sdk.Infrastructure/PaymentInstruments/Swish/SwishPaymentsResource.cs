using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

public class SwishPaymentsResource : ResourceBase, ISwishResource
{
    public SwishPaymentsResource(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<ISwishPaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        Uri url = id.GetUrlWithQueryString(paymentExpand);

        var paymentResponse = await HttpClient.GetAsJsonAsync<SwishPaymentResponseDto>(url);
        return new SwishPaymentResponse(paymentResponse, HttpClient);
    }

    public async Task<ISwishPaymentResponse> Create(SwishPaymentRequest paymentRequest,
                                                        PaymentExpand paymentExpand = PaymentExpand.None)
    {
        var url = new Uri("/psp/swish/payments", UriKind.Relative).GetUrlWithQueryString(paymentExpand);

        var requestDto = new SwishPaymentRequestDto(paymentRequest);

        var paymentResponse = await HttpClient.PostAsJsonAsync<SwishPaymentResponseDto>(url, requestDto);
        return new SwishPaymentResponse(paymentResponse, HttpClient);
    }
}
