using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.VippsPayments
{
    public interface IVippsPaymentsResource
    {
        /// <summary>
        ///     Creates a new Vipps payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<VippsPayment> Create(VippsPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


        ///// <summary>
        /////     Gets an existing Vipps payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="paymentExpand"></param>
        ///// <returns></returns>
        Task<VippsPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}
