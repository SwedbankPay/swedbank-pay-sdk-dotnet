using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public interface ISwishPaymentsResource
    {
        /// <summary>
        ///     Creates a new swish payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<SwishPayment> Create(SwishPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


        ///// <summary>
        /////     Gets an existing swish payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="paymentExpand"></param>
        ///// <returns></returns>
        Task<SwishPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}
