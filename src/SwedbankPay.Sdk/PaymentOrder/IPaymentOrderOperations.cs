using SwedbankPay.Sdk.PaymentOrder.OperationRequest;

namespace SwedbankPay.Sdk.PaymentOrder;

/// <summary>
/// Represents operations that can be performed on a payment order.
/// </summary>
public interface IPaymentOrderOperations : IDictionary<LinkRelation, HttpOperation?>
{
    /// <summary>
    /// Updates the contents of the payment order, if available.
    /// </summary>
    Func<PaymentOrderUpdateRequest, Task<IPaymentOrderResponse?>>? Update { get; }

    /// <summary>
    /// Gets the  function for aborting a payment order.
    /// </summary>
    Func<PaymentOrderAbortRequest, Task<IPaymentOrderResponse?>>? Abort { get; }

    /// <summary>
    /// Gets the cancellation function for a payment order.
    /// </summary>
    Func<PaymentOrderCancelRequest, Task<IPaymentOrderResponse?>>? Cancel { get; }

    /// <summary>
    ///  Gets the function to to capture a payment order request..
    /// </summary>
    Func<PaymentOrderCaptureRequest, Task<IPaymentOrderResponse?>>? Capture { get; }

    /// <summary>
    /// Gets the function to reverse a payment order request.
    /// </summary>
    Func<PaymentOrderReversalRequest, Task<IPaymentOrderResponse?>>? Reverse { get; }
    
    HttpOperation? Redirect { get; }

    /// <summary>
    /// Returns details needed to created a hosted view for the payer to see the payment order, if available.
    /// </summary>
    HttpOperation? View { get; }
}