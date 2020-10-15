using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public interface IVippsResource
    {
        /// <summary>
        ///     Creates a new Vipps payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<IVippsPaymentReponse> Create(VippsPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


        ///// <summary>
        /////     Gets an existing Vipps payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="paymentExpand"></param>
        ///// <returns></returns>
        Task<IVippsPaymentReponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}
