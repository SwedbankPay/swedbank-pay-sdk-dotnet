using SwedbankPay.Sdk.Infrastructure.Extensions;
using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

public class PaymentOrdersResource : ResourceBase, IPaymentOrdersResource
{
    public PaymentOrdersResource(HttpClient httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Create a payment order asynchronously with the given request.
    /// </summary>
    /// <param name="paymentOrderRequest">The payment order request object.</param>
    /// <returns>A task representing an optional payment order response.</returns>
    public async Task<IPaymentOrderResponse?> Create(PaymentOrderRequest paymentOrderRequest)
    {
        return await Create(paymentOrderRequest, PaymentOrderExpand.None);
    }

    /// <summary>
    /// Creates a payment order.
    /// </summary>
    /// <param name="paymentOrderRequest">The payment order request.</param>
    /// <param name="paymentOrderExpand">The optional payment order expand.</param>
    /// <exception cref="System.ArgumentNullException">Thrown when paymentOrderRequest is null.</exception>
    /// <exception cref="System.InvalidOperationException">Thrown when the request is invalid.</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">Thrown when an HTTP request error occurs.</exception>
    /// <returns>The payment order response.</returns>
    public async Task<IPaymentOrderResponse?> Create(PaymentOrderRequest paymentOrderRequest, PaymentOrderExpand paymentOrderExpand)
    {
        var url = new Uri("/psp/paymentorders", UriKind.Relative).GetUrlWithQueryString(paymentOrderExpand);

        var request = new PaymentOrderRequestDto(paymentOrderRequest);

        var paymentOrderResponseDto = await HttpClient.PostAsJsonAsync<PaymentOrderResponseDto>(url, request);

        return paymentOrderResponseDto != null ? new PaymentOrderResponse(paymentOrderResponseDto, HttpClient) : null;
    }

    /// <summary>
    /// Retrieves a payment order by its ID.
    /// </summary>
    /// <param name="id">The ID of the payment order to retrieve.</param>
    /// <returns>The payment order response if found; otherwise, it returns null.</returns>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="id"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">Thrown when the operation is invalid.</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">Thrown when an error occurs during the HTTP request.</exception>
    public async Task<IPaymentOrderResponse?> Get(Uri id)
    {
        return await Get(id, PaymentOrderExpand.None);
    }

    /// <summary>
    /// Retrieves a payment order by its ID.
    /// </summary>
    /// <param name="id">The ID of the payment order to retrieve.</param>
    /// <param name="paymentOrderExpand">The expansion options for the payment order.</param>
    /// <returns>The retrieved payment order response, or null if not found.</returns>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="id"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">Thrown when the operation is invalid.</exception>
    /// <exception cref="System.Net.Http.HttpRequestException">Thrown when an error occurs during the HTTP request.</exception>
    public async Task<IPaymentOrderResponse?> Get(Uri id, PaymentOrderExpand paymentOrderExpand)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id), $"{id} cannot be null");
        }

        Uri url = id.GetUrlWithQueryString(paymentOrderExpand);

        var paymentOrderResponseContainer = await HttpClient.GetAsJsonAsync<PaymentOrderResponseDto>(url);

        return paymentOrderResponseContainer != null ? new PaymentOrderResponse(paymentOrderResponseContainer, HttpClient) : null;
    }

    /// <summary>
    /// Retrieves user-owned tokens for a specific payer reference.
    /// </summary>
    /// <param name="payerReference">The payer reference for which to retrieve the tokens.</param>
    /// <returns>
    /// The <see cref="IUserTokenResponse"/> object representing the user-owned tokens,
    /// or <c>null</c> if no tokens are found for the specified payer reference.
    /// </returns>
    public async Task<IUserTokenResponse?> GetOwnedTokens(string payerReference)
    {
        var url = new Uri($"/psp/paymentorders/payerownedtokens/{payerReference}", UriKind.Relative);

        var tokenResponseDto = await HttpClient.GetAsJsonAsync<UserTokenResponseDto>(url);

        return tokenResponseDto != null ? new UserTokenResponse(tokenResponseDto, HttpClient) : null;
    }
}