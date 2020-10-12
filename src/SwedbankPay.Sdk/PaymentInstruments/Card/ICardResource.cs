﻿using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public interface ICardResource
    {
        /// <summary>
        ///     Creates a new credit card payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        Task<ICardPaymentResponse> Create(CardPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


        ///// <summary>
        /////     Gets an existing card payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="paymentExpand"></param>
        ///// <returns></returns>
        Task<ICardPaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
    }
}