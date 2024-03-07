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

    Task<IUserTokenResponse?> GetOwnedTokens(string payerReference);
}