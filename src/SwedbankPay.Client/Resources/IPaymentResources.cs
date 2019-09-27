namespace SwedbankPay.Client.Resources
{
    using SwedbankPay.Client.Models;
    using SwedbankPay.Client.Models.Request.Transaction;
    using SwedbankPay.Client.Models.Vipps.PaymentAPI.Request;
    using SwedbankPay.Client.Models.Vipps.PaymentAPI.Response;
    using SwedbankPay.Client.Models.Vipps.TransactionAPI.Response;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPaymentResources
    {
        /// <summary>
        /// Creates a new Vipps payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        PaymentResponseContainer PostVippsPayment(PaymentRequest payment);

        /// <summary>
        /// Creates a new CreditCard payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        PaymentResponseContainer PostCreditCardPayment(PaymentRequest payment);

        /// <summary>
        /// Gets an existing payment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PaymentResponseContainer GetPayment(string id);

        /// <summary>
        /// Gets all transactions for a payment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<TransactionResponse> GetTransactions(string id);

        /// <summary>
        /// Captures a payment a.k.a POSTs a transaction.
        /// </summary>
        TransactionResponse PostCapture(string id, TransactionRequest transaction);

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
        PaymentResponseContainer PatchAbortPayment(string id);

        string GetRaw(string id, PaymentOrderExpand paymentOrderExpand);
    }
}