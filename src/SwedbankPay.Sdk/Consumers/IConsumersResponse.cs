namespace SwedbankPay.Sdk.Consumers;

/// <summary>
/// Interface describing a API response from Consumers.
/// </summary>
public interface IConsumersResponse
{
    /// <summary>
    ///     The array of operation objects to choose from
    /// </summary>
    public ConsumerOperations Operations { get; }

    /// <summary>
    ///     A session token used to initiate Checkout UI
    /// </summary>
    string Token { get; }
}