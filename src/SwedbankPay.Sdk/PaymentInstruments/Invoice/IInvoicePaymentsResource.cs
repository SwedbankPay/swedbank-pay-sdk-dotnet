using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoiceResource
    {
        /// <summary>
        ///     Creates a new invoice payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<IInvoicePaymentResponse> Create(InvoicePaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


        ///// <summary>
        /////     Gets an existing invoice payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="paymentExpand"></param>
        ///// <returns></returns>
        Task<IInvoicePaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}