using SwedbankPay.Sdk.Infrastructure.Extensions;
using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

public class PaymentOrdersResource : ResourceBase, IPaymentOrdersResource
{
    public PaymentOrdersResource(HttpClient httpClient) : base(httpClient)
    {
    }

    /// <summary>
    ///     Creates a payment order
    /// </summary>
    /// <param name="paymentOrderRequest"></param>
    /// <param name="paymentOrderExpand"></param>
    /// <exception cref="System.ArgumentNullException"></exception>
    /// <exception cref="System.InvalidOperationException"></exception>
    /// <exception cref="System.Net.Http.HttpRequestException"></exception>
    /// <returns></returns>
    public async Task<IPaymentOrderResponse?> Create(PaymentOrderRequest paymentOrderRequest,
        PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
    {
        var url = new Uri("/psp/paymentorders", UriKind.Relative).GetUrlWithQueryString(paymentOrderExpand);

        var request = new PaymentOrderRequestDto(paymentOrderRequest);

        var paymentOrderResponseDto = await HttpClient.PostAsJsonAsync<PaymentOrderResponseDto>(url, request);

        return paymentOrderResponseDto != null ? new PaymentOrderResponse(paymentOrderResponseDto, HttpClient) : null;
    }

    /// <summary>
    ///     Get payment order by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="paymentOrderExpand"></param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    /// <exception cref="System.InvalidOperationException"></exception>
    /// <exception cref="System.Net.Http.HttpRequestException"></exception>
    /// <exception cref="System.Net.Http.HttpRequestException"></exception>
    public async Task<IPaymentOrderResponse?> Get(Uri id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id), $"{id} cannot be null");
        }

        Uri url = id.GetUrlWithQueryString(paymentOrderExpand);

        var paymentOrderResponseContainer = await HttpClient.GetAsJsonAsync<PaymentOrderResponseDto>(url);

        return paymentOrderResponseContainer != null ? new PaymentOrderResponse(paymentOrderResponseContainer, HttpClient) : null;
    }
    
    public async Task<IUserTokenResponse?> GetOwnedTokens(string payerReference)
    {
        var url = new Uri($"/psp/paymentorders/payerownedtokens/{payerReference}", UriKind.Relative);//.GetUrlWithQueryString(paymentOrderExpand);

        var tokenResponseDto = await HttpClient.GetAsJsonAsync<UserTokenResponseDto>(url);

        return tokenResponseDto != null ? new UserTokenResponse(tokenResponseDto, HttpClient) : null;
    }
}