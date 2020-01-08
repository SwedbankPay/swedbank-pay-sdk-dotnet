using System;
using System.Threading.Tasks;

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

        Task<Card.Payment> CreateCreditCardPayment(Card.PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


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
        Task<Card.Payment> GetCreditCardPayment(Uri id, PaymentExpand paymentExpand);

        ///// <summary>
        /////     Gets an existing swish payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="paymentExpand"></param>
        ///// <returns></returns>
        Task<Swish.Payment> GetSwishPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}