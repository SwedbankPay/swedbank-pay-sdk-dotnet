using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

/// <summary>
/// Resource identificatior to access the sales response available
/// on a Swish payment.
/// </summary>
public interface ISwishPaymentSaleResponse
{
    /// <summary>
    /// A unique <seealso cref="Uri"/> to access this sale response.
    /// </summary>
    Uri Payment { get; }

    /// <summary>
    /// Transactional details about the sale.
    /// </summary>
    ISwishPaymentSale Sale { get; }
}