using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public interface ITrustlyResource
    {
        /// <summary>
        ///     Creates a new Trustly payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<ITrustlyPaymentResponse> Create(TrustlyPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);

        ///// <summary>
        /////     Gets an existing swish payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="paymentExpand"></param>
        ///// <returns></returns>
        Task<ITrustlyPaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}
