using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
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
}