namespace SwedbankPay.Sdk.PaymentOrder;

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
    Task<IPaymentOrderResponse?> Create(PaymentOrderRequest paymentOrderRequest,
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
    Task<IPaymentOrderResponse?> Get(Uri id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);
    
    /// <summary>
    ///     Get payment order for the given id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="payeeId"></param>
    /// <param name="paymentOrderExpand"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="System.Net.Http.HttpRequestException"></exception>
    /// <returns></returns>
    Task<IPaymentOrderResponse?> Get(Uri id, string payeeId, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);


    /// <summary>
    /// Retrieves user-owned tokens for a specified payer reference.
    /// </summary>
    /// <param name="payerReference">The payer reference associated with the user-owned tokens.</param>
    /// <returns>
    /// An <see cref="IUserTokenResponse"/> instance containing the user-owned tokens,
    /// or <c>null</c> if no tokens are found for the specified payer reference.
    /// </returns>
    Task<IUserTokenResponse?> GetOwnedTokens(string payerReference);


    /// <summary>
    /// Retrieves user-owned tokens for a specific payer reference.
    /// </summary>
    /// <param name="payerReference">The payer reference for which to retrieve the tokens.</param>
    /// <param name="payeeId">The payee identifier associated with the request.</param>
    /// <returns>The <see cref="IUserTokenResponse"/> containing the user-owned tokens, or <c>null</c> if no tokens are found.</returns>
    Task<IUserTokenResponse?> GetOwnedTokens(string payerReference, string? payeeId);
}