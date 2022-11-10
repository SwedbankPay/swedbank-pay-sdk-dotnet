﻿using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// The entry point for talking with the creditcard APIs.
    /// </summary>
    public interface ICardResource
    {
        /// <summary>
        ///     Creates a new credit card payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<ICardPaymentResponse> Create(CardPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


        /// <summary>
        ///     Gets an existing card payment.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<ICardPaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);

        /// <summary>
        /// Creates a new card payment with recur token
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<ICardPaymentRecurResponse> Create(CardPaymentRecurRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.All);

        /// <summary>
        /// Creates a new card payment with verify
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<ICardPaymentVerifyResponse> Create(CardPaymentVerifyRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.All);
    }
}
