namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.Capture;

/// <summary>
/// API request object for capturing funds for a payment order.
/// </summary>
public record PaymentOrderCaptureRequest
{
    /// <summary>
    /// Instantiates a <see cref="PaymentOrderCaptureRequest"/> with the provided parameters.
    /// </summary>
    /// <param name="amount">The amount of funds to capture.</param>
    /// <param name="vatAmount">The amount of funds to capture as value added taxes.</param>
    /// <param name="description">A textual description of the capture.</param>
    /// <param name="payeeReference">Transactionally unique reference from the merchant system.</param>
    /// <param name="receiptReference"></param>
    public PaymentOrderCaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference,
        string receiptReference)
    {
        Transaction = new PaymentOrderCaptureTransaction(amount, vatAmount, description, payeeReference, receiptReference);
    }

    /// <summary>
    /// Transactional details about the capture of the current payment order.
    /// </summary>
    public PaymentOrderCaptureTransaction Transaction { get; }
}