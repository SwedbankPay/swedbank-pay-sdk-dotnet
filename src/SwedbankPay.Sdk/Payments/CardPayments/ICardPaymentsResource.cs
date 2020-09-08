using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardPaymentsResource
    {
        /// <summary>
        ///     Creates a new credit card payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<CardPayment> Create(CardPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);

        /// <summary>
        ///     Initiates a new credit card verify
        /// </summary>
        /// <param name="paymentVerifyRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<CardVerify> Verify(CardPaymentVerifyRequest paymentVerifyRequest, PaymentExpand paymentExpand = PaymentExpand.None);

        ///// <summary>
        /////     Gets an existing card payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="paymentExpand"></param>
        ///// <returns></returns>
        Task<CardPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);

        Task<CardVerify> GetVerify(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}
