using SwedbankPay.Sdk.PaymentOrder.OperationRequest;

namespace SwedbankPay.Sdk.PaymentOrder;

public interface IPaymentOrderOperations : IDictionary<LinkRelation, HttpOperation?>
{
    /// <summary>
    /// Updates the contents of the payment order, if available.
    /// </summary>
    Func<PaymentOrderUpdateRequest, Task<IPaymentOrderResponse?>>? Update { get; }
 
    /// <summary>
    /// Aborts the payment order, if available.
    /// </summary>
    Func<PaymentOrderAbortRequest, Task<IPaymentOrderResponse?>>? Abort { get; }
    
    Func<PaymentOrderCancelRequest, Task<IPaymentOrderResponse?>>? Cancel { get; }
    
    Func<PaymentOrderCaptureRequest, Task<IPaymentOrderResponse?>>? Capture { get; }
    
    Func<PaymentOrderReversalRequest, Task<IPaymentOrderResponse?>>? Reverse { get; }
    
    HttpOperation? Redirect { get; }
    
    /// <summary>
    /// Returns details needed to created a hosted view for the payer to see the payment order, if available.
    /// </summary>
    HttpOperation? View { get; }
}