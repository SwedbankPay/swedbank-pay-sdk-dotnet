using System.Net;

namespace SwedbankPay.Sdk.PaymentOrder;

public interface IPaymentOrderResponse
{
    /// <summary>
    /// Currently available operations of this payment order.
    /// </summary>
    IPaymentOrderOperations Operations { get; }

    /// <summary>
    /// The current payment order.
    /// </summary>
    IPaymentOrder PaymentOrder { get; }

    /// <summary>
    /// Indicates whether the payment order is currently in a pending state.
    /// </summary>
    bool IsPending { get; }
}
