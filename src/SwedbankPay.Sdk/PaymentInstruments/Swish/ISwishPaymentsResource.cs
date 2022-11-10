﻿using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

/// <summary>
/// Entrypoint to our Swish resource API.
/// </summary>
public interface ISwishResource
{
    /// <summary>
    /// Creates a new swish payment
    /// </summary>
    /// <param name="paymentRequest"></param>
    /// <param name="paymentExpand"></param>
    /// <returns></returns>
    Task<ISwishPaymentResponse> Create(SwishPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None);


    /// <summary>
    /// Gets an existing swish payment.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="paymentExpand"></param>
    /// <returns></returns>
    Task<ISwishPaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None);
}
