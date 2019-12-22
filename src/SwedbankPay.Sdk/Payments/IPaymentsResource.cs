using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public interface IPaymentsResource
    {
        ///// <summary>
        /////     Gets an existing payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //Task<PaymentResponseContainer> GetPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.All);


        ///// <summary>
        /////     Gets all sales for a payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //Task<IEnumerable<SaleResponse>> GetSales(Uri id);


        ///// <summary>
        /////     Gets all transactions for a payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //Task<IEnumerable<TransactionResponse>> GetTransactions(Uri id, PaymentExpand paymentExpand = PaymentExpand.All);


        ///// <summary>
        /////     Cancels an unauthorized creditcard payment a.k.a PATCH with a static abort object.
        ///// </summary>
        //Task<PaymentResponseContainer> PatchAbortPayment(Uri id);


        ///// <summary>
        /////     Cancels a payment a.k.a POSTs a transaction.
        ///// </summary>
        //Task<TransactionResponse> PostCancellation(Uri id, TransactionRequest transaction);


        ///// <summary>
        /////     Captures a payment a.k.a POSTs a transaction.
        ///// </summary>
        //Task<TransactionResponse> PostCapture(Uri id, TransactionRequest transaction);


        ///// <summary>
        /////     Creates a new CreditCard payment
        ///// </summary>
        ///// <param name="payment"></param>
        ///// <returns></returns>
        //Task<PaymentResponseContainer> PostCreditCardPayment(PaymentRequest payment);


        ///// <summary>
        /////     Reverses a payment a.k.a POSTs a transaction.
        ///// </summary>
        //Task<TransactionResponse> PostReversal(Uri id, TransactionRequest transaction);


        ///// <summary>
        /////     Creates a new Vipps payment
        ///// </summary>
        ///// <param name="payment"></param>
        ///// <returns></returns>
        //Task<PaymentResponseContainer> PostVippsPayment(PaymentRequest payment);


        /// <summary>
        ///     Creates a new payment
        /// </summary>
        /// <param name="paymentType"></param>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<Payment> Create(PaymentType paymentType, PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


        /// <summary>
        ///     Creates a new credit card payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>

        Task<Payment> CreateCreditCardPayment(PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


        /// <summary>
        ///     Gets an existing payment.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<Payment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);

    }
}