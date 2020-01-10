using System;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments.Card;

namespace SwedbankPay.Sdk.Payments
{
    public interface IPaymentsResource
    {
        /// <summary>
        ///     Creates a new credit card payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<Payment> CreateCreditCardPayment(PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


        /// <summary>
        ///     Creates a new swish payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<Swish.Payment> CreateSwishPayment(Swish.PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


        ///// <summary>
        /////     Gets an existing card payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="paymentExpand"></param>
        ///// <returns></returns>
        Task<Payment> GetCreditCardPayment(Uri id, PaymentExpand paymentExpand);


        ///// <summary>
        /////     Gets an existing swish payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="paymentExpand"></param>
        ///// <returns></returns>
        Task<Swish.Payment> GetSwishPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}