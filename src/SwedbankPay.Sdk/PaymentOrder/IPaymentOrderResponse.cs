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
    /// The HTTP status code returned by the platform for the operation that produced this
    /// response. For synchronous responses this is always <see cref="HttpStatusCode.OK"/>.
    /// </summary>
    /// <remarks>
    /// BankLink instruments in the Baltic region process reversals asynchronously. In that case
    /// the platform returns <see cref="HttpStatusCode.Accepted"/> (HTTP 202) with the standard
    /// payment order body — the initialized reversal transaction is not yet visible. Check
    /// <c>StatusCode</c> after calling <c>Operations.Reverse</c>; when it equals
    /// <see cref="HttpStatusCode.Accepted"/>, wait for the platform callback (up to three days)
    /// and then <c>GET</c> the payment order to read
    /// <see cref="IPaymentOrder.FinancialTransactions"/> (success) or
    /// <see cref="IPaymentOrder.PostPurchaseFailedAttempts"/> (failure). While the reversal is
    /// pending the platform will not return post-purchase operations on the payment order, which
    /// effectively blocks further attempts until the callback arrives.
    ///
    /// See https://developer.swedbankpay.com/checkout-v3/features/payment-operations/reversal/#asynchronous-reversals.
    /// </remarks>
    HttpStatusCode StatusCode { get; }
}
