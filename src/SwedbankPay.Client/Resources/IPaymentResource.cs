namespace SwedbankPay.Client.Resources
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SwedbankPay.Client.Models;
    using SwedbankPay.Client.Models.Request.Transaction;
    using SwedbankPay.Client.Models.Vipps.PaymentAPI.Request;
    using SwedbankPay.Client.Models.Vipps.PaymentAPI.Response;
    using SwedbankPay.Client.Models.Vipps.TransactionAPI.Response;

    public interface IPaymentResource
    {
        /// <summary>
        /// Creates a new Vipps payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        Task<PaymentResponseContainer> PostVippsPayment(PaymentRequest payment);

        /// <summary>
        /// Creates a new CreditCard payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        Task<PaymentResponseContainer> PostCreditCardPayment(PaymentRequest payment);

        /// <summary>
        /// Gets an existing payment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PaymentResponseContainer> GetPayment(string id, PaymentExpand paymentExpand = PaymentExpand.All);

        /// <summary>
        /// Gets all transactions for a payment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<TransactionResponse>> GetTransactions(string id, PaymentExpand paymentExpand = PaymentExpand.All);

        /// <summary>
        /// Captures a payment a.k.a POSTs a transaction.
        /// </summary>
        Task<TransactionResponse> PostCapture(string id, TransactionRequest transaction);

        /// <summary>
        /// Reverses a payment a.k.a POSTs a transaction.
        /// </summary>
        Task<TransactionResponse> PostReversal(string id, TransactionRequest transaction);

        /// <summary>
        /// Cancels a payment a.k.a POSTs a transaction.
        /// </summary>
        Task<TransactionResponse> PostCancellation(string id, TransactionRequest transaction);

        /// <summary>
        /// Cancels an unauthorized creditcard payment a.k.a PATCH with a static abort object.
        /// </summary>
        Task<PaymentResponseContainer> PatchAbortPayment(string id);

        Task<string> GetRaw(string id, PaymentOrderExpand paymentOrderExpand);
    }
}