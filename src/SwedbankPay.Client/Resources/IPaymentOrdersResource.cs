namespace SwedbankPay.Client.Resources
{
    using SwedbankPay.Client.Models;
    using SwedbankPay.Client.Models.Request;
    using SwedbankPay.Client.Models.Request.Transaction;
    using SwedbankPay.Client.Models.Response;
    using SwedbankPay.Client.Models.Vipps.TransactionAPI.Response;

    public interface IPaymentOrdersResource
    {
        /// <summary>
        /// Creates a payment order
        /// </summary>
        /// <param name="paymentOrderRequest"></param>
        /// <returns></returns>
        PaymentOrderResponseContainer CreatePaymentOrder(PaymentOrderRequestContainer paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);

        /// <summary>
        /// Gets an existing payment order.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        PaymentOrderResponseContainer GetPaymentOrder(string id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);

        /// <summary>
        /// Updates an existing payment.
        /// </summary>
        /// <param name="paymentOrderRequest"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        PaymentOrderResponseContainer UpdatePaymentOrder(string id, PaymentOrderRequestContainer paymentOrderRequest);

        /// <summary>
        /// Aborts a payment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PaymentOrderResponseContainer AbortPaymentOrder(string id);

        /// <summary>
        /// Captures a payment
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="requestObject"></param>
        /// <returns></returns>
        TransactionResponse Capture(string id, TransactionRequestContainer requestObject);

        /// <summary>
        /// Reverses a payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestObject"></param>
        /// <returns></returns>
        TransactionResponse Reversal(string id, TransactionRequestContainer requestObject);

        /// <summary>
        /// Cancels a payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestObject"></param>
        /// <returns></returns>
        TransactionResponse CancelPaymentOrder(string id, TransactionRequestContainer requestObject);
    }
}
