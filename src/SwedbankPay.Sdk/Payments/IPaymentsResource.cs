using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public interface IPaymentsResource
    {
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