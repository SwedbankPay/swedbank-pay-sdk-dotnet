using SwedbankPay.Sdk.Extensions;

namespace SwedbankPay.Sdk.PaymentOrder;

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
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="System.Net.Http.HttpRequestException"></exception>
    /// <returns></returns>
    public async Task<IPaymentOrderResponse> Create(PaymentOrderRequest paymentOrderRequest,
        PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
    {
        var url = new Uri("/psp/paymentorders", UriKind.Relative).GetUrlWithQueryString(paymentOrderExpand);

        var request = new PaymentOrderRequestDto(paymentOrderRequest);

        var paymentOrderResponseDto = await HttpClient.PostAsJsonAsync<PaymentOrderResponseDto>(url, request);

        return new PaymentOrderResponse(paymentOrderResponseDto, HttpClient);
    }
    
    /// <summary>
    ///     Get payment order by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="paymentOrderExpand"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="System.Net.Http.HttpRequestException"></exception>
    public async Task<IPaymentOrderResponse> Get(Uri id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id), $"{id} cannot be null");
        }

        Uri url = id.GetUrlWithQueryString(paymentOrderExpand);

        var paymentOrderResponseContainer = await HttpClient.GetAsJsonAsync<PaymentOrderResponseDto>(url);

        return new PaymentOrderResponse(paymentOrderResponseContainer, HttpClient);
    }
}


public interface IPaymentOrdersResource
{
    /// <summary>
    ///     Creates a payment order
    /// </summary>
    /// <param name="paymentOrderRequest"></param>
    /// <param name="paymentOrderExpand"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="System.Net.Http.HttpRequestException"></exception>
    /// <returns></returns>
    Task<IPaymentOrderResponse> Create(PaymentOrderRequest paymentOrderRequest,
        PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);


    /// <summary>
    ///     Get payment order for the given id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="paymentOrderExpand"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="System.Net.Http.HttpRequestException"></exception>
    /// <returns></returns>
    Task<IPaymentOrderResponse> Get(Uri id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);
}