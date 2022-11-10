using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay;

public class MobilePayPaymentsResource : ResourceBase, IMobilePayResource
{
    public MobilePayPaymentsResource(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<IMobilePayPaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        Uri url = id.GetUrlWithQueryString(paymentExpand);

        var mobilepaymentResponseDto = await HttpClient.GetAsJsonAsync<MobilePayPaymentResponseDto>(url);
        return new MobilePayPaymentResponse(mobilepaymentResponseDto, HttpClient);
    }

    public async Task<IMobilePayPaymentResponse> Create(MobilePayPaymentRequest paymentRequest,
                                                        PaymentExpand paymentExpand = PaymentExpand.None)
    {
        var url = new Uri("/psp/mobilepay/payments", UriKind.Relative).GetUrlWithQueryString(paymentExpand);

        var requestDto = new MobilePayPaymentRequestDto(paymentRequest);

        var mobilepaymentResponseDto = await HttpClient.PostAsJsonAsync<MobilePayPaymentResponseDto>(url, requestDto);
        return new MobilePayPaymentResponse(mobilepaymentResponseDto, HttpClient);
    }
}
