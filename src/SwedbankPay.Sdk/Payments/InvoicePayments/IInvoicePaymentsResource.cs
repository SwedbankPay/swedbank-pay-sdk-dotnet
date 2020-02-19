using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentsResource
    {
        /// <summary>
        ///     Creates a new invoice payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<InvoicePayment> Create(InvoicePaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


        ///// <summary>
        /////     Gets an existing invoice payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="paymentExpand"></param>
        ///// <returns></returns>
        Task<InvoicePayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}