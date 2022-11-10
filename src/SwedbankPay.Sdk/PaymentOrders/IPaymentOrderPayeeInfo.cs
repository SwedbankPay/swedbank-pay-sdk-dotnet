namespace SwedbankPay.Sdk.PaymentOrders;

/// <summary>
/// <inheritdoc/>
/// </summary>
public interface IPaymentOrderPayeeInfo: IPayeeInfo
{
    /// <summary>
    /// The Corporation ID for the Payee
    /// </summary>
    string CorporationId { get; }

    /// <summary>
    /// The Corporation name for the Payee
    /// </summary>
    string CorporationName { get; }
}
